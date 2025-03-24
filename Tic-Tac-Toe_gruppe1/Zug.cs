using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tic_Tac_Toe_gruppe1
{
    /// <summary>
    /// Repräsentiert einen Zug im Spiel, einschließlich des Spielers, der den Zug gemacht hat, 
    /// der Position des Zugs und des Zeitstempels, wann der Zug gemacht wurde.
    /// </summary>
    public class Zug
    {
        /// <summary>
        ///  Der Spieler, der den Zug gemacht hat.
        /// </summary>
        public Spieler Spieler { get; }
        /// <summary>
        /// Die Zeilenposition des Zugs auf dem Spielfeld (0-basiert).
        /// </summary>
        public int Row { get; }
        /// <summary>
        /// Die Spaltenposition des Zugs auf dem Spielfeld (0-basiert).
        /// </summary>
        public int Col { get; }
        /// <summary>
        /// Der Zeitstempel, der den Zeitpunkt angibt, an dem der Zug gemacht wurde.
        /// </summary>
        public DateTime Zeitstempel { get; }
        /// <summary>
        /// Initialisiert einen neuen Zug mit dem angegebenen Spieler und der Position des Zugs.
        /// Der Zeitstempel wird automatisch auf den aktuellen Zeitpunkt gesetzt.
        /// </summary>
        /// <param name="spieler">Der Spieler, der den Zug gemacht hat.</param>
        /// <param name="row">Die Zeile des Zugs auf dem Spielfeld (0-basiert).</param>
        /// <param name="col">Die Spalte des Zugs auf dem Spielfeld (0-basiert).</param>
        public Zug(Spieler spieler, int row, int col)
        {
            Spieler = spieler;
            Row = row;
            Col = col;
            Zeitstempel = DateTime.Now;
        }
    }
}
