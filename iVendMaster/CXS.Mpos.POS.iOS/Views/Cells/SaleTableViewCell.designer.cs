// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace CXS.Mpos.POS.iOS
{
	[Register ("SaleTableViewCell")]
	partial class SaleTableViewCell
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel DiscountLabel { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIImageView IconImageView { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel PriceLabel { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel ProductIdLabel { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel QuantityLabel { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel TitleLabel { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel TotalPriceLabel { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (DiscountLabel != null) {
				DiscountLabel.Dispose ();
				DiscountLabel = null;
			}
			if (IconImageView != null) {
				IconImageView.Dispose ();
				IconImageView = null;
			}
			if (PriceLabel != null) {
				PriceLabel.Dispose ();
				PriceLabel = null;
			}
			if (ProductIdLabel != null) {
				ProductIdLabel.Dispose ();
				ProductIdLabel = null;
			}
			if (QuantityLabel != null) {
				QuantityLabel.Dispose ();
				QuantityLabel = null;
			}
			if (TitleLabel != null) {
				TitleLabel.Dispose ();
				TitleLabel = null;
			}
			if (TotalPriceLabel != null) {
				TotalPriceLabel.Dispose ();
				TotalPriceLabel = null;
			}
		}
	}
}
