using UniversalForm.Client.Persistence;

namespace UniversalForm.Client.Model
{
    public class StatisticsModel
    {
        private readonly List<FillStatistic> Statistics;
        private int _questionCount;
        public StatisticsModel(List<FillStatistic> stats)
        {
            Statistics = stats;
            _questionCount = stats[0].QuestionStatistics.Count;
        }
        public int GetSubmissionCount()
        {
            return Statistics.Count;
        }
        public int GetQuestionCount()
        {
            return _questionCount;
        }
        public List<string> GetSubbmitters(bool isAnonym)
        {
            if (isAnonym)
            {
                int i = 1;
                return Statistics.Select(x => x.UserName + $"#{i++}").ToList();
            }
            else
                return Statistics.Select(x => x.UserName).ToList();
        }
        public List<DateTime> GetSubmissionDates()
        {
            return Statistics.Select(x => x.Date).ToList();
        }
        public double GetAllAverageTime()
        {
            return Statistics.Sum(x => x.QuestionStatistics.Sum(y => y.Time)) / Statistics.Count;
        }
        public double GetAllAverageLostFocus()
        {
            return Statistics.Sum(x => x.QuestionStatistics.Sum(y => y.LostFocusTime)) / Statistics.Count;
        }

        public double GetAllAverageCorrections()
        {
            return Statistics.Sum(x => x.QuestionStatistics.Sum(y => y.Corrections)) / Statistics.Count;
        }
        public List<long> GetQuestionAverageTimes()
        {
            List<long> back = new();
            for (int i = 0; i < _questionCount; i++)
            {
                back.Add(Statistics.Sum(x => x.QuestionStatistics[i].Time) / Statistics.Count);
            }
            return back;
        }
        public List<long> GetQuestionAverageLostFocusTimes()
        {
            List<long> back = new();
            for (int i = 0; i < _questionCount; i++)
            {
                back.Add(Statistics.Sum(x => x.QuestionStatistics[i].LostFocusTime) / Statistics.Count);
            }
            return back;
        }
        public List<int> GetQuestionAverageCorrections()
        {
            List<int> back = new();
            for (int i = 0; i < _questionCount; i++)
            {
                back.Add(Statistics.Sum(x => x.QuestionStatistics[i].Corrections) / Statistics.Count);
            }
            return back;
        }
        public Dictionary<string, int> GetAnswersOfQuestion(int index)
        {
            Dictionary<string, int> back = new();
            foreach (var stat in Statistics)
            {
                foreach (var answer in stat.QuestionStatistics[index].GetMultipleAnswers())
                {
                    if (back.ContainsKey(answer))
                    {
                        back[answer]++;
                    }
                    else
                    {
                        back.Add(answer, 1);
                    }
                }
            }
            return back;
        }
        public List<long> GetTimesOfQuestion(int index)
        {
            return Statistics.Select(x => x.QuestionStatistics[index].Time).ToList();
        }
        public List<long> GetLostFocusTimesOfQuestion(int index)
        {
            return Statistics.Select(x => x.QuestionStatistics[index].LostFocusTime).ToList();
        }
        public List<int> GetCorrectionsOfQuestion(int index)
        {
            return Statistics.Select(x => x.QuestionStatistics[index].Corrections).ToList();
        }
        public List<long> GetSubmitterTimes(int index)
        {
            return Statistics[index].QuestionStatistics.Select(x => x.Time).ToList();
        }
        public List<long> GetSubmitterTimes(string userName)
        {
            return GetSubmitterTimes(Statistics.FindIndex(x => x.UserName == userName));
        }
        public List<long> GetSubmitterLostFocusTimes(int index)
        {
            return Statistics[index].QuestionStatistics.Select(x => x.LostFocusTime).ToList();
        }
        public List<long> GetSubmitterLostFocusTimes(string userName)
        {
            return GetSubmitterLostFocusTimes(Statistics.FindIndex(x => x.UserName == userName));
        }
        public List<int> GetSubmitterCorrections(int index)
        {
            return Statistics[index].QuestionStatistics.Select(x => x.Corrections).ToList();
        }
        public List<int> GetSubmitterCorrections(string userName)
        {
            return GetSubmitterCorrections(Statistics.FindIndex(x => x.UserName == userName));
        }
        public List<HashSet<string>> GetSubmitterAnswers(int index)
        {
            return Statistics[index].QuestionStatistics.Select(x => x.GetMultipleAnswers()).ToList();
        }
        public List<HashSet<string>> GetSubmitterAnswers(string userName)
        {
            return GetSubmitterAnswers(Statistics.FindIndex(x => x.UserName == userName));
        }
        public DateTime GetSubmitterDate(int index)
        {
            return Statistics[index].Date;
        }
        public DateTime GetSubmitterDate(string userName)
        {
            return GetSubmitterDate(Statistics.FindIndex(x => x.UserName == userName));
        }
    }
}
