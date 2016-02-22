using System;

using Foundation;
using UIKit;

namespace CXS.Mpos.POS.iOS
{
	public partial class PersonalDetailTableViewCell : UITableViewCell, IUITextFieldDelegate
	{
		public const string REUSE_IDENTIFIER = "PersonalDetailCell";

		public CustomerPersonalDetailType DetailType { get; set; }
		
		public PersonalDetailTableViewCell (IntPtr handle) : base (handle)
		{
		}

		public override void AwakeFromNib ()
		{
			base.AwakeFromNib ();

			DetailTextField.Delegate = this;
		}

		public void SetDetailType (CustomerPersonalDetailType detailType)
		{
			DetailType = detailType;
			string placeholderId = null;
			switch (DetailType) {
			case CustomerPersonalDetailType.WorkPhone:
				placeholderId = LocalizedStrings.WORK_PHONE_PLACEHOLDER;
				break;
			case CustomerPersonalDetailType.MobilePhone:
				placeholderId = LocalizedStrings.MOBILE_PHONE_PLACEHOLDER;
				break;
			case CustomerPersonalDetailType.Email:
				placeholderId = LocalizedStrings.EMAIL_PLACEHOLDER;
				break;
			case CustomerPersonalDetailType.TaxNumber:
				placeholderId = LocalizedStrings.TAX_NUMBER_PLACEHOLDER;
				break;
			case CustomerPersonalDetailType.ElectronicId:
				placeholderId = LocalizedStrings.ELECTRONIC_ID_PLACEHOLDER;
				break;
			case CustomerPersonalDetailType.Discount:
				placeholderId = LocalizedStrings.DISCOUNT_PLACEHOLDER;
				break;
			case CustomerPersonalDetailType.CustomerGroup:
				placeholderId = LocalizedStrings.CUSTOMER_GROUP_PLACEHOLDER;
				break;
			case CustomerPersonalDetailType.CompanyType:
				placeholderId = LocalizedStrings.COMPANY_TYPE_PLACEHOLDER;
				break;
			}
			DetailTextField.Placeholder = LocalizedStrings.GetString (placeholderId);
		}

		#region IUITextFieldDelegate

		[Export ("textFieldShouldReturn:")]
		public Boolean ShouldReturn (UITextField textField)
		{
			textField.ResignFirstResponder ();
			return true;
		}

		#endregion
	}
}
