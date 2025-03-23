using Tic_Tac_Toe_gruppe1;

namespace TicTacToeApp
{
    public class Protokoll
    {
        // Die einzige Instanz der Protokoll-Klasse
        private static Protokoll _instance;

        // Privater Konstruktor, um die Instanz nicht von außen erstellen zu können
        private Protokoll() { }

        // Statische Methode, um auf die einzige Instanz zuzugreifen
        public static Protokoll GetInstance()
        {
            // Wenn die Instanz noch nicht existiert, erstelle sie
            if (_instance == null)
            {
                _instance = new Protokoll();
            }
            return _instance;
        }

        // Funktion zum Speichern eines Zuges in der Datei
        internal void Speichern(Zug zug)
        {
            try
            {
                // Bestimmen des Pfads zum "Documents"-Ordner des Benutzers
                string userDocumentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

                // Erstellen des vollständigen Dateipfads
                string filePath = Path.Combine(userDocumentsPath, "TicTacToe_Protokoll.txt");

                // Erstellen des Protokolltexts für den Zug
                string protokollText = $"{zug.Spieler.Name} setzte auf ({zug.Row}, {zug.Col}) um {zug.Zeitstempel}\n";

                // Den Text an die Datei anhängen
                File.AppendAllText(filePath, protokollText);

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Fehler beim Speichern des Zugs: {ex.Message}");
            }
        }

        // Funktion zum Speichern des Spielstarts
        internal void SpielStarten(int size)
        {
            try
            {
                string userDocumentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                string filePath = Path.Combine(userDocumentsPath, "TicTacToe_Protokoll.txt");

                // Protokolltext für den Spielstart
                string protokollText = $"Spiel gestartet mit Spielfeldgröße {size}x{size}\n";

                File.AppendAllText(filePath, protokollText);

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Fehler beim Protokollieren des Spielstarts: {ex.Message}");
            }
        }

        // Funktion zum Speichern des Spielendes und des Gewinners
        internal void SpielBeenden(Spieler gewinner)
        {
            try
            {
                string userDocumentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                string filePath = Path.Combine(userDocumentsPath, "TicTacToe_Protokoll.txt");

                // Protokolltext für das Spielende
                string protokollText = gewinner == null ? "Spiel endete mit Unentschieden.\n" : $"{gewinner.Name} hat gewonnen!\n";

                File.AppendAllText(filePath, protokollText);
                Console.WriteLine($"Gesamte Spiel wurde protokolliert: {filePath}");

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Fehler beim Protokollieren des Spielendes: {ex.Message}");
            }
        }

        internal void ZeitProtokollieren(string verstricheneZeit)
        {
            try
            {
                string userDocumentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                string filePath = Path.Combine(userDocumentsPath, "TicTacToe_Protokoll.txt");

                string protokollText = $"Gesamtspielzeit: {verstricheneZeit}\n----------------------";
                File.AppendAllText(filePath, protokollText);

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Fehler beim Protokollieren der Spielzeit: {ex.Message}");
            }
        }

        internal void UngueltigeEingabe(Zug zug)
        {
            try
            {
                string userDocumentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                string filePath = Path.Combine(userDocumentsPath, "TicTacToe_Protokoll.txt");

                string protokollText = $"{zug.Spieler.Name} versuchte eine ungültige Eingabe auf ({zug.Row}, {zug.Col}) um {zug.Zeitstempel}!\n";

                File.AppendAllText(filePath, protokollText);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Fehler beim Protokollieren der ungültigen Eingabe: {ex.Message}");
            }
        }
    }
}
