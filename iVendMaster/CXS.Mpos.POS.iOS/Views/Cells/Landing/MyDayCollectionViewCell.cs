using System;

using Foundation;
using UIKit;

namespace CXS.Mpos.POS.iOS
{
	public partial class MyDayCollectionViewCell : UICollectionViewCell
	{
		public const string REUSE_IDENTIFIER = "MyDayCell";
		private const string PERCENT = "%";
		private const string USD = "$";

		public MyDayItem Item { get; set; }

		public MyDayCollectionViewCell (IntPtr handle) : base (handle)
		{
		}

		public override void AwakeFromNib ()
		{
			base.AwakeFromNib ();

			TodaysSaleTitleLabel.Text = LocalizedStrings.GetString (LocalizedStrings.TODAYS_SALE_TITLE);
			CommissionTitleLabel.Text = LocalizedStrings.GetString (LocalizedStrings.COMMISSION_TITLE);
			SalesTargetTitleLabel.Text = LocalizedStrings.GetString (LocalizedStrings.SALES_TARGET_TITLE);
		}

		public void SetItem (MyDayItem item)
		{
			Item = item;
			TitleLabel.Text = LocalizedStrings.GetString (Item.TitleId);
			TodaysSaleLabel.Text = USD + Item.TodaysSale.ToString ();
			CommissionLabel.Text = USD + Item.Commission.ToString ();
			SalesTargetLabel.Text = Item.SalesTarget.ToString () + PERCENT;
		}
	}
}

