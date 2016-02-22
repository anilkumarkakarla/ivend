// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace CXS.Mpos.POS.iOS
{
	[Register ("AddressTableViewCell")]
	partial class AddressTableViewCell
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITextField AddressLine1TextField { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITextField AddressLine2TextField { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITextField AddressLine3TextField { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITextField AlternatePhoneNumberTextField { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITextField CityTextField { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITextField CountryTextField { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITextField PhoneNumberTextField { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITextField StateTextField { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITextField ZipCodeTextField { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (AddressLine1TextField != null) {
				AddressLine1TextField.Dispose ();
				AddressLine1TextField = null;
			}
			if (AddressLine2TextField != null) {
				AddressLine2TextField.Dispose ();
				AddressLine2TextField = null;
			}
			if (AddressLine3TextField != null) {
				AddressLine3TextField.Dispose ();
				AddressLine3TextField = null;
			}
			if (AlternatePhoneNumberTextField != null) {
				AlternatePhoneNumberTextField.Dispose ();
				AlternatePhoneNumberTextField = null;
			}
			if (CityTextField != null) {
				CityTextField.Dispose ();
				CityTextField = null;
			}
			if (CountryTextField != null) {
				CountryTextField.Dispose ();
				CountryTextField = null;
			}
			if (PhoneNumberTextField != null) {
				PhoneNumberTextField.Dispose ();
				PhoneNumberTextField = null;
			}
			if (StateTextField != null) {
				StateTextField.Dispose ();
				StateTextField = null;
			}
			if (ZipCodeTextField != null) {
				ZipCodeTextField.Dispose ();
				ZipCodeTextField = null;
			}
		}
	}
}
