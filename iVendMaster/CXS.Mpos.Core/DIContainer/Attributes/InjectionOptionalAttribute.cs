using System;

namespace CXS.Mpos.Core
{
	public class InjectionOptionalAttribute : InjectionAttribute
	{
		public InjectionOptionalAttribute (string name) : base (name)
		{
		}

		public InjectionOptionalAttribute ()
		{
		}
	}
}

