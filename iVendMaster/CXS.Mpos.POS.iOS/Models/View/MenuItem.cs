using System;

namespace CXS.Mpos.POS.iOS
{
	public class MenuItem
	{
		public string Title { get; set; }
		public string IconName { get; set; }
		public Action Action { get; set; }

		public MenuItem (string title, string iconName, Action action)
		{
			Title = title;
			IconName = iconName;
			Action = action;
		}
	}
}

