using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tic_Tac_Toe_gruppe1
{
    /// <summary>
    /// Repräsentiert die Ansicht des Spiels, die die Anzeige des Spielbretts aktualisiert.
    /// </summary>
    internal class GameView
    {
        /// <summary>
        /// Aktualisiert die Ansicht des Spielbretts und zeigt das aktuelle Spielbrett an.
        /// Diese Methode ruft die Methode <see cref="GameBoardModel.DisplayBoard"/> auf, um das
        /// Spielbrett darzustellen. Sie wird verwendet, um die grafische Darstellung des Spiels zu
        /// aktualisieren und anzuzeigen.
        /// </summary>
        /// <param name="board">Das Modell des Spielbretts, das die aktuelle Spielzustand enthält.</param>
        public void UpdateView(GameBoardModel board)
        {
            board.DisplayBoard();
        }

    }
}
