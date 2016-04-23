using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;

namespace Breakout
{
    public partial class Form1 : Form
    {
        protected override CreateParams CreateParams
        {
            get
            {
                var cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                return cp;
            }
        }

        private List<Block> blocks = new List<Block>();
        private Player player = new Player();

        public Form1()
        {
            InitializeComponent();
            StartUp();
        }

        private void StartUp()
        {
            SimpleLayout();
            SpawnPlayer();


            startGame();
        }

        private void SimpleLayout()
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    Block block = new Block();
                    block.Name = blocks.Count.ToString();
                    block.BackColor = Color.Blue;
                    block.Location = new Point(20 + ((block.Width + 10) * i), 20 + (block.Height + 10) * j);

                    blocks.Add(block);
                    playGround.Controls.Add(block);
                }
            }
        }

        private void SpawnPlayer()
        {
            player.Speed = 10;
            player.BackColor = Color.Green;
            player.Location = new Point((playGround.ClientSize.Width / 2) - (player.Width / 2), (playGround.ClientSize.Height - player.Height) - 20);

            playGround.Controls.Add(player);
        }

        private void startGame()
        {
            GameLoop.Start();
        }


        private void GameLoop_Tick(object sender, EventArgs e)
        {
            

            if (e.KeyCode == Keys.A)
                if (player.Location.X - Convert.ToInt32(1.2 * player.Speed) > 0)
                    player.Location = new Point(player.Location.X - Convert.ToInt32(1.2 * player.Speed), player.Location.Y);

            if (e.KeyCode == Keys.D)
                if (player.Location.X + Convert.ToInt32(1.2 * player.Speed) < (playGround.Width - player.Width))
                    player.Location = new Point(player.Location.X + Convert.ToInt32(1.2 * player.Speed), player.Location.Y);
        }

    }
}
