using System;
using CXS.Mpos.Core;
using Foundation;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace CXS.Mpos.POS.iOS
{
	public class UserPreferences : IUserPreferences
	{
		private const string INCORRECT_VALUE_TYPE_ERROR = "Incorrect value type for shared preferences";
		private NSUserDefaults UserDefaults;

		public UserPreferences ()
		{
			UserDefaults = NSUserDefaults.StandardUserDefaults;
		}

		#region IUserPrefs implementation

		public void SetValue (string key, object anyValue)
		{
			Type valueType = anyValue.GetType ();
			if (valueType == typeof(string)) {
				UserDefaults.SetString ((string)anyValue, key);
			} else if (valueType == typeof(int)) {
				UserDefaults.SetInt ((int)anyValue, key);
			} else if (valueType == typeof(bool)) {
				UserDefaults.SetBool ((bool)anyValue, key);
			} else if (valueType == typeof(float)) {
				UserDefaults.SetFloat ((float)anyValue, key);
			} else if (valueType == typeof(double)) {
				UserDefaults.SetDouble ((double)anyValue, key);
			} else if (valueType == typeof(long)) {
				UserDefaults.SetValueForKey (new NSNumber((long)anyValue), new NSString(key));
			} else {
				Log.Error (INCORRECT_VALUE_TYPE_ERROR);
			}
			UserDefaults.Synchronize ();
		}

		public object GetValue (Type valueType, string key)
		{
			object value = null;
			if (valueType == typeof(string)) {
				value = UserDefaults.StringForKey (key);
			} else if (valueType == typeof(int)) {
				value = UserDefaults.IntForKey (key);
			} else if (valueType == typeof(bool)) {
				value = UserDefaults.BoolForKey (key);
			} else if (valueType == typeof(float)) {
				value = UserDefaults.FloatForKey (key);
			} else if (valueType == typeof(double)) {
				value = UserDefaults.DoubleForKey (key);
			} else if (valueType == typeof(long)) {
				value = (long)((NSNumber)UserDefaults.ValueForKey (new NSString(key)));
			} else {
				Log.Error (INCORRECT_VALUE_TYPE_ERROR);
			}

			return value;


		}

		public T GetValue<T> (string key)
		{
			Type valueType = typeof(T);

			object value = GetValue(valueType, key);

			T retValue = default(T);
			try {
				retValue = (T)Convert.ChangeType (value, valueType);
			}
			catch (Exception e) {
				Log.PrintException (e);
			}
			
			return retValue;
		}

		public void ClearSaves ()
		{
			UserDefaults.RemovePersistentDomain (NSBundle.MainBundle.BundleIdentifier);
		}

		public bool DoesValueExist (string key)
		{
			return UserDefaults[key] != null;
		}

		#endregion
	}
}

