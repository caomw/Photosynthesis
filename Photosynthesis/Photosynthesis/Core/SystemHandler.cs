using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Photosynthesis.Core
{
    public class SystemHandler
    {
        public List<String> CurrentText;
        public int TextIndex;
        public SpriteFont TextFont;
        public Vector2 TextLocation;
        public int ButtonLag;

        public SpriteBatch Batch;
        public ContentManager Content;

        public enum Stage
        {
            PhotosystemTwo,
            Plastoquinone,
            Cytochrome,
            Plastocyanin,
            PhotosystemOne
        };

        public SystemHandler(SpriteBatch batch, ContentManager content)
        {
            this.Batch = batch;
            this.Content = content;

            this.TextFont = Content.Load<SpriteFont>("Font/TextFont");
            this.CurrentText = null;
            this.TextIndex = 0;
            this.TextLocation = new Vector2(20, 550);
            this.ButtonLag = 0;
            
            List<String> testText = new List<string>();
            testText.Add("Hello");
            testText.Add("Test");
            testText.Add("Bye");
            this.DrawText(testText);
        }

        public void Draw()
        {
            this.Batch.Begin();

            this.DrawStringOnScreen(this.TextLocation);

            this.Batch.End();
        }

        public void Update(MouseState mState, KeyboardState kState)
        {
            this.UpdateText(mState, kState);
        }

        public void DrawText(List<String> text)
        {
            this.CurrentText = text;
            this.TextIndex = 0;
        }

        public void UpdateText(MouseState mState, KeyboardState kState)
        {
            if (this.ButtonLag > 0)
            {
                this.ButtonLag--;
            }
            else 
            {
                if (mState.LeftButton == ButtonState.Pressed || kState.IsKeyDown(Keys.Enter))
                {
                    this.TextIndex++;
                    this.ButtonLag = 20;
                    if (this.TextIndex >= this.CurrentText.Count)
                    {
                        this.CurrentText = null;
                        this.TextIndex = 0;
                    }
                }
            }
        }

        public void DrawStringOnScreen(Vector2 location)
        {
            if (this.CurrentText != null)
            {
                this.Batch.DrawString(TextFont, this.CurrentText[this.TextIndex], location, Color.Black);
            }
        }
    }
}
