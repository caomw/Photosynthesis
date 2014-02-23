using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Photosynthesis.Core;

namespace Photosynthesis.Systems
{
    public class System
    {
        public bool IsLight;
        public Texture2D Background;
        public SystemHandler Handler;
        public Sprite Player;

        public System(bool isLight, Texture2D background, SystemHandler handler)
        {
            this.IsLight = isLight;
            this.Background = background;
            this.Handler = handler;
        }
    }
}
