using System;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SupportToolbar = Android.Support.V7.Widget.Toolbar;
using Android.Support.V7.App;
using Android.Support.V4.Widget;
using System.Collections.Generic;
using CXS.Mpos.Core;

namespace CXS.Mpos.POS.Android
{
	public abstract class BaseActivity : AppCompatActivity
	{
		private SupportToolbar Toolbar;
		private DrawerLayout DrawerLayout;
		private ListView SideMenu;
		private ActionBarDrawerToggle DrawerToggle;
		private List<SideMenuAction> SideMenuActions;
		protected bool IsUserLoggedIn = true;
		protected SideMenuBuilder SideMenuBuilder;

		protected void ConfigureDrawer ()
		{
			this.Toolbar = FindViewById <SupportToolbar> (Resource.Id.toolbar);
			this.DrawerLayout = FindViewById <DrawerLayout> (Resource.Id.drawer_layout);
			this.SideMenu = FindViewById <ListView> (Resource.Id.side_menu);

			SetSupportActionBar (this.Toolbar);

			this.DrawerToggle = new ActionBarDrawerToggle (
				this, 
				this.DrawerLayout, 
				Resource.String.OpenDrawer, 
				Resource.String.CloseDrawer);

			this.DrawerLayout.SetDrawerListener (this.DrawerToggle);
			this.SideMenuBuilder = new SideMenuBuilder (this);
			this.SideMenuActions = this.GetSideMenuActions ();

			this.SideMenu.Adapter = new SideMenuItemAdapter (this, this.SideMenuActions);

			this.SideMenu.ItemClick += this.StartActionFromNavigationDrawer;

			SupportActionBar.SetDisplayHomeAsUpEnabled (true);
			SupportActionBar.SetHomeButtonEnabled (true);
			this.DrawerToggle.SyncState ();
		}

		private void StartActionFromNavigationDrawer (object sender, AdapterView.ItemClickEventArgs e)
		{
			this.DrawerLayout.CloseDrawer (this.SideMenu);
			SideMenuAction action = this.SideMenuActions [e.Position];
			if (action.ActionTypes.Contains (SideMenuActionType.EXECUTE_ACTION) && action.PerformAction != null) {
				action.PerformAction ();
			} else if (action.ActionTypes.Contains (SideMenuActionType.START_ACTIVITY)) {
				StartActivity (action.Intent);
			}
		}

		public override bool OnOptionsItemSelected (IMenuItem item)
		{
			this.DrawerToggle.OnOptionsItemSelected (item);
			return base.OnOptionsItemSelected (item);
		}

		protected override void OnPostCreate (Bundle savedInstanceState)
		{
			base.OnPostCreate (savedInstanceState);
			this.DrawerToggle.SyncState ();
		}

		protected List<SideMenuAction> GetSideMenuActions ()
		{
			return this.IsUserLoggedIn ? this.SideMenuBuilder.GetDefaultSideMenuItemsForLogInState () :
				this.SideMenuBuilder.GetDefaultSideMenuItemsForLogOutState ();
		}
	}
}

