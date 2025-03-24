using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tic_Tac_Toe_gruppe1
{
    public class Spieler
    {
        public string Name { get; }
        public char Symbol { get; }
        public UndoFunction Undo { get; } = new UndoFunction();

        public Spieler(string name, char symbol)
        {
            Name = name;
            Symbol = symbol;
        }
    }
}
