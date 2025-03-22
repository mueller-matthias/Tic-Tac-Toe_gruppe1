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
        private SpielTimer timer;  // Deine eigene Timer-Klasse

        public GameController(int size)
        {
            spielfeld = new GameBoardModel(size);
            spieler = new Spieler[] { new Spieler("Spieler 1", 'X'), new Spieler("Spieler 2", 'O') };
            aktuellerSpielerIndex = 0;
            timer = new SpielTimer();
        }

        public void Starten(int size)
        {
            protokoll.SpielStarten(size);  // Spielfeldgröße in das Protokoll schreiben
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
                    Console.Write("Zeile eingeben: ");
                    row = int.Parse(Console.ReadLine());
                    Console.Write("Spalte eingeben: ");
                    col = int.Parse(Console.ReadLine());
                    if (spielfeld.ValidateMove(row, col)) break;
                    Console.WriteLine("Ungültiger Zug!");
                }

                spielfeld.SetCell(row, col, aktuellerSpieler.Symbol);
                protokoll.Speichern(new Zug(aktuellerSpieler, row, col));

                if (spielfeld.PruefeGewinner(aktuellerSpieler.Symbol))
                {
                    view.UpdateView(spielfeld);
                    protokoll.SpielBeenden(aktuellerSpieler);
                    timer.Stoppen();
                    protokoll.ZeitProtokollieren(timer.Erhalten());
                    Console.WriteLine($"{aktuellerSpieler.Name} hat gewonnen!");
                    spielLaufend = false;
                }
                else if (IstUnentschieden(size))
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
        }

        private bool IstUnentschieden(int size)
        {
            for (int i = 0; i <size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (spielfeld.GetCell(i, j) == '.') // Überprüft, ob ein Feld leer ist
                    {
                        return false;  // Wenn noch ein leeres Feld existiert, ist es kein Unentschieden
                    }
                }
            }
            return true;  // Alle Felder sind besetzt, daher Unentschieden
        }


    }

}

