using CSharpConsoleHangmanGame.Utils.Debugging.Interfaces;
using CSharpConsoleHangmanGame.Utils.FileManaging.Interfaces;
using Newtonsoft.Json;
using Optional;
using JsonException = Newtonsoft.Json.JsonException;

namespace CSharpConsoleHangmanGame.Utils.FileManaging
{
    internal class JsonConverter : IJsonConverter
    {
        readonly IDebugLog debugLog;

        internal JsonConverter(IDebugLog debugLog)
        {
            this.debugLog = debugLog;
        }

        Option<string> IJsonConverter.ToJson<T>(T objectToSerialize)
        {
            try
            {
                var json = JsonConvert.SerializeObject(objectToSerialize, Formatting.Indented);
                return Option.Some(json);
            }
            catch (JsonException ex)
            {
                debugLog.Print($"Error: An error occurred while converting to JSON: {ex.Message}");
            }
            return Option.None<string>();
        }

        Option<T> IJsonConverter.FromJson<T>(string jsonToDeserialize)
        {
            try
            {
                var obj = JsonConvert.DeserializeObject<T>(jsonToDeserialize);
                if (obj != null)
                    return Option.Some<T>(obj);
            }
            catch (JsonException ex)
            {
                debugLog.Print($"Error: An error occurred while converting from JSON: {ex.Message}");
            }
            return Option.None<T>();
        }
    }
}
