using System;
using CXS.Mpos.Core;

namespace CXS.Mpos.POS.Tests
{
	public class CheckUserScopeOperation : Operation
	{
		public override void Execute ()
		{
			if (UserScope.Count > 0) {
				throw new Exception ();
			}
		}
	}
}

