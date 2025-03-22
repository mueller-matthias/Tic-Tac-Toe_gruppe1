namespace Tic_Tac_Toe_gruppe1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Spielfeldgröße wählen: ");
            int size = int.Parse(Console.ReadLine());
            GameController spiel = new GameController(size);
            spiel.Starten(size);
        }
    }
}
