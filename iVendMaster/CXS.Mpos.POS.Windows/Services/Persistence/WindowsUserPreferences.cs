using CXS.Mpos.Core;
using System;
using Windows.Storage;


namespace CXS.Mpos.POS.Windows
{
	public class WindowsUserPreferences : IUserPreferences
	{

		public WindowsUserPreferences ()
		{
			LocalSettings = ApplicationData.Current.LocalSettings;
		}

		ApplicationDataContainer LocalSettings;

		public void SetValue (string key, object anyValue)
		{
			if (TypePrimitiveOrString (anyValue))
			{
				if (LocalSettings.Values.ContainsKey (key))
				{
					if (LocalSettings.Values[key] != anyValue)
					{
						LocalSettings.Values[key] = anyValue;
					}
				}
				else
				{
					try
					{
						LocalSettings.Values.Add (key, anyValue);
					}
					catch (Exception e)
					{
						Log.PrintException(e);
					}
				}
			}
			else
			{
				Log.Debug ("Value type for shared preference error");
			}
		}


		private bool TypePrimitiveOrString (object value)
		{
			bool result = false;
			if (value.GetType () == typeof (string))
			{
				result = true;
			}
			else if (value.GetType () == typeof (int))
			{
				result = true;
			}
			else if (value.GetType () == typeof (bool))
			{
				result = true;
			}
			else if (value.GetType () == typeof (float))
			{
				result = true;
			}
			else if (value.GetType () == typeof (double))
			{
				result = true;
			}
			else if (value.GetType () == typeof (long))
			{
				result = true;
			}
			else
			{
				result = false;
			}

			return result;
		}

		public object GetValue (Type type, string key)
		{
			object value = null;
			if (LocalSettings.Values.ContainsKey (key))
			{
				value = LocalSettings.Values[key];
			}

			return value;
		}

		public T GetValue<T> (string key)
		{
			return (T)GetValue(typeof(T), key);
		}

		public void ClearSaves ()
		{
			LocalSettings.Values.Clear ();
		}

		public bool DoesValueExist (string key)
		{
			return LocalSettings.Values.ContainsKey (key);
		}
	}
}