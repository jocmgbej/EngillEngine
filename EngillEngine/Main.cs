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
			//graphicsDeviceManager = new GraphicsDeviceManager(this);
			Resources.InitializeResources(Content, new GraphicsDeviceManager(this), new Window(Window));            
        }

        protected override void Initialize()
        {         
			Resources.Window.OnWindowResize += Window_OnWindowResize;
			Resources.Window.OnWindowStateChange += Window_OnWindowStateChange;
            base.Initialize();
        }

		void Window_OnWindowResize(Point size)
        {
			Debug.WriteLine(size.ToString());
        }

		void Window_OnWindowStateChange(WindowStates newState)
		{
			Debug.WriteLine(newState.ToString());
		}


        protected override void LoadContent()
        {              

		}

        protected override void Update(GameTime gameTime)
        {
			KeyboardState state = Keyboard.GetState();
            
			if (state.IsKeyDown(Keys.A))
				Resources.Window.State = WindowStates.WINDOWED;
			else if (state.IsKeyDown(Keys.S))
				Resources.Window.State = WindowStates.BORDERLESS;
			else if (state.IsKeyDown(Keys.D))
				Resources.Window.State = WindowStates.FULLSCREEN;

			Resources.GetInstance.Update();
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
