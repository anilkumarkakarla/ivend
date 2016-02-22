using System;
using CXS.Mpos.Core;

namespace CXS.Mpos.POS.Tests
{
	public class LoadUserScopeOperation : Operation
	{
		public override void Execute ()
		{
			var userString = "User test string";
			SaveUserScope ("UserString", userString);
		}
	}
}

