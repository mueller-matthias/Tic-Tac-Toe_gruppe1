using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tic_Tac_Toe_gruppe1
{
    public class UndoFunction
    {
        private Stack<Zug> zugHistory = new Stack<Zug>();

        public void SpeichereZug(Zug zug)
        {
            zugHistory.Push(zug);
        }

        public Zug LadeLetztenZug()
        {
            return zugHistory.Count > 0 ? zugHistory.Pop() : null;
        }

    }
}
