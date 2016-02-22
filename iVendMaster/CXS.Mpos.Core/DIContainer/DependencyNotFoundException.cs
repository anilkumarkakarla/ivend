using System;

namespace CXS.Mpos.Core
{
	public class DependencyNotFoundException : Exception
	{
		public DependencyNotFoundException ()
		{
		}

		public DependencyNotFoundException (string message) : base (message)
		{
		}

		public DependencyNotFoundException (string message, Exception inner) : base (message, inner)
		{
		}
	}
}

