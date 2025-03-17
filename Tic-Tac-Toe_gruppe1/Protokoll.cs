using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tic_Tac_Toe_gruppe1
{
    internal class Protokoll
    {
        private List<Zug> spielverlauf = new List<Zug>();

        public void Speichern(Zug zug)
        {
            spielverlauf.Add(zug);
            File.AppendAllText("protokoll.txt", $"{zug.Spieler.Name} setzte auf ({zug.Row}, {zug.Col}) um {zug.Zeitstempel}\n");
        }
    }
}
