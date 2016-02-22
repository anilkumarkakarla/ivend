using System;

using Foundation;
using UIKit;

namespace CXS.Mpos.POS.iOS
{
	public partial class ProductTableViewCell : UITableViewCell
	{
		public const string REUSE_IDENTIFIER = "ProductCell";

		private string Product { get; set; }
		public ProductsViewController ProductsController { get; set; }

		public ProductTableViewCell (IntPtr handle) : base (handle)
		{
		}

		public void SetProduct (string product)
		{
			Product = product;
			TitleLabel.Text = product;
			ProductIdLabel.Text = "000";
			CountLabel.Text = "0 Available";
		}

		partial void AddButtonClicked (UIButton sender)
		{
			ProductsController.ParentController.AddProduct (Product);
		}
	}
}
