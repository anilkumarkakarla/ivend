using System;
using System.Collections.Generic;
using UIKit;
using Foundation;

namespace CXS.Mpos.POS.iOS
{
	public partial class CustomersViewController : BaseViewController, IUITableViewDataSource, IUITableViewDelegate, IUISearchBarDelegate
	{
		public const string STORYBOARD_ID = "CustomersViewController";
		private const float ROW_HEIGHT = 80.0f;

		private Dictionary<string, List<string>> Customers { get; set; }

		public CustomersViewController () : base ("CustomersViewController", null)
		{
		}

		public CustomersViewController (IntPtr handle) : base (handle)
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			// for test purposes
			List<string> customers = new List<string> () { 
				"aaron Wood",
				"Barry D",
				"Vsevolod Borisov",
				"Artem Kalachev",
				"Bill Good",
				"Andrey Filyakov",
				"Vyacheslav Kormushkin",
				"adam Ramirez",
				"Alexandra Lukyanchikova",
				"Semen Churyakov",
				"Alan Simons",
				"Igor Karpunin",
				"Berry G"
			};
			Customers = (new CustomersViewModel (customers)).Customers;

			SearchBar.Delegate = this;
			TableView.DataSource = this;
			TableView.Delegate = this;
		}

		public override void ViewWillAppear (bool animated)
		{
			base.ViewWillAppear (animated);

			NavigationItem.Title = LocalizedStrings.GetString (LocalizedStrings.CUSTOMERS_SCREEN_TITLE);
		}

		#region UITableViewDataSource

		public UITableViewCell GetCell (UITableView tableView, NSIndexPath indexPath)
		{
			CustomerTableViewCell cell = (CustomerTableViewCell)TableView.DequeueReusableCell (CustomerTableViewCell.REUSE_IDENTIFIER, indexPath);
			List<string> keys = new List<string> (Customers.Keys);
			string key = keys [indexPath.Section];
			List<string> customers = Customers [key];
			cell.SetCustomer (customers [indexPath.Row]);
			return cell;
		}

		[Export ("numberOfSectionsInTableView:")]
		public nint NumberOfSections (UITableView tableView)
		{
			return Customers.Keys.Count;
		}

		[Export ("tableView:titleForHeaderInSection:")]
		public String TitleForHeader (UITableView tableView, nint section)
		{
			List<string> keys = new List<string> (Customers.Keys);
			return keys [(int)section];
		}

		[Export ("sectionIndexTitlesForTableView:")]
		public String[] SectionIndexTitles (UITableView tableView)
		{
			return (new List<string> (Customers.Keys)).ToArray ();
		}

		public nint RowsInSection (UITableView tableView, nint section)
		{
			List<string> keys = new List<string> (Customers.Keys);
			string key = keys [(int)section];
			List<string> customers = Customers [key];
			return customers.Count;
		}

		#endregion

		#region UITableViewDelegate

		[Export ("tableView:didSelectRowAtIndexPath:")]
		public void RowSelected (UITableView tableView, NSIndexPath indexPath)
		{
			TableView.DeselectRow (indexPath, true);
			List<string> keys = new List<string> (Customers.Keys);
			string key = keys [indexPath.Section];
			List<string> customers = Customers [key];
			((NavigationViewController)NavigationController).PushCustomerDetailViewController (customers [indexPath.Row]);
		}

		[Export ("tableView:heightForRowAtIndexPath:")]
		public nfloat GetHeightForRow (UITableView tableView, NSIndexPath indexPath)
		{
			return ROW_HEIGHT;
		}

		#endregion

		#region IUISearchBarDelegate

		[Export ("searchBarTextDidEndEditing:")]
		public void OnEditingStopped (UISearchBar searchBar)
		{
			searchBar.ResignFirstResponder ();
		}

		[Export ("searchBarSearchButtonClicked:")]
		public void SearchButtonClicked (UISearchBar searchBar)
		{
			searchBar.ResignFirstResponder ();
		}

		#endregion
	}
}


