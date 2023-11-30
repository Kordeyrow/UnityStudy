using CSharpConsoleHangmanGame.Dialogue.Databases;

namespace CSharpConsoleHangmanGame.Dialogue.DialogueUnitKeys
{
    internal class MenuDialogueUnitKeys : BaseDialogueUnitKeys, IMenuDialogueUnitKeys
    {
        public string WelcomeMessage             { get; } = FormatedKey("Menu_Welcome_Message");
        public string StartChoiceQuestion        { get; } = FormatedKey("Menu_StartChoice_Question");
        public string StartChoiceStartGameOption { get; } = FormatedKey("Menu_StartChoice_StartGame_Option");
        public string StartChoiceExitGameOption  { get; } = FormatedKey("Menu_StartChoice_ExitGame_Option");
    }
}