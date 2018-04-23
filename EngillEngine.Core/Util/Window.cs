using System;
using Microsoft.Xna.Framework;
using EngillEngine.Core.Util;
using System.Diagnostics;
using Microsoft.Xna.Framework.Graphics;

namespace EngillEngine.Core.Util
{
	public class Window : IWindow
    {
		/// <summary>
        /// Occurs when on window resize.
        /// </summary>
		public event OnWindowResize OnWindowResize;

        /// <summary>
        /// Occurs when on window state change.
        /// </summary>
		public event OnWindowStateChange OnWindowStateChange;
        
        /// <summary>
        /// Gets or sets the size of the window.
        /// </summary>
        /// <value>The window size.</value>
		public Point Size
		{
			get
			{
				return new Point();
			}
			set
			{
				SetSize(value);
			}
		}

        /// <summary>
        /// Gets or sets the state of the window.
        /// </summary>
        /// <value>The window state.</value>
		public WindowStates State
		{
			get
			{
				return WindowStates.WINDOWED;
			}
			set
			{
				SetState(value);
			}
		}
        
		/// <summary>
        /// Gets or sets if the window is resizable.
        /// </summary>
        /// <value>is window resizable.</value>
		public bool Resizable
		{
			get
			{
				return gameWindow.AllowUserResizing;
			}
			set
			{
				gameWindow.AllowUserResizing = value;
			}
		}

		private GameWindow gameWindow;
		private Point currentWindowSize;
		private Point currentWindowFullscreenSize;
		private WindowStates currentWindowState;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:EngillEngine.Core.Util.Window"/> class.
        /// </summary>
        /// <param name="gameWindow">Game window.</param>
		public Window(GameWindow gameWindow)
        {
			this.gameWindow = gameWindow;
			gameWindow.AllowUserResizing = true;
			currentWindowState = WindowStates.WINDOWED;
			currentWindowSize = gameWindow.ClientBounds.Size;
			DisplayMode displayMode = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode;
			Point fullscreenSize = new Point(displayMode.Width, displayMode.Height);
			currentWindowFullscreenSize = fullscreenSize;
		}

        /// <summary>
        /// Checks for events.
        /// </summary>
		public void CheckForEvents()
		{
			Point sizeToCheck = (currentWindowState == WindowStates.FULLSCREEN)? currentWindowFullscreenSize : currentWindowSize;  
			
			if(!gameWindow.ClientBounds.Size.Equals(sizeToCheck))
				SetSize(gameWindow.ClientBounds.Size);
		}

        /// <summary>
        /// Sets the window size.
        /// </summary>
        /// <param name="newSize">New size.</param>
		private void SetSize(Point newSize)
		{
			if(currentWindowState == WindowStates.FULLSCREEN)
			{            
				Resources.GraphicsDeviceManager.IsFullScreen = true;
				Resources.GraphicsDeviceManager.PreferredBackBufferWidth = currentWindowFullscreenSize.X;
				Resources.GraphicsDeviceManager.PreferredBackBufferHeight = currentWindowFullscreenSize.Y;
			}
			else
			{
				Resources.GraphicsDeviceManager.IsFullScreen = false;
				Resources.GraphicsDeviceManager.PreferredBackBufferWidth = newSize.X;
				Resources.GraphicsDeviceManager.PreferredBackBufferHeight = newSize.Y;
				currentWindowSize = newSize;
			}

			Resources.GraphicsDeviceManager.ApplyChanges();

			OnWindowResize?.Invoke(newSize);
		}

        /// <summary>
        /// Sets the window state.
        /// </summary>
        /// <param name="newState">New state.</param>
		private void SetState(WindowStates newState)
		{
			gameWindow.IsBorderless = !(newState == WindowStates.WINDOWED);       
            currentWindowState = newState;
            
            SetSize(currentWindowSize);

			OnWindowStateChange?.Invoke(newState);

		}
    }
}
