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
	[Register ("LandingViewController")]
	partial class LandingViewController
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UICollectionView CollectionView { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel SaleTransactionLabel { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UISwitch SaleTransactionSwitch { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (CollectionView != null) {
				CollectionView.Dispose ();
				CollectionView = null;
			}
			if (SaleTransactionLabel != null) {
				SaleTransactionLabel.Dispose ();
				SaleTransactionLabel = null;
			}
			if (SaleTransactionSwitch != null) {
				SaleTransactionSwitch.Dispose ();
				SaleTransactionSwitch = null;
			}
		}
	}
}
