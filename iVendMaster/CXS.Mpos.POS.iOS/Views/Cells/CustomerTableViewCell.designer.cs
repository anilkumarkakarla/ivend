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

namespace CitiXsys.Mobile.POS.iOS
{
	[Register ("CustomerTableViewCell")]
	partial class CustomerTableViewCell
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel CustomerIdLabel { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIImageView IconImageView { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel NameLabel { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (CustomerIdLabel != null) {
				CustomerIdLabel.Dispose ();
				CustomerIdLabel = null;
			}
			if (IconImageView != null) {
				IconImageView.Dispose ();
				IconImageView = null;
			}
			if (NameLabel != null) {
				NameLabel.Dispose ();
				NameLabel = null;
			}
		}
	}
}
