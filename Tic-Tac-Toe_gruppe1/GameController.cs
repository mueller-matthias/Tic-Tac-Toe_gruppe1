using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToeApp;

namespace Tic_Tac_Toe_gruppe1
{
    internal class GameController
    {
            private GameBoardModel spielfeld;
            private Spieler[] spieler;
            private int aktuellerSpielerIndex;
            private TicTacToeApp.Protokoll protokoll;
            private GameView view = new GameView();
            private SpielTimer timer;
            private int siegBedingung;
            private IGameStrategy gameStrategy;

            public GameController()
            {
                protokoll = TicTacToeApp.Protokoll.GetInstance(); // Hole die Singleton-Instanz
                InitialisiereSpiel();
            }

            private void InitialisiereSpiel()
            {
                int size;
                while (true)
                {
                    Console.WriteLine("Wählen Sie die Spielfeldgröße: 3x3, 5x5 oder 7x7: (bitte 3, 5 oder 7 eingeben)");
                    string input = Console.ReadLine();
                    if (input == "3")
                    {
                        gameStrategy = new ThreeByThreeStrategy(); // Strategy für 3x3 Spielfeld
                        break;
                    }
                    else if (input == "5")
                    {
                        gameStrategy = new FiveByFiveStrategy(); // Strategy für 5x5 Spielfeld
                        break;
                    }
                    else if (input == "7")
                    {
                        gameStrategy = new SevenBySevenStrategy(); // Strategy für 7x7 Spielfeld
                        break;
                    }
                    Console.WriteLine("Ungültige Eingabe! Bitte geben Sie 3, 5 oder 7 ein.");
                }

                spielfeld = new GameBoardModel(gameStrategy.GetBoardSize()); // Spielfeldgröße aus der gewählten Strategie
                spieler = new Spieler[] { new Spieler("Spieler 1", 'X'), new Spieler("Spieler 2", 'O') };
                aktuellerSpielerIndex = 0;
                timer = new SpielTimer();
                siegBedingung = (spielfeld.Groesse == 3) ? 3 : 4;
            }

            public void Starten()
            {
                protokoll.SpielStarten(spielfeld.Groesse);
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
                        eingabe = Console.ReadLine().ToLower(); // Eingabe wird auf Kleinbuchstaben konvertiert

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
                            Console.WriteLine("Ungültige Eingabe! Bitte z.B. 'a1', 'b2' usw. eingeben (innerhalb der Spielfeldgröße).");
                        }
                    }

                    // Spieler macht den Zug
                    spielfeld.SetCell(row, col, aktuellerSpieler.Symbol);
                    aktuellerSpieler.Undo.SpeichereZug(new Zug(aktuellerSpieler, row, col));
                    protokoll.Speichern(new Zug(aktuellerSpieler, row, col));

                    Console.WriteLine($"Zug {aktuellerSpieler.Symbol} auf ({(char)('a' + col)}{row + 1}) gemacht.");
                    Console.WriteLine("Bestätigen? (y/n) (automatisch bestätigt nach 10 Sekunden)");

                    var task = Task.Run(() => Console.ReadLine()?.ToLower());
                    if (!task.Wait(TimeSpan.FromSeconds(10)))
                    {
                        Console.WriteLine("Zeit abgelaufen! Zug wurde automatisch bestätigt.");
                    }
                    else if (task.Result == "n")
                    {
                        // Zug rückgängig machen und neuen Zug eingeben lassen
                        spielfeld.SetCell(row, col, '.');
                        aktuellerSpieler.Undo.LadeLetztenZug(); // Entfernt den letzten gespeicherten Zug
                        Console.WriteLine("Zug wurde rückgängig gemacht. Versuchen Sie es erneut.");
                        continue; // Wiederhole den Zug
                    }

                    // Überprüfen, ob es einen Gewinner gibt
                    if (spielfeld.PruefeGewinner(aktuellerSpieler.Symbol, siegBedingung))
                    {
                        view.UpdateView(spielfeld);
                        protokoll.SpielBeenden(aktuellerSpieler);
                        timer.Stoppen();
                        protokoll.ZeitProtokollieren(timer.Erhalten());
                        Console.WriteLine($"{aktuellerSpieler.Name} hat gewonnen!");
                        spielLaufend = false;
                    }
                    else if (IstUnentschieden())
                    {
                        view.UpdateView(spielfeld);
                        protokoll.SpielBeenden(null);
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

            private void UndoLetzterZug()
            {
                Spieler aktuellerSpieler = spieler[aktuellerSpielerIndex];
                Zug letzterZug = aktuellerSpieler.Undo.LadeLetztenZug();

                if (letzterZug != null)
                {
                    // Rückgängig gemachten Zug protokollieren
                    protokoll.UngueltigeEingabe(letzterZug);  // Oder eine Methode, die das Zurücksetzen protokolliert
                    spielfeld.SetCell(letzterZug.Row, letzterZug.Col, '.');
                    Console.WriteLine("Letzter Zug wurde rückgängig gemacht.");
                }
                else
                {
                    Console.WriteLine("Kein Zug zum Rückgängig machen verfügbar.");
                }
            }


            private bool IstUnentschieden()
            {
                for (int row = 0; row < spielfeld.Groesse; row++)
                {
                    for (int col = 0; col < spielfeld.Groesse; col++)
                    {
                        if (spielfeld.GetCell(row, col) == '.') // Wenn es ein leeres Feld gibt
                        {
                            return false; // Es gibt noch ein leeres Feld, also kein Unentschieden
                        }
                    }
                }
                return true; // Alle Felder sind belegt, also Unentschieden
            }

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

