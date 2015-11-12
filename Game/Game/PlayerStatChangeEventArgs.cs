namespace Game
{
    public class PlayerStatChangeEventArgs
    {
        public Player Player;

        public PlayerStatChangeEventArgs(Player player)
        {
            Player = player;
        }
    }
}