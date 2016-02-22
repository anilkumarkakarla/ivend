using System;

namespace CXS.Mpos.Core
{
	public interface IUserPreferences
	{
		void SetValue (string key, object anyValue);

		T GetValue<T> (string key);

		object GetValue (Type type, string key);

		void ClearSaves ();

		bool DoesValueExist (string key);
	}
}