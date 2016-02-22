using System;

namespace CXS.Mpos.Core
{
	public class InjectionRequiredAttribute : InjectionAttribute
	{
		public InjectionRequiredAttribute (string name) : base (name)
		{
		}

		public InjectionRequiredAttribute ()
		{
		}
	}
}

