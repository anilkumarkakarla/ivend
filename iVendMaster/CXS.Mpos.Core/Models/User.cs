using System;
using System.Collections.Generic;

namespace CXS.Mpos.Core
{
	//[Serializable]
	public class User
	{
		public List<string> Privileges;
		public string UserId { get; set; }
		public string UserName { get; set; }

		public User ()
		{
			Privileges = new List<string> ();
		}
	}
}

