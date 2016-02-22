using System;

namespace CXS.Mpos.Core.Tests
{
	public class DependenciesRequiredOperation : Operation
	{
		[InjectionRequired]
		public string Count { get; set; }

		public override void Execute ()
		{
			if (Count.Equals ("1")) {
				Count = "2";
			}

			SaveResult ("Count", Count);
		}
	}
}

