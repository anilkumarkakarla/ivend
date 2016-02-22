using System;

namespace CXS.Mpos.Core.Tests
{
	public class DITestClass
	{
		[InjectionOptional ("StringProperty1")]
		public string StringProperty { get; set; }

		[InjectionRequired]
		public string StringProperty2 { get; set; }

		[InjectionOptional]
		public string StringProperty3 { get; set; }

		[InjectionOptional]
		public DITestInterface InterfaceProperty { get; set; }
	}
}

