using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace UniversalForm.Client.Persistence
{
    public class Statistics
    {
        public bool MultipleAnswers { get; set; } = false;
        private HashSet<string> Answers { get; set; } = new();
        public int Corrections { get; set; } = -1;
        public long Time { get; set; } = 0;
        public long LostFocusTime { get; set; } = 0;
        public static Statistics operator +(Statistics? left, Statistics right)
        {
            if (left == null)
            {
                return right;
            }
            if (left.MultipleAnswers)
            {
                left.Answers.UnionWith(right.Answers);
            } else
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
            return Answers.Count > 0;
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
            }
            else
            {
                Answers.Add(answer);
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
        }
    }
}
