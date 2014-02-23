using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Photosynthesis.Core;

namespace Photosynthesis
{
    public class Photosynthesis : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        SystemHandler handler;

        public Photosynthesis()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            base.Initialize();

            this.graphics.PreferredBackBufferHeight = 600;
            this.graphics.PreferredBackBufferWidth = 600;
            this.graphics.ApplyChanges();

            this.handler = new SystemHandler(this.spriteBatch, this.Content);
            this.IsMouseVisible = true;
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
        }

        protected override void UnloadContent()
        {

        }

        protected override void Update(GameTime gameTime)
        {
            this.handler.Update(Mouse.GetState(), Keyboard.GetState());

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {

            this.handler.Draw();

            base.Draw(gameTime);
        }
    }
}
