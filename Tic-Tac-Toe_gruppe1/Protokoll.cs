using Tic_Tac_Toe_gruppe1;

namespace TicTacToeApp
{
    public class Protokoll
    {
        /// <summary>
        /// Instanz wird erstellt.
        /// </summary>
        private static Protokoll _instance;

        /// <summary>
        /// Privater Konstruktor, um die Instanz nicht von außen erstellen zu können
        /// </summary>
        private Protokoll() { }

        /// <summary>
        /// Statische Methode, um auf die einzige Instanz zuzugreifen. Wenn keine Instanz existiert, sollte eine ersellt werden.
        /// </summary>
        /// <returns>Instanz</returns>
        public static Protokoll GetInstance()
        {
            
            if (_instance == null)
            {
                _instance = new Protokoll();
            }
            return _instance;
        }

        /// <summary>
        /// Sobald man einen Zug macht, wird diese Methode aufgerufen und dokumentiert den Zug.
        /// 1. Pfad zum Dokumente-Ordner wird gesucht und in Variable gespeichert.
        /// 2. Variable mit Pfad und Dateiname wird erstellt.
        /// 3. Koordinaten werden in passendes Format umgewandelt und in "result" gespeichert.
        /// 4. Protokolltext wird zusammengeführt und auch in eine Variable gespeichert.
        /// 5. Zuletzt wird der ProtokollText in die Datei gespeichert.
        /// </summary>
        /// <param name="zug"></param>
        public void Protokollieren(Zug zug)
        {
            try
            {
                
                string userDocumentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

                
                string filePath = Path.Combine(userDocumentsPath, "TicTacToe_Protokoll.txt");
                string result = ConvertToChessNotation(zug.Col, zug.Row);

                string protokollText = $"{zug.Spieler.Name} setzte auf {result} um {zug.Zeitstempel}\n";

                File.AppendAllText(filePath, protokollText);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Fehler beim Protokollieren des Zugs: {ex.Message}");
            }
        }

        /// <summary>
        /// Diese Methode wird direkt am Start aufgerufen. Sie Dokumentiert den Start und mit welcher Spielfeldgrösse das Match gestartet wurde.
        /// </summary>
        /// <param name="size">Grösse des Spielfeldes</param>
        public void ProtokolliereSpielStart(int size)
        {
            try
            {
                string userDocumentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                string filePath = Path.Combine(userDocumentsPath, "TicTacToe_Protokoll.txt");

                
                string protokollText = $"Spiel gestartet mit Spielfeldgröße {size}x{size}\n";

                File.AppendAllText(filePath, protokollText);

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Fehler beim Protokollieren des Spielstarts: {ex.Message}");
            }
        }

        /// <summary>
        /// Sobald das Spiel beendet ist, wird der Name des Gewinners in dem Protokoll festgehalten.
        /// </summary>
        /// <param name="gewinner">Name des Gewinners wird übergeben. Falls dieser "null" ist, bedeutet das, dass es ein Unentschieden war.</param>
        public void ProtokolliereSpielEnde(Spieler gewinner)
        {
            try
            {
                string userDocumentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                string filePath = Path.Combine(userDocumentsPath, "TicTacToe_Protokoll.txt");

                
                string protokollText = gewinner == null ? "Spiel endete mit Unentschieden.\n" : $"{gewinner.Name} hat gewonnen!\n";

                File.AppendAllText(filePath, protokollText);
                Console.WriteLine($"Gesamte Spiel wurde protokolliert: {filePath}");

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Fehler beim Protokollieren des Spielendes: {ex.Message}");
            }
        }
        /// <summary>
        /// Sobald das Match vorbei ist, wird die verstrichene Zeit im Protokoll niedergeschrieben.
        /// </summary>
        /// <param name="verstricheneZeit">Die Zeit, welche seit dem Start des Spieles gestoppt wurde.</param>
        public void ZeitProtokollieren(string verstricheneZeit)
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
        /// <summary>
        /// Sobald eine ungültige Eingabe gemacht wird, wird diese Protokolliert.
        /// </summary>
        /// <param name="zug">Informationen des Zug's werden übergeben</param>
        public void ProtokolliereUngueltigeEingabe(Zug zug)
        {
            try
            {
                string userDocumentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                string filePath = Path.Combine(userDocumentsPath, "TicTacToe_Protokoll.txt");
                string result = ConvertToChessNotation(zug.Col, zug.Row);
                string protokollText = $"{zug.Spieler.Name} versuchte eine ungültige Eingabe auf {result} um {zug.Zeitstempel}!\n";

                File.AppendAllText(filePath, protokollText);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Fehler beim Protokollieren der ungültigen Eingabe: {ex.Message}");
            }
        }
        /// <summary>
        /// Diese Methode wird aufgerugen, wenn der Zug bestätigt wird. So kann man das Spiel im Protokoll besser nachvollziehen.
        /// </summary>
        /// <param name="zug">Informationen des Zug's werden übergeben.</param>
        public void ProtokolliereBestaetigung(Zug zug)
        {
            try
            {
                string userDocumentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                string filePath = Path.Combine(userDocumentsPath, "TicTacToe_Protokoll.txt");
                string result = ConvertToChessNotation(zug.Col, zug.Row);
                string protokollText = $"{zug.Spieler.Name} bestätigte den Zug auf {result}\n";

                File.AppendAllText(filePath, protokollText);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Fehler beim Protokollieren der ungültigen Eingabe: {ex.Message}");
            }
        }
        /// <summary>
        /// Diese Methode wird aufgerufen, wenn der Spieler seinen Zug nicht bestätigt. So können wir sicherstellen, dass man im Protokoll alles mitverfolgen kann.
        /// </summary>
        /// <param name="zug">Informationen des Zug's werden übergeben.</param>
        public void ProtokolliereNichtBestaetigung(Zug zug)
        {
            try
            {
                string userDocumentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                string filePath = Path.Combine(userDocumentsPath, "TicTacToe_Protokoll.txt");
                string result = ConvertToChessNotation(zug.Col, zug.Row);
                string protokollText = $"{zug.Spieler.Name} bestätigte nicht den Zug auf {result}. Erneute Eingabe:\n";

                File.AppendAllText(filePath, protokollText);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Fehler beim Protokollieren der ungültigen Eingabe: {ex.Message}");
            }
        }

        /// <summary>
        /// Diese Methode wandelt die Parameter col und row wieder in unseres verständliches Format. 
        /// Bislang erscheint in der Protokoll-Datei z.B. (3/3) für c2. Dies ist allerdings schwierig zum Nachvollziehen. 
        /// Also ändert diese Methode die Koordinaten wieder zurück. 
        /// </summary>
        /// <param name="col">Übernimmt den Platz im Array der x-Achse</param>
        /// <param name="row">Übernimmt den Platz im Array der y-Achse</param>
        /// <returns></returns>
        static string ConvertToChessNotation(int col, int row)
        {
            char column = (char)('a' + col);
            int chessRow = row + 1;
            return $"{column}{chessRow}";
        }
    }
    }
