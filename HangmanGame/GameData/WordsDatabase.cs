using CSharpConsoleHangmanGame.GameLogic.SecretWordHangman.Interfaces;
using CSharpConsoleHangmanGame.HelperServices.Debugging.Interfaces;
using CSharpConsoleHangmanGame.HelperServices.FileManaging;

namespace CSharpConsoleHangmanGame.GameData
{
    internal class WordsDatabase : IWordsDatabase
    {
        readonly WordsDatabaseModel wordsDatabaseModel;

        internal WordsDatabase(IDebugLog debugLog, string wordsFilePath)
        {
            var fileReader = new FileReader(debugLog);
            var readObj = fileReader.GetObjectFromJsonFileInRoot<WordsDatabaseModel>(wordsFilePath);
            wordsDatabaseModel = readObj ?? new WordsDatabaseModel();
        }

        static string GetRandomWord(string[] arr)
        {
            var random = new Random();
            var size = arr.Length;
            return arr[random.Next(0, size)];
        }

        public string GetRandomEasyWord()
        {
            return GetRandomWord(wordsDatabaseModel.Words.Easy);
        }

        public string GetRandomMediumWord()
        {
            return GetRandomWord(wordsDatabaseModel.Words.Medium);
        }

        public string GetRandomHardWord()
        {
            return GetRandomWord(wordsDatabaseModel.Words.Hard);
        }
    }
}
