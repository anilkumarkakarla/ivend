using System;

namespace CXS.Mpos.Core.Tests
{
	public class DependenciesOptionalOperation : Operation
	{
		[InjectionOptional]
		public string Count { get; set; }

		public override void Execute ()
		{
			if (Count == null) {
				Count = "1";
			}

			SaveResult ("Count", Count);
		}
	}
}