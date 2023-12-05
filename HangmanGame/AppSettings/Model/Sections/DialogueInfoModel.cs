using System.ComponentModel.DataAnnotations;

namespace CSharpConsoleHangmanGame.AppSettings.Model.Sections
{
    internal class DialogueInfoModel
    {
        [Required]
        public string CurrentLanguageID { get; set; }
        [Required]
        public string[] AllLanguageIDs { get; set; }
        [Required]
        public string DatabaseURL { get; set; }

        public DialogueInfoModel(
            string currentLanguageID,
            string[] allLanguageIDs,
            string databaseURL)
        {
            CurrentLanguageID = currentLanguageID;
            AllLanguageIDs = allLanguageIDs;
            DatabaseURL = databaseURL;
        }
    }
}
