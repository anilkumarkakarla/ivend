
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace CXS.Mpos.POS.Android
{
	[Activity (Label = "@string/SettingsCellTitle", Theme = "@style/CitiXsysMainTheme")]			
	public class SettingsActivity : BaseActivity
	{
		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);
			SetContentView (Resource.Layout.settings_activity);
			this.IsUserLoggedIn = false;
			this.ConfigureDrawer ();
		}
	}
}

