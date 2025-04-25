using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace UniversalForm.Client.Persistence
{
    
    public abstract class Question
    {
        public enum QTYPE
        {
            TEXT_AREA,
            SINGLE_SELECT
        }
        QTYPE Type { get; }
        [JsonInclude]
        string Title { get; }
        [JsonInclude]
        string Description { get; }

        public Question(QTYPE type, string title, string description)
        {
            Type = type;
            Title = title;
            Description = description;
        }

        public override string ToString()
        {
            return $"Type:{Type.ToString()}\nTitle:{Title}\nDescription:{Description}\n{extraStr()}";
        }

        protected abstract string extraStr();
    }
}
