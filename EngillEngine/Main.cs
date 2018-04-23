﻿using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace EngillEngine.Desktop
{
    public class Main : Game
    {
		private GraphicsDeviceManager graphicsDeviceManager;

		public Main()
        {
			graphicsDeviceManager = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";            
        }

        protected override void Initialize()
        {         
            base.Initialize();
        }

        protected override void LoadContent()
        {
			
		}

        protected override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }
        
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            base.Draw(gameTime);
        }
        
        protected override void UnloadContent()
        {
			
        }        

		protected override void OnExiting(object sender, EventArgs args)
		{
			base.OnExiting(sender, args);
		}
    }
}
