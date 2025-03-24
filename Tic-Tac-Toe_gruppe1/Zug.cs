using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tic_Tac_Toe_gruppe1
{
    public class Zug
    {
        public Spieler Spieler { get; }
        public int Row { get; }
        public int Col { get; }
        public DateTime Zeitstempel { get; }

        public Zug(Spieler spieler, int row, int col)
        {
            Spieler = spieler;
            Row = row;
            Col = col;
            Zeitstempel = DateTime.Now;
        }
    }
}
