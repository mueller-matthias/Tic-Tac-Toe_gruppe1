using System;
using System.Diagnostics;

namespace TicTacToeApp
{
    public class SpielTimer
    {
        /// <summary>
        /// Dies ist eine private Instanzvariable vom Typ Stopwatch. 
        /// </summary>
        private Stopwatch stopwatch;

        /// <summary>
        /// Dies ist der Konstruktor der Klasse SpielTimer. Der Konstruktor wird aufgerufen, wenn eine neue Instanz der Klasse erstellt wird.
        /// </summary>
        public SpielTimer()
        {
            stopwatch = new Stopwatch();
        }

        /// <summary>
        /// Timer starten
        /// </summary>
        public void Starten()
        {
            stopwatch.Start();
        }

        /// <summary>
        /// Timer stoppen
        /// </summary>
        public void Stoppen()
        {
            stopwatch.Stop();
        }

        /// <summary>
        /// Verstrichene Zeit erhalten (z.B. in Sekunden)
        /// </summary>
        /// <returns></returns>
        public string Erhalten()
        {
            return stopwatch.Elapsed.ToString(@"mm\:ss");  // Gibt die Zeit im Format Minuten:Sekunden zurück
        }

        /// <summary>
        /// // Timer zurücksetzen (für neue Spiele)
        /// </summary>
        public void Zuruecksetzen()
        {
            stopwatch.Reset();
        }
    }
}
