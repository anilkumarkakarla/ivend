using System;
using NUnit.Framework;
using CXS.Mpos.Core;

namespace CXS.Mpos.POS.iOS.UnitTests
{
	[TestFixture]
	public class UserPreferencesTest
	{
		private const string STRING_TEST_KEY = "StringTestKey";
		private const string INT_TEST_KEY = "IntTestKey";
		private const string BOOL_TEST_KEY = "BoolTestKey";
		private const string FLOAT_TEST_KEY = "FloatTestKey";
		private const string DOUBLE_TEST_KEY = "DoubleTestKey";
		private const string LONG_TEST_KEY = "LongTestKey";

		private UserPreferences UserPreferences;

		[SetUp]
		public void SetupTests () {
			LogStorage.Initialize (new LogConfiguration());
			UserPreferences = new UserPreferences ();
			UserPreferences.ClearSaves ();
		}

		[Test]
		public void StringSavingTest ()
		{
			string stringValue = "StringSavingTest";
			UserPreferences.SetValue (STRING_TEST_KEY, stringValue);
			string stringRetValue = UserPreferences.GetValue<string> (STRING_TEST_KEY);
			Assert.True (stringValue.Equals (stringRetValue));
		}

		[Test]
		public void IntSavingTest ()
		{
			int intValue = 42;
			UserPreferences.SetValue (INT_TEST_KEY, intValue);
			int intRetValue = UserPreferences.GetValue<int> (INT_TEST_KEY);
			Assert.True (intValue == intRetValue);
		}

		[Test]
		public void BoolSavingTest ()
		{
			bool boolValue = true;
			UserPreferences.SetValue (BOOL_TEST_KEY, boolValue);
			bool boolRetValue = UserPreferences.GetValue<bool> (BOOL_TEST_KEY);
			Assert.True (boolValue == boolRetValue);
		}

		[Test]
		public void FloatSavingTest ()
		{
			float floatValue = 11.5F;
			UserPreferences.SetValue (FLOAT_TEST_KEY, floatValue);
			float floatRetValue = UserPreferences.GetValue<float> (FLOAT_TEST_KEY);
			Assert.True (floatValue == floatRetValue);
		}

		[Test]
		public void DoubleSavingTest ()
		{
			double doubleValue = 23.23;
			UserPreferences.SetValue (DOUBLE_TEST_KEY, doubleValue);
			double doubleRetValue = UserPreferences.GetValue<double> (DOUBLE_TEST_KEY);
			Assert.True (doubleValue == doubleRetValue);
		}

		[Test]
		public void LongSavingTest ()
		{
			long longValue = 9223372036854775807L;
			UserPreferences.SetValue (LONG_TEST_KEY, longValue);
			long longRetValue = UserPreferences.GetValue<long> (LONG_TEST_KEY);
			Assert.True (longValue == longRetValue);
		}

		[Test]
		public void IncorrectObjectSavingTest ()
		{
			object objectValue = new Object ();
			UserPreferences.SetValue (STRING_TEST_KEY, objectValue);
			object objectRetValue = UserPreferences.GetValue<string> (STRING_TEST_KEY);
			Assert.False (objectValue.Equals (objectRetValue));
		}

		[Test]
		public void NullObjectGettingTest ()
		{
			string stringValue = UserPreferences.GetValue<string> (STRING_TEST_KEY);
			Assert.True (stringValue == null);
		}
	}
}

