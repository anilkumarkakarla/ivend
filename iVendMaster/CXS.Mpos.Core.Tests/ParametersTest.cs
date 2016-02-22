using System;
using NUnit.Framework;


namespace CXS.Mpos.Core.Tests
{
	[TestFixture ()]
	public class ParametersTest
	{
		[Test ()]
		public void AddParametersTest ()
		{
			Parameters param = new Parameters ();
			param ["key1"] = 1;
			param ["key2"] = 2;

			Parameters subParam = new Parameters ();
			subParam ["key2"] = 4;
			subParam ["key3"] = 3;

			param.AddParameters (subParam);
			Assert.True (param.Keys.Count.Equals (3));
			Assert.True (param ["key1"].Equals(1));
			Assert.True (param ["key2"].Equals(4));
			Assert.True (param ["key3"].Equals(3));
		}
	}
}

