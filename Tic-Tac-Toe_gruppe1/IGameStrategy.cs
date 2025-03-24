using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tic_Tac_Toe_gruppe1
{
    /// <summary>
    /// Definiert eine Strategie für ein Spiel, die grundlegende Spielfunktionen bereitstellt.
    /// </summary>
    
    public interface IGameStrategy
    {
        /// <summary>
        /// Gibt die Größe des Spielfelds zurück.
        /// </summary>
        /// <returns>Die Größe des Spielfelds, z. B. 3 für ein 3x3-Spielfeld.</returns>
        int GetBoardSize();
    }
}
