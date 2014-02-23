using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Photosynthesis.Core;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Photosynthesis.Systems
{
    public class PhotosystemWing : System
    {
        public enum Stages
        {
            Text,
            Photon,
            Escape,
            End
        }

        public Stages Stage;

        public PhotosystemWing(SystemHandler handler)
            : base(handler.Content.Load<Texture2D>("Textures/PhotosystemWing"), handler, new Vector2(420, 600))
        {
            this.Stage = Stages.Text;
        }

        public bool Update()
        {
            switch (this.Stage)
            {
                case Stages.Text:
                    List<String> text = new List<string>();
                    text.Add("Woahhh, where am I?");
                    text.Add("I've heard stories about this place...");
                    text.Add("They call it, Photosystem II.");
                    text.Add("I hear they give out free 5 hour energy.");
                    text.Add("Hey those blue guys seem pretty exciting.");
                    text.Add("I should go talk to one.");
                    text.Add("STAGE 1: BUMP A PHOTON");
                    this.Handler.DrawText(text);

                    this.Stage++;
                    break;

                case Stages.Photon:

                    break;
            }

            return false;
        }
    }
}
