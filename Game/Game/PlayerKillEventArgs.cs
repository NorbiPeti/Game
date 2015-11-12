using System;

namespace Game
{
    public class PlayerKillEventArgs : EventArgs
    {
        public Player Player;
        public Player Killer;

        public PlayerKillEventArgs(Player player, Player killer)
        {
            Player = player;
            Killer = killer;
        }
    }
}