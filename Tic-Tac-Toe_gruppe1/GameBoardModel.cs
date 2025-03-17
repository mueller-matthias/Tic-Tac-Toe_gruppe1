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
            {
                for (int j = 0; j < size; j++)
                {
                    board[i, j] = ' ';
                }
            }
        }

        public char GetCell(int row, int col)
        {
            return board[row, col];
        }

        public void SetCell(int row, int col, char symbol)
        {
            board[row, col] = symbol;
        }

        public bool ValidateMove(Spieler spieler, int row)
        {
            return row >= 0 && row < groesse && board[row, 0] == ' ';
        }

        public bool pruefeGewinner(GameBoardModel spielfeld, Spieler spieler)
        {
            char symbol = spieler.Symbol;

            // Horizontale und vertikale Prüfung
            for (int i = 0; i < groesse; i++)
            {
                if (CheckRow(i, symbol) || CheckColumn(i, symbol))
                    return true;
            }

            // Diagonale Prüfung
            return CheckDiagonal(symbol) || CheckAntiDiagonal(symbol);
        }

        private bool CheckRow(int row, char symbol)
        {
            for (int i = 0; i < groesse; i++)
            {
                if (board[row, i] != symbol)
                    return false;
            }
            return true;
        }

        private bool CheckColumn(int col, char symbol)
        {
            for (int i = 0; i < groesse; i++)
            {
                if (board[i, col] != symbol)
                    return false;
            }
            return true;
        }

        private bool CheckDiagonal(char symbol)
        {
            for (int i = 0; i < groesse; i++)
            {
                if (board[i, i] != symbol)
                    return false;
            }
            return true;
        }

        private bool CheckAntiDiagonal(char symbol)
        {
            for (int i = 0; i < groesse; i++)
            {
                if (board[i, groesse - 1 - i] != symbol)
                    return false;
            }
            return true;
        }
    }
}
