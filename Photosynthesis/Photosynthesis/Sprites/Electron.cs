using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Photosynthesis.Core;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Photosynthesis.Sprites
{
    public class Electron : MovingSprite
    {
        public bool IsEnergized;

        public Electron(Texture2D texture, SystemHandler handler, Vector2 location)
            : base(texture, location, 0f, 1f, 4f, handler)
        {
            this.IsEnergized = false;
        }

        public void Update()
        {
            if (this.IsEnergized)
            {
                this.MovementSpeed += new Vector2((float)this.Handler.RNG.NextDouble() - 0.5f, (float)this.Handler.RNG.NextDouble() - 0.5f);
            }

            base.Update();
        }
    }
}
