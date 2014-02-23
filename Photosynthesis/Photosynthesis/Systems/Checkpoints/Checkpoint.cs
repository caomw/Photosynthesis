using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Photosynthesis.Systems.Checkpoints
{
    public class Checkpoint
    {
        public List<String> StartText;
        public List<String> FinishText;
        public System CurrentSystem;

        public Checkpoint(List<String> startText, List<String> finishText, System currentSystem)
        {
            this.StartText = startText;
            this.FinishText = finishText;
            this.CurrentSystem = currentSystem;
        }

        public void Start()
        {
            this.CurrentSystem.Handler.DrawText(this.StartText);
        }
    }
}
