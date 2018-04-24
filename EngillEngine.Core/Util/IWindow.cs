///@Author  :       Nordel / Chuk95
///@Date    :       2018-04-22
///@Purpose :       
/// Every window should implement this interface this way every window wether its a editor window
/// or game window should be managed the same way

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
