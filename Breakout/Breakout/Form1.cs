using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Breakout
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// enable double buffering on every control
        /// </summary>
        protected override CreateParams CreateParams
        {
            get
            {
                var cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                return cp;
            }
        }

        private List<Block> bloecke = new List<Block>();

        public Form1()
        {
            InitializeComponent();
            StartUp();
        }

        private void StartUp()
        {
            SimpleLayout();

        }


        private void SimpleLayout()
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    Block block = new Block();
                    block.Name = bloecke.Count.ToString();
                    block.BackColor = Color.Blue;
                    block.Location = new Point(20 + ((block.Width + 10) * i), 20 + (block.Height + 10) * j);

                    bloecke.Add(block);
                    Controls.Add(block);
                }
            }
        }
    }
}
