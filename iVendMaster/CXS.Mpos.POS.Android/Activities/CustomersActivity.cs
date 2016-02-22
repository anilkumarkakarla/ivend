
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
using SupportToolbar = Android.Support.V7.Widget.Toolbar;
using LayoutParams = Android.Widget.LinearLayout.LayoutParams;
using ItemClickEventArgs = Android.Widget.AdapterView.ItemClickEventArgs;
using Android.Support.V7.App;

namespace CXS.Mpos.POS.Android
{
	[Activity (Label = "@string/CustomersItem", Theme = "@style/CitiXsysMainTheme")]			
	public class CustomersActivity : AppCompatActivity
	{
		private SupportToolbar Toolbar;
		private ListView CustomerListView;
		private LinearLayout SideIndexBar;
		private Dictionary<string, List<string>> Customers;

		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);
			SetContentView (Resource.Layout.customers_activity);

			this.CustomerListView = FindViewById<ListView> (Resource.Id.customer_list);
			this.SideIndexBar = FindViewById<LinearLayout> (Resource.Id.side_index_bar);
			this.Toolbar = FindViewById <SupportToolbar> (Resource.Id.toolbar);
			SetSupportActionBar (this.Toolbar);
			SupportActionBar.SetDisplayHomeAsUpEnabled (true);

			List<string> customers = new List<string> () { 
				"aaron Wood",
				"Barry D",
				"Vsevolod Borisov",
				"Artem Kalachev",
				"Bill Good",
				"Andrey Filyakov",
				"Vyacheslav Kormushkin",
				"adam Ramirez",
				"Alexandra Lukyanchikova",
				"Semen Churyakov",
				"Alan Simons",
				"Igor Karpunin",
				"Berry G"
			};

			this.Customers = (new CustomersViewModel (customers)).Customers;

			this.CustomerListView.Adapter = new CustomerListAdapter (this, this.Customers);
			this.CustomerListView.ChoiceMode = global::Android.Widget.ChoiceMode.Single;
			this.CustomerListView.ItemClick += (object sender, ItemClickEventArgs e) => {
				Intent intent = new Intent (this, typeof(CustomerDetailsActivity));
				intent.SetFlags (ActivityFlags.ClearTask);
				StartActivity (intent);
			};

			this.FillSideIndexBar ();
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

		private void FillSideIndexBar ()
		{
			List<string> firstLetters = new List<string> (this.Customers.Keys);
			foreach (string letter in firstLetters) {
				TextView textView = new TextView (this);
				textView.Text = letter;
				LayoutParams layoutParams = new LayoutParams (LayoutParams.WrapContent, LayoutParams.MatchParent);
				layoutParams.Weight = 1;
				textView.LayoutParameters = layoutParams;
				this.SideIndexBar.AddView (textView);
			}
		}
	}
}

