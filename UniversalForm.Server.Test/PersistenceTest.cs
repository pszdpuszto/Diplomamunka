using UniversalForm.Server.Persistence;
using UniversalForms.TestUtils;

namespace UniversalForm.Server.Test
{
    [TestClass]
    public sealed class PersistenceTest
    {
        private const string TestPath = "Persistence";
        private IPersistence _persistence;
        [TestInitialize]
        public void TestInitialize()
        {
            _persistence = new BinaryPersistence(Path.Join(FileUtil.outputPath, TestPath));
        }
        [TestMethod]
        public void CheckLoginTest()
        {
            string userName = "testUserToRead";
            string password = "testPassword";
            var result = _persistence.CheckLogin(userName, password);
            Assert.AreEqual(IPersistence.LoginResult.SUCCESS, result, "Login failed.");
        }
        [TestMethod]
        public void RegisterUserTest()
        {
            string userName = "testUser";
            string password = "testPassword";
            bool result = _persistence.RegisterUser(userName, password);
            Assert.IsTrue(result, "User registration failed.");
            var loginResult = _persistence.CheckLogin(userName, password);
            Assert.AreEqual(IPersistence.LoginResult.SUCCESS, loginResult, "Login after registration failed.");
        }
        [TestMethod]
        public void GetJsonFormTest()
        {
            string formName = "testFormToRead";
            string jsonStr = _persistence.GetJsonForm(formName);
            Assert.IsTrue(FileUtil.CompareToFile(jsonStr, FilePath("testFormForm")), "GetJsonForm failed.");
        }
        [TestMethod]
        public void GetJsonStatisticsTest()
        {
            string jsonStr = _persistence.GetJsonStatistics("testFormToRead");
            Assert.IsTrue(FileUtil.CompareToFile(jsonStr, FilePath("testFormStat")), "GetJsonStatistics failed.");
        }
        [TestMethod]
        public void SaveFormTest()
        {
            // Depends on GetJsonForm
            string readStr = _persistence.GetJsonForm("testFormToRead");
            var result = _persistence.SaveForm("testUserToAppend", "testFormSaved", readStr);
            Assert.IsTrue(result, "SaveForm failed.");
            Assert.IsTrue(FileUtil.CompareFiles(FilePath("testFormSaved.uff")), "SaveForm failed.");
            Assert.IsTrue(FileUtil.CompareFiles(FilePath("testUserToAppend.ufu")), "SaveForm user update failed.");
        }
        [TestMethod]
        public void SaveStatisticsTest()
        {
            // Depends on GetJsonStatistics
            string readStr = _persistence.GetJsonStatistics("testFormToRead");
            var result = _persistence.SaveStatistics("testFormSaved", readStr);
            Assert.IsTrue(result, "SaveStatistics failed.");
            Assert.IsTrue(FileUtil.CompareFiles(FilePath("testFormSaved.ufs")), "SaveStatistics failed.");
        }
        [TestMethod]
        public void GetFormsTest()
        {
            string userName = "testUserToRead2";
            var result = _persistence.GetForms(userName);
            Assert.IsTrue(FileUtil.CompareToFile(result, FilePath("testUserForms")), "GetForms failed.");
        }
        [TestMethod]
        public void DeleteFormTest()
        {
            string userName = "testUserToDelete";
            string formName = "testFormToDelete";
            var result = _persistence.DeleteForm(userName, formName);
            Assert.IsTrue(result, "DeleteForm failed.");
            Assert.IsFalse(File.Exists(FilePath("testFormToDelete.uff")), "DeleteForm form deletion failed.");
            Assert.IsFalse(File.Exists(FilePath("testFormToDelete.ufs")), "DeleteForm stat deletion failed.");
            Assert.IsTrue(FileUtil.CompareFiles(FilePath("testUserToDelete.ufu")), "DeleteForm user update failed.");
        }
        public void DeleteUserTest()
        {
            string userName = "testUserToFullDelete";
            var result = _persistence.DeleteUser(userName);
            Assert.IsTrue(result, "DeleteUser failed.");
            Assert.IsFalse(File.Exists(FilePath("testUserToDelete.ufu")), "DeleteUser user file deletion failed.");
            Assert.IsFalse(File.Exists(FilePath("testFormToUserDelete.uff")), "DeleteUser form file deletion failed.");
            Assert.IsFalse(File.Exists(FilePath("testFormToUserDelete.ufs")), "DeleteUser stat file deletion failed.");
        }
        private string FilePath(string fileName)
        {
            return Path.Combine(TestPath, fileName);
        }
    }
}
