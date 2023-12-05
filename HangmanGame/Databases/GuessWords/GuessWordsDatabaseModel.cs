using Newtonsoft.Json;

namespace CSharpConsoleHangmanGame.Databases.GuessWords
{
    internal class GuessWordsDatabaseModel
    {
        [JsonRequired]
        public WordsModel Words { get; set; }

        public GuessWordsDatabaseModel(WordsModel words)
        {
            Words = words;
        }
    }
}
