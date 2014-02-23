using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Photosynthesis.Systems;

namespace Photosynthesis.Core.Generators
{
    public class Generator
    {
        public PhotoSystem CurrentSystem;
        public List<Sprite> Sprites;
        public int Frequency;
        public SystemHandler Handler;

        public Generator(PhotoSystem currentSystem, int frequency, SystemHandler handler)
        {
            this.CurrentSystem = currentSystem;
            this.Sprites = new List<Sprite>();
            this.Frequency = frequency;
            this.Handler = handler;
        }
    }
}
