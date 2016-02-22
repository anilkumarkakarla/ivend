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
	[Register ("ProductTableViewCell")]
	partial class ProductTableViewCell
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel CountLabel { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel ProductIdLabel { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel TitleLabel { get; set; }

		[Action ("AddButtonClicked:")]
		[GeneratedCode ("iOS Designer", "1.0")]
		partial void AddButtonClicked (UIButton sender);

		void ReleaseDesignerOutlets ()
		{
			if (CountLabel != null) {
				CountLabel.Dispose ();
				CountLabel = null;
			}
			if (ProductIdLabel != null) {
				ProductIdLabel.Dispose ();
				ProductIdLabel = null;
			}
			if (TitleLabel != null) {
				TitleLabel.Dispose ();
				TitleLabel = null;
			}
		}
	}
}
