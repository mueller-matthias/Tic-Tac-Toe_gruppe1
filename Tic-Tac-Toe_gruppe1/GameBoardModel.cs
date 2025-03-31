using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tic_Tac_Toe_gruppe1
{
    /// <summary>
    /// Repräsentiert das Spielfeld im Tic-Tac-Toe-Spiel.
    /// Diese Klasse verwaltet das Spielfeld, prüft Züge und ermittelt den Gewinner.
    /// </summary>
    public class GameBoardModel
    {
        private char[,] board;
        /// <summary>
        /// Die Größe des Spielbretts (Anzahl der Zeilen und Spalten).
        /// </summary>
        public int Groesse { get; private set; }
        private int siegBedingung;
        /// <summary>
        /// Initialisiert das Spielbrett mit einer angegebenen Größe.
        /// Das Spielfeld wird mit Platzhaltern ('.') initialisiert, und die Siegbedingung wird
        /// je nach Spielfeldgröße festgelegt (3 für 3x3, 4 für 5x5 und 7x7).
        /// </summary>
        /// <param name="size">Die Größe des Spielfelds (z. B. 3 für ein 3x3 Spielfeld).</param>
        public GameBoardModel(int size)
        {
            Groesse = size;
            board = new char[size, size];

            for (int i = 0; i < size; i++)
                for (int j = 0; j < size; j++)
                    board[i, j] = '.';

            siegBedingung = (size == 3) ? 3 : 4;
        }
        /// <summary>
        /// Gibt den Inhalt einer bestimmten Zelle im Spielfeld zurück.
        /// </summary>
        /// <param name="row">Die Zeile der Zelle (0-basiert).</param>
        /// <param name="col">Die Spalte der Zelle (0-basiert).</param>
        /// <returns>Das Symbol an der angegebenen Position (z. B. '.' für leer, 'X' oder 'O').</returns>
        public char GetCell(int row, int col) => board[row, col];
        /// <summary>
        /// Setzt ein Symbol an einer bestimmten Position auf dem Spielfeld.
        /// </summary>
        /// <param name="row">Die Zeile der Zelle (0-basiert).</param>
        /// <param name="col">Die Spalte der Zelle (0-basiert).</param>
        /// <param name="symbol">Das Symbol, das in die Zelle gesetzt werden soll (X oder O).</param>
        public void SetCell(int row, int col, char symbol) => board[row, col] = symbol;
        /// <summary>
        /// Überprüft, ob ein Zug an der angegebenen Position gültig ist.
        /// Ein Zug ist gültig, wenn die Zelle leer ist ('.').
        /// </summary>
        /// <param name="row">Die Zeile der Zelle (0-basiert).</param>
        /// <param name="col">Die Spalte der Zelle (0-basiert).</param>
        /// <returns>true, wenn der Zug gültig ist, andernfalls false.</returns>
        public bool ValidateMove(int row, int col) => board[row, col] == '.';
        /// <summary>
        /// Überprüft, ob ein Spieler das Spiel gewonnen hat.
        /// Diese Methode prüft die Zeilen, Spalten und Diagonalen des Spielfelds, um festzustellen,
        /// ob der Spieler mit dem angegebenen Symbol die Siegbedingung erfüllt hat.
        /// </summary>
        /// <param name="symbol">Das Symbol des Spielers (X oder O.</param>
        /// <param name="siegBedingung">Die Anzahl der gleichen Symbole, die in einer Reihe für einen Sieg erforderlich sind.</param>
        /// <returns>true, wenn der Spieler gewonnen hat, andernfalls false</returns>
        public bool PruefeGewinner(char symbol, int siegBedingung)
        {

            for (int i = 0; i < Groesse; i++)
            {
                if (CheckLine(i, 0, 0, 1, symbol, siegBedingung) ||
                    CheckLine(0, i, 1, 0, symbol, siegBedingung))
                {
                    return true;
                }
            }


            return CheckLine(0, 0, 1, 1, symbol, siegBedingung) ||
                   CheckLine(0, Groesse - 1, 1, -1, symbol, siegBedingung);
        }
        /// <summary>
        /// Überprüft eine bestimmte Reihe (Zeile, Spalte oder Diagonale) auf eine Siegbedingung.
        /// </summary>
        /// <param name="startX">Der Start-X-Wert (Zeile oder Spalte).</param>
        /// <param name="startY">Der Start-Y-Wert (Zeile oder Spalte).</param>
        /// <param name="stepX">Der Schrittwert in der X-Richtung (1 für Zeile, 0 für Spalte, -1 für Diagonale).</param>
        /// <param name="stepY">Der Schrittwert in der Y-Richtung (1 für Zeile, 0 für Spalte, -1 für Diagonale).</param>
        /// <param name="symbol">Das Symbol des Spielers.</param>
        /// <param name="siegBedingung">Die Siegbedingung (z. B. 3 für 3 gleiche Symbole).</param>
        /// <returns>true, wenn die Siegbedingung erfüllt ist, andernfalls false.</returns>
        private bool CheckLine(int startX, int startY, int stepX, int stepY, char symbol, int siegBedingung)
        {
            int count = 0;
            int x = startX, y = startY;

            while (x < Groesse && y < Groesse && y >= 0)
            {
                if (board[x, y] == symbol)
                {
                    count++;
                    if (count == siegBedingung) return true;
                }
                else
                {
                    count = 0;
                }

                x += stepX;
                y += stepY;
            }

            return false;
        }

        /// <summary>
        /// Zeigt das aktuelle Spielfeld auf der Konsole an.
        /// </summary>
        public void DisplayBoard()
        {

            Console.Write("    ");
            for (int i = 0; i < Groesse; i++)
            {
                Console.Write((char)('a' + i) + " ");
            }
            Console.WriteLine();


            for (int i = 0; i < Groesse; i++)
            {
                Console.Write((i + 1) + "   ");
                for (int j = 0; j < Groesse; j++)
                {
                    Console.Write(board[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Validiert die Benutzereingabe in der Form "a1", "b2", "c3", etc.
        /// </summary>
        /// <param name="input">Die Eingabe des Spielers (z. B. "a1", "b2").</param>
        /// <param name="row">Die Zeile (0-basiert), die aus der Eingabe extrahiert wird.</param>
        /// <param name="col">Die Spalte (0-basiert), die aus der Eingabe extrahiert wird.</param>
        /// <returns>true, wenn die Eingabe gültig ist, andernfalls false.</returns>
        public bool ValidateInput(string input, out int row, out int col)
        {
            row = -1;
            col = -1;
            if (string.IsNullOrWhiteSpace(input) || input.Length < 2)
            {
                return false;
            }

            char columnChar = char.ToLower(input[0]);
            col = columnChar - 'a';
            if (col < 0 || col >= Groesse)
            {
                return false;
            }


            string rowString = input.Substring(1);


            if (!int.TryParse(rowString, out row))
            {
                return false;
            }


            if (row < 1 || row > Groesse)
            {
                return false;
            }


            row--;

            return true;
        }
    }

}

