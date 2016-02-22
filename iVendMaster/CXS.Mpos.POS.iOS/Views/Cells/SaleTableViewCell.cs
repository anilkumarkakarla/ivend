using System;

using Foundation;
using UIKit;

namespace CXS.Mpos.POS.iOS
{
	public partial class SaleTableViewCell : UITableViewCell
	{
		public const string REUSE_IDENTIFIER = "SaleCell";

		public SaleTableViewCell (IntPtr handle) : base (handle)
		{
		}

		public void SetProduct (string product)
		{
			TitleLabel.Text = product;
			ProductIdLabel.Text = "000";
			QuantityLabel.Text = "1";
			PriceLabel.Text = LocalizedStrings.GetString (LocalizedStrings.PRICE_LABEL) + "$ 10.00";
			DiscountLabel.Text = LocalizedStrings.GetString (LocalizedStrings.DISCOUNT_LABEL) + "$ 0.00";
			TotalPriceLabel.Text = LocalizedStrings.GetString (LocalizedStrings.TOTAL_PRICE_LABEL) + "$ 10.00";
		}
	}
}
