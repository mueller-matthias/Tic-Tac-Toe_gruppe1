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
        private TicTacToeApp.Protokoll protokoll = new TicTacToeApp.Protokoll();
        private GameView view = new GameView();
        private SpielTimer timer;
        private int siegBedingung;

        public GameController()
        {
            InitialisiereSpiel();
        }

        private void InitialisiereSpiel()
        {
            int size;
            while (true)
            {
                Console.WriteLine("Wählen Sie die Spielfeldgröße: 3x3, 5x5 oder 7x7: (bitte 3, 5 oder 7 eingeben)");
                string input = Console.ReadLine();
                if (input == "3" || input == "5" || input == "7")
                {
                    size = int.Parse(input);
                    break;
                }
                Console.WriteLine("Ungültige Eingabe! Bitte geben Sie 3, 5 oder 7 ein.");
            }

            spielfeld = new GameBoardModel(size);
            spieler = new Spieler[] { new Spieler("Spieler 1", 'X'), new Spieler("Spieler 2", 'O') };
            aktuellerSpielerIndex = 0;
            timer = new SpielTimer();
            siegBedingung = (size == 3) ? 3 : 4; // 3 bei 3x3, 4 bei 5x5 oder 7x7
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

                int row, col;
                while (true)
                {
                    row = HoleEingabe("Zeile eingeben: ");
                    col = HoleEingabe("Spalte eingeben: ");

                    if (spielfeld.ValidateMove(row, col)) break;
                    protokoll.UngueltigeEingabe(new Zug(aktuellerSpieler, row, col));  // Hier wird das ungültige Eingabeprotokoll geschrieben
                    Console.WriteLine("Ungültiger Zug! Feld bereits belegt.");
                }

                spielfeld.SetCell(row, col, aktuellerSpieler.Symbol);
                protokoll.Speichern(new Zug(aktuellerSpieler, row, col));

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

        private int HoleEingabe(string aufforderung)
        {
            int zahl;
            while (true)
            {
                Console.Write(aufforderung);
                string input = Console.ReadLine();
                if (int.TryParse(input, out zahl) && zahl >= 0 && zahl < spielfeld.Groesse)
                {
                    return zahl;
                }
                Console.WriteLine($"Ungültige Eingabe! Bitte eine Zahl zwischen 0 und {spielfeld.Groesse - 1} eingeben.");
            }
        }

        private bool IstUnentschieden()
        {
            for (int i = 0; i < spielfeld.Groesse; i++)
                for (int j = 0; j < spielfeld.Groesse; j++)
                    if (spielfeld.GetCell(i, j) == '.') return false;
            return true;
        }

        private void FrageNachNeustart()
        {
            Console.WriteLine("Möchten Sie ein neues Spiel starten? (y/n): ");
            string input = Console.ReadLine().ToLower();
            if (input == "y")
            {
                Console.WriteLine("Das Spiel wird zurückgesetzt...");
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

