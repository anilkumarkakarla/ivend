using System;

using NUnit.Framework;

namespace CXS.Mpos.POS.Android.UnitTests
{
	[TestFixture]
	public class AndroidUserPreferencesTests
	{

		[Test]
		public void ValueSavigTest ()
		{
			AndroidUserPreferences testObject = new AndroidUserPreferences ();

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

			Assert.True (testStringSave == testStringLoad);
			Assert.True (testIntSave == testIntLoad);
			Assert.True (testBoolSave == testBoolLoad);
			Assert.True (testFloatSave == testFloatLoad);
			Assert.True (testDoubleSave == testDoubleLoad);
			Assert.True (testLongSave == testLongLoad);
			Assert.True (testLongSave2 == testLongLoad2);
		}

		[Test]
		public void WrongTypeSavigTest ()
		{
			AndroidUserPreferences testObject = new AndroidUserPreferences ();
			testObject.ClearSaves ();

			Object wrongObject = new Object ();
			testObject.SetValue ("WrongTypeSavigTest", wrongObject);
			var testWhatLoad = testObject.GetValue<string> ("WrongTypeSavigTest");
			Assert.False (wrongObject.Equals (testWhatLoad));
		}

		[Test]
		public void NotSavedValueTest ()
		{
			AndroidUserPreferences testObject = new AndroidUserPreferences ();
			testObject.ClearSaves ();

			var testWhatLoad = testObject.GetValue<string> ("NotSavedValueTest");
			Assert.True (testWhatLoad == null);
		}
	}
}