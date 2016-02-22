using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content;

using CXS.Mpos.Core;
using Android.Content.PM;
using Android.Views;
using System.Collections.Generic;

namespace CXS.Mpos.POS.Android
{
	[Activity (MainLauncher = true, Icon = "@mipmap/icon", Theme = "@style/CitiXsysLoginTheme")]
	public class LoginActivity : BaseActivity
	{
		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);
			SetContentView (Resource.Layout.login_activity);
			this.IsUserLoggedIn = false;
			this.ConfigureDrawer ();

			LogStorage.Initialize (new LogConfiguration ());

			Button button = FindViewById<Button> (Resource.Id.LoginButton);
			TextView versionLabel = FindViewById<TextView> (Resource.Id.VersionName);
			versionLabel.Text = this.GetAppVersion ();
			button.Click += delegate {
				Intent intent = new Intent (this, typeof(MainMenuActivity));
				intent.SetFlags (ActivityFlags.ClearTask | ActivityFlags.NewTask);
				StartActivity (intent);
			};
		}

		private string GetAppVersion ()
		{
			return this.PackageManager.GetPackageInfo (this.PackageName, 0).VersionName;
		}
	}
}


