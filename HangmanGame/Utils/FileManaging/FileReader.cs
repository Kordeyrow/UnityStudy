using CSharpConsoleHangmanGame.Utils.Debugging.Interfaces;
using CSharpConsoleHangmanGame.Utils.FileManaging.Interfaces;
using Optional;

namespace CSharpConsoleHangmanGame.Utils.FileManaging
{
    internal class FileReader : IFileReader
    {
        readonly string rootDirectory = Directory.GetCurrentDirectory();
        readonly IFileReader ThisIFileReader;
        readonly IDebugLog debugLog;
        readonly IJsonConverter jsonConverter;

        internal FileReader(
            IDebugLog debugLog,
            IJsonConverter jsonConverter)
        {
            ThisIFileReader = this;
            this.debugLog = debugLog;
            this.jsonConverter = jsonConverter;
        }

        Option<T> IFileReader.GetObjectFromJsonFileInRoot<T>(string filePath)
        {
            var result = Option.None<T>();
            var fileDataJsonOpt = ThisIFileReader.ReadFileInRoot(filePath);
            fileDataJsonOpt.MatchSome(fileDataJson =>
            {
                var objOpt = jsonConverter.FromJson<T>(fileDataJson);
                objOpt.MatchSome(obj =>
                {
                    result = Option.Some<T>(obj);
                });
            });
            return result;
        }

        Option<string> IFileReader.ReadFileInRoot(string filePath)
        {
            try
            {
                if (File.Exists(filePath) == false)
                {
                    debugLog.Warn($"Error: File does not exist: {filePath}.");
                    return Option.None<string>();
                }

                var fullPath = Path.Combine(rootDirectory, filePath);

                return Option.Some<string>(File.ReadAllText(fullPath));
            }
            catch (Exception ex)
            {
                debugLog.Warn($"Error: Reading the file: {ex.Message}");
                return Option.None<string>();
            }
        }
    }
}
