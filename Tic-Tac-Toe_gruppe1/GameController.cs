using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToeApp;

namespace Tic_Tac_Toe_gruppe1
{
    /// <summary>
    /// Die GameController-Klasse verwaltet das Spiel TicTacToe, einschließlich der Spiellogik,
    /// der Spielerinteraktionen und der Spielfeldverwaltung. Sie steuert den Spielablauf,
    /// überprüft die Eingaben der Spieler und führt das Spiel zu einem Ende (Gewinner oder Unentschieden).
    /// </summary>
    public class GameController
    {
            private GameBoardModel spielfeld;
            private Spieler[] spieler;
            private int aktuellerSpielerIndex;
            private TicTacToeApp.Protokoll protokoll;
            private GameView view = new GameView();
            private SpielTimer timer;
            private int siegBedingung;
            private IGameStrategy gameStrategy;
        /// <summary>
        /// Konstruktor für die GameController-Klasse. Initialisiert das Spiel und wählt die
        /// Spielfeldstrategie basierend auf der Eingabe des Benutzers.
        /// </summary>
        public GameController()
            {
                protokoll = TicTacToeApp.Protokoll.GetInstance(); 
                InitialisiereSpiel();
            }

        public IGameStrategy IGameStrategy
        {
            get => default;
            set
            {
            }
        }

        public Spieler Spieler
        {
            get => default;
            set
            {
            }
        }

        public GameBoardModel GameBoardModel
        {
            get => default;
            set
            {
            }
        }

        public Protokoll Protokoll
        {
            get => default;
            set
            {
            }
        }

        public SpielTimer SpielTimer
        {
            get => default;
            set
            {
            }
        }

