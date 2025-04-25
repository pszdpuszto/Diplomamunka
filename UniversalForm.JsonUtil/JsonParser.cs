using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace UniversalForm.JsonUtil
{
    public struct Request
    {
        public enum Type
        {
            GET_FORM,
            SAVE_FORM,
            GET_STATISTICS,
            SAVE_STATISTICS,
            LOGIN
        }
        public Type ID { get; set; }
        public string FormName { get; set; }
        public string JsonStr { get; set; }
    }
    public struct Response
    {
        public enum Type
        {
            FORM,
            ERROR,
            FORM_LIST,
            STATISTICS,
            ACKNOWLEDGE
        }
        public Type ID { get; set; }
        public string JsonStr { get; set; }
    }
    public static class JsonParser
    {
        public const string EOT = "<<<EOT>>>";
        private static readonly JsonSerializerOptions _options = new()
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            WriteIndented = true,
            IncludeFields = true
        };
        public static string Serialize<T>(T obj)
        {
            return JsonSerializer.Serialize(obj, _options);
        }
        public static T? Deserialize<T>(string jsonStr)
        {
            return JsonSerializer.Deserialize<T>(jsonStr, _options);
        }
    }
}
