using System;

using Foundation;
using UIKit;

namespace CXS.Mpos.POS.iOS
{
	public partial class AddressTableViewCell : UITableViewCell, IUITextFieldDelegate
	{
		public const string REUSE_IDENTIFIER = "AddressCell";

		public AddressTableViewCell (IntPtr handle) : base (handle)
		{
		}

		public override void AwakeFromNib ()
		{
			base.AwakeFromNib ();

			AddressLine1TextField.Placeholder = LocalizedStrings.GetString (LocalizedStrings.ADDRESS_LINE_1_PLACEHOLDER);
			AddressLine2TextField.Placeholder = LocalizedStrings.GetString (LocalizedStrings.ADDRESS_LINE_2_PLACEHOLDER);
			AddressLine3TextField.Placeholder = LocalizedStrings.GetString (LocalizedStrings.ADDRESS_LINE_3_PLACEHOLDER);
			ZipCodeTextField.Placeholder = LocalizedStrings.GetString (LocalizedStrings.ZIP_CODE_PLACEHOLDER);
			CityTextField.Placeholder = LocalizedStrings.GetString (LocalizedStrings.CITY_PLACEHOLDER);
			StateTextField.Placeholder = LocalizedStrings.GetString (LocalizedStrings.STATE_PLACEHOLDER);
			CountryTextField.Placeholder = LocalizedStrings.GetString (LocalizedStrings.COUNTRY_PLACEHOLDER);
			PhoneNumberTextField.Placeholder = LocalizedStrings.GetString (LocalizedStrings.PHONE_NUMBER_PLACEHOLDER);
			AlternatePhoneNumberTextField.Placeholder = LocalizedStrings.GetString (LocalizedStrings.ALTERNATE_PHONE_NUMBER_PLACEHOLDER);
			AddressLine1TextField.Delegate = this;
			AddressLine2TextField.Delegate = this;
			AddressLine3TextField.Delegate = this;
			ZipCodeTextField.Delegate = this;
			CityTextField.Delegate = this;
			StateTextField.Delegate = this;
			CountryTextField.Delegate = this;
			PhoneNumberTextField.Delegate = this;
			AlternatePhoneNumberTextField.Delegate = this;
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
