using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game
{
    public class Player
    {
        private int health;
        public int Health
        {
            get
            {
                return health;
            }
            set
            {
                health = value;
                if (ChangeEvent != null)
                    ChangeEvent(this, new PlayerStatChangeEventArgs(this));
            }
        }
        private string name;
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
                if (ChangeEvent != null)
                    ChangeEvent(this, new PlayerStatChangeEventArgs(this));
            }
        }
        private Point position;
        public Point Position
        {
            get
            {
                return position;
            }
            set
            {
                if (MoveEvent != null)
                    MoveEvent(this, new PlayerMoveEventArgs(this, position, value));
                position = value;
            }
        }
        public event EventHandler<PlayerMoveEventArgs> MoveEvent;
        public event EventHandler<PlayerSpawnEventArgs> SpawnEvent;
        public event EventHandler<PlayerStatChangeEventArgs> ChangeEvent;

        public Label HealthLabel;
        public Label NameLabel;
        public Player(Point position, string name)
        {
            Health = 100;
            MoveEvent += Form1.Instance.PlayerMove;
            SpawnEvent += Form1.Instance.PlayerSpawn;
            ChangeEvent += Form1.Instance.PlayerStatChange;
            SpawnEvent(this, new PlayerSpawnEventArgs(this));
            Position = position;
            Name = name;
        }
    }
}
