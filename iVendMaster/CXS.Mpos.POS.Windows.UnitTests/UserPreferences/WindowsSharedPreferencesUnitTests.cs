using System;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;

namespace CXS.Mpos.POS.Windows.UnitTests
{
	[TestClass]
	public class WindowsSharedPreferencesUnitTests
	{
		[TestMethod]
		public void TestMethod1 ()
		{
			Assert.IsTrue (true);
		}

		[TestMethod]
		public void ValueSavigTest ()
		{
			WindowsUserPreferences testObject = new WindowsUserPreferences ();

			testObject.ClearSaves ();

			string testStringSave = "ValueSavigTest";
			int testIntSave = 42;
			bool testBoolSave = true;
			float testFloatSave = 11.5F;
			double testDoubleSave = 23.23;
			long testLongSave = 9223372036854775807;
			long testLongSave2 = 64L;

			testObject.SetValue ("ItemName", testStringSave);
			testObject.SetValue ("ItemPrise", testIntSave);
			testObject.SetValue ("ItemOnStorage", testBoolSave);
			testObject.SetValue ("ItemSize", testFloatSave);
			testObject.SetValue ("ItemSubSize", testDoubleSave);
			testObject.SetValue ("ItemCode", testLongSave);
			testObject.SetValue ("ItemCode2", testLongSave2);

			var testStringLoad = testObject.GetValue<string> ("ItemName");
			var testIntLoad = testObject.GetValue<int> ("ItemPrise");
			var testBoolLoad = testObject.GetValue<bool> ("ItemOnStorage");
			var testFloatLoad = testObject.GetValue<float> ("ItemSize");
			var testDoubleLoad = testObject.GetValue<double> ("ItemSubSize");
			var testLongLoad = testObject.GetValue<long> ("ItemCode");
			var testLongLoad2 = testObject.GetValue<long> ("ItemCode2");

			Assert.IsTrue (testStringSave == testStringLoad);
			Assert.IsTrue (testIntSave == testIntLoad);
			Assert.IsTrue (testBoolSave == testBoolLoad);
			Assert.IsTrue (testFloatSave == testFloatLoad);
			Assert.IsTrue (testDoubleSave == testDoubleLoad);
			Assert.IsTrue (testLongSave == testLongLoad);
			Assert.IsTrue (testLongSave2 == testLongLoad2);
		}

		[TestMethod]
		public void WrongTypeSavigTest ()
		{
			WindowsUserPreferences testObject = new WindowsUserPreferences ();
			testObject.ClearSaves ();
			object wrongObject = new Object ();
			testObject.SetValue ("WrongTypeSavigTest", wrongObject);
			var testWhatLoad = testObject.GetValue<string> ("WrongTypeSavigTest");
			Assert.IsTrue (testWhatLoad == null);
		}

		[TestMethod]
		public void NotSavedValueTest ()
		{
			WindowsUserPreferences testObject = new WindowsUserPreferences ();
			testObject.ClearSaves ();
			var testWhatLoad = testObject.GetValue<string> ("NotSavedValueTest");
			Assert.IsTrue (testWhatLoad == null);
		}
	}
}
