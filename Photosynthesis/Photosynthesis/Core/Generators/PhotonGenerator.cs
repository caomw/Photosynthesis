using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Photosynthesis.Systems;
using Photosynthesis.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Photosynthesis.Core.Generators
{
    public class PhotonGenerator : Generator
    {
        public List<Photon> Photons;
        public PhotosystemWing ThisSystem;
        public Texture2D BlueTexture;
        public Texture2D BlueWarning;
        public Texture2D BadTexture;
        public Texture2D BadWarning;

        public PhotonGenerator(PhotosystemWing currentSystem, int frequency)
            : base(currentSystem, frequency, currentSystem.Handler)
        {
            this.Photons = new List<Photon>();
            this.ThisSystem = currentSystem;

            this.BlueTexture = this.CurrentSystem.Handler.Content.Load<Texture2D>("Textures/Photon");
            this.BlueWarning = this.CurrentSystem.Handler.Content.Load<Texture2D>("Textures/PhotonWarning");
            this.BadTexture = this.CurrentSystem.Handler.Content.Load<Texture2D>("Textures/PhotonBad");
            this.BadWarning = this.CurrentSystem.Handler.Content.Load<Texture2D>("Textures/PhotonBadWarning");
        }

        public void Update()
        {
            int makeUp = this.Frequency - this.Photons.Count;

            if (makeUp > 0)
            {
                for (int i = 0; i < makeUp; i++)
                {
                    bool isBad = this.Handler.RNG.Next(this.Frequency) == 1 ? false : true;
                    this.Photons.Add(new Photon(isBad ? this.BadWarning : this.BlueWarning, this.Handler, new Vector2(this.Handler.RNG.Next(600), 0), isBad));
                }
            }

            for (int i = 0; i < this.Photons.Count; i++)
            {
                this.Photons[i].TimeExisted++;
                if (this.Photons[i].TimeExisted == 30)
                {
                    this.Photons[i].MovementSpeed = new Vector2(0, this.Photons[i].MaxMovementSpeed);
                    if (this.Photons[i].IsBad)
                    {
                        this.Photons[i].Texture = this.BadTexture;
                    }
                    else
                    {
                        this.Photons[i].Texture = this.BlueTexture;
                    }
                }

                this.Photons[i].Update();

                if (this.Photons[i].DoesCollide(this.Photons[i], this.ThisSystem.Player))
                {
                    List<String> text = new List<string>();

                    if (this.Photons[i].IsBad)
                    {
                        text.Add("Hey, get out of my way!");
                        text.Add("YOU LOST, START OVER! XD");
                        this.ThisSystem.Stage = 0;
                        this.ThisSystem.HasStart = false;
                    }
                    else
                    {
                        text.Add("Hey man, take some of my energy!");
                        this.ThisSystem.Player.IsEnergized = true;
                    }

                    this.ThisSystem.Handler.DrawText(text);
                }

                if (this.Photons[i].DoesCollide(this.Photons[i], this.ThisSystem.Player) || this.Photons[i].Location.Y > 600)
                {
                    this.Photons.RemoveAt(i);
                    i--;
                }
            }
        }

        public void Draw()
        {
            for (int i = 0; i < this.Photons.Count; i++)
            {
                this.Photons[i].Draw(this.CurrentSystem.Handler.Batch);
            }
        }
    }
}
