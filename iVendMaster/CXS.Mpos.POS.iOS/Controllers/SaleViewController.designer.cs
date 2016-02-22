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
	[Register ("SaleViewController")]
	partial class SaleViewController
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel CustomerLabel { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel DiscountLabel { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel DiscountTitleLabel { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton PauseButton { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton ScanButton { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIView SearchBarContainerView { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITableView TableView { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel TaxLabel { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel TaxTitleLabel { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel TotalLabel { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel TotalTitleLabel { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton TrashButton { get; set; }

		[Action ("ProductsButtonClicked:")]
		[GeneratedCode ("iOS Designer", "1.0")]
		partial void ProductsButtonClicked (UIButton sender);

		void ReleaseDesignerOutlets ()
		{
			if (CustomerLabel != null) {
				CustomerLabel.Dispose ();
				CustomerLabel = null;
			}
			if (DiscountLabel != null) {
				DiscountLabel.Dispose ();
				DiscountLabel = null;
			}
			if (DiscountTitleLabel != null) {
				DiscountTitleLabel.Dispose ();
				DiscountTitleLabel = null;
			}
			if (PauseButton != null) {
				PauseButton.Dispose ();
				PauseButton = null;
			}
			if (ScanButton != null) {
				ScanButton.Dispose ();
				ScanButton = null;
			}
			if (SearchBarContainerView != null) {
				SearchBarContainerView.Dispose ();
				SearchBarContainerView = null;
			}
			if (TableView != null) {
				TableView.Dispose ();
				TableView = null;
			}
			if (TaxLabel != null) {
				TaxLabel.Dispose ();
				TaxLabel = null;
			}
			if (TaxTitleLabel != null) {
				TaxTitleLabel.Dispose ();
				TaxTitleLabel = null;
			}
			if (TotalLabel != null) {
				TotalLabel.Dispose ();
				TotalLabel = null;
			}
			if (TotalTitleLabel != null) {
				TotalTitleLabel.Dispose ();
				TotalTitleLabel = null;
			}
			if (TrashButton != null) {
				TrashButton.Dispose ();
				TrashButton = null;
			}
		}
	}
}
