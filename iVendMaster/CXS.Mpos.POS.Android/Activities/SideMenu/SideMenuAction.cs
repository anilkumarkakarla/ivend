using System;
using Android.Content;
using System.Collections.Generic;

namespace CXS.Mpos.POS.Android
{
	public enum SideMenuItemIds
	{
		SYNCHRONIZE = 0,
		SETTINGS,
		HOME,
		SUPPORT,
		HELP,
		SIGN_OUT
	}

	public enum SideMenuActionType
	{
		START_ACTIVITY = 0,
		EXECUTE_ACTION,
		NO_ACTION
	}

	public delegate void SideMenuClickAction ();

	public class SideMenuAction
	{
		public SideMenuItemIds Id { get; set; }

		public string Title { get; set; }

		public List<SideMenuActionType> ActionTypes { get; set; }

		public Intent Intent { get; set; }

		public SideMenuClickAction PerformAction { get; set; }
	}
}

