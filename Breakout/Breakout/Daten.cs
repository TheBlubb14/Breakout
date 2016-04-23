using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Breakout
{
    public class Block : Label
    {
        public bool bottom { get; set; }
        public bool top { get; set; }
        public bool left { get; set; }
        public bool right { get; set; }

    }

    public class Player : Label
    {
        public float Speed { get; set; }
    }

    class Daten
    {


    }
}
