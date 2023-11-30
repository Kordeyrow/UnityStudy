using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpConsoleHangmanGame.GameGenericModules.Dialogue
{
    internal class DialogueDatabaseModel
    {
        public DialoguesModel Dialogues { get; set; }

        public class DialoguesModel
        {
            public MenuModel Menu { get; set; }
            public InGameModel InGame { get; set; }
            public GameOverModel GameOver { get; set; }
        }

        public class GameOverModel
        {
            public string WinMsg { get; set; }
            public string LoseMsg { get; set; }
            public string AaskUserOptionPlayAgainOrExitToMenuMessage { get; set; }
            public string PlayAgainOptionText { get; set; }
            public string ExitToMenuOptionText { get; set; }
        }

        public class InGameModel
        {
            public string StartGameMsg { get; set; }
            public string AskForLetterMsg { get; set; }
        }

        public class MenuModel
        {
            public string AskUserOptionStartGameOrExitGame { get; set; }
            public string StartGameOptionText { get; set; }
            public string ExitGameOptionText { get; set; }
        }
    }
}
