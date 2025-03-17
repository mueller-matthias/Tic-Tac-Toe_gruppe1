using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tic_Tac_Toe_gruppe1
{
    internal class GameView
    {
        public void UpdateView() { }
        public void zeichneSpielfeld(GameBoardModel board) { }
        public void zeigeFehlermeldung(string nachricht) { }
        public void zeigeSpielerAmZug(Spieler spieler) { }
        public void zeigeSpielzeit(TimeSpan dauer) { }
        public void zeigeGewinner(Spieler spieler) { }

    }
}
