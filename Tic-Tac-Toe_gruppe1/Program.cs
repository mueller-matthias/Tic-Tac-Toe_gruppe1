namespace Tic_Tac_Toe_gruppe1
{
    internal class Program
    {
        public GameController GameController
        {
            get => default;
            set
            {
            }
        }

        internal GameView GameView
        {
            get => default;
            set
            {
            }
        }

        static void Main(string[] args)
        {
            GameController spiel = new GameController();
            spiel.Starten();
        }
    }
}
