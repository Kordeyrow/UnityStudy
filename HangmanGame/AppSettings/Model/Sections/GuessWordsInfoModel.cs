using System.ComponentModel.DataAnnotations;

namespace CSharpConsoleHangmanGame.AppSettings.Model.Sections
{
    internal class GuessWordsInfoModel
    {
        [Required]
        public string DatabaseFilePath { get; set; }

        public GuessWordsInfoModel(string databaseFilePath)
        {
            DatabaseFilePath = databaseFilePath;
        }
    }
}
