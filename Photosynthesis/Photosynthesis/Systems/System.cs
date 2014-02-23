using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Photosynthesis.Core;
using Microsoft.Xna.Framework;

namespace Photosynthesis.Systems
{
    public class System
    {
        public Texture2D Background;
        public SystemHandler Handler;
        public Sprite Player;
        public Vector2 Focus;

        public System(Texture2D background, SystemHandler handler, Vector2 focus)
        {
            this.Background = background;
            this.Handler = handler;
            this.Focus = focus;
        }

        public void Update()
        {
            
        }

        public void Draw()
        {
            this.Handler.Batch.Draw(this.Background, new Rectangle(0, 0, 600, 600), new Rectangle((int)this.Focus.X - 300, (int)this.Focus.Y - 300, 600, 600), Color.White);
        }
    }
}
