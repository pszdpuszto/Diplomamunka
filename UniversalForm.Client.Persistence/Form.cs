using System.Text;
using System.Text.Json.Serialization;

namespace UniversalForm.Client.Persistence
{
    public class Form
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public bool MeasureCorrections { get; set; } = false;
        public bool MeasureTime { get; set; } = false;
        public bool Anonymous { get; set; } = false;
        public bool FocusTracking { get; set; } = false;
        public bool AllowBack { get; set; } = false;
        [JsonIgnore]
        public string UserName { get; set; } = string.Empty;
        [JsonInclude]
        public List<Question> Questions { get; }
        [JsonConstructor]
        public Form(string title, string description, List<Question> questions)
        {
            Title = title;
            Description = description;
            Questions = [.. questions];
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append($"""Title: {Title}\nDescription: {Description}""");
            sb.Append(Questions);
            return sb.ToString();
        }
        public void AddQuestion(Question q) => Questions.Add(q);
        public bool RemoveQuestion(Question q) => Questions.Remove(q);
        public Question? GetQuestion(int index)
        {
            if (index < 0 || index >= Questions.Count)
                return null;
            return Questions[index];
        }
        public int NumberOfQuestions()
        {
            return Questions.Count;
        }
    }
}
