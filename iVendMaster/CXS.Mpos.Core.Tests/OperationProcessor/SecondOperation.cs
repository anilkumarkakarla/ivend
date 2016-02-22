using System;
using CXS.Mpos.Core;

namespace CXS.Mpos.Core.Tests
{
	public class SecondOperation : Operation
	{
		public override void Execute ()
		{
			SaveResult ("2", 2);
		}
	}
}
