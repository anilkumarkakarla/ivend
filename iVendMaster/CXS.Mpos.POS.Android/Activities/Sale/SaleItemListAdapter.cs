using System;
using Android.Widget;
using Android.Views;
using Android.Content;
using System.Collections.Generic;
using Log = CXS.Mpos.Core.Log;

namespace CXS.Mpos.POS.Android
{
	public class SaleItemListAdapter : BaseAdapter<string>
	{
		private LayoutInflater LayoutInflater;
		private List<string> SaleItems;

		public SaleItemListAdapter (Context context)
		{
			this.LayoutInflater = (LayoutInflater)context.GetSystemService (Context.LayoutInflaterService);
			this.SaleItems = new List<string> ();
		}

		public override View GetView (int position, View convertView, ViewGroup parent)
		{
			View view = convertView;
			SaleItemViewHolder viewHolder;

			if (view == null) {
				view = this.LayoutInflater.Inflate (Resource.Layout.sale_item, null);
				viewHolder = new SaleItemViewHolder ();
				viewHolder.SaleItemName = view.FindViewById <TextView> (Resource.Id.saleItemName);
				view.Tag = viewHolder;
			} else {
				viewHolder = (SaleItemViewHolder)view.Tag;
			}

			viewHolder.SaleItemName.Text = this.SaleItems [position];

			return view;
		}

		public void AddSaleItem (string item)
		{
			this.SaleItems.Add (item);
			this.NotifyDataSetChanged ();
		}

		public void RemoveSaleItem (int index)
		{
			this.SaleItems.RemoveAt (index);
			this.NotifyDataSetChanged ();
		}

		public override string this [int position] {
			get { return this.SaleItems [position]; }
		}

		public override long GetItemId (int position)
		{
			return position;
		}

		public override int Count {
			get {
				return this.SaleItems.Count;
			}
		}
	}
}

