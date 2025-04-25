using System.Text;
using System.Text.Json.Serialization;

namespace UniversalForm.Client.Persistence
{
    public class Form
    {
        public string Title { get; }
        public string Description { get; }
        [JsonPropertyName("questions")]
        [JsonInclude]
        List<Question> _questions;
        [JsonIgnore]
        int _index = 0;
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
        public Question? NextQuestion() => (_index + 1 < _questions.Count ) ? _questions[_index++] : null;
        public Question? PreviousQuestion() => (_index > 1) ? _questions[--_index] : null;
    }
}
