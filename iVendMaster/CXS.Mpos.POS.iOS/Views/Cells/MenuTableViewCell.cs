using System;

using Foundation;
using UIKit;

namespace CXS.Mpos.POS.iOS
{
	public partial class MenuTableViewCell : UITableViewCell
	{
		public MenuItem Item { get; set; }

		public MenuTableViewCell (IntPtr handle) : base (handle)
		{
		}

		public void SetItem (MenuItem item)
		{
			Item = item;
			if (Item.IconName != null) {
				IconImageView.Image = new UIImage (Item.IconName);	
			}
			TitleLabel.Text = Item.Title;
		}
	}
}
