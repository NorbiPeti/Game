using System;

namespace Game
{
    public class PlayerSpawnEventArgs : EventArgs
    {
        public Player Player;

        public PlayerSpawnEventArgs(Player player)
        {
            Player = player;
        }
    }
}