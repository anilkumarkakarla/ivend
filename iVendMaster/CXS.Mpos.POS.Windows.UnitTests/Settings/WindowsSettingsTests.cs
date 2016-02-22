using System;
using System.Threading;
using System.Collections.Generic;
using CXS.Mpos.Core;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using CXS.Mpos.POS;

namespace CXS.Mpos.POS.Windows.UnitTests
{
    [TestClass]
    public class SettingsTest
    {

        private SettingsService SettingsService;

        [TestInitialize]
        public void SetupTests()
        {

            SettingsService = new SettingsService();

            DependencyConfig config = new DependencyConfig();
            Parameters parameters = new Parameters();
            config.Define(typeof(IUserPreferences), typeof(WindowsUserPreferences));
            config.Define (typeof(ISettingsService), typeof(SettingsService));
            DependencyContainer container = new DependencyContainer(config);
            container.ResolveDependencies(SettingsService, parameters);
        }

        [TestMethod]
        public void TestStringSetting()
        {
            string testValue = "TestValue";
            string testId = "StringSetting";
            Setting testSetting = new Setting(testId, typeof(string), testValue);
            List<Setting> settings = new List<Setting>();
            settings.Add(testSetting);
            SettingsService.Initialize(settings);

            Setting outputSetting = SettingsService.GetSetting(testId);
            string outputValue = (string)outputSetting.Value;

            Assert.IsTrue(outputValue.Equals(testValue));
        }

        [TestMethod]
        public void TestIntSetting()
        {
            int testValue = 42;
            string testId = "IntSetting";
            Setting testSetting = new Setting(testId, typeof(int), (object)testValue);
            List<Setting> settings = new List<Setting>();
            settings.Add(testSetting);
            SettingsService.Initialize(settings);

            Setting outputSetting = SettingsService.GetSetting(testId);
            int outputValue = (int)outputSetting.Value;

            Assert.IsTrue(outputValue == testValue);
        }

        [TestMethod]
        public void TestFloatSetting()
        {
            float testValue = 42.5f;
            string testId = "FloatSetting";
            Setting testSetting = new Setting(testId, typeof(float), (object)testValue);
            List<Setting> settings = new List<Setting>();
            settings.Add(testSetting);
            SettingsService.Initialize(settings);

            Setting outputSetting = SettingsService.GetSetting(testId);
            float outputValue = (float)outputSetting.Value;
            Assert.IsTrue(outputValue == testValue);
        }

        [TestMethod]
        public void TestDoubleSetting()
        {
            double testValue = 42.5f;
            string testId = "DoubleSetting";
            Setting testSetting = new Setting(testId, typeof(float), (object)testValue);
            List<Setting> settings = new List<Setting>();
            settings.Add(testSetting);
            SettingsService.Initialize(settings);

            Setting outputSetting = SettingsService.GetSetting(testId);
            double outputValue = (double)outputSetting.Value;
            Assert.IsTrue(outputValue == testValue);
        }

        [TestMethod]
        public void TestBoolSetting()
        {
            Boolean testValue = true;
            string testId = "BoolSetting";
            Setting testSetting = new Setting(testId, typeof(Boolean), (object)testValue);
            List<Setting> settings = new List<Setting>();
            settings.Add(testSetting);
            SettingsService.Initialize(settings);

            Setting outputSetting = SettingsService.GetSetting(testId);
            Boolean outputValue = (Boolean)outputSetting.Value;

            Assert.IsTrue(outputValue == testValue);
        }

        [TestMethod]
        public void TestInitializationOperation ()
        {
            Setting setting1 = new Setting ("setting1", typeof(int), 42);
            Setting setting2 = new Setting ("setting2", typeof(string), "fortytwo");

            List<Setting> settings = new List<Setting> ();
            settings.Add (setting1);
            settings.Add (setting2);

            Parameters parameters = new Parameters();
            parameters ["Settings"] = settings;

            var settingsIntializationExpectation = new AutoResetEvent (false);

            OperationProcessor op = OperationProcessor.Instance;
            op.PerformOperation (typeof(InitializeSettingsOperation), parameters, (Parameters result) => {
                settingsIntializationExpectation.Set ();
            });

            Assert.IsTrue (settingsIntializationExpectation.WaitOne (TimeSpan.FromSeconds (10)));
        }
    }
}
