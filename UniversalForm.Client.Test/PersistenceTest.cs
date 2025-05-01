using System.Diagnostics.CodeAnalysis;
using System.Net;
using UniversalForm.Client.Model;
using UniversalForm.Client.Persistence;
using UniversalForm.Utils;

namespace UniversalForm.Client.Test
{ 

    [TestClass]
    public sealed class PersistenceTest
    {
        
        private IPersistence _persistence;
        private static FakeServer? _server = null;
        public PersistenceTest()
        {
            var iniReader = new IniReader(null);
            if (_server == null)
                _server = new FakeServer(iniReader.ReadServerAddress()!);
            Task.Run(() => _server.Start());
            _persistence = new ClientJsonPersistence(FormModel.getQuestionTypes(), iniReader.ReadServerAddress()!);
        }
        [TestMethod]
        public void LoadFormTest()
        {
            var result = _persistence.LoadForm(TestValues.FormName);
            Assert.AreEqual(result, TestValues.Form, new FormEqualityComparer(), "LoadForm failed.");
        }

        private class FormEqualityComparer : IEqualityComparer<Form>
        {
            private class QuestionEqualityComparer : IEqualityComparer<Question>
            {
                public bool Equals(Question? x, Question? y)
                {
                    return x?.GetHashCode() == y?.GetHashCode();
                }

                public int GetHashCode(Question obj)
                {
                    return obj.GetHashCode();
                }
            }
            public bool Equals(Form? x, Form? y)
            {
                if (x == null || y == null)
                    return false;

                return x.Title == y.Title &&
                       x.Description == y.Description &&
                       x.MeasureCorrections == y.MeasureCorrections &&
                       x.MeasureTime == y.MeasureTime &&
                       x.Anonymous == y.Anonymous &&
                       x.FocusTracking == y.FocusTracking &&
                       x.AllowBack == y.AllowBack &&
                       x.UserName == y.UserName &&
                       QuestionEquals(x.Questions, y.Questions);
            }

            private bool QuestionEquals(List<Question> list1, List<Question> list2)
            {
                if (list1.Count != list2.Count)
                    return false;
                for (int i = 0; i < list1.Count; i++)
                {
                    if (!list1[i].Equals(list2[i]))
                        return false;
                }
                return true;
            }

            public int GetHashCode(Form obj)
            {
                return HashCode.Combine(obj.Title, obj.Description, obj.MeasureCorrections, obj.MeasureTime,
                                        obj.Anonymous, obj.FocusTracking, obj.AllowBack, obj.UserName);
            }
        }
        [TestMethod]
        public void SaveFormTest()
        {
            var result = _persistence.SaveForm(TestValues.UserName, TestValues.FormName, TestValues.Form);
            Assert.IsTrue(result, "SaveForm failed.");
        }
        [TestMethod]
        public void LogInTest()
        {
            var result = _persistence.LogIn(TestValues.UserName, TestValues.Password);
            Assert.IsTrue(result, "LogIn failed.");
        }
        [TestMethod]
        public void GetFormsTest()
        {
            var result = _persistence.GetForms(TestValues.UserName);
            CollectionAssert.AreEqual(result, TestValues.FormList, "GetForms failed.");
        }
        [TestMethod]
        public void GetStatisticsTest() // Fail
        {
            var r2 = JsonParser.Deserialize<List<FillStatistic>>(TestValues.StatisticsString);
            var r3 = JsonParser.Serialize(TestValues.Statistics);
            var result = _persistence.GetStatistics(TestValues.FormName);
            Assert.AreEqual(result, TestValues.Statistics, new StatisticsEqualityComparer(), "GetStatistics failed.");
        }
        private class StatisticsEqualityComparer : IEqualityComparer<List<FillStatistic>>
        {
            public bool Equals(List<FillStatistic>? x, List<FillStatistic>? y)
            {
                if (x == null || y == null) return false;
                for (int i = 0; i < x.Count; i++)
                {
                    if (!EqualsStatistics(x[i], y[i])) return false;
                }
                return true;
            }
            public bool EqualsStatistics(FillStatistic x, FillStatistic y)
            {
                return x.UserName == y.UserName &&
                    x.Date == y.Date &&
                    StatisticsEquals(x.QuestionStatistics, y.QuestionStatistics);
            }
            private bool StatisticsEquals(List<Statistics> list1, List<Statistics> list2)
            {
                if (list1.Count != list2.Count)
                    return false;
                for (int i = 0; i < list1.Count; i++)
                {
                    if (list1[i].GetHashCode() != list2[i].GetHashCode())
                        return false;
                }
                return true;
            }
            public int GetHashCode(List<FillStatistic> obj)
            {
                return 0;
            }
        }
        [TestMethod]
        public void SaveFormStatisticsTest()
        {
            var result = _persistence.SaveFormStatistics(TestValues.UserName, TestValues.FormName, TestValues.StatisticsList);
            Assert.IsTrue(result, "SaveFormStatistics failed.");
        }
        [TestMethod]
        public void DeleteFormTest()
        {
            var result = _persistence.DeleteForm(TestValues.UserName, TestValues.FormName);
            Assert.IsTrue(result, "DeleteForm failed.");
        }
    }
}
