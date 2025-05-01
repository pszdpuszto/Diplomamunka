using System.Text.Json.Serialization;

namespace UniversalForm.Client.Persistence
{
    public struct FillStatistic
    {
        public string UserName;

        public DateTime Date;
        public List<Statistics> QuestionStatistics;
    }
    public class Statistics
    {
        public bool MultipleAnswers { get; set; } = false;
        [JsonInclude]
        private HashSet<string> Answers { get; set; } = new();
        public int Corrections { get; set; } = 0;
        public long Time { get; set; } = 0;
        public long LostFocusTime { get; set; } = 0;
        public event EventHandler<bool>? HasAnserChanged;
        public Statistics() { }
        public Statistics(bool multipleAnswers, HashSet<string> answers, int corrections, long time, long lostFocusTime)
        {
            MultipleAnswers = multipleAnswers;
            Answers = answers;
            Corrections = corrections;
            Time = time;
            LostFocusTime = lostFocusTime;
        }

        public static Statistics operator +(Statistics? left, Statistics right)
        {
            if (left == null)
            {
                return right;
            }
            if (left.MultipleAnswers)
            {
                left.Answers.UnionWith(right.Answers);
            }
            else
            {
                left.Answers = new();
                left.Answers.Add(right.Answers.First());
            }
            left.Corrections += right.Corrections;
            left.Time += right.Time;
            left.LostFocusTime += right.LostFocusTime;
            return left;
        }
        public bool HasAnswer()
        {
            return Answers.Count > 0 && Answers.Order().First() != string.Empty;
        }
        public string GetSingleAnswer()
        {
            if (Answers.Count == 0)
            {
                return string.Empty;
            }
            return Answers.First();
        }
        public void SetSingleAnswer(string answer)
        {
            Answers.Clear();
            Answers.Add(answer);
            HasAnserChanged?.Invoke(this, true);
        }
        public HashSet<string> GetMultipleAnswers()
        {
            return Answers;
        }
        public bool IsAnswer(string answer)
        {
            return Answers.Contains(answer);
        }
        public void ToggleAnswer(string answer)
        {
            if (Answers.Contains(answer))
            {
                Answers.Remove(answer);
                HasAnserChanged?.Invoke(this, HasAnswer());
            }
            else
            {
                Answers.Add(answer);
                HasAnserChanged?.Invoke(this, true);
            }
        }
        public string? GetCustomAnswer(List<string> options)
        {
            return Answers.FirstOrDefault(x => !options.Contains(x));
        }
        public void ChangeCustomAnswer(List<string> options, string? newValue)
        {
            var customAnswer = GetCustomAnswer(options);
            if (customAnswer != null)
            {
                Answers.Remove(customAnswer);
                if (newValue != null)
                {
                    Answers.Add(newValue);
                }
            }
            HasAnserChanged?.Invoke(this, HasAnswer());
        }

        public override int GetHashCode()
        {
            var answersHash = Answers.Aggregate(0, (current, option) => current ^ option.GetHashCode());
            return HashCode.Combine(MultipleAnswers, answersHash, Corrections, Time, LostFocusTime);
        }
    }
}
