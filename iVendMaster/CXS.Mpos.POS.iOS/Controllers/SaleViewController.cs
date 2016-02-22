using System;
using ObjCRuntime;
using UIKit;
using Foundation;
using System.Collections.Generic;

namespace CXS.Mpos.POS.iOS
{
	public partial class SaleViewController : UIViewController, IUITableViewDataSource, IUITableViewDelegate, IUISearchBarDelegate
	{
		public const string STORYBOARD_ID = "SaleViewController";
		private const float CELL_HEIGHT = 100.0f;
		private const string USD = "$ ";

		public List<string> Items { get; set; }
		private UISearchController SearchController { get; set; }

		public SaleViewController () : base ("SaleViewController", null)
		{
		}

		public SaleViewController (IntPtr handle) : base (handle)
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			Items = new List<string> () { 
				"aaron Wood's solid polo",
				"Barry D's suit",
				"Vsevolod Borisov's jeans",
				"Artem Kalachev's solid polo",
				"Bill Good's jeans",
				"Andrey Filyakov's suit",
				"Igor Karpunin's boots",
				"Berry G's hat"
			};

			TableView.DataSource = this;
			TableView.Delegate = this;

			SetupSearchBar ();

			CustomerLabel.Text = LocalizedStrings.GetString (LocalizedStrings.CUSTOMER_LABEL_PLACEHOLDER);
			ScanButton.SetTitle (LocalizedStrings.GetString (LocalizedStrings.SCAN_BUTTON), UIControlState.Normal);
			DiscountTitleLabel.Text = LocalizedStrings.GetString (LocalizedStrings.DISCOUNT_LABEL);
			TaxTitleLabel.Text = LocalizedStrings.GetString (LocalizedStrings.TAX_LABEL);
			TotalTitleLabel.Text = LocalizedStrings.GetString (LocalizedStrings.TOTAL_LABEL);

			// TODO: remove default values
			DiscountLabel.Text = USD + "0.0";
			TaxLabel.Text = USD + "0.0";
			TotalLabel.Text = USD + "0.0";
		}

		public override void ViewWillAppear (bool animated)
		{
			base.ViewWillAppear (animated);

			NavigationItem.Title = LocalizedStrings.GetString (LocalizedStrings.SALE_SCREEN_TITLE);
			NavigationItem.RightBarButtonItem = new UIBarButtonItem (UIBarButtonSystemItem.Action, this, new Selector (null));
		}

		public override void ViewDidAppear (bool animated)
		{
			base.ViewDidAppear (animated);
		
			SearchController.SearchBar.Frame = SearchBarContainerView.Bounds;
			SearchBarContainerView.AddSubview (SearchController.SearchBar);
		}

		private void SetupSearchBar ()
		{
			ProductsViewController productsController = (ProductsViewController)Storyboard.InstantiateViewController(ProductsViewController.STORYBOARD_ID);
			productsController.ParentController = this;
			SearchController = new UISearchController (productsController);
			SearchController.SearchResultsUpdater = productsController;
			SearchController.SearchBar.Delegate = this;
			SearchController.SearchBar.ShowsCancelButton = false;
			SearchController.SearchBar.Placeholder = LocalizedStrings.GetString (LocalizedStrings.SALE_SEARCH_PLACEHOLDER);
			SearchController.SearchBar.BarTintColor = UIColor.Clear;
			SearchController.SearchBar.TintColor = UIColor.White;
			SearchController.HidesNavigationBarDuringPresentation = false;
			DefinesPresentationContext = true;
			SearchController.SearchBar.SizeToFit ();
		}

		public void AddProduct (string product)
		{
			Items.Add (product);
			TableView.ReloadData ();
		}

		#region UITableViewDatasource

		public UITableViewCell GetCell (UITableView tableView, NSIndexPath indexPath)
		{
			SaleTableViewCell cell = (SaleTableViewCell)TableView.DequeueReusableCell (SaleTableViewCell.REUSE_IDENTIFIER, indexPath);
			cell.SetProduct (Items [indexPath.Row]);
			return cell;
		}

		public nint RowsInSection (UITableView tableView, nint section)
		{
			return Items.Count;
		}

		[Export ("tableView:commitEditingStyle:forRowAtIndexPath:")]
		public void CommitEditingStyle (UITableView TableView, UITableViewCellEditingStyle editingStyle, NSIndexPath indexPath)
		{
			if (editingStyle == UITableViewCellEditingStyle.Delete) {
				Items.RemoveAt (indexPath.Row);
				TableView.DeleteRows(new NSIndexPath[] {indexPath}, UITableViewRowAnimation.Fade);
			}
		}

		#endregion

		#region UITableViewDelegate

		[Export ("tableView:heightForRowAtIndexPath:")]
		public nfloat GetHeightForRow (UITableView tableView, NSIndexPath indexPath)
		{
			return CELL_HEIGHT;
		}

		[Export ("tableView:editingStyleForRowAtIndexPath:")]
		public UITableViewCellEditingStyle EditingStyleForRow (UITableView tableView, NSIndexPath indexPath)
		{
			return UITableViewCellEditingStyle.Delete;
		}

		#endregion

		#region IUISearchBarDelegate

		[Export ("searchBarSearchButtonClicked:")]
		public void SearchButtonClicked (UISearchBar searchBar)
		{
			searchBar.ResignFirstResponder ();
		}

		#endregion
	}
}


