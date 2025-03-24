using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tic_Tac_Toe_gruppe1
{
    /// <summary>
    /// Repräsentiert einen Spieler im Tic-Tac-Toe-Spiel.
    /// </summary>
    public class Spieler
    {
        /// <summary>
        /// Der Name des Spielers
        /// </summary>
        public string Name { get; }
        /// <summary>
        /// Das Symbol des Spielers (X oder O).
        /// </summary>
        public char Symbol { get; }
        /// <summary>
        /// Die Undo-Funktion für den Spieler, um einen Zug rückgängig zu machen.
        /// </summary>
        public UndoFunction Undo { get; } = new UndoFunction();

        public Zug Zug
        {
            get => default;
            set
            {
            }
        }

        /// <summary>
        /// Initialisiert einen neuen Spieler mit einem Namen und einem Symbol.
        /// Der Konstruktor erstellt einen Spieler mit dem angegebenen Namen und Symbol.
        /// Das Symbol könnte X oder O im Tic-Tac-Toe-Spiel sein.
        /// </remarks>
        /// </summary>
        /// <param name="name">Der Name des Spielers.</param>
        /// <param name="symbol">Das Symbol des Spielers (X oder O).</param>
        public Spieler(string name, char symbol)
        {
            Name = name;
            Symbol = symbol;
        }
    }
}
