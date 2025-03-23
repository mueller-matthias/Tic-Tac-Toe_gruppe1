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

        // Anpassung der Anzeige des Spielfelds
        public void DisplayBoard()
        {
            // Spaltenüberschrift (Buchstaben a, b, c, ...)
            Console.Write("    ");
            for (int i = 0; i < Groesse; i++)
            {
                Console.Write((char)('a' + i) + " "); // Spalten mit Buchstaben
            }
            Console.WriteLine();

            // Zeilen (Zahlen 1, 2, 3, ...)
            for (int i = 0; i < Groesse; i++)
            {
                Console.Write((i + 1) + "   "); // Zeilenanzeige (1, 2, 3, ...)
                for (int j = 0; j < Groesse; j++)
                {
                    Console.Write(board[i, j] + " "); // Spielfeld-Inhalt
                }
                Console.WriteLine();
            }
        }

        // Validierung der Eingabe in der Form "a1", "b2", "c3", etc.
        public bool ValidateInput(string input, out int row, out int col)
        {
            row = -1;
            col = -1;

            if (input.Length < 2) return false;

            // Zeile und Spalte extrahieren
            char columnChar = Char.ToLower(input[0]);
            if (columnChar < 'a' || columnChar > 'z') return false; // ungültiger Buchstabe

            // Umwandlung der Buchstaben in die Spaltennummer (z.B. 'a' -> 0, 'b' -> 1, ...)
            col = columnChar - 'a';
            if (col >= Groesse) return false; // Spalte außerhalb der Spielfeldgröße

            if (!int.TryParse(input.Substring(1), out row)) return false;

            row--; // Umwandlung in 0-basierten Index
            if (row < 0 || row >= Groesse) return false; // Zeile außerhalb der Spielfeldgröße

            return true;
        }
    }

}

