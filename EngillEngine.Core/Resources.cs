using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace EngillEngine.Core
{
    public class Resources
    {
		/// <summary>
        /// The instance.
        /// </summary>
		public static Resources instance;

        /// <summary>
        /// Initializes the resources.
        /// </summary>
        /// <param name="contentManager">Content manager.</param>
        /// <param name="graphicsDeviceManager">Graphics device manager.</param>
        /// <param name="gameWindow">Game window.</param>
		public static void InitializeResources(ContentManager contentManager, GraphicsDeviceManager graphicsDeviceManager, GameWindow gameWindow)
		{
			
		}

        /// <summary>
        /// Gets the instance.
        /// </summary>
        /// <value>The instance.</value>
		public static Resources GetInstance
		{
			get
			{
				return instance;
			}
		}

        /// <summary>
        /// Gets the content manager.
        /// </summary>
        /// <value>The content manager.</value>
		public static ContentManager ContentManager
		{
			get
			{
				return instance.contentManager;
			}
		}

        /// <summary>
        /// Gets the graphics device manager.
        /// </summary>
        /// <value>The graphics device manager.</value>
		public static GraphicsDeviceManager GraphicsDeviceManager
		{
			get
			{
				return instance.graphicsDeviceManager;
			}
		}

        /// <summary>
        /// Gets the graphics device.
        /// </summary>
        /// <value>The graphics device.</value>
		public static GraphicsDevice GraphicsDevice 
		{
			get
			{
				return instance.graphicsDeviceManager.GraphicsDevice;
			}
		}
                
		private ContentManager contentManager;
		private GraphicsDeviceManager graphicsDeviceManager;

		public Resources(ContentManager contentManager, GraphicsDeviceManager graphicsDeviceManager, GameWindow gameWindow)
        {
			this.contentManager = contentManager;
			this.graphicsDeviceManager = graphicsDeviceManager;
        }
    }
}
