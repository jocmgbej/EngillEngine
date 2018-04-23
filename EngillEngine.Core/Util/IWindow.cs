using System;
using Microsoft.Xna.Framework;

namespace EngillEngine.Core.Util
{
	/// <summary>
    /// Window states.
    /// </summary>
	public enum WindowStates
	{
		WINDOWED,
		BORDERLESS,
        FULLSCREEN
	}

    /// <summary>
    /// On window resize.
    /// </summary>
	public delegate void OnWindowResize(Point size);

    /// <summary>
    /// On window state change.
    /// </summary>
	public delegate void OnWindowStateChange(WindowStates newState);

    /// <summary>
    /// Window.
    /// </summary>
    public interface IWindow
    {
		/// <summary>
        /// Occurs when window resize.
        /// </summary>
		event OnWindowResize OnWindowResize;

        /// <summary>
        /// Occurs when window state change.
        /// </summary>
		event OnWindowStateChange OnWindowStateChange;
        
        /// <summary>
        /// Gets or sets the size.
        /// </summary>
        /// <value>The size.</value>
		Point Size
		{
			get;
			set;
		}

        /// <summary>
        /// Gets or sets the state.
        /// </summary>
        /// <value>The state.</value>
		WindowStates State
		{
			get;
			set;
		}

        /// <summary>
        /// Checks for events.
        /// </summary>
		void CheckForEvents();
    }

}
