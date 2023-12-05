using System.ComponentModel.DataAnnotations;

namespace CSharpConsoleHangmanGame.AppSettings.Model.Sections
{
    internal class GameConfigsModel
    {
        [Required]
        public DialogueInfoModel DialogueInfo { get; set; }
        [Required]
        public GuessWordsInfoModel GuessWordsInfo { get; set; }

        public GameConfigsModel(
            DialogueInfoModel dialogueInfo,
            GuessWordsInfoModel guessWordsInfo)
        {
            DialogueInfo = dialogueInfo;
            GuessWordsInfo = guessWordsInfo;
        }
    }
}
