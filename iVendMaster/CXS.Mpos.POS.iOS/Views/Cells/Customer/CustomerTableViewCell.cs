using System;

using Foundation;
using UIKit;

namespace CXS.Mpos.POS.iOS
{
	public partial class CustomerTableViewCell : UITableViewCell
	{
		public const string REUSE_IDENTIFIER = "CustomerCell";

		public CustomerTableViewCell (IntPtr handle) : base (handle)
		{
		}

		public void SetCustomer (string customer)
		{
			NameLabel.Text = customer;
			CustomerIdLabel.Text = "000";
		}
	}
}
