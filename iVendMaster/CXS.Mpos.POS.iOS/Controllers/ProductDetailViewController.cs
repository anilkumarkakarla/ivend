using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace CXS.Mpos.POS.iOS
{
	partial class ProductDetailViewController : BaseViewController, IUITableViewDataSource, IUITableViewDelegate
	{
		public const string STORYBOARD_ID = "ProductDetailViewController";
		private const int ROWS_COUNT = 11;
		private const string CELL_REUSE_IDENTIFIER = "ProductDetailCell";
		public string Product { get; set; }

		public ProductDetailViewController (IntPtr handle) : base (handle)
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			TitleLabel.Text = Product;

			TableView.DataSource = this;
			TableView.Delegate = this;
		}

		#region UITableViewDataSource

		public UITableViewCell GetCell (UITableView tableView, NSIndexPath indexPath)
		{
			UITableViewCell cell = TableView.DequeueReusableCell (CELL_REUSE_IDENTIFIER, indexPath);
			switch (indexPath.Row) {
			case 0:
				cell.TextLabel.Text = LocalizedStrings.GetString (LocalizedStrings.ITEM_CODE_CELL);
				cell.DetailTextLabel.Text = "000";
				cell.Accessory = UITableViewCellAccessory.None;
				break;
			case 1:
				cell.TextLabel.Text = LocalizedStrings.GetString (LocalizedStrings.DESCRIPTION_CELL);
				cell.DetailTextLabel.Text = Product;
				cell.Accessory = UITableViewCellAccessory.None;
				break;
			case 2:
				cell.TextLabel.Text = LocalizedStrings.GetString (LocalizedStrings.UOM_CELL);
				cell.DetailTextLabel.Text = "1 Pcs";
				cell.Accessory = UITableViewCellAccessory.None;
				break;
			case 3:
				cell.TextLabel.Text = LocalizedStrings.GetString (LocalizedStrings.QUANTITY_CELL);
				cell.DetailTextLabel.Text = "1";
				cell.Accessory = UITableViewCellAccessory.None;
				break;
			case 4:
				cell.TextLabel.Text = LocalizedStrings.GetString (LocalizedStrings.PRICE_CELL);
				cell.DetailTextLabel.Text = "$ 24.95";
				cell.Accessory = UITableViewCellAccessory.None;
				break;
			case 5:
				cell.TextLabel.Text = LocalizedStrings.GetString (LocalizedStrings.TAX_CODE_CELL);
				cell.DetailTextLabel.Text = "Exempt";
				cell.Accessory = UITableViewCellAccessory.DisclosureIndicator;
				break;
			case 6:
				cell.TextLabel.Text = LocalizedStrings.GetString (LocalizedStrings.TAX_AMOUNT_CELL);
				cell.DetailTextLabel.Text = "$ 0.00";
				cell.Accessory = UITableViewCellAccessory.None;
				break;
			case 7:
				cell.TextLabel.Text = LocalizedStrings.GetString (LocalizedStrings.MANUAL_DISCOUNT_CELL);
				cell.DetailTextLabel.Text = "0.00 %";
				cell.Accessory = UITableViewCellAccessory.DisclosureIndicator;
				break;
			case 8:
				cell.TextLabel.Text = LocalizedStrings.GetString (LocalizedStrings.BATCH_SERIAL_CELL);
				cell.DetailTextLabel.Text = "Batch";
				cell.Accessory = UITableViewCellAccessory.None;
				break;
			case 9:
				cell.TextLabel.Text = LocalizedStrings.GetString (LocalizedStrings.SALES_PERSON_CELL);
				cell.DetailTextLabel.Text = "";
				cell.Accessory = UITableViewCellAccessory.DisclosureIndicator;
				break;
			case 10:
				cell.TextLabel.Text = LocalizedStrings.GetString (LocalizedStrings.SURCHARGE_CELL);
				cell.DetailTextLabel.Text = "$ 0.00";
				cell.Accessory = UITableViewCellAccessory.DisclosureIndicator;
				break;
			}
			return cell;
		}

		public nint RowsInSection (UITableView tableView, nint section)
		{
			return ROWS_COUNT;
		}

		#endregion

		#region UITableViewDelegate

		[Export ("tableView:didSelectRowAtIndexPath:")]
		public void RowSelected (UITableView tableView, NSIndexPath indexPath)
		{
			TableView.DeselectRow (indexPath, true);
		}

		#endregion

		partial void CloseButtonClicked (UIButton sender)
		{
			NavigationController.PopViewController (true);
		}
	}
}
