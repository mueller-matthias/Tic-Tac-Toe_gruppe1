using System;
using System.Diagnostics;

namespace TicTacToeApp
{
    public class SpielTimer
    {
        private Stopwatch stopwatch;

        public SpielTimer()
        {
            stopwatch = new Stopwatch();
        }

        // Timer starten
        public void Starten()
        {
            stopwatch.Start();
        }

        // Timer stoppen
        public void Stoppen()
        {
            stopwatch.Stop();
        }

        // Verstrichene Zeit erhalten (z.B. in Sekunden)
        public string Erhalten()
        {
            return stopwatch.Elapsed.ToString(@"mm\:ss");  // Gibt die Zeit im Format Minuten:Sekunden zurück
        }

        // Timer zurücksetzen (für neue Spiele)
        public void Zuruecksetzen()
        {
            stopwatch.Reset();
        }
    }
}
