using System;
using System.Collections.Generic;
using UIKit;
using Foundation;

namespace CXS.Mpos.POS.iOS
{
	public partial class ProductsViewController : UIViewController, IUITableViewDataSource, IUITableViewDelegate, IUISearchResultsUpdating
	{
		public const string STORYBOARD_ID = "ProductsViewController";
		private const float ROW_HEIGHT = 100.0f;

		private List<string> Products { get; set; }
		private List<string> FilteredProducts { get; set; }
		public SaleViewController ParentController { get; set; }

		public ProductsViewController () : base ("ProductsViewController", null)
		{
		}

		public ProductsViewController (IntPtr handle) : base (handle)
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			// for test purposes
			Products = new List<string> () { 
				"aaron Wood's solid polo",
				"Barry D's suit",
				"Vsevolod Borisov's jeans",
				"Artem Kalachev's solid polo",
				"Bill Good's jeans",
				"Andrey Filyakov's suit",
				"Vyacheslav Kormushkin's solid polo",
				"adam Ramirez's jeans",
				"Alexandra Lukyanchikova's jacket",
				"Semen Churyakov's tshirt",
				"Alan Simons's shirt",
				"Igor Karpunin's boots",
				"Berry G's hat"
			};
			FilteredProducts = new List<string> ();

			TableView.DataSource = this;
			TableView.Delegate = this;
		}

		#region UITableViewDataSource

		public UITableViewCell GetCell (UITableView tableView, NSIndexPath indexPath)
		{
			ProductTableViewCell cell = (ProductTableViewCell)TableView.DequeueReusableCell (ProductTableViewCell.REUSE_IDENTIFIER, indexPath);
			cell.ProductsController = this;
			cell.SetProduct (FilteredProducts [indexPath.Row]);
			return cell;
		}

		public nint RowsInSection (UITableView tableView, nint section)
		{
			return FilteredProducts.Count;
		}

		#endregion

		#region UITableViewDelegate

		[Export ("tableView:didSelectRowAtIndexPath:")]
		public void RowSelected (UITableView tableView, NSIndexPath indexPath)
		{
			TableView.DeselectRow (indexPath, true);
			((NavigationViewController)ParentController.NavigationController).PushProductDetailViewController (FilteredProducts [indexPath.Row]);
		}
			
		[Export ("tableView:heightForRowAtIndexPath:")]
		public nfloat GetHeightForRow (UITableView tableView, NSIndexPath indexPath)
		{
			return ROW_HEIGHT;
		}

		#endregion

		#region UISearchResultsUpdating

		public void UpdateSearchResultsForSearchController (UISearchController searchController)
		{
			if (searchController.SearchBar.Text.Length == 0) {
				FilteredProducts.Clear ();
			} else {
				FilteredProducts = new List<string> ();

				foreach (string product in Products)
				{
					if(product.IndexOf (searchController.SearchBar.Text, StringComparison.OrdinalIgnoreCase) >= 0)
					{
						FilteredProducts.Add (product);
					}
				}
			}

			TableView.ReloadData ();
		}

		#endregion
	}
}