using System;

namespace CXS.Mpos.Core.Tests
{
	public class LoadUserOperation : Operation
	{
		public override void Execute ()
		{
			User user = new User ();
			user.Privileges.Add ("RUN_OPERATION");
			SaveUserScope ("User", user);
		}
	}
}

