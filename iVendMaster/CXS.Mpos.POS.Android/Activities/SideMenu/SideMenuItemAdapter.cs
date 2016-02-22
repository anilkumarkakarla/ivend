using System;
using Android.Widget;
using Android.App;
using System.Collections.Generic;
using Android.Views;

namespace CXS.Mpos.POS.Android
{
	public class SideMenuItemAdapter : BaseAdapter<SideMenuAction>
	{
		private List<SideMenuAction> SideMenuActions = new List<SideMenuAction> ();
		private Activity Context;

		public SideMenuItemAdapter (Activity context, List<SideMenuAction> actions) : base ()
		{
			this.Context = context;
			this.SideMenuActions = actions;
		}

		public override long GetItemId (int position)
		{
			return position;
		}

		public override SideMenuAction this [int position] {   
			get { return this.SideMenuActions [position]; } 
		}

		public override int Count {
			get { return this.SideMenuActions.Count; } 
		}

		public override View GetView (int position, View convertView, ViewGroup parent)
		{
			SideMenuAction action = this.SideMenuActions [position];
			View view = convertView;
			if (view == null) {
				view = this.Context.LayoutInflater.Inflate(Resource.Layout.side_menu_item, null);
			}
				
			view.FindViewById<TextView>(Resource.Id.SideMenuItemTitle).Text = action.Title;

			return view;
		}
	}
}

