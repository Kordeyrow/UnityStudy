using Newtonsoft.Json;

namespace CSharpConsoleHangmanGame.Databases.GuessWords
{
    internal class WordsModel
    {
        [JsonRequired]
        public string[] Easy { get; set; }
        [JsonRequired]
        public string[] Medium { get; set; }
        [JsonRequired]
        public string[] Hard { get; set; }

        public WordsModel(string[] easy, string[] medium, string[] hard)
        {
            Easy = easy;
            Medium = medium;
            Hard = hard;
        }
    }
}