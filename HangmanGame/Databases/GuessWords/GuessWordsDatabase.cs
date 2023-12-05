using CSharpConsoleHangmanGame.Utils.FileManaging.Interfaces;
using CSharpConsoleHangmanGame.Databases.GuessWords.Interfaces;
using Optional;
using Optional.Unsafe;

namespace CSharpConsoleHangmanGame.Databases.GuessWords
{
    internal class GuessWordsDatabase : IGuessWordsDatabase
    {
        readonly Option<GuessWordsDatabaseModel> wordsDatabaseModelOpt;

        internal GuessWordsDatabase(
            IFileReader fileReader,
            string wordsFilePath)
        {
            wordsDatabaseModelOpt = fileReader.GetObjectFromJsonFileInRoot<GuessWordsDatabaseModel>(wordsFilePath);
        }

        static string GetRandomWord(string[] arr)
        {
            var random = new Random();
            var size = arr.Length;
            return arr[random.Next(0, size)];
        }

        string IGuessWordsDatabase.GetRandomEasyWord()
        {
            var word = "";
            wordsDatabaseModelOpt.MatchSome(wordsDatabaseModel =>
            {
                word = GetRandomWord(wordsDatabaseModel.Words.Easy);
            });
            return word;
        }

        string IGuessWordsDatabase.GetRandomMediumWord()
        {
            var word = "";
            wordsDatabaseModelOpt.MatchSome(wordsDatabaseModel =>
            {
                word = GetRandomWord(wordsDatabaseModel.Words.Medium);
            });
            return word;
        }

        string IGuessWordsDatabase.GetRandomHardWord()
        {
            var word = "";
            wordsDatabaseModelOpt.MatchSome(wordsDatabaseModel =>
            {
                word = GetRandomWord(wordsDatabaseModel.Words.Hard);
            });
            return word;
        }

        bool IGuessWordsDatabase.Empty()
        {
            var val = true;
            wordsDatabaseModelOpt.MatchSome(wordsDatabaseModel =>
            {
                val = wordsDatabaseModel.Words.Easy.Length == 0
                   && wordsDatabaseModel.Words.Medium.Length == 0
                   && wordsDatabaseModel.Words.Hard.Length == 0;
            });
            return val;
        }
    }
}
