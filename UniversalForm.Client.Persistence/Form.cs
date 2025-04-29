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
        [JsonPropertyName("questions")]
        [JsonInclude]
        List<Question> _questions;
        [JsonConstructor]
        public Form(string title, string description, List<Question> _questions)
        {
            Title = title;
            Description = description;
            this._questions = [.. _questions];
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append($"""Title: {Title}\nDescription: {Description}""");
            sb.Append(_questions);
            return sb.ToString();
        }
        public void AddQuestion(Question q) => _questions.Add(q);
        public bool RemoveQuestion(Question q) => _questions.Remove(q);
        public Question? GetQuestion(int index)
        {
            if (index < 0 || index >= _questions.Count)
                return null;
            return _questions[index];
        }
    }
}
