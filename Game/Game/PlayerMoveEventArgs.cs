using System;
using System.Drawing;

namespace Game
{
    public class PlayerMoveEventArgs : EventArgs
    {
        public Player Player;
        public Point From;
        public Point To;

        public PlayerMoveEventArgs(Player player, Point from, Point to)
        {
            Player = player;
            From = from;
            To = to;
        }
    }
}