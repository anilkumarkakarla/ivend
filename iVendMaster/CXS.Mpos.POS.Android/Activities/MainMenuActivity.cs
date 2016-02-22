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
using LayoutParams = Android.Widget.LinearLayout.LayoutParams;
using Android.Util;

namespace CXS.Mpos.POS.Android
{
	[Activity (Label = "@string/LandingScreenTitle", Theme = "@style/CitiXsysMainTheme")]			
	public class MainMenuActivity : BaseActivity, ILandingViewDelegate
	{
		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);
			SetContentView (Resource.Layout.main_menu_activity);
			this.ConfigureDrawer ();

			this.CreateLandingItemsFromList (new LandingViewModel (this).LandingItems);
		}

		private void CreateLandingItemsFromList (List<List<LandingItem>> landingItems)
		{
			LinearLayout rootLandingLayout = FindViewById<LinearLayout> (Resource.Id.LandingLayout);

			foreach (List<LandingItem> landingItemsPerLine in landingItems) {
				LinearLayout linearLayout = new LinearLayout (this);
				LayoutParams layoutParams = new LayoutParams (LayoutParams.MatchParent, LayoutParams.WrapContent);
				layoutParams.Weight = 1;
				linearLayout.LayoutParameters = layoutParams;
				linearLayout.Orientation = Orientation.Horizontal;

				if (landingItemsPerLine.Count == 1 && landingItemsPerLine [0] is MyDayItem) {
					linearLayout.AddView (this.LayoutInflater.Inflate (Resource.Layout.my_day_item, null));
				} else if (landingItemsPerLine.Count == 1 && landingItemsPerLine [0] is TransactionsItem) {
					linearLayout.AddView (this.LayoutInflater.Inflate (Resource.Layout.transactions_item, null));
				} else {
					this.CreateLandingItemsForRow (linearLayout, landingItemsPerLine);
				}

				rootLandingLayout.AddView (linearLayout);
			}
		}

		private void CreateLandingItemsForRow (LinearLayout linearLayout, List<LandingItem> landingItemsPerLine)
		{
			foreach (LandingItem item in landingItemsPerLine) {
				View view = this.LayoutInflater.Inflate (Resource.Layout.landing_item, null);
				view.LayoutParameters = new LayoutParams (LayoutParams.MatchParent, LayoutParams.MatchParent, 1.0f);
				view.FindViewById<TextView> (Resource.Id.LandingItemTitle).Text = GetStringResourceByName (item.TitleId);
				if (item.Action != null) {
					view.Click += delegate {
						item.Action ();
					};
				}
				linearLayout.AddView (view);
			}
		}

		private string GetStringResourceByName (string name)
		{
			return GetString (Resources.GetIdentifier (name, "string", PackageName));
		}

		public void SaleItemAction ()
		{
			Intent intent = new Intent (this, typeof(SaleActivity));
			intent.SetFlags (ActivityFlags.ClearTask);
			StartActivity (intent);
		}

		public void CustomersItemAction ()
		{
			Intent intent = new Intent (this, typeof(CustomersActivity));
			intent.SetFlags (ActivityFlags.ClearTask);
			StartActivity (intent);
		}
	}
}