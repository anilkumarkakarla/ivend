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
	[Register ("CustomerDetailViewController")]
	partial class CustomerDetailViewController
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIImageView AvatarImageView { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITextField CustomerIdTextField { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UISegmentedControl DetailTypeSegmentedControl { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITextField FirstNameTextField { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITextField LastNameTextField { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITableView TableView { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (AvatarImageView != null) {
				AvatarImageView.Dispose ();
				AvatarImageView = null;
			}
			if (CustomerIdTextField != null) {
				CustomerIdTextField.Dispose ();
				CustomerIdTextField = null;
			}
			if (DetailTypeSegmentedControl != null) {
				DetailTypeSegmentedControl.Dispose ();
				DetailTypeSegmentedControl = null;
			}
			if (FirstNameTextField != null) {
				FirstNameTextField.Dispose ();
				FirstNameTextField = null;
			}
			if (LastNameTextField != null) {
				LastNameTextField.Dispose ();
				LastNameTextField = null;
			}
			if (TableView != null) {
				TableView.Dispose ();
				TableView = null;
			}
		}
	}
}
