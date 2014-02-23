using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Photosynthesis.Core;
using Microsoft.Xna.Framework;

namespace Photosynthesis.Systems
{
    public class PhotoSystem
    {
        public Texture2D Background;
        public SystemHandler Handler;

        public PhotoSystem(Texture2D background, SystemHandler handler)
        {
            this.Background = background;
            this.Handler = handler;
        }

        public void Update()
        {
            
        }

        public void Draw()
        {
            this.Handler.Batch.Draw(this.Background, new Vector2(0, 0), Color.White);
        }
    }
}
