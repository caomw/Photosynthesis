using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Photosynthesis.Core
{
    public class MovingSprite : Sprite
    {
        public float MaxMovementSpeed;
        public Vector2 MovementSpeed = new Vector2(0, 0);

        public MovingSprite(Texture2D texture, Vector2 location, float rotation, float scale, float maxMovementSpeed, SystemHandler handler)
            : base(texture, location, rotation, scale, handler)
        {
            this.MaxMovementSpeed = maxMovementSpeed;
        }

        public MovingSprite(Texture2D texture, Vector2 location, float rotation, float scale, float maxMovementSpeed, SystemHandler handler, Vector2 movementSpeed)
            : base(texture, location, rotation, scale, handler)
        {
            this.MaxMovementSpeed = maxMovementSpeed;
            this.MovementSpeed = movementSpeed;
        }

        public void Update()
        {
            this.Location += this.MovementSpeed;
        }
    }
}
