using System;

using Foundation;
using UIKit;

namespace CXS.Mpos.POS.iOS
{
	public partial class TransactionsCollectionViewCell : UICollectionViewCell
	{
		public const string REUSE_IDENTIFIER = "TransactionsCell";

		public TransactionsItem Item { get; set; }

		public TransactionsCollectionViewCell (IntPtr handle) : base (handle)
		{
		}

		public override void AwakeFromNib ()
		{
			base.AwakeFromNib ();

			CompletedTitleLabel.Text = LocalizedStrings.GetString (LocalizedStrings.COMPLETED_TITLE);
			PendingTitleLabel.Text = LocalizedStrings.GetString (LocalizedStrings.PENDING_TITLE);
		}

		public void SetItem (TransactionsItem item)
		{
			Item = item;
			CompletedLabel.Text = Item.CompletedCount.ToString ();
			PendingLabel.Text = Item.PendingCount.ToString ();
		}
	}
}
