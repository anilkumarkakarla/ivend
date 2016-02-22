using System;
using UIKit;
using System.Collections.Generic;
using Foundation;
using CoreGraphics;
using ObjCRuntime;

namespace CXS.Mpos.POS.iOS
{
	public partial class LandingViewController : BaseViewController, IUICollectionViewDataSource, IUICollectionViewDelegate, IUICollectionViewDelegateFlowLayout, ILandingViewDelegate
	{
		public const string STORYBOARD_ID = "LandingViewController";
		private const float CELL_HEIGHT = 150.0f;
		private const float CELL_MARGIN = 1.0f;

		private List<List<LandingItem>> Items { get; set; }

		public LandingViewController () : base ("LandingViewController", null)
		{
		}

		public LandingViewController (IntPtr handle) : base (handle)
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			Items = (new LandingViewModel (this)).LandingItems;

			CollectionView.DataSource = this;
			CollectionView.Delegate = this;

			SaleTransactionLabel.Text = LocalizedStrings.GetString (LocalizedStrings.DIRECTLY_SALE_TRANSACTION);
		}

		public override void ViewWillAppear (bool animated)
		{
			base.ViewWillAppear (animated);

			NavigationItem.Title = LocalizedStrings.GetString (LocalizedStrings.LANDING_SCREEN_TITLE);
			ContainerViewController containerController = ((NavigationViewController)NavigationController).ContainerController;
			NavigationItem.LeftBarButtonItem = new UIBarButtonItem (UIBarButtonSystemItem.Action, containerController, new Selector ("showMenu"));
		}

		public override void WillAnimateRotation (UIInterfaceOrientation toInterfaceOrientation, double duration)
		{
			base.WillAnimateRotation (toInterfaceOrientation, duration);

			CollectionView.ReloadData ();
		}

		#region UICollectionViewDataSource

		[Export ("numberOfSectionsInCollectionView:")]
		public nint NumberOfSections (UICollectionView collectionView)
		{
			return Items.Count;
		}
			
		public nint GetItemsCount (UICollectionView collectionView, nint section)
		{
			return Items [(int)section].Count;
		}
			
		public UICollectionViewCell GetCell (UICollectionView collectionView, NSIndexPath indexPath)
		{
			UICollectionViewCell cell;
			LandingItem item = Items [(int)indexPath.Section][(int)indexPath.Item];
			if (item is MyDayItem) {
				MyDayCollectionViewCell myDayCell = (MyDayCollectionViewCell)collectionView.DequeueReusableCell (MyDayCollectionViewCell.REUSE_IDENTIFIER, indexPath);
				myDayCell.SetItem ((MyDayItem)item);
				cell = myDayCell;
			} else if (item is TransactionsItem) {
				TransactionsCollectionViewCell transactionsCell = (TransactionsCollectionViewCell)collectionView.DequeueReusableCell (TransactionsCollectionViewCell.REUSE_IDENTIFIER, indexPath);
				transactionsCell.SetItem ((TransactionsItem)item);
				cell = transactionsCell;
			} else {
				LandingCollectionViewCell landingCell = (LandingCollectionViewCell)collectionView.DequeueReusableCell (LandingCollectionViewCell.REUSE_IDENTIFIER, indexPath);
				landingCell.SetItem (item);
				cell = landingCell;
			}
			return cell;
		}

		#endregion

		#region UICollectionViewDelegate

		[Export ("collectionView:didSelectItemAtIndexPath:")]
		public void ItemSelected (UICollectionView collectionView, NSIndexPath indexPath)
		{
			CollectionView.DeselectItem (indexPath, true);
			LandingItem item = Items [(int)indexPath.Section][(int)indexPath.Item];
			Action action = item.Action;
			if (action != null) {
				action ();
			}
		}

		#endregion

		#region UICollectionViewDelegateFlowLayout

		[Export ("collectionView:layout:sizeForItemAtIndexPath:")]
		public CGSize GetSizeForItem (UICollectionView collectionView, UICollectionViewLayout layout, NSIndexPath indexPath)
		{
			float screenWidth = (float)UIScreen.MainScreen.Bounds.Size.Width;
			int itemsCount = Items [indexPath.Section].Count;
			float cellHeight = CELL_HEIGHT;
			LandingItem item = Items [(int)indexPath.Section][(int)indexPath.Item];
			if (item is MyDayItem || item is TransactionsItem) {
				cellHeight = CELL_HEIGHT / 2;
			}
			CGSize itemSize = new CGSize (screenWidth / itemsCount, cellHeight);
			return new CGSize (itemSize.Width - CELL_MARGIN * 2, itemSize.Height);
		}

		[Export ("collectionView:layout:minimumInteritemSpacingForSectionAtIndex:")]
		public nfloat GetMinimumInteritemSpacingForSection (UICollectionView collectionView, UICollectionViewLayout layout, nint section)
		{
			return 0f;
		}

		[Export ("collectionView:layout:insetForSectionAtIndex:")]
		public UIEdgeInsets GetInsetForSection (UICollectionView collectionView, UICollectionViewLayout layout, nint section)
		{
			return new UIEdgeInsets (CELL_MARGIN, CELL_MARGIN, CELL_MARGIN, CELL_MARGIN);
		}

		#endregion

		#region LandingViewDelegate

		public void SaleItemAction ()
		{
			((NavigationViewController)NavigationController).PushSaleViewController ();
		}

		public void CustomersItemAction ()
		{
			((NavigationViewController)NavigationController).PushCustomersViewController ();
		}

		#endregion
	}
}