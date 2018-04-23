using System;
using Microsoft.Xna.Framework;

namespace EngillEngine.Core.Util
{
	public enum WindowStates
	{
		WINDOWED,
		BORDERLESS,
        FULLSCREEN
	}

	public delegate void OnWindowResize(Point size);
	public delegate void OnWindowStateChange(WindowStates newState);

    public interface Window
    {        
		event OnWindowResize OnWindowResize
		{
			add;
			remove;
		}

		event OnWindowStateChange OnWindowStateChange
		{
			add;
			remove;
		}
        
		Point Size
		{
			get;
			set;
		}

		WindowStates States
		{
			get;
			set;
		}

		void CheckForEvents();
    }

}
