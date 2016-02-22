using System;
using System.IO;
using CXS.Mpos.POS.Windows;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using Windows.Storage;
using CXS.Mpos.POS.Windows.Services.File_Manager;
using System.Text;

namespace CXS.Mpos.POS.Windows.UnitTests.File_Manager
{
    [TestClass]
    public class FileServiceTests
    {

        private FileService FService;
        private string FilePath;

        [TestInitialize]
        public void BeforeEachTests()
        {
            FService = new FileService();

            FilePath = Path.Combine(ApplicationData.Current.LocalFolder.Path, "one.txt");

            FileStream fileStream = new FileStream(FilePath, FileMode.CreateNew);
            StreamWriter writer = new StreamWriter(fileStream);

            writer.Write("data\n");
            writer.Dispose();
        }

        [TestMethod]
        public void SaveFileTests()
        {
            FService.SaveFile("value", "key.txt");
            string filePath = Path.Combine(ApplicationData.Current.LocalFolder.Path, "key.txt");
            string result = File.ReadAllText(filePath);
            Assert.IsTrue(result.Equals("value"));
            System.IO.File.Delete(filePath);
        }

        [TestMethod]
        public void SaveFileByPathTests()
        {
            string filePath = Path.Combine(ApplicationData.Current.LocalFolder.Path, "two.txt");
            FService.SaveFileByPath("string", filePath);
            string result = File.ReadAllText(filePath);
            Assert.IsTrue(result.Equals("string"));
            System.IO.File.Delete(filePath);
        }

        [TestMethod]
        public void GetFileTests()
        {
            string result = FService.GetFile("one.txt");
            Assert.IsTrue(result.Equals("data\n"));
        }

        [TestMethod]
        public void GetFileByPathTests()
        {
            string result = FService.GetFileByPath(FilePath);
            Assert.IsTrue(result.Equals("data\n"));
        }
    }
}
