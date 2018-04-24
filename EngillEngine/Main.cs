using System;
using EngillEngine.Core;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using EngillEngine.Core.Util;
using System.Diagnostics;

namespace EngillEngine.Desktop
{
    public class Main : Game
    {
		//private GraphicsDeviceManager graphicsDeviceManager;

		public Main()
        {
			Resources.InitializeResources(Content, new GraphicsDeviceManager(this), new Window(Window));            
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
			Resources.GetInstance.Update();
			base.Update(gameTime);
        }
        
        protected override void Draw(GameTime gameTime)
        {
			Resources.GetInstance.Render();
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
