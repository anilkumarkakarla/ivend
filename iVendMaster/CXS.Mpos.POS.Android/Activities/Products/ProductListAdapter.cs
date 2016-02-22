using System;
using Android.Widget;
using Android.Views;
using Android.Content;
using System.Collections.Generic;
using Log = CXS.Mpos.Core.Log;
using System.Linq;

namespace CXS.Mpos.POS.Android
{
	public delegate void AddItemToTransactionClickAction (string item);

	public class ProductListAdapter : BaseAdapter<string>, IFilterable
	{
		private LayoutInflater LayoutInflater;
		public List<string> ProductTitles;
		public List<string> FilteredProductTitles;
		private const int PRODUCT_ROW = 0;
		private const int SECTION_HEADER = 1;
		private Filter ProductFilter;
		private AddItemToTransactionClickAction AddToTransactionAction;

		public ProductListAdapter (Context context, List<string> products, AddItemToTransactionClickAction addToTransactionAction)
		{
			this.LayoutInflater = (LayoutInflater)context.GetSystemService (Context.LayoutInflaterService);
			this.ProductTitles = products;
			this.ProductFilter = new ProductFilter (this);
			this.FilteredProductTitles = products;
			this.AddToTransactionAction = addToTransactionAction;
		}

		public override View GetView (int position, View convertView, ViewGroup parent)
		{
			View view = convertView;
			ProductViewHolder viewHolder;

			if (view == null) {
				view = this.LayoutInflater.Inflate (Resource.Layout.product_list_item, null);
				viewHolder = new ProductViewHolder ();
				viewHolder.Name = view.FindViewById <TextView> (Resource.Id.productName);
				viewHolder.AddToTransactionButtton = view.FindViewById <ImageView> (Resource.Id.addToTransactionButton);
				viewHolder.AddToTransactionButtton.Click += delegate {
					this.AddToTransactionAction (this.FilteredProductTitles [position]);
				};
				view.Tag = viewHolder;
			} else {
				viewHolder = (ProductViewHolder)view.Tag;
			}

			viewHolder.Name.Text = this.FilteredProductTitles [position];

			return view;
		}

		public override string this [int position] {
			get { return this.ProductTitles [position]; }
		}

		public override long GetItemId (int position)
		{
			return position;
		}

		public override int Count {
			get {
				return this.FilteredProductTitles != null ? this.FilteredProductTitles.Count : 0;
			}
		}

		public Filter Filter {
			get {
				return this.ProductFilter;
			}
		}
	}

	class ProductFilter : Filter
	{
		readonly ProductListAdapter Adapter;

		public ProductFilter (ProductListAdapter adapter)
		{
			this.Adapter = adapter;
		}

		protected override FilterResults PerformFiltering (Java.Lang.ICharSequence constraint)
		{
			FilterResults results = new FilterResults ();

			if (!String.IsNullOrEmpty (constraint.ToString ())) {
				this.Adapter.FilteredProductTitles = new List<string> ();

				foreach (string item in this.Adapter.ProductTitles) {
					if (item.ToLower ().Contains (constraint.ToString ().ToLower ())) {
						this.Adapter.FilteredProductTitles.Add (item);
					}
				}

				Java.Lang.Object[] matchObjects;
				matchObjects = new Java.Lang.Object[this.Adapter.FilteredProductTitles.Count];
				for (int i = 0; i < this.Adapter.FilteredProductTitles.Count; i++) {
					matchObjects [i] = new Java.Lang.String (this.Adapter.FilteredProductTitles [i]);
				}

				results.Values = matchObjects;
				results.Count = this.Adapter.FilteredProductTitles.Count;

			} else {
				this.Adapter.FilteredProductTitles = this.Adapter.ProductTitles;
			}

			return results;
		}

		protected override void PublishResults (Java.Lang.ICharSequence constraint, FilterResults results)
		{
			this.Adapter.NotifyDataSetChanged ();
		}
	}
}

