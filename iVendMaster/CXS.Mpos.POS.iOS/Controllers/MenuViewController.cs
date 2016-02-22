using System;
using UIKit;
using Foundation;
using CoreGraphics;
using System.Collections.Generic;

namespace CXS.Mpos.POS.iOS
{
	public partial class MenuViewController : UIViewController, IUITableViewDataSource, IUITableViewDelegate
	{
		public const string STORYBOARD_ID = "MenuViewController";
		private const string TITLE = "Menu";
		private const string CELL_REUSE_IDENTIFIER = "MenuCell";
		private const float ROW_HEIGHT = 60.0f;

		public ContainerViewController ContainerController { get; set; }
		private List<MenuItem> Items { get; set; }

		public MenuViewController () : base ("MenuViewController", null)
		{
		}

		public MenuViewController (IntPtr handle) : base (handle)
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			NavigationViewController navigationController = ContainerController.MainViewController;
			Items = new List<MenuItem> {	
				new MenuItem (LocalizedStrings.GetString (LocalizedStrings.SYNCHRONIZE_CELL_TITLE), null, null),
				new MenuItem (LocalizedStrings.GetString (LocalizedStrings.SETTINGS_CELL_TITLE), null, () => {
					navigationController.PushSettingsViewController ();
				}),
				new MenuItem (LocalizedStrings.GetString (LocalizedStrings.SUPPORT_CELL_TITLE), null, null),
				new MenuItem (LocalizedStrings.GetString (LocalizedStrings.HELP_CELL_TITLE), null, null),
				new MenuItem (LocalizedStrings.GetString (LocalizedStrings.SIGNOUT_CELL_TITLE), null, null) 
			};

			TableView.DataSource = this;
			TableView.Delegate = this;
			TableView.TableFooterView = new UIView (CGRect.Empty);
		}

		partial void CloseMenu (UIButton sender)
		{
			ContainerController.HideMenu ();
		}

		#region UITableViewDataSource

		public UITableViewCell GetCell (UITableView tableView, NSIndexPath indexPath)
		{
			MenuTableViewCell cell = (MenuTableViewCell)tableView.DequeueReusableCell (CELL_REUSE_IDENTIFIER, indexPath);
			cell.SetItem (Items [indexPath.Row]);

			return cell;
		}

		public nint RowsInSection (UITableView tableView, nint section)
		{
			return Items.Count;
		}

		#endregion

		#region UITableViewDelegate

		[Export ("tableView:didSelectRowAtIndexPath:")]
		public void RowSelected (UITableView tableView, NSIndexPath indexPath)
		{
			tableView.DeselectRow (indexPath, true);
			MenuItem item = Items [indexPath.Row];
			Action action = item.Action;
			if (action != null) {
				action ();
			}
			ContainerController.HideMenu ();
		}

		[Export ("tableView:heightForRowAtIndexPath:")]
		public nfloat GetHeightForRow (UITableView tableView, NSIndexPath indexPath)
		{
			return ROW_HEIGHT;
		}

		#endregion
	}
}