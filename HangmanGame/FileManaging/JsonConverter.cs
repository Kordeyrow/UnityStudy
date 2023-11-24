using CSharpConsoleHangmanGame.Debugging.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml;
using JsonException = Newtonsoft.Json.JsonException;

namespace CSharpConsoleHangmanGame.FileManaging
{
    internal class JsonConverter
    {
        readonly IDebugLog debugLog;

        internal JsonConverter(IDebugLog debugLog)
        {
            this.debugLog = debugLog;
        }

        public string? ToJson<T>(T objectToSerialize)
        {
            try
            {
                return JsonConvert.SerializeObject(objectToSerialize, Newtonsoft.Json.Formatting.Indented);
            }
            catch (JsonException ex)
            {
                debugLog.Print("An error occurred while converting to JSON");
                debugLog.Print(ex.Message);
                return null;
            }
        }

        public T? FromJson<T>(string jsonToDeserialize)
        {
            try
            {
                return JsonConvert.DeserializeObject<T>(jsonToDeserialize);
            }
            catch (JsonException ex)
            {
                debugLog.Print("An error occurred while converting from JSON");
                debugLog.Print(ex.Message);
                return default;
            }
        }
    }
}
