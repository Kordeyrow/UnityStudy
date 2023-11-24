using CSharpConsoleHangmanGame.Debugging.Interfaces;
using System.Data.SqlTypes;
using System.Diagnostics.CodeAnalysis;

namespace CSharpConsoleHangmanGame.FileManaging
{
    internal class FileReader
    {
        readonly string rootDirectory = Directory.GetCurrentDirectory();
        readonly IDebugLog debugLog;
        readonly JsonConverter jsonConverter;

        internal FileReader(IDebugLog debugLog)
        {
            this.debugLog = debugLog;
            jsonConverter = new JsonConverter(debugLog);
        }

        internal T? GetObjectFromJsonFileInRoot<T>(string filePath)
        {
            var rawContent = ReadFileInRoot(filePath);
            if (rawContent == null)
                return default;
            return jsonConverter.FromJson<T>(rawContent);
        }

        internal string? ReadFileInRoot(string filePath)
        {
            try
            {
                if (File.Exists(filePath) == false)
                {
                    debugLog.Warn("File does not exist.");
                    return null;
                }

                var fullPath = Path.Combine(rootDirectory, filePath);

                return File.ReadAllText(fullPath);
            }
            catch (Exception ex)
            {
                debugLog.Warn($"An error occurred while reading the file: {ex.Message}");
                return null;
            }
        }
    }
}