        /// <summary>
        /// Initialisiert das Spiel, wählt das Spielfeld und setzt alle nötigen Parameter.
        /// </summary>
        private void InitialisiereSpiel()
            {
                int size;
                while (true)
                {
                    Console.WriteLine("Wählen Sie die Spielfeldgröße: 3x3, 5x5 oder 7x7: (bitte 3, 5 oder 7 eingeben)");
                    string input = Console.ReadLine();
                    if (input == "3")
                    {
                        gameStrategy = new ThreeByThreeStrategy(); 
                        break;
                    }
                    else if (input == "5")
                    {
                        gameStrategy = new FiveByFiveStrategy(); 
                        break;
                    }
                    else if (input == "7")
                    {
                        gameStrategy = new SevenBySevenStrategy(); 
                        break;
                    }
                    Console.WriteLine("Ungültige Eingabe! Bitte geben Sie 3, 5 oder 7 ein.");
                }

                spielfeld = new GameBoardModel(gameStrategy.GetBoardSize()); 
                spieler = new Spieler[] { new Spieler("Spieler 1", 'X'), new Spieler("Spieler 2", 'O') };
                aktuellerSpielerIndex = 0;
                timer = new SpielTimer();
                siegBedingung = (spielfeld.Groesse == 3) ? 3 : 4;
            }
        /// <summary>
        /// Startet das Spiel und lässt die Spieler abwechselnd Züge machen.
        /// </summary>
        public void Starten()
            {
                protokoll.ProtokolliereSpielStart(spielfeld.Groesse);
                timer.Starten();
                bool spielLaufend = true;

                while (spielLaufend)
                {
                    view.UpdateView(spielfeld);
                    Spieler aktuellerSpieler = spieler[aktuellerSpielerIndex];
                    Console.WriteLine($"{aktuellerSpieler.Name} ({aktuellerSpieler.Symbol}) ist am Zug.");

                    string eingabe;
                    int row, col;

                    while (true)
                    {
                        Console.WriteLine("Geben Sie eine Position (z.B. a1, b2, ...) ein.");
                        eingabe = Console.ReadLine().ToLower(); 

                        if (spielfeld.ValidateInput(eingabe, out row, out col))
                        {
                            if (spielfeld.ValidateMove(row, col))
                            {
                                break;
                            }
                            protokoll.ProtokolliereUngueltigeEingabe(new Zug(aktuellerSpieler, row, col));
                            Console.WriteLine("Ungültiger Zug! Feld bereits belegt.");
                        }
                        else
                        {
                        protokoll.ProtokolliereUngueltigeEingabe(new Zug(aktuellerSpieler, row, col));
                        Console.WriteLine("Ungültige Eingabe! Bitte z.B. 'a1', 'b2' usw. eingeben (innerhalb der Spielfeldgröße).");
                        }
                    }

                    // Spieler macht den Zug
                    spielfeld.SetCell(row, col, aktuellerSpieler.Symbol);
                    aktuellerSpieler.Undo.SpeichereZug(new Zug(aktuellerSpieler, row, col));
                    protokoll.Protokollieren(new Zug(aktuellerSpieler, row, col));

                    Console.WriteLine($"Zug {aktuellerSpieler.Symbol} auf ({(char)('a' + col)}{row + 1}) gemacht.");
                    Console.WriteLine("Bestätigen? (y/n) (automatisch bestätigt nach 10 Sekunden)");

                    var task = Task.Run(() => Console.ReadLine()?.ToLower());
                    if (!task.Wait(TimeSpan.FromSeconds(10)))
                    {
                        Console.WriteLine("Zeit abgelaufen! Zug wurde automatisch bestätigt.");
                    }
                    else if (task.Result == "n")
                    {
                        
                        spielfeld.SetCell(row, col, '.');
                        aktuellerSpieler.Undo.LadeLetztenZug(); 
                        Console.WriteLine("Zug wurde rückgängig gemacht. Versuchen Sie es erneut.");
                        protokoll.ProtokolliereNichtBestaetigung(new Zug(aktuellerSpieler, row, col));
                        continue; 
                    }
                    protokoll.ProtokolliereBestaetigung(new Zug(aktuellerSpieler, row, col));
                
                if (spielfeld.PruefeGewinner(aktuellerSpieler.Symbol, siegBedingung))
                    {
                        view.UpdateView(spielfeld);
                        protokoll.ProtokolliereSpielEnde(aktuellerSpieler);
                        timer.Stoppen();
                        protokoll.ZeitProtokollieren(timer.Erhalten());
                        Console.WriteLine($"{aktuellerSpieler.Name} hat gewonnen!");
                        spielLaufend = false;
                    }
                    else if (IstUnentschieden())
                    {
                        view.UpdateView(spielfeld);
                        protokoll.ProtokolliereSpielEnde(null);
                        timer.Stoppen();
                        protokoll.ZeitProtokollieren(timer.Erhalten());
                        Console.WriteLine("Unentschieden!");
                        spielLaufend = false;
                    }
                    else
                    {
                        aktuellerSpielerIndex = 1 - aktuellerSpielerIndex;
                    }
                }

                FrageNachNeustart();
            }
        /// <summary>
        ///  Überprüft, ob das Spiel unentschieden endet.
        /// </summary>
        /// <returns>True, wenn alle Felder belegt sind und es keinen Gewinner gibt, sonst False.</returns>
        private bool IstUnentschieden()
            {
                for (int row = 0; row < spielfeld.Groesse; row++)
                {
                    for (int col = 0; col < spielfeld.Groesse; col++)
                    {
                        if (spielfeld.GetCell(row, col) == '.') 
                        {
                            return false; 
                        }
                    }
                }
                return true; 
            }
        /// <summary>
        /// Fragt den Benutzer, ob er eine neue Runde starten möchte.
        /// </summary>
        private void FrageNachNeustart()
            {
                Console.WriteLine("Möchten Sie eine neue Runde starten? (ja/nein)");
                string antwort = Console.ReadLine().ToLower();
                if (antwort == "ja")
                {
                    InitialisiereSpiel();
                    Starten();
                }
                else
                {
                    Console.WriteLine("Spiel beendet.");
                }
            }
        }
    }

