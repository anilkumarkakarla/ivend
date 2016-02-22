
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
using Android.Support.V7.App;
using SupportToolbar = Android.Support.V7.Widget.Toolbar;

namespace CXS.Mpos.POS.Android
{
	[Activity (Label = "@string/CustomerDetailsTitle", Theme = "@style/CitiXsysMainTheme")]		
	public class CustomerDetailsActivity : AppCompatActivity
	{
		private SupportToolbar Toolbar;

		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);
			SetContentView (Resource.Layout.customer_details_activity);

			this.Toolbar = FindViewById <SupportToolbar> (Resource.Id.toolbar);
			SetSupportActionBar (this.Toolbar);
			SupportActionBar.SetDisplayHomeAsUpEnabled (true);
		}

		public override bool OnOptionsItemSelected (IMenuItem item)
		{
			if (item.ItemId == global::Android.Resource.Id.Home) {
				Finish ();
				return true;
			} else {
				return base.OnOptionsItemSelected (item);
			}
		}
	}
}

