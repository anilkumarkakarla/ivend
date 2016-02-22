using System;
using Foundation;
using UIKit;

namespace CXS.Mpos.POS.iOS
{
	public partial class CustomerDetailViewController : BaseViewController, IUITableViewDataSource, IUITableViewDelegate, IUITextFieldDelegate
	{
		public const string STORYBOARD_ID = "CustomerDetailViewController";
		private const int PERSONAL_SECTIONS_COUNT = 3;
		private const int ADDRESS_SECTIONS_COUNT = 2;
		private const int CONTACT_ROWS_COUNT = 3;
		private const int ACCOUNTING_ROWS_COUNT = 3;
		private const int MISCELLANEOUS_ROWS_COUNT = 2;
		private const float DETAIL_CELL_HEIGHT = 44.0f;
		private const float ADDRESS_CELL_HEIGHT = 320.0f;

		public string Customer { get; set; }
		public CustomerDetailsViewType ViewType { get; set; }

		public CustomerDetailViewController () : base ("CustomerDetailViewController", null)
		{
		}

		public CustomerDetailViewController (IntPtr handle) : base (handle)
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			DetailTypeSegmentedControl.SetTitle (LocalizedStrings.GetString (LocalizedStrings.PERSONAL_DETAIL_SEGMENT), 0);
			DetailTypeSegmentedControl.SetTitle (LocalizedStrings.GetString (LocalizedStrings.ADDRESS_DETAIL_SEGMENT), 1);
			DetailTypeSegmentedControl.ValueChanged += (sender, e) => {
				ChangeDetailType ();
			};

			ViewType = CustomerDetailsViewType.Personal;
			TableView.DataSource = this;
			TableView.Delegate = this;

			FirstNameTextField.Text = Customer;
			CustomerIdTextField.Text = "000";
			FirstNameTextField.Delegate = this;
			LastNameTextField.Delegate = this;
			CustomerIdTextField.Delegate = this;
		}

		public override void ViewWillAppear (bool animated)
		{
			base.ViewWillAppear (animated);

			NavigationItem.Title = null;
			NavigationItem.LeftBarButtonItem = new UIBarButtonItem (UIBarButtonSystemItem.Edit, null, null);
			NavigationItem.RightBarButtonItem = new UIBarButtonItem (LocalizedStrings.GetString (LocalizedStrings.ADD_TO_TRANSACTION_TITLE), UIBarButtonItemStyle.Plain, null, null);
		}

		#region UITableViewDataSource

		public UITableViewCell GetCell (UITableView tableView, NSIndexPath indexPath)
		{
			UITableViewCell cell = null;
			if (ViewType == CustomerDetailsViewType.Personal) {
				PersonalDetailTableViewCell personalCell = (PersonalDetailTableViewCell)TableView.DequeueReusableCell (PersonalDetailTableViewCell.REUSE_IDENTIFIER, indexPath);
				if (indexPath.Section == 0) {
					if (indexPath.Row == 0) {
						personalCell.SetDetailType (CustomerPersonalDetailType.WorkPhone);
					} else if (indexPath.Row == 1) {
						personalCell.SetDetailType (CustomerPersonalDetailType.MobilePhone);
					} else if (indexPath.Row == 2) {
						personalCell.SetDetailType (CustomerPersonalDetailType.Email);
					}
				} else if (indexPath.Section == 1) {
					if (indexPath.Row == 0) {
						personalCell.SetDetailType (CustomerPersonalDetailType.TaxNumber);
					} else if (indexPath.Row == 1) {
						personalCell.SetDetailType (CustomerPersonalDetailType.ElectronicId);
					} else if (indexPath.Row == 2) {
						personalCell.SetDetailType (CustomerPersonalDetailType.Discount);
					}
				} else if (indexPath.Section == 2) {
					if (indexPath.Row == 0) {
						personalCell.SetDetailType (CustomerPersonalDetailType.CustomerGroup);
					} else if (indexPath.Row == 1) {
						personalCell.SetDetailType (CustomerPersonalDetailType.CompanyType);
					}
				}
				cell = personalCell;
			} else if (ViewType == CustomerDetailsViewType.Address) {
				AddressTableViewCell addressCell = (AddressTableViewCell)TableView.DequeueReusableCell (AddressTableViewCell.REUSE_IDENTIFIER, indexPath);

				cell = addressCell;
			}
			return cell;
		}

		[Export ("numberOfSectionsInTableView:")]
		public nint NumberOfSections (UITableView tableView)
		{
			int sectionsCount = 0;
			if (ViewType == CustomerDetailsViewType.Personal) {
				sectionsCount = PERSONAL_SECTIONS_COUNT;
			} else if (ViewType == CustomerDetailsViewType.Address) {
				sectionsCount = ADDRESS_SECTIONS_COUNT;
			}
			return sectionsCount;
		}

		[Export ("tableView:titleForHeaderInSection:")]
		public String TitleForHeader (UITableView tableView, nint section)
		{
			string titleId = null;
			if (ViewType == CustomerDetailsViewType.Personal) {
				if (section == 0) {
					titleId = LocalizedStrings.CONTACT_SECTION_TITLE;
				} else if (section == 1) {
					titleId = LocalizedStrings.ACCOUNTING_SECTION_TITLE;
				} else if (section == 2) {
					titleId = LocalizedStrings.MISCELLANEOUS_SECTION_TITLE;
				}
			} else if (ViewType == CustomerDetailsViewType.Address) {
				if (section == 0) {
					titleId = LocalizedStrings.BILLING_ADDRESS_SECTION_TITLE;
				} else if (section == 1) {
					titleId = LocalizedStrings.SHIPPING_ADDRESS_SECTION_TITLE;
				}
			}
			return LocalizedStrings.GetString (titleId);
		}

		public nint RowsInSection (UITableView tableView, nint section)
		{
			int rowsCount = 0;
			if (ViewType == CustomerDetailsViewType.Personal) {
				if (section == 0) {
					rowsCount = CONTACT_ROWS_COUNT;
				} else if (section == 1) {
					rowsCount = ACCOUNTING_ROWS_COUNT;
				} else if (section == 2) {
					rowsCount = MISCELLANEOUS_ROWS_COUNT;
				}
			} else if (ViewType == CustomerDetailsViewType.Address) {
				rowsCount = 1;
			}
			return rowsCount;
		}

		#endregion

		#region UITableViewDelegate

		[Export ("tableView:heightForRowAtIndexPath:")]
		public nfloat GetHeightForRow (UITableView tableView, NSIndexPath indexPath)
		{
			float rowHeight = 0;
			if (ViewType == CustomerDetailsViewType.Personal) {
				rowHeight = DETAIL_CELL_HEIGHT;
			} else if (ViewType == CustomerDetailsViewType.Address) {
				rowHeight = ADDRESS_CELL_HEIGHT;
			}
			return rowHeight;
		}

		#endregion

		#region IUITextFieldDelegate

		[Export ("textFieldShouldReturn:")]
		public Boolean ShouldReturn (UITextField textField)
		{
			textField.ResignFirstResponder ();
			return true;
		}

		#endregion
			
		private void ChangeDetailType ()
		{
			switch (DetailTypeSegmentedControl.SelectedSegment) {
			case 0:
				ViewType = CustomerDetailsViewType.Personal;
				break;
			case 1:
				ViewType = CustomerDetailsViewType.Address;
				break;
			}
			TableView.ReloadData ();
		}
	}
}


