using System;

using Foundation;
using UIKit;

namespace CXS.Mpos.POS.iOS
{
	public partial class LandingCollectionViewCell : UICollectionViewCell
	{
		public const string REUSE_IDENTIFIER = "LandingCell";

		public LandingItem Item { get; set; }

		public LandingCollectionViewCell (IntPtr handle) : base (handle)
		{
		}

		public void SetItem (LandingItem item)
		{
			Item = item;
			TitleLabel.Text = LocalizedStrings.GetString (Item.TitleId);
			if (Item.IconName != null) {
				IconImageView.Image = new UIImage (Item.IconName);
			}
		}
	}
}
