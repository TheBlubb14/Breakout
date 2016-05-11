using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Breakout
{
    public class Entity
    {
        public Texture2D Texture { get; set; }
        public Vector2 Position { get; set; }

        public int Width { get { return Texture.Width; } }

        public int Height { get { return Texture.Height; } }
    }
}
