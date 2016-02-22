using System;
using UIKit;
using Foundation;
using CXS.Mpos.Core;
using System.Collections.Generic;

namespace CXS.Mpos.POS.iOS
{
	public partial class LoginViewController : BaseViewController, IUITextFieldDelegate
	{
		private const string BUNDLE_VERSION_KEY = "CFBundleVersion";

		public LoginViewController () : base ("LoginViewController", null)
		{
		}

		public LoginViewController (IntPtr handle) : base (handle)
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			LoginTextField.Delegate = this;
			PasswordTextField.Delegate = this;
			SetupViewBorder (LoginTextField);
			SetupViewBorder (PasswordTextField);
			SetupViewBorder (LoginButton);
			SetupTextField (LoginTextField);
			SetupTextField (PasswordTextField);
			ErrorImageView.Hidden = true;
			ErrorLabel.Hidden = true;

			string version = NSBundle.MainBundle.ObjectForInfoDictionary (BUNDLE_VERSION_KEY).ToString ();
			VersionLabel.Text = LocalizedStrings.GetString (LocalizedStrings.APP_VERSION_PREFIX) + version;
			TitleLabel.Text = LocalizedStrings.GetString (LocalizedStrings.LOGIN_TITLE_LABEL);
			LoginTextField.Placeholder = LocalizedStrings.GetString (LocalizedStrings.LOGIN_PLACEHOLDER);
			PasswordTextField.Placeholder = LocalizedStrings.GetString (LocalizedStrings.PASSWORD_PLACEHOLDER);
			IVendLabel.Text = LocalizedStrings.GetString (LocalizedStrings.IVEND_TITLE);
			LoginButton.SetTitle (LocalizedStrings.GetString (LocalizedStrings.SIGN_IN_BUTTON), UIControlState.Normal);
		}
		
		public override void ViewWillAppear (bool animated)
		{
			base.ViewWillAppear (animated);

			NavigationController.NavigationBar.Hidden = true;
		}

		partial void PushLoginButton (UIButton sender)
		{
			DependencyConfig config = new DependencyConfig ();
			config.Define (typeof (IServiceAuthenticator), typeof (OnlineModeAuthenticator));

			OperationProcessor processor = OperationProcessor.Instance;
			processor.DepedencyContainer.Config = config;
			Parameters parameters = new Parameters ();
			parameters ["Credentials"] = new List<string> () { LoginTextField.Text, PasswordTextField.Text };
			processor.PerformOperation (typeof (LoginOperation), parameters, (Parameters result) => {
				InvokeOnMainThread (() => {
					NavigationViewController navigationController = (NavigationViewController) NavigationController;
					navigationController.PushLandingViewController ();	
				});
			}, null);
		}

		partial void PushMenuButton (UIButton sender)
		{
			ContainerViewController containerController = ((NavigationViewController)NavigationController).ContainerController;
			containerController.ShowMenu ();
		}

		#region IUITextFieldDelegate

		[Export ("textFieldShouldReturn:")]
		public Boolean ShouldReturn (UITextField textField)
		{
			textField.ResignFirstResponder ();
			return true;
		}

		#endregion
	}
}