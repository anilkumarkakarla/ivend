using System;
using Foundation;

namespace CXS.Mpos.POS.iOS
{
	public class LocalizedStrings
	{
		public static string BACK_BUTTON_TITLE = "BackButtonTitle";
		public static string LANDING_SCREEN_TITLE = "LandingScreenTitle";
		public static string LOGIN_SCREEN_TITLE = "LoginScreenTitle";
		public static string APP_VERSION_PREFIX = "AppVersionPrefix";
		public static string SYNCHRONIZE_CELL_TITLE = "SyncronizeCellTitle";
		public static string SETTINGS_CELL_TITLE = "SettingsCellTitle";
		public static string SUPPORT_CELL_TITLE = "SupportCellTitle";
		public static string HELP_CELL_TITLE = "HelpCellTitle";
		public static string SIGNOUT_CELL_TITLE = "SignOutCellTitle";
		public static string LOGIN_TITLE_LABEL = "LoginTitleLabel";
		public static string LOGIN_PLACEHOLDER = "LoginPlaceholder";
		public static string PASSWORD_PLACEHOLDER = "PasswordPlaceholder";
		public static string SIGN_IN_BUTTON = "SignInButton";
		public static string PENDING_TITLE = "PendingTitle";
		public static string COMPLETED_TITLE = "CompletedTitle";
		public static string OTHERS_TITLE = "OthersTitle";
		public static string IVEND_TITLE = "IVendTitle";
		public static string TODAYS_SALE_TITLE = "TodaysSaleTitle";
		public static string COMMISSION_TITLE = "CommissionTitle";
		public static string SALES_TARGET_TITLE = "SalesTargetTitle";
		public static string DIRECTLY_SALE_TRANSACTION = "DirectlySaleTransaction";
		public static string SALE_SCREEN_TITLE = "SaleScreenTitle";
		public static string CUSTOMERS_SCREEN_TITLE = "CustomersListTitle";
		public static string SALE_SEARCH_PLACEHOLDER = "SaleSearchPlaceholder";
		public static string CUSTOMER_LABEL_PLACEHOLDER = "CustomerLabelPlaceholder";
		public static string SCAN_BUTTON = "ScanButton";
		public static string DISCOUNT_LABEL = "DiscountLabel";
		public static string TAX_LABEL = "TaxLabel";
		public static string TOTAL_LABEL = "TotalLabel";
		public static string ADDRESS_LINE_1_PLACEHOLDER = "AddressLine1Placeholder";
		public static string ADDRESS_LINE_2_PLACEHOLDER = "AddressLine2Placeholder";
		public static string ADDRESS_LINE_3_PLACEHOLDER = "AddressLine3Placeholder";
		public static string ZIP_CODE_PLACEHOLDER = "ZipCodePlaceholder";
		public static string CITY_PLACEHOLDER = "CityPlaceholder";
		public static string STATE_PLACEHOLDER = "StatePlaceholder";
		public static string COUNTRY_PLACEHOLDER = "CountryPlaceholder";
		public static string PHONE_NUMBER_PLACEHOLDER = "PhoneNumberPlaceholder";
		public static string ALTERNATE_PHONE_NUMBER_PLACEHOLDER = "AlternatePhoneNumberPlaceholder";
		public static string WORK_PHONE_PLACEHOLDER = "WorkPhonePlaceholder";
		public static string MOBILE_PHONE_PLACEHOLDER = "MobilePhonePlaceholder";
		public static string EMAIL_PLACEHOLDER = "EmailPlaceholder";
		public static string TAX_NUMBER_PLACEHOLDER = "TaxNumberPlaceholder";
		public static string ELECTRONIC_ID_PLACEHOLDER = "ElectronicIdPlaceholder";
		public static string DISCOUNT_PLACEHOLDER = "DiscountPlaceholder";
		public static string CUSTOMER_GROUP_PLACEHOLDER = "CustomerGroupPlaceholder";
		public static string COMPANY_TYPE_PLACEHOLDER = "CompanyTypePlaceholder";
		public static string PERSONAL_DETAIL_SEGMENT = "PersonalDetailSegment";
		public static string ADDRESS_DETAIL_SEGMENT = "AddressDetailSegment";
		public static string CONTACT_SECTION_TITLE = "ContactSectionTitle";
		public static string ACCOUNTING_SECTION_TITLE = "AccountingSectionTitle";
		public static string MISCELLANEOUS_SECTION_TITLE = "MiscellaneousSectionTitle";
		public static string BILLING_ADDRESS_SECTION_TITLE = "BillingAddressSectionTitle";
		public static string SHIPPING_ADDRESS_SECTION_TITLE = "ShippingAddressSectionTitle";
		public static string ADD_TO_TRANSACTION_TITLE = "AddToTransactionTitle";
		public static string PRODUCTS_SCREEN_TITLE = "ProductsScreenTitle";
		public static string ITEM_CODE_CELL = "ItemCodeCell";
		public static string DESCRIPTION_CELL = "DescriptionCell";
		public static string UOM_CELL = "UOMCell";
		public static string PRICE_LABEL = "PriceLabel";
		public static string SALE_DISCOUNT_LABEL = "SaleDiscountLabel";
		public static string TOTAL_PRICE_LABEL = "TotalPriceLabel";
		public static string QUANTITY_CELL = "QuantityCell";
		public static string PRICE_CELL = "PriceCell";
		public static string TAX_CODE_CELL = "TaxCodeCell";
		public static string TAX_AMOUNT_CELL = "TaxAmountCell";
		public static string MANUAL_DISCOUNT_CELL = "ManualDiscountCell";
		public static string BATCH_SERIAL_CELL = "BatchSerialCell";
		public static string SALES_PERSON_CELL = "SalesPersonCell";
		public static string SURCHARGE_CELL = "SurchargeCell";

		public static string GetString (string key)
		{
			return NSBundle.MainBundle.LocalizedString (key, null);
		}
	}
}

