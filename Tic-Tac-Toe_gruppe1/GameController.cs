using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tic_Tac_Toe_gruppe1
{
    internal class GameController
    {
        private GameBoardModel spielfeld;
        private Spieler[] spieler;
        private int aktuellerSpielerIndex;
        private Protokoll protokoll = new Protokoll();
        private GameView view = new GameView();

        public GameController(int size)
        {
            spielfeld = new GameBoardModel(size);
            spieler = new Spieler[] { new Spieler("Spieler 1", 'X'), new Spieler("Spieler 2", 'O') };
            aktuellerSpielerIndex = 0;
        }

        public void Starten()
        {
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
                    Console.WriteLine($"{aktuellerSpieler.Name} hat gewonnen!");
                    spielLaufend = false;
                }
                else if (IstUnentschieden())
                {
                    view.UpdateView(spielfeld);
                    Console.WriteLine("Unentschieden!");
                    spielLaufend = false;
                }
                else
                {
                    aktuellerSpielerIndex = 1 - aktuellerSpielerIndex;
                }
            }
        }

        private bool IstUnentschieden()
        {
            for (int i = 0; i < spielfeld.GetCell(0, 0).ToString().Length; i++)
                for (int j = 0; j < spielfeld.GetCell(0, 0).ToString().Length; j++)
                    if (spielfeld.GetCell(i, j) == '.') return false;
            return true;
        }

    }

}

