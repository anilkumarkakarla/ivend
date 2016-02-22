using System;
using System.Reflection;

namespace CXS.Mpos.Core
{
	public class DependencyTemplate
	{
		public Parameters Parameters;
		public Type Type;

		public DependencyTemplate ()
		{
		}

		public DependencyTemplate(Type type, Parameters parameters)
		{
			this.Type = type;
			Parameters = new Parameters ();
			Parameters.AddParameters (parameters);
		}
	}
}