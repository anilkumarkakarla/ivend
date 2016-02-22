using System;

namespace CXS.Mpos.Core
{
	public abstract class Operation
	{
		private Parameters result;

		public Parameters Result {
			get {
				return result;
			}
		}

		[InjectionRequired]
		public Parameters UserScope { get; set; }

		public abstract void Execute ();

		protected void SaveResult (string key, dynamic value)
		{
			if (Result == null) {
				result = new Parameters ();
			}
			if (Result.ContainsKey (key)) {
				result [key] = value;
			} else {
				result.Add (key, value);
			}
		}

		protected void SaveUserScope (string key, dynamic value)
		{
			if (UserScope.ContainsKey (key)) {
				UserScope [key] = value;
			} else {
				UserScope.Add (key, value);
			}
		}
	}
}

