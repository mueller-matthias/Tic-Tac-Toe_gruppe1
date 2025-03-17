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
        private int groesse;

        public GameBoardModel(int size)
        {
            groesse = size;
            board = new char[size, size];
            for (int i = 0; i < size; i++)
                for (int j = 0; j < size; j++)
                    board[i, j] = '.'; // Initialisierung mit Platzhaltern
        }

        public char GetCell(int row, int col) => board[row, col];

        public void SetCell(int row, int col, char symbol) => board[row, col] = symbol;

        public bool ValidateMove(int row, int col) => board[row, col] == '.';

        public bool PruefeGewinner(char symbol)
        {
            for (int i = 0; i < groesse; i++)
            {
                if (CheckRow(i, symbol) || CheckCol(i, symbol)) return true;
            }
            return CheckDiagonals(symbol);
        }

        private bool CheckRow(int row, char symbol)
        {
            for (int col = 0; col < groesse; col++)
                if (board[row, col] != symbol) return false;
            return true;
        }

        private bool CheckCol(int col, char symbol)
        {
            for (int row = 0; row < groesse; row++)
                if (board[row, col] != symbol) return false;
            return true;
        }

        private bool CheckDiagonals(char symbol)
        {
            bool diag1 = true, diag2 = true;
            for (int i = 0; i < groesse; i++)
            {
                if (board[i, i] != symbol) diag1 = false;
                if (board[i, groesse - 1 - i] != symbol) diag2 = false;
            }
            return diag1 || diag2;
        }

        public void DisplayBoard()
        {
            Console.Write("  ");
            for (int i = 0; i < groesse; i++) Console.Write(i + " ");
            Console.WriteLine();

            for (int i = 0; i < groesse; i++)
            {
                Console.Write(i + " ");
                for (int j = 0; j < groesse; j++)
                {
                    Console.Write(board[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
