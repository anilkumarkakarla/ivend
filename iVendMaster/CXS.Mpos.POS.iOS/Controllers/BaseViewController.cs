using System;
using UIKit;
using Foundation;
using CoreGraphics;

namespace CXS.Mpos.POS.iOS
{
	public partial class BaseViewController : UIViewController
	{
		private const float VIEW_BORDER_WIDTH = 1.0f;
		private const float TEXT_FIELD_MARGIN = 15.0f;
		private const float VIEW_CORNER_RADIUS = 4.0f;

		public BaseViewController (string nibName, NSBundle bundle) : base (nibName, bundle)
		{
		}

		public BaseViewController (IntPtr handle) : base (handle)
		{
		}

		public override void ViewWillAppear (bool animated)
		{
			base.ViewWillAppear (animated);

			NavigationController.NavigationBar.Hidden = false;
		}

		protected void SetupViewBorder (UIView view)
		{
			view.Layer.CornerRadius = VIEW_CORNER_RADIUS;
			view.Layer.BorderColor = UIColor.Black.CGColor;
			view.Layer.BorderWidth = VIEW_BORDER_WIDTH;
		}

		protected void SetupTextField (UITextField textField)
		{
			textField.LeftViewMode = UITextFieldViewMode.Always;
			textField.LeftView = new UIView (new CGRect (0, 0, TEXT_FIELD_MARGIN, TEXT_FIELD_MARGIN));
		}
	}
}