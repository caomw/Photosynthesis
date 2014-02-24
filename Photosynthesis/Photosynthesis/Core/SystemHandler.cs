using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Photosynthesis.Systems;

namespace Photosynthesis.Core
{
    public class SystemHandler
    {
        public List<List<String>> TextList;
        public int TextIndex;
        public SpriteFont TextFont;
        public Vector2 TextLocation;
        public int ButtonLag;

        public SpriteBatch Batch;
        public ContentManager Content;
        public Random RNG;
        public Stage CurrentStage;

        public PhotosystemWing One;
        public PhotosystemETC Two;

        public enum Stage
        {
            Photon,
            ToPlastoquinone
        };

        public SystemHandler(SpriteBatch batch, ContentManager content)
        {
            this.Batch = batch;
            this.Content = content;
            this.RNG = new Random();
            this.CurrentStage = Stage.Photon;

            this.TextFont = Content.Load<SpriteFont>("Font/TextFont");
            this.TextList = null;
            this.TextIndex = 0;
            this.TextLocation = new Vector2(20, 550);
            this.ButtonLag = 0;

            this.One = new PhotosystemWing(this);
            this.Two = new PhotosystemETC(this);
        }

        public void Draw()
        {
            this.Batch.Begin();

            switch (this.CurrentStage)
            {
                case Stage.Photon:
                    this.One.Draw();
                    break;

                case Stage.ToPlastoquinone:
                    this.Two.Draw();
                    break;
            }

            this.DrawStringOnScreen(this.TextLocation);

            this.Batch.End();
        }

        public void Update(MouseState mState, KeyboardState kState)
        {
            switch (this.CurrentStage)
            {
                case Stage.Photon:
                    this.One.Update(mState, kState);
                    break;

                case Stage.ToPlastoquinone:
                    this.Two.Update(mState, kState);
                    break;
            }

            this.UpdateText(mState, kState);
        }

        public void DrawText(List<String> text)
        {
            if (this.TextList == null)
            {
                this.TextList = new List<List<string>>();
            }

            this.TextList.Add(text);
        }

        public void UpdateText(MouseState mState, KeyboardState kState)
        {
            if (this.ButtonLag > 0)
            {
                this.ButtonLag--;
            }
            else 
            {
                if (this.TextList != null && this.TextList.Count > 0 && this.TextList[0] != null)
                {
                    if (mState.LeftButton == ButtonState.Pressed || kState.IsKeyDown(Keys.Enter))
                    {
                        this.TextIndex++;
                        this.ButtonLag = 20;

                        if (this.TextIndex >= this.TextList[0].Count)
                        {
                            this.TextList.RemoveAt(0);
                            this.TextIndex = 0;
                        }
                    }
                }
            }
        }

        public void DrawStringOnScreen(Vector2 location)
        {
            if (this.TextList != null && this.TextList.Count > 0 && this.TextList[0] != null)
            {
                this.Batch.DrawString(TextFont, this.TextList[0][this.TextIndex], location, Color.Black);
            }
        }
    }
}
