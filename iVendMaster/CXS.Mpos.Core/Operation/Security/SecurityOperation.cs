using System;
using System.Collections.Generic;

namespace CXS.Mpos.Core
{
	public class SecurityOperation : Operation
	{
		[InjectionRequired]
		public List<string> Credentials { get; set; }

		[InjectionOptional]
		public User User { get; set; }

		public override void Execute ()
		{
			if (User == null) {
				throw new UnauthorizedAccessException ("User is required");
			}
			foreach (string credential in Credentials) {
				if (!User.Privileges.Contains (credential)) {
					throw new UnauthorizedAccessException (String.Format ("Credential {0} not found", credential));
				}
			}
		}
	}
}

