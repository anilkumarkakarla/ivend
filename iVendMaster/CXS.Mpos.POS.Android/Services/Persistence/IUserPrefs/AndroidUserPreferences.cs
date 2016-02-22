using Android.App;
using Android.Content;
using Android.Preferences;
using CXS.Mpos.Core;
using System;

namespace CXS.Mpos.POS.Android
{
	public class AndroidUserPreferences : IUserPreferences
	{
		ISharedPreferences AndroidSharedPreferences;

		public AndroidUserPreferences ()
		{
			AndroidSharedPreferences = PreferenceManager.GetDefaultSharedPreferences (Application.Context);
		}

		public void ClearSaves ()
		{
			AndroidSharedPreferences = PreferenceManager.GetDefaultSharedPreferences (Application.Context);
			ISharedPreferencesEditor sharedPreferencesEditor = AndroidSharedPreferences.Edit ();
			sharedPreferencesEditor.Clear ();
			sharedPreferencesEditor.Apply ();
		}

		#region IUserPrefs implementation

		public void SetValue (string key, object anyValue)
		{
			Type valueType = anyValue.GetType ();

			if (valueType == typeof (string))
			{
				string stringValue = (string)anyValue;
				SetStringObject (key, stringValue);
			}
			else if (valueType == typeof (int))
			{
				int itnValue = (int)anyValue;
				SetIntObject (key, itnValue);
			}
			else if (valueType == typeof (bool))
			{
				bool boolValue = (bool)anyValue;
				SetBoolObject (key, boolValue);
			}
			else if (valueType == typeof (float))
			{
				float floatValue = (float)anyValue;
				SetFloatObject (key, floatValue);
			}
			else if (valueType == typeof (long))
			{
				long longValue = (long)anyValue;
				SetLongObject (key, longValue);
			}
			else if (valueType == typeof (double))
			{
				double doubleValue = (double)anyValue;
				SetDoubleObject (key, doubleValue);
			}
			else
			{
				Log.Debug ("Value type for shared preference error");
			}
		}

		public object GetValue (Type keyType, string key)
		{
			object value = null;

			if (keyType == typeof (string))
			{
				value = Convert.ChangeType (GetStringObject (key), keyType);
			}
			else if (keyType == typeof (int))
			{
				value = Convert.ChangeType (GetIntObject (key), keyType);
			}
			else if (keyType == typeof (bool))
			{
				value = Convert.ChangeType (GetBoolObject (key), keyType);
			}
			else if (keyType == typeof (float))
			{
				value = Convert.ChangeType (GetFloatObject (key), keyType);
			}
			else if (keyType == typeof (long))
			{
				value = Convert.ChangeType (GetLongObject (key), keyType);
			}
			else if (keyType == typeof (double))
			{
				value = Convert.ChangeType (GetDoubleObject (key), keyType);
			}
			else
			{
				Log.Debug ("Key type for shared preference error");
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

		public bool DoesValueExist(string key)
		{
			return AndroidSharedPreferences.Contains (key);
		}

		#endregion

		private void SetStringObject (string stringKey, string stringValue)
		{
			AndroidSharedPreferences = PreferenceManager.GetDefaultSharedPreferences (Application.Context);
			ISharedPreferencesEditor spEditor = AndroidSharedPreferences.Edit ();
			spEditor.PutString (stringKey, stringValue);
			spEditor.Apply ();
		}

		private string GetStringObject (string stringKey)
		{
			AndroidSharedPreferences = PreferenceManager.GetDefaultSharedPreferences (Application.Context);
			string stringValue = AndroidSharedPreferences.GetString (stringKey, null);
			return stringValue;
		}

		private void SetIntObject (string intKey, int intValue)
		{
			AndroidSharedPreferences = PreferenceManager.GetDefaultSharedPreferences (Application.Context);
			ISharedPreferencesEditor spEditor = AndroidSharedPreferences.Edit ();
			spEditor.PutInt (intKey, intValue);
			spEditor.Apply ();
		}

		private int GetIntObject (string intKey)
		{
			int intValue = AndroidSharedPreferences.GetInt (intKey, 0);
			return intValue;
		}

		private void SetBoolObject (string boolKey, bool boolValue)
		{
			AndroidSharedPreferences = PreferenceManager.GetDefaultSharedPreferences (Application.Context);
			ISharedPreferencesEditor spEditor = AndroidSharedPreferences.Edit ();
			spEditor.PutBoolean (boolKey, boolValue);
			spEditor.Apply ();
		}

		private bool GetBoolObject (string boolKey)
		{
			bool boolValue = AndroidSharedPreferences.GetBoolean (boolKey, false);
			return boolValue;
		}

		private void SetFloatObject (string floatKey, float floatValue)
		{
			AndroidSharedPreferences = PreferenceManager.GetDefaultSharedPreferences (Application.Context);
			ISharedPreferencesEditor spEditor = AndroidSharedPreferences.Edit ();
			spEditor.PutFloat (floatKey, floatValue);
			spEditor.Apply ();
		}

		private float GetFloatObject (string floatKey)
		{
			float floatValue = AndroidSharedPreferences.GetFloat (floatKey, 0);
			return floatValue;
		}

		private void SetDoubleObject (string doubleKey, double doubleValue)
		{
			AndroidSharedPreferences = PreferenceManager.GetDefaultSharedPreferences (Application.Context);
			ISharedPreferencesEditor spEditor = AndroidSharedPreferences.Edit ();
			long doubleToLong = Java.Lang.Double.DoubleToLongBits (doubleValue);
			spEditor.PutLong (doubleKey, doubleToLong);
			spEditor.Apply ();
		}

		private double GetDoubleObject (string doubleKey)
		{
			long doubleValueAsLong = AndroidSharedPreferences.GetLong (doubleKey, 0);
			double doubleValue = Java.Lang.Double.LongBitsToDouble (doubleValueAsLong);
			return doubleValue;
		}

		private void SetLongObject (string longKey, long longValue)
		{
			AndroidSharedPreferences = PreferenceManager.GetDefaultSharedPreferences (Application.Context);
			ISharedPreferencesEditor spEditor = AndroidSharedPreferences.Edit ();
			spEditor.PutLong (longKey, longValue);
			spEditor.Apply ();
		}

		private long GetLongObject (string longKey)
		{
			long longValue = AndroidSharedPreferences.GetLong (longKey, 0);
			return longValue;
		}
	}
}