using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Json.Serialization.Metadata;

namespace UniversalForm.Client.Persistence
{
    public abstract class JsonPersistence : IPersistence
    {
        private class QuestionTypeResolver : DefaultJsonTypeInfoResolver
        {
            List<Type> _questionTypes;
            public QuestionTypeResolver(IEnumerable<Type> questionTypes) => _questionTypes = [.. questionTypes];
            public override JsonTypeInfo GetTypeInfo(Type type, JsonSerializerOptions options)
            {
                var jsonTypeInfo = base.GetTypeInfo(type, options);
                if (jsonTypeInfo.Type == typeof(Question))
                {
                    jsonTypeInfo.PolymorphismOptions = new JsonPolymorphismOptions
                    {
                        TypeDiscriminatorPropertyName = "$questionType",
                        IgnoreUnrecognizedTypeDiscriminators = true,
                        UnknownDerivedTypeHandling = JsonUnknownDerivedTypeHandling.FallBackToBaseType
                    };

                    _questionTypes.ForEach(t => jsonTypeInfo.PolymorphismOptions.DerivedTypes.Add(new JsonDerivedType(t, t.Name)));
                }
                return jsonTypeInfo;
            }
        }
        protected const string ERROR = "ERROR";

        private readonly JsonSerializerOptions _options;

        public JsonPersistence(IEnumerable<Type> questionTypes)
        {
            _options = new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true,
                IncludeFields = true,
                TypeInfoResolver = new QuestionTypeResolver(questionTypes)
            };                 
        }
            
        public Form? LoadForm(string name)
        {
            var jsonStr = LoadJson(name);
            if (jsonStr == ERROR)
                return null;
            try
            {
                return JsonSerializer.Deserialize<Form>(jsonStr, _options);
            }
            catch {  return null; }
        }

        public bool SaveForm(string userName, string formName, Form form)
        {
            var jsonStr = JsonSerializer.Serialize(form, _options);
            return SaveJson(userName, formName, jsonStr);
        }
        public List<string>? GetForms(string userName)
        {
            var jsonStr = GetFormsJson(userName);
            if (jsonStr == ERROR)
                return null;
            return JsonSerializer.Deserialize<List<string>>(jsonStr, _options);
        }
        protected abstract string LoadJson(string name);
        protected abstract bool SaveJson(string userName, string formName, string jsonStr);
        public abstract bool LogIn(string userName, string password);
        public abstract string GetFormsJson(string userName);
    }
}
