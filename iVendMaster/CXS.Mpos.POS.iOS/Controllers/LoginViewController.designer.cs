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
	[Register ("LoginViewController")]
	partial class LoginViewController
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIImageView ErrorImageView { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel ErrorLabel { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel IVendLabel { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton LoginButton { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITextField LoginTextField { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton MenuButton { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITextField PasswordTextField { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel TitleLabel { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel VersionLabel { get; set; }

		[Action ("PushLoginButton:")]
		[GeneratedCode ("iOS Designer", "1.0")]
		partial void PushLoginButton (UIButton sender);

		[Action ("PushMenuButton:")]
		[GeneratedCode ("iOS Designer", "1.0")]
		partial void PushMenuButton (UIButton sender);

		void ReleaseDesignerOutlets ()
		{
			if (ErrorImageView != null) {
				ErrorImageView.Dispose ();
				ErrorImageView = null;
			}
			if (ErrorLabel != null) {
				ErrorLabel.Dispose ();
				ErrorLabel = null;
			}
			if (IVendLabel != null) {
				IVendLabel.Dispose ();
				IVendLabel = null;
			}
			if (LoginButton != null) {
				LoginButton.Dispose ();
				LoginButton = null;
			}
			if (LoginTextField != null) {
				LoginTextField.Dispose ();
				LoginTextField = null;
			}
			if (MenuButton != null) {
				MenuButton.Dispose ();
				MenuButton = null;
			}
			if (PasswordTextField != null) {
				PasswordTextField.Dispose ();
				PasswordTextField = null;
			}
			if (TitleLabel != null) {
				TitleLabel.Dispose ();
				TitleLabel = null;
			}
			if (VersionLabel != null) {
				VersionLabel.Dispose ();
				VersionLabel = null;
			}
		}
	}
}
