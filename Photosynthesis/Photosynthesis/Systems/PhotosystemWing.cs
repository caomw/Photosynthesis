using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Photosynthesis.Core;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Photosynthesis.Sprites;
using Microsoft.Xna.Framework.Input;
using Photosynthesis.Core.Generators;

namespace Photosynthesis.Systems
{
    public class PhotosystemWing : PhotoSystem
    {
        public enum Stages
        {
            Text,
            Photon,
            Escape,
            End
        }

        public Stages Stage;
        public Electron Player;
        public PhotonGenerator PhGen;
        public bool HasStart;

        public PhotosystemWing(SystemHandler handler)
            : base(handler.Content.Load<Texture2D>("Textures/PhotosystemWing"), handler)
        {
            this.Stage = Stages.Text;
            this.Player = new Electron(this.Handler.Content.Load<Texture2D>("Textures/Electron"), this.Handler, new Vector2(300, 500));
            this.PhGen = new PhotonGenerator(this, 6);
            this.HasStart = false;
        }

        public bool Update(MouseState mState, KeyboardState kState)
        {
            switch (this.Stage)
            {
                case Stages.Text:
                    if (!this.HasStart)
                    {
                        List<String> text = new List<string>();
                        text.Add("Woahhh, where am I?");
                        text.Add("I've heard stories about this place...");
                        text.Add("They call it, Photosystem II.");
                        text.Add("I hear they give out free 5 hour energy.");
                        text.Add("Hey those blue guys seem pretty exciting.");
                        text.Add("I should go talk to one.");
                        text.Add("STAGE 1: BUMP A BLUE PHOTON");
                        this.Handler.DrawText(text);
                        this.HasStart = true;
                    }

                    if (this.Handler.TextList.Count == 0)
                    {
                        this.Stage++;
                    }

                    break;

                case Stages.Photon:
                    if (kState.IsKeyDown(Keys.Left) || kState.IsKeyDown(Keys.Right))
                    {
                        if (kState.IsKeyDown(Keys.Left))
                        {
                            this.Player.MovementSpeed.X = -this.Player.MaxMovementSpeed;
                        }
                        else
                        {
                            this.Player.MovementSpeed.X = this.Player.MaxMovementSpeed;
                        }
                    }
                    else
                    {
                        this.Player.MovementSpeed.X = 0;
                    }

                    this.Player.Update();
                    if (this.Player.Location.X > 600)
                    {
                        this.Player.Location.X = 600;
                    }
                    if (this.Player.Location.X < 0)
                    {
                        this.Player.Location.X = 0;
                    }

                    this.PhGen.Update();

                    if (this.Player.IsEnergized)
                    {
                        this.Stage++;
                    }

                    break;
            }

            return false;
        }

        public void Draw()
        {
            base.Draw();

            this.PhGen.Draw();

            this.Player.Draw(this.Handler.Batch);
        }
    }
}
