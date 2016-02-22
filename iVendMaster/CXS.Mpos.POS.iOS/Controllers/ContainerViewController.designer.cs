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
	[Register ("ContainerViewController")]
	partial class ContainerViewController
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIView MainContainerView { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIView MenuContainerView { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		NSLayoutConstraint MenuLeftMargin { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		NSLayoutConstraint MenuRightMargin { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (MainContainerView != null) {
				MainContainerView.Dispose ();
				MainContainerView = null;
			}
			if (MenuContainerView != null) {
				MenuContainerView.Dispose ();
				MenuContainerView = null;
			}
			if (MenuLeftMargin != null) {
				MenuLeftMargin.Dispose ();
				MenuLeftMargin = null;
			}
			if (MenuRightMargin != null) {
				MenuRightMargin.Dispose ();
				MenuRightMargin = null;
			}
		}
	}
}
