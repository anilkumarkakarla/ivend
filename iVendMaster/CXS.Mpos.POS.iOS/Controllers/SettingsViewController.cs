using System;
using UIKit;
using Foundation;
using ObjCRuntime;
using CoreGraphics;

namespace CXS.Mpos.POS.iOS
{
	public partial class SettingsViewController : BaseViewController, IUITableViewDataSource, IUITableViewDelegate
	{
		public const string STORYBOARD_ID = "SettingsViewController";
		private const string TITLE = "Settings";
		private const string CELL_REUSE_IDENTIFIER = "SettingsCell";
		private const int ROWS_COUNT = 1;
		private const string SERVER_URL_CELL = "Server URL";
		private const string SERVER_URL_PLACEHOLDER = "No URL";

		public SettingsViewController () : base ("SettingsViewController", null)
		{
		}

		public SettingsViewController (IntPtr handle) : base (handle)
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			TableView.DataSource = this;
			TableView.Delegate = this;
			TableView.TableFooterView = new UIView (CGRect.Empty);
		}

		public override void ViewWillAppear (bool animated)
		{
			base.ViewWillAppear (animated);

			NavigationController.NavigationBar.Hidden = false;
			NavigationItem.Title = TITLE;
		}
			
		public void SaveSettings ()
		{
			// TODO: save settings
		}

		#region UITableViewDataSource

		public UITableViewCell GetCell (UITableView tableView, NSIndexPath indexPath)
		{
			TextSettingTableViewCell cell = (TextSettingTableViewCell)TableView.DequeueReusableCell (CELL_REUSE_IDENTIFIER, indexPath);
			switch (indexPath.Row) {
			case 0:
				cell.SetTitle (SERVER_URL_CELL);
				cell.SetValue (null); // TODO: use real server url here
				cell.SetPlaceholder (SERVER_URL_PLACEHOLDER);
				break;
			}
			return cell;
		}

		public nint RowsInSection (UITableView tableView, nint section)
		{
			return ROWS_COUNT;
		}

		#endregion
	}
}


