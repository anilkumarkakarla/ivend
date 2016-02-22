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
	[Register ("MyDayCollectionViewCell")]
	partial class MyDayCollectionViewCell
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel CommissionLabel { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel CommissionTitleLabel { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel SalesTargetLabel { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel SalesTargetTitleLabel { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel TitleLabel { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel TodaysSaleLabel { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel TodaysSaleTitleLabel { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (CommissionLabel != null) {
				CommissionLabel.Dispose ();
				CommissionLabel = null;
			}
			if (CommissionTitleLabel != null) {
				CommissionTitleLabel.Dispose ();
				CommissionTitleLabel = null;
			}
			if (SalesTargetLabel != null) {
				SalesTargetLabel.Dispose ();
				SalesTargetLabel = null;
			}
			if (SalesTargetTitleLabel != null) {
				SalesTargetTitleLabel.Dispose ();
				SalesTargetTitleLabel = null;
			}
			if (TitleLabel != null) {
				TitleLabel.Dispose ();
				TitleLabel = null;
			}
			if (TodaysSaleLabel != null) {
				TodaysSaleLabel.Dispose ();
				TodaysSaleLabel = null;
			}
			if (TodaysSaleTitleLabel != null) {
				TodaysSaleTitleLabel.Dispose ();
				TodaysSaleTitleLabel = null;
			}
		}
	}
}
