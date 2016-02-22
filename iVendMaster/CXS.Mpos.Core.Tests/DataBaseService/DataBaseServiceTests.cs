using NUnit.Framework;
using System.Collections.Generic;
using CXS.Mpos.Core;
using CXS.Mpos.POS;
using System;

namespace CXS.Mpos.Core.Tests
{
	[TestFixture ()]
	public class DataBaseServiceTest
	{
		DataBaseService DatabaseService;
		static private string TEST_CREATE_TABLE_REQUEST = "CREATE TABLE DataBaseItem(Id VARCHAR,  Title VARCHAR)";

		[SetUp]
		public void BeforeTests ()
		{
			MockDataBasePathService mockDBService = new MockDataBasePathService ();
			DatabaseService = mockDBService.GetDataBaseService ();
		}

		[Test ()]
		public void TestInitializationDataBase()
		{
			DatabaseService.Initialize ("dbDemo");
		}

		[Test ()]
		public void TestCreateTableRequest ()
		{
			DataBaseRequest ctReq = new DataBaseRequest (TEST_CREATE_TABLE_REQUEST);
			DatabaseService.Initialize (ctReq);
		}

		[Test ()]
		public void TestInsertRequest ()
		{
			DataBaseInsertRequest iReq = new DataBaseInsertRequest ("DataBaseItem", "Id, Title", "'3', 'Dog'");
			var result = DatabaseService.PerformRequest<DataBaseItem> (iReq);

			Assert.NotNull (result);
		}

		[Test ()]
		public void TestSelectRequest ()
		{
			DataBaseSelectRequest sReq = new DataBaseSelectRequest ("DataBaseItem", "Id, Title", "Id = '3'");
			var result = DatabaseService.PerformRequest<DataBaseItem> (sReq);
			Assert.NotNull (result);
		}


		[Test ()]
		public void TestUpdateRequest ()
		{
			DataBaseUpdateRequest uReq = new DataBaseUpdateRequest ("DataBaseItem", "Title = 'Cat'", "Id = '3'");
			var result = DatabaseService.PerformRequest<DataBaseItem> (uReq);
			Assert.NotNull (result);
		}

	}
}