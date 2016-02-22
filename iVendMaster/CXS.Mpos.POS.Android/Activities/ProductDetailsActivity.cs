
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
using Android.Support.V7.App;
using LayoutParams = Android.Widget.LinearLayout.LayoutParams;

namespace CXS.Mpos.POS.Android
{
	[Activity (Label = "@string/ProductDetailsTitle", Theme = "@style/CitiXsysMainTheme")]			
	public class ProductDetailsActivity : AppCompatActivity
	{
		private SupportToolbar Toolbar;
		private LinearLayout ProductDetailList;
		private Dictionary<string, string> ProductDetails = new Dictionary<string, string> {
			{ "ItemCodeTitle", "100103" },
			{ "DescriptionTitle", "" },
			{ "UOMTitle", "1 Pcs" },
			{ "QuantityTitle", "1" },
			{ "PriceTitle", "$24.95" },
			{ "TaxCodeTitle", "Exempt" },
			{ "TaxAmountTitle", "$0.00" },
			{ "ManualDiscountTitle", "$0.00%" },
			{ "BatchSerialTitle", "Batch" },
			{ "SalesPersonTitle", "" },
			{ "SurchargeTitle", "$0.00" }
		};

		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);
			SetContentView (Resource.Layout.product_details_activity);

			this.Toolbar = FindViewById <SupportToolbar> (Resource.Id.toolbar);
			SetSupportActionBar (this.Toolbar);
			SupportActionBar.SetDisplayHomeAsUpEnabled (true);

			this.ProductDetailList = FindViewById<LinearLayout> (Resource.Id.product_detail_list);
			FindViewById <TextView> (Resource.Id.productNameTitle).Text = this.Intent.Extras.GetString ("ProductTitle");
			this.ProductDetails ["DescriptionTitle"] = this.Intent.Extras.GetString ("ProductTitle");
			this.GenerateProductDetails ();
		}

		private void GenerateProductDetails ()
		{
			foreach (KeyValuePair<string, string> detail in this.ProductDetails) {
				LinearLayout detailLayout = (LinearLayout)this.LayoutInflater.Inflate (Resource.Layout.product_details_item, null);
				detailLayout.FindViewById <TextView> (Resource.Id.product_detail_name).Text = this.GetStringResourceByName (detail.Key);
				detailLayout.FindViewById <TextView> (Resource.Id.product_detail_value).Text = detail.Value;
				this.ProductDetailList.AddView (detailLayout);
			}
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

		private string GetStringResourceByName (string name)
		{
			return GetString (Resources.GetIdentifier (name, "string", PackageName));
		}
	}
}

