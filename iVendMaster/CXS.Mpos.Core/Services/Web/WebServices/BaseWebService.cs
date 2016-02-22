using System;

namespace CXS.Mpos.Core
{
	public class BaseWebService
	{
		protected WebClient WebClient { get; set; }

		public BaseWebService ()
		{
			WebClient = new WebClient ();
		}
	}
}

