using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tic_Tac_Toe_gruppe1
{
    internal class GameController
    {

        private Spieler aktuellerSpieler;
        private int spielmodus;
        private GameBoardModel spielfeld;
        private Timer timer;
        private WinChecker winChecker;
        private UndoFunction undo;
        private Protokoll protokoll;

        public void starten() { }
        public void beenden() { }
        public void rückgängigMachen() { }
        public bool validiereZug(Spieler spieler, int position) { }
        public bool pruefeGewinn() { }



    }
}
