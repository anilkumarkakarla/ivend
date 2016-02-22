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
	[Register ("TransactionsCollectionViewCell")]
	partial class TransactionsCollectionViewCell
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel CompletedLabel { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel CompletedTitleLabel { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel PendingLabel { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel PendingTitleLabel { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel TitleLabel { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (CompletedLabel != null) {
				CompletedLabel.Dispose ();
				CompletedLabel = null;
			}
			if (CompletedTitleLabel != null) {
				CompletedTitleLabel.Dispose ();
				CompletedTitleLabel = null;
			}
			if (PendingLabel != null) {
				PendingLabel.Dispose ();
				PendingLabel = null;
			}
			if (PendingTitleLabel != null) {
				PendingTitleLabel.Dispose ();
				PendingTitleLabel = null;
			}
			if (TitleLabel != null) {
				TitleLabel.Dispose ();
				TitleLabel = null;
			}
		}
	}
}
