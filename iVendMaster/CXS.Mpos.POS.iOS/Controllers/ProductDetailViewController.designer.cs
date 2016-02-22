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
	[Register ("ProductDetailViewController")]
	partial class ProductDetailViewController
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		NSLayoutConstraint CloseButton { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITableView TableView { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel TitleLabel { get; set; }

		[Action ("CloseButtonClicked:")]
		[GeneratedCode ("iOS Designer", "1.0")]
		partial void CloseButtonClicked (UIButton sender);

		void ReleaseDesignerOutlets ()
		{
			if (CloseButton != null) {
				CloseButton.Dispose ();
				CloseButton = null;
			}
			if (TableView != null) {
				TableView.Dispose ();
				TableView = null;
			}
			if (TitleLabel != null) {
				TitleLabel.Dispose ();
				TitleLabel = null;
			}
		}
	}
}
