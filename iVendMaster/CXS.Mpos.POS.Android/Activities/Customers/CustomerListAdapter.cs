using System;
using Android.Widget;
using Android.Views;
using Android.Content;
using System.Collections.Generic;
using Log = CXS.Mpos.Core.Log;

namespace CXS.Mpos.POS.Android
{
	public class CustomerListAdapter : BaseAdapter<string>
	{
		private LayoutInflater LayoutInflater;
		private List<string> CustomersWithSectionTitle;
		private const int CUSTOMER_ROW = 0;
		private const int SECTION_HEADER = 1;

		public CustomerListAdapter (Context context, Dictionary<string, List<string>> customers)
		{
			this.LayoutInflater = (LayoutInflater)context.GetSystemService (Context.LayoutInflaterService);
			this.CustomersWithSectionTitle = new List<string> ();
			this.PrepareCustomersToShow (customers);
		}

		public override View GetView (int position, View convertView, ViewGroup parent)
		{
			View view = convertView;
			CustomerViewHolder viewHolder;

			if (this.GetItemViewType (position) == CUSTOMER_ROW) {
				if (view == null) {
					view = this.LayoutInflater.Inflate (Resource.Layout.customer_list_item, null);
					viewHolder = new CustomerViewHolder ();
					viewHolder.Name = view.FindViewById <TextView> (Resource.Id.customerName);
					view.Tag = viewHolder;
				} else {
					viewHolder = (CustomerViewHolder)view.Tag;
				}
			} else {
				if (view == null) {
					view = this.LayoutInflater.Inflate (Resource.Layout.customer_list_section_header, null);
					viewHolder = new CustomerViewHolder ();
					viewHolder.Name = view.FindViewById<TextView> (Resource.Id.sectionName);
					view.Tag = viewHolder;
				} else {
					viewHolder = (CustomerViewHolder)view.Tag;
				}
			}

			viewHolder.Name.Text = this.CustomersWithSectionTitle [position];

			return view;
		}

		public override string this [int position] {
			get { return this.CustomersWithSectionTitle [position]; }
		}

		public override long GetItemId (int position)
		{
			return position;
		}

		public override int ViewTypeCount {
			get {
				return 2;
			}
		}

		public override int Count {
			get {
				return this.CustomersWithSectionTitle.Count;
			}
		}

		public override int GetItemViewType (int position)
		{
			return this.CustomersWithSectionTitle [position].Length == 1 ? SECTION_HEADER : CUSTOMER_ROW;
		}

		private void PrepareCustomersToShow (Dictionary<string, List<string>> customers)
		{
			List<string> keys = new List<string> (customers.Keys);
			foreach (string letter in keys) {
				this.CustomersWithSectionTitle.Add (letter);
				this.CustomersWithSectionTitle.AddRange (customers [letter]);
			}
		}
	}
}

