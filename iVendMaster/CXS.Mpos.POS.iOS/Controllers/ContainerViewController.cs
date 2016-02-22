using System;
using UIKit;
using Foundation;

namespace CXS.Mpos.POS.iOS
{
	public partial class ContainerViewController : UIViewController
	{
		private const double MENU_WIDTH_PERCENT = 0.65;
		private const double MENU_ANIMATION_DURATION = 0.5;

		public NavigationViewController MainViewController { get; set; }
		private MenuViewController MenuViewController { get; set; }
		private bool IsMenuShown { get; set; }

		public ContainerViewController () : base ("ContainerViewController", null)
		{
		}

		public ContainerViewController (IntPtr handle) : base (handle)
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			MainViewController = (NavigationViewController)Storyboard.InstantiateViewController (NavigationViewController.STORYBOARD_ID);
			MainViewController.ContainerController = this;
			SetupContainerController (MainContainerView, MainViewController);

			MenuViewController = (MenuViewController)Storyboard.InstantiateViewController (MenuViewController.STORYBOARD_ID);
			MenuViewController.ContainerController = this;
			SetupContainerController (MenuContainerView, MenuViewController);
			MenuContainerView.TranslatesAutoresizingMaskIntoConstraints = false;
			MenuContainerView.ClipsToBounds = true;
			ShowMenu (false, false);

			UISwipeGestureRecognizer rightSwipeGesture = new UISwipeGestureRecognizer (() => {
				ShowMenu ();
			});
			rightSwipeGesture.Direction = UISwipeGestureRecognizerDirection.Right;
			MainContainerView.AddGestureRecognizer (rightSwipeGesture);
			UISwipeGestureRecognizer leftSwipeGesture = new UISwipeGestureRecognizer (() => {
				HideMenu ();
			});
			leftSwipeGesture.Direction = UISwipeGestureRecognizerDirection.Left;
			MenuContainerView.AddGestureRecognizer (leftSwipeGesture);
		}

		public override void WillAnimateRotation (UIInterfaceOrientation toInterfaceOrientation, double duration)
		{
			base.WillAnimateRotation (toInterfaceOrientation, duration);

			ShowMenu (IsMenuShown, false);
		}

		private void SetupContainerController (UIView containerView, UIViewController controller) 
		{
			controller.RemoveFromParentViewController ();
			AddChildViewController (controller);
			controller.View.Frame = containerView.Frame;
			containerView.AddSubview (controller.View);
			controller.DidMoveToParentViewController (this);
		}

		[Export ("showMenu")]
		public void ShowMenu () 
		{
			ShowMenu (true, true);
		}

		[Export ("hideMenu")]
		public void HideMenu () 
		{
			ShowMenu (false, true);
		}

		private void ShowMenu (bool show, bool animated)
		{
			float screenWidth = (float)UIScreen.MainScreen.Bounds.Width;
			MenuContainerView.SetNeedsUpdateConstraints ();
			double animationDuration;
			if (animated) {
				animationDuration = MENU_ANIMATION_DURATION;
			} else {
				animationDuration = 0;
			}
			UIView.Animate (animationDuration, () => 
			{
				if (show) {
					MenuRightMargin.Constant = (float)(screenWidth * (1.0 - MENU_WIDTH_PERCENT));
					MenuLeftMargin.Constant = 0;
				} else {
					MenuRightMargin.Constant = screenWidth;
					MenuLeftMargin.Constant = (float)(- screenWidth * MENU_WIDTH_PERCENT);
				}
				View.LayoutIfNeeded ();
			});
			MainContainerView.UserInteractionEnabled = !show;
			IsMenuShown = show;
		}
	}
}