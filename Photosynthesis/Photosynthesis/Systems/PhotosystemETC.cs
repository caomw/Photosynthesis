using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Photosynthesis.Core.Generators;
using Photosynthesis.Core;
using Photosynthesis.Sprites;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Photosynthesis.Systems
{
    public class PhotosystemETC : PhotoSystem
    {
        public enum Stages
        {
            Text,
            Walls,
            End
        }

        public Stages Stage;
        public Electron Player;
        public WallGenerator WallGen;
        public bool HasStart;
        public bool LastKey;

        public PhotosystemETC(SystemHandler handler)
            : base(handler.Content.Load<Texture2D>("Textures/ETC"), handler)
        {
            this.Stage = Stages.Text;
            this.Player = new Electron(this.Handler.Content.Load<Texture2D>("Textures/Electron"), this.Handler, new Vector2(120, 300));
            //this.WallGen = new WallGenerator(this, 6);
            this.HasStart = false;
            this.LastKey = false;
        }

        public bool Update(MouseState mState, KeyboardState kState)
        {
            switch (this.Stage)
            {
                case Stages.Text:
                    if (!this.HasStart)
                    {
                        List<String> text = new List<string>();
                        text.Add("This place is fun.");
                        text.Add("It's even named after me!");
                        text.Add("They call it, the...");
                        text.Add("Electron Transport Chain!");
                        text.Add("Hopefully I can get to the end.");
                        text.Add("STAGE 2: NAVIGATE THE ETC");
                        this.Handler.DrawText(text);
                        this.HasStart = true;
                    }

                    if (this.Handler.TextList.Count == 0)
                    {
                        this.Stage++;
                    }

                    break;

                case Stages.Walls:
                    if (kState.IsKeyDown(Keys.Space))// && !this.LastKey)
                    {
                        this.Player.MovementSpeed.Y -= 0.4f;
                    }

                    this.LastKey = kState.IsKeyDown(Keys.Space);

                    this.Player.MovementSpeed.Y += 0.25f;

                    this.Player.Update();

                    if (this.Player.Location.Y > 600)
                    {
                        this.Player.Location.Y = 600;
                    }
                    if (this.Player.Location.Y < 0)
                    {
                        this.Player.Location.Y = 0;
                    }

                    //this.WallGen.Update();

                    break;

                case Stages.End:
                    this.Handler.CurrentStage++;
                    break;
            }

            return false;
        }

        public void Draw()
        {
            base.Draw();

            //this.WallGen.Draw();

            this.Player.Draw(this.Handler.Batch);
        }
    }
}