using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tic_Tac_Toe_gruppe1
{
    public class GameBoardModel
    {
            private char[,] board;
            public int Groesse { get; private set; }
            private int siegBedingung;

            public GameBoardModel(int size)
            {
                Groesse = size;
                board = new char[size, size];

                for (int i = 0; i < size; i++)
                    for (int j = 0; j < size; j++)
                        board[i, j] = '.'; // Initialisierung mit Platzhaltern

                siegBedingung = (size == 3) ? 3 : 4; // 3 gleiche für 3x3, 4 gleiche für 5x5 und 7x7
            }

            public char GetCell(int row, int col) => board[row, col];

            public void SetCell(int row, int col, char symbol) => board[row, col] = symbol;

            public bool ValidateMove(int row, int col) => board[row, col] == '.';

        public bool PruefeGewinner(char symbol, int siegBedingung)
        {
            // Zeilen, Spalten und Diagonalen prüfen
            for (int i = 0; i < Groesse; i++)
            {
                if (CheckLine(i, 0, 0, 1, symbol, siegBedingung) || // Zeilenprüfung
                    CheckLine(0, i, 1, 0, symbol, siegBedingung))   // Spaltenprüfung
                {
                    return true;
                }
            }

            // Diagonalen prüfen
            return CheckLine(0, 0, 1, 1, symbol, siegBedingung) || // Hauptdiagonale
                   CheckLine(0, Groesse - 1, 1, -1, symbol, siegBedingung); // Nebendiagonale
        }

        private bool CheckLine(int startX, int startY, int stepX, int stepY, char symbol, int siegBedingung)
        {
            int count = 0;
            int x = startX, y = startY;

            while (x < Groesse && y < Groesse && y >= 0)
            {
                if (board[x, y] == symbol)
                {
                    count++;
                    if (count == siegBedingung) return true; // Siegbedingung erfüllt
                }
                else
                {
                    count = 0; // Serie unterbrochen
                }

                x += stepX;
                y += stepY;
            }

            return false;
        }

        public void DisplayBoard()
            {
                Console.Write("  ");
                for (int i = 0; i < Groesse; i++) Console.Write(i + " ");
                Console.WriteLine();

                for (int i = 0; i < Groesse; i++)
                {
                    Console.Write(i + " ");
                    for (int j = 0; j < Groesse; j++)
                    {
                        Console.Write(board[i, j] + " ");
                    }
                    Console.WriteLine();
                }
            }
    }
}

