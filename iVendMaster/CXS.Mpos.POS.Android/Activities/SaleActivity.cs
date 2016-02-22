
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
using ItemClickEventArgs = Android.Widget.AdapterView.ItemClickEventArgs;
using AdapterContextMenuInfo = Android.Widget.AdapterView.AdapterContextMenuInfo;

namespace CXS.Mpos.POS.Android
{
	[Activity (Label = "@string/SaleItem", Theme = "@style/CitiXsysMainTheme")]			
	public class SaleActivity : AppCompatActivity, SearchView.IOnQueryTextListener, View.IOnFocusChangeListener
	{
		private SupportToolbar Toolbar;
		private ListView ProductListView;
		private ListView SaleItemListView;
		private LinearLayout ProductListLayout;
		private SearchView ProductSearchTextField;

		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);
			SetContentView (Resource.Layout.sale_activity);

			this.Toolbar = FindViewById <SupportToolbar> (Resource.Id.toolbar);
			SetSupportActionBar (this.Toolbar);
			SupportActionBar.SetDisplayHomeAsUpEnabled (true);

			this.InitializeProductCatalog ();
			this.InitializeSaleItemList ();
		}

		private void InitializeProductCatalog()
		{
			this.ProductSearchTextField = FindViewById <SearchView> (Resource.Id.searchTextField);
			this.ProductSearchTextField.SetOnQueryTextListener (this);
			this.ProductSearchTextField.SetOnQueryTextFocusChangeListener (this);

			this.ProductListView = FindViewById<ListView> (Resource.Id.product_list);
			this.ProductListLayout = FindViewById <LinearLayout> (Resource.Id.product_list_layout);
			this.ProductListView.EmptyView = this.ProductListLayout.FindViewById<TextView> (global::Android.Resource.Id.Empty);

			List<string> products = new List<string> () { 
				"Men's Solid Polo",
				"Men's Ralph Lauren Suit",
				"Women's Suit",
				"Men's Levi's Jeans",
				"Men's Solid Polo",
				"Men's Ralph Lauren Suit",
				"Women's Polo"
			};

			this.ProductListView.Adapter = new ProductListAdapter (this, products, this.AddToTransactionItem);
			this.ProductListView.ChoiceMode = global::Android.Widget.ChoiceMode.Single;

			this.ProductListView.ItemClick += (object sender, ItemClickEventArgs e) => {
				Intent intent = new Intent (this, typeof(ProductDetailsActivity));
				Bundle bundle = new Bundle ();
				bundle.PutString ("ProductTitle", products [e.Position]);
				intent.PutExtras (bundle);
				intent.SetFlags (ActivityFlags.ClearTask);
				StartActivity (intent);
			};
		}

		private void AddToTransactionItem (string item)
		{
			((SaleItemListAdapter)this.SaleItemListView.Adapter).AddSaleItem (item);
		}

		private void InitializeSaleItemList()
		{
			this.SaleItemListView = FindViewById<ListView> (Resource.Id.sale_item_list);
			LinearLayout saleItemListLayout = FindViewById<LinearLayout> (Resource.Id.sale_item_list_layout);
			this.SaleItemListView.EmptyView = saleItemListLayout.FindViewById<TextView> (global::Android.Resource.Id.Empty);
			this.SaleItemListView.Adapter = new SaleItemListAdapter (this);
			RegisterForContextMenu (this.SaleItemListView);
		}

		public override void OnCreateContextMenu (IContextMenu menu, View v, IContextMenuContextMenuInfo menuInfo)
		{
			base.OnCreateContextMenu (menu, v, menuInfo);
			this.MenuInflater.Inflate (Resource.Menu.sale_item_details, menu);
		}

		public override bool OnContextItemSelected (IMenuItem item)
		{
			AdapterContextMenuInfo info = (AdapterContextMenuInfo) item.MenuInfo;

			switch (item.ItemId) {
			case Resource.Id.remove_sale_item:
				((SaleItemListAdapter)this.SaleItemListView.Adapter).RemoveSaleItem (info.Position);
				return true;
			default:
				return base.OnContextItemSelected (item);
			}
		}

		public override bool OnPrepareOptionsMenu (IMenu menu)
		{
			MenuInflater.Inflate (Resource.Menu.sale, menu);
			return base.OnPrepareOptionsMenu (menu);
		}

		public override bool OnOptionsItemSelected (IMenuItem item)
		{
			switch (item.ItemId) {
			case global::Android.Resource.Id.Home:
				Finish ();
				return true;
			case Resource.Id.start_sale:
				return true;
			default:
				return base.OnOptionsItemSelected (item);
			}
		}

		public void OnFocusChange (View v, bool hasFocus)
		{
			if (hasFocus) {
				this.ProductListLayout.Visibility = ViewStates.Visible;
			} else {
				this.ProductListLayout.Visibility = ViewStates.Gone;
			}
		}

		public bool OnQueryTextChange (string newText)
		{
			((ProductListAdapter)this.ProductListView.Adapter).Filter.InvokeFilter (newText);

			return true;
		}

		public bool OnQueryTextSubmit (string query)
		{
			return true;
		}
	}
}

