using System;
using CXS.Mpos.Core;

namespace CXS.Mpos.Core.Tests
{
	public class MockDataBasePathService
	{
		public MockDataBasePathService ()
		{
		}

		public DataBaseService GetDataBaseService ()
		{
			string DataBasePath = System.IO.Path.Combine (Environment.CurrentDirectory, "database.db");
			return new DataBaseService (DataBasePath);
		}
	}
}

