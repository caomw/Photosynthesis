using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Photosynthesis.Systems
{
    public class Checkpoint
    {
        public Vector2 Target;
        public List<String> StartText;
        public List<String> FinishText;
        public System CurrentSystem;

        public Checkpoint(Vector2 target, List<String> startText, List<String> finishText, System currentSystem)
        {
            this.Target = target;
            this.StartText = startText;
            this.FinishText = finishText;
            this.CurrentSystem = currentSystem;
        }

        public void Start()
        {
 
        }
    }
}
