using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Photosynthesis.Core
{
    public class Sprite
    {
        public Texture2D Texture;
        public Vector2 Location;
        public float Rotation;
        public Vector2 Origin;
        public float Scale;

        public Sprite(Texture2D texture, Vector2 location, float rotation, float scale)
        {
            this.Texture = texture;
            this.Location = location;
            this.Rotation = rotation;
            this.Origin = new Vector2(this.Texture.Width / 2, this.Texture.Height / 2);
            this.Scale = scale;
        }

        public void Draw(SpriteBatch batch, Vector2 focus)
        {
            batch.Draw(this.Texture, this.GetScreenPosition(this.Location, focus), null, Color.White, this.Rotation, this.Origin, this.Scale, SpriteEffects.None, 0f);
        }

        public bool DoesCollide(Sprite sp1, Sprite sp2)
        {
            if (sp1.Location.X > sp2.Location.X && sp1.Location.X < sp2.Location.X + sp2.Texture.Width)
            {
                if (sp1.Location.Y > sp2.Location.Y && sp1.Location.Y < sp2.Location.Y + sp2.Texture.Height)
                {
                    return true;
                }
            }

            return false;
        }

        public Vector2 GetScreenPosition(Vector2 l1, Vector2 focus)
        {
            return new Vector2(-(focus.X - l1.X) + 400, -(focus.Y - l1.Y) + 400);
        }
    }
}
