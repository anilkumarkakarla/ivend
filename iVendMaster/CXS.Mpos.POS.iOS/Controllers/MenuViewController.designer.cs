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
	[Register ("MenuViewController")]
	partial class MenuViewController
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITableView TableView { get; set; }

		[Action ("CloseMenu:")]
		[GeneratedCode ("iOS Designer", "1.0")]
		partial void CloseMenu (UIButton sender);

		void ReleaseDesignerOutlets ()
		{
			if (TableView != null) {
				TableView.Dispose ();
				TableView = null;
			}
		}
	}
}
