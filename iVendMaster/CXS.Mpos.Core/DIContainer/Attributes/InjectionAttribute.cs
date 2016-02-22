using System;

namespace CXS.Mpos.Core
{
	[AttributeUsage (AttributeTargets.All)]
	public class InjectionAttribute : Attribute
	{
		public readonly string Name;

		public InjectionAttribute (string name = null)
		{
			Name = name;
		}

		public InjectionAttribute ()
		{
		}
	}
}

