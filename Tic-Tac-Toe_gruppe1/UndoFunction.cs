using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tic_Tac_Toe_gruppe1
{
    /// <summary>
    /// Repräsentiert die Historie der Züge in einem Spiel.
    /// </summary>
    public class UndoFunction
    {
        /// <summary>
        /// Stellt einen Stack zur Speicherung der Züge bereit.
        /// </summary>
        private Stack<Zug> zugHistory = new Stack<Zug>();
        /// <summary>
        /// Speichert einen Zug in der Historie.
        /// </summary>
        /// <param name="zug">Der Zug, der gespeichert werden soll.</param>
        public void SpeichereZug(Zug zug)
        {
            zugHistory.Push(zug);
        }
        /// <summary>
        /// Lädt den letzten gespeicherten Zug aus der Historie.
        /// </summary>
        /// <returns>Der letzte gespeicherte Zug oder <c>null</c>, wenn keine Züge gespeichert sind.</returns>
        public Zug LadeLetztenZug()
        {
            return zugHistory.Count > 0 ? zugHistory.Pop() : null;
        }

    }
}
