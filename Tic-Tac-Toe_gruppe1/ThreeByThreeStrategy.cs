using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tic_Tac_Toe_gruppe1
{
        public class ThreeByThreeStrategy : IGameStrategy
        {
        /// <summary>
        /// Für das Strategy-Pattern. So kann die Spielfeldgrösse definieren.
        /// </summary>
        /// <returns>Grösse des Spielfeldes</returns>
        public int GetBoardSize()
            {
                return 3;
            }
        }
    }
