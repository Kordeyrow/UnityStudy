using CSharpConsoleHangmanGame.Dialogue.Databases;

namespace CSharpConsoleHangmanGame.Dialogue.DialogueUnitKeys
{
    internal class DialogueUnitKeys : IDialogueUnitKeys
    {
        public IMenuDialogueUnitKeys MenuDialogueUnitKeys => new MenuDialogueUnitKeys();
        public IInGameDialogueUnitKeys InGameDialogueUnitKeys => new InGameDialogueUnitKeys();
        public IGameOverDialogueUnitKeys GameOverDialogueUnitKeys => new GameOverDialogueUnitKeys();
    }

    internal class BaseDialogueUnitKeys
    {
        protected static string FormatedKey(string s) => s.ToLower();
    }

    internal class MenuDialogueUnitKeys : BaseDialogueUnitKeys, IMenuDialogueUnitKeys
    {
        public string WelcomeMessage             { get; } = FormatedKey("Menu_Welcome_Message");
        public string StartChoiceQuestion        { get; } = FormatedKey("Menu_StartChoice_Question");
        public string StartChoiceStartGameOption { get; } = FormatedKey("Menu_StartChoice_StartGame_Option");
        public string StartChoiceExitGameOption  { get; } = FormatedKey("Menu_StartChoice_ExitGame_Option");
    }

    internal class InGameDialogueUnitKeys : BaseDialogueUnitKeys, IInGameDialogueUnitKeys
    {
        public string GameStartedMessage   { get; } = FormatedKey("InGame_GameStarted_Message");
        public string RequestLetterRequest { get; } = FormatedKey("InGame_Letter_Request");
    }

    internal class GameOverDialogueUnitKeys : BaseDialogueUnitKeys, IGameOverDialogueUnitKeys
    {
        public string WinMessage                { get; } = FormatedKey("GameOver_Win_Message");
        public string LoseMessage               { get; } = FormatedKey("GameOver_Lose_Message");
        public string EndChoiceQuestion         { get; } = FormatedKey("GameOver_EndChoice_Question");
        public string EndChoicePlayAgainOption  { get; } = FormatedKey("GameOver_EndChoice_PlayAgain_Option");
        public string EndChoiceExitToMenuOption { get; } = FormatedKey("GameOver_EndChoice_ExitToMenu_Option");
    }
}