using System;
using System.Collections.Generic;
using Android.Content;

namespace CXS.Mpos.POS.Android
{
	public class SideMenuBuilder
	{
		private List<SideMenuAction> SideMenuActions = new List<SideMenuAction> ();
		private Context Context;

		public SideMenuBuilder (Context context)
		{
			this.Context = context;
		}

		public List<SideMenuAction> GetDefaultSideMenuItemsForLogOutState ()
		{
			return this.GetCustomSideMenuItemsFromArrayOfTypes (new List<SideMenuItemIds> {
				SideMenuItemIds.SYNCHRONIZE,
				SideMenuItemIds.SETTINGS,
				SideMenuItemIds.SUPPORT,
				SideMenuItemIds.HELP
			});
		}

		public List<SideMenuAction> GetDefaultSideMenuItemsForLogInState ()
		{
			return this.GetCustomSideMenuItemsFromArrayOfTypes (new List<SideMenuItemIds> {
				SideMenuItemIds.HOME,
				SideMenuItemIds.SYNCHRONIZE,
				SideMenuItemIds.SUPPORT,
				SideMenuItemIds.HELP,
				SideMenuItemIds.SIGN_OUT
			});
		}

		public List<SideMenuAction> GetCustomSideMenuItemsFromArrayOfTypes (List<SideMenuItemIds> sideMenuItemIds)
		{
			this.SideMenuActions = new List<SideMenuAction> ();

			foreach (SideMenuItemIds sideMenuItemId in sideMenuItemIds) {
				switch (sideMenuItemId) {
				case SideMenuItemIds.HOME:
					{
						SideMenuAction action = new SideMenuAction ();
						Intent intent = new Intent (this.Context, typeof(MainMenuActivity));
						intent.SetFlags (ActivityFlags.SingleTop);
						action.Id = SideMenuItemIds.HOME;
						action.ActionTypes = new List<SideMenuActionType> {
							SideMenuActionType.START_ACTIVITY
						};
						action.Title = this.Context.GetString (Resource.String.LandingScreenTitle);
						action.Intent = intent;
						this.SideMenuActions.Add (action);
						break;
					}
				case SideMenuItemIds.HELP:
					{
						SideMenuAction action = new SideMenuAction ();
						action.Id = SideMenuItemIds.HELP;
						action.ActionTypes = new List<SideMenuActionType> {
							SideMenuActionType.NO_ACTION
						};
						action.Title = this.Context.GetString (Resource.String.HelpCellTitle);
						this.SideMenuActions.Add (action);
						break;
					}
				case SideMenuItemIds.SETTINGS:
					{
						SideMenuAction action = new SideMenuAction ();
						Intent intent = new Intent (this.Context, typeof(SettingsActivity));
						intent.SetFlags (ActivityFlags.ClearTask);
						action.Id = SideMenuItemIds.SETTINGS;
						action.ActionTypes = new List<SideMenuActionType> {
							SideMenuActionType.START_ACTIVITY
						};
						action.Title = this.Context.GetString (Resource.String.SettingsCellTitle);
						action.Intent = intent;
						this.SideMenuActions.Add (action);
						break;
					}
				case SideMenuItemIds.SIGN_OUT:
					{
						SideMenuAction action = new SideMenuAction ();
						Intent intent = new Intent (this.Context, typeof(LoginActivity));
						intent.SetFlags (ActivityFlags.ClearTask | ActivityFlags.NewTask);
						action.Id = SideMenuItemIds.SIGN_OUT;
						action.ActionTypes = new List<SideMenuActionType> {
							SideMenuActionType.START_ACTIVITY
						};
						action.Title = this.Context.GetString (Resource.String.SignOutTitle);
						action.Intent = intent;
						this.SideMenuActions.Add (action);
						break;
					}
				case SideMenuItemIds.SUPPORT:
					{
						SideMenuAction action = new SideMenuAction ();
						action.Id = SideMenuItemIds.SUPPORT;
						action.ActionTypes = new List<SideMenuActionType> {
							SideMenuActionType.NO_ACTION
						};
						action.Title = this.Context.GetString (Resource.String.SupportCellTitle);
						this.SideMenuActions.Add (action);
						break;
					}
				case SideMenuItemIds.SYNCHRONIZE:
					{
						SideMenuAction action = new SideMenuAction ();
						action.Id = SideMenuItemIds.SYNCHRONIZE;
						action.ActionTypes = new List<SideMenuActionType> {
							SideMenuActionType.NO_ACTION
						};
						action.Title = this.Context.GetString (Resource.String.SynchronizeScreenTitle);
						this.SideMenuActions.Add (action);
						break;
					}
				}
			}

			return this.SideMenuActions;
		}
	}
}

