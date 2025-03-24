namespace Tic_Tac_Toe_gruppe1
{
    public class SevenBySevenStrategy : IGameStrategy
    {
        /// <summary>
        /// Für das Strategy-Pattern. So kann die Spielfeldgrösse definieren.
        /// </summary>
        /// <returns>Grösse des Spielfeld</returns>
        public int GetBoardSize()
        {
            return 7;
        }
    }
}
