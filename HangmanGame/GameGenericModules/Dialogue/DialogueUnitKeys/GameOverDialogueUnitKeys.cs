using CSharpConsoleHangmanGame.GameGenericModules.Dialogue.Interfaces;

namespace CSharpConsoleHangmanGame.GameGenericModules.Dialogue.DialogueUnitKeys
{
    internal class GameOverDialogueUnitKeys : BaseDialogueUnitKeys, IGameOverDialogueUnitKeys
    {
        public string WinMessage { get; } = FormatedKey("GameOver_Win_Message");
        public string LoseMessage { get; } = FormatedKey("GameOver_Lose_Message");
        public string EndChoiceQuestion { get; } = FormatedKey("GameOver_EndChoice_Question");
        public string EndChoicePlayAgainOption { get; } = FormatedKey("GameOver_EndChoice_PlayAgain_Option");
        public string EndChoiceExitToMenuOption { get; } = FormatedKey("GameOver_EndChoice_ExitToMenu_Option");
    }
}