using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Photosynthesis.Core;
using Microsoft.Xna.Framework;

namespace Photosynthesis.Sprites
{
    public class Photon : MovingSprite
    {
        public bool IsBad;
        public int TimeExisted;

        public Photon(Texture2D texture, SystemHandler handler, Vector2 location, bool isBad)
            : base(texture, location, 0f, 1f, 12f, handler)
        {
            this.IsBad = isBad;
            this.TimeExisted = 0;
        }
    }
}
