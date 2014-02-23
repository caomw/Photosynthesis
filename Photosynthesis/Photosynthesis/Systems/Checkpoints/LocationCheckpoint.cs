using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Photosynthesis.Systems.Checkpoints
{
    public class LocationCheckpoint : Checkpoint
    {
        public Vector2 TargetLocation;
        public Vector2 TargetSize;

        public LocationCheckpoint(List<String> startText, List<String> finishText, System currentSystem, Vector2 targetLocation, Vector2 targetSize)
            : base(startText, finishText, currentSystem)
        {
            this.TargetLocation = targetLocation;
            this.TargetSize = targetSize;
        }

        public bool Update()
        {
            Vector2 location = this.CurrentSystem.Player.Location;

            if (location.X > this.TargetLocation.X && location.X < this.TargetLocation.X + this.TargetSize.X)
            {
                if (location.Y > this.TargetLocation.Y && location.Y < this.TargetLocation.Y + this.TargetSize.Y)
                {
                    this.CurrentSystem.Handler.DrawText(this.FinishText);
                    return true;
                }
            }

            return false;
        }
    }
}
