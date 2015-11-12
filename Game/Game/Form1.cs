using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game
{
    public partial class Form1 : Form
    {
        public const int AvatarSize = 20;
        public static Form1 Instance { get; private set; }

        private Timer Timer;
        private Graphics Gr;
        private Point Mouse;
        public Form1()
        {
            InitializeComponent();
            Timer = new Timer();
            Timer.Interval = 25;
            Timer.Tick += Timer_Tick;
            Gr = panel1.CreateGraphics();
            Instance = this;
            Timer.Start();
        }

        private Player hittingplayer = null;
        private void Timer_Tick(object sender, EventArgs e)
        {
            try
            {
                //Gr.DrawEllipse(Pens.Black, Mouse.X - CircleRadius, Mouse.Y - CircleRadius, 2 * CircleRadius, 2 * CircleRadius);
                Gr.DrawLine(Pens.Black, 0, Mouse.Y, panel1.Width, Mouse.Y);
                Gr.DrawLine(Pens.Black, 0, Mouse.Y, Mouse.X - 5, Mouse.Y);
                Gr.DrawLine(Pens.Black, Mouse.X + 5, Mouse.Y, panel1.Width, Mouse.Y);
                Gr.DrawLine(Pens.Black, Mouse.X, 0, Mouse.X, Mouse.Y - 5);
                Gr.DrawLine(Pens.Black, Mouse.X, Mouse.Y + 5, Mouse.X, panel1.Height);
                //Game.Players.ForEach(a => Gr.FillRectangle(Brushes.Black, a.Position.X - CircleRadius, a.Position.Y - CircleRadius, 2 * CircleRadius, 2 * CircleRadius));

                Mouse = panel1.PointToClient(Cursor.Position);

                Player player = Game.Players.FirstOrDefault(a => Mouse.X > a.Position.X - AvatarSize && Mouse.X < a.Position.X + AvatarSize
                      & Mouse.Y > a.Position.Y - AvatarSize && Mouse.Y < a.Position.Y + AvatarSize);
                hittingplayer = player;

                //Gr.DrawEllipse(Pens.Blue, Mouse.X - CircleRadius, Mouse.Y - CircleRadius, 2 * CircleRadius, 2 * CircleRadius);
                if (player != null)
                {
                    Gr.DrawLine(Pens.Red, 0, Mouse.Y, panel1.Width, Mouse.Y);
                    Gr.DrawLine(Pens.Red, 0, Mouse.Y, Mouse.X - 5, Mouse.Y);
                    Gr.DrawLine(Pens.Red, Mouse.X + 5, Mouse.Y, panel1.Width, Mouse.Y);
                    Gr.DrawLine(Pens.Red, Mouse.X, 0, Mouse.X, Mouse.Y - 5);
                    Gr.DrawLine(Pens.Red, Mouse.X, Mouse.Y + 5, Mouse.X, panel1.Height);
                }
                else
                {
                    Gr.DrawLine(Pens.Blue, 0, Mouse.Y, panel1.Width, Mouse.Y);
                    Gr.DrawLine(Pens.Blue, 0, Mouse.Y, Mouse.X - 5, Mouse.Y);
                    Gr.DrawLine(Pens.Blue, Mouse.X + 5, Mouse.Y, panel1.Width, Mouse.Y);
                    Gr.DrawLine(Pens.Blue, Mouse.X, 0, Mouse.X, Mouse.Y - 5);
                    Gr.DrawLine(Pens.Blue, Mouse.X, Mouse.Y + 5, Mouse.X, panel1.Height);
                }
                Game.Players.ForEach(a => Gr.FillRectangle(Brushes.Blue, a.Position.X - AvatarSize, a.Position.Y - AvatarSize, 2 * AvatarSize, 2 * AvatarSize));
            }
            catch (ObjectDisposedException)
            {
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Gr.Dispose();
            Gr = panel1.CreateGraphics();
        }

        private void singleplayerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Game.NewGame(new Player(new Point(), "Player"), true, panel1.Size);
        }

        public void PlayerMove(object sender, PlayerMoveEventArgs e)
        {
            Gr.FillRectangle(Brushes.Black, e.From.X - AvatarSize, e.From.Y - AvatarSize, 2 * AvatarSize, 2 * AvatarSize);
            Gr.FillRectangle(Brushes.Blue, e.To.X - AvatarSize, e.To.Y - AvatarSize, 2 * AvatarSize, 2 * AvatarSize);
        }

        private void panel1_Click(object sender, EventArgs e)
        {
            if (hittingplayer != null)
            {
                hittingplayer.Health -= 10; //TODO
            }
        }

        public void PlayerSpawn(object sender, PlayerSpawnEventArgs e)
        {
            flowLayoutPanel1.Controls.Add(e.Player.NameLabel = new Label { Text = e.Player.Name, ForeColor = Color.Blue });
            flowLayoutPanel1.Controls.Add(e.Player.HealthLabel = new Label { Text = "Health: " + e.Player.Health, ForeColor = Color.Blue });
        }

        public void PlayerStatChange(object sender, PlayerStatChangeEventArgs e)
        {
            e.Player.NameLabel.Text = e.Player.Name;
            e.Player.HealthLabel.Text = "Health: " + e.Player.Health;
        }
    }
}
