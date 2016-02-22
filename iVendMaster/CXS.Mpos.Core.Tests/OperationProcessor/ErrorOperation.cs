using System;
using CXS.Mpos.Core;

namespace CXS.Mpos.Core.Tests
{
	public class ErrorOperation : Operation
	{
		public override void Execute ()
		{
			throw new NotImplementedException ();
		}
	}
}

