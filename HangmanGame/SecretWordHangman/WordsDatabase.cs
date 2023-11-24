using CSharpConsoleHangmanGame.Debugging;
using CSharpConsoleHangmanGame.Debugging.Interfaces;
using CSharpConsoleHangmanGame.FileManaging;
using CSharpConsoleHangmanGame.SecretWordHangman.Interfaces;

namespace CSharpConsoleHangmanGame.SecretWordHangman
{
    internal class WordsDatabase : IWordsDatabase
    {
        readonly string wordsFilePath = "GameData/BuildGameData/Words/en_1.txt";
        readonly WordsDatabaseModel wordsDatabaseModel;

        internal WordsDatabase(IDebugLog debugLog)
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
