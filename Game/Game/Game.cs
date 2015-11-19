using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game
{
    public static class Game
    {
        public static List<Player> Players = new List<Player>();
        public static bool InGame = false;
        public static Player CurrentPlayer;
        public static bool SingplePlayer;
        public static Size GameSize;

        public static void NewGame(Player currentplayer, bool singleplayer, Size gamesize)
        {
            if (InGame)
            {
                QuitGame();
                return;
            }
            CurrentPlayer = currentplayer;
            SingplePlayer = singleplayer;
            GameSize = gamesize;
            var rand = new Random();
            if (SingplePlayer)
            {
                for (int i = 0; i < 5; i++)
                {
                    Players.Add(new Player(new Point(rand.Next(GameSize.Width), rand.Next(GameSize.Height)), "Bot" + (i + 1), null));
                }
            }
        }

        public static void QuitGame()
        {
            InGame = false;
            Players.ForEach(a => a.Kill(null));
            CurrentPlayer = null;
        }
    }
}
