using System;
using CXS.Mpos.Core;

namespace CXS.Mpos.Core.Tests
{
	public class FirstOperation : Operation
	{
		public override void Execute ()
		{
			SaveResult ("1", 1);
		}
	}
}

