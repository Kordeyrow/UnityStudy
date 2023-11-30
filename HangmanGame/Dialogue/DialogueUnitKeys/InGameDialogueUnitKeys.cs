using CSharpConsoleHangmanGame.Dialogue.Databases;

namespace CSharpConsoleHangmanGame.Dialogue.DialogueUnitKeys
{
    internal class InGameDialogueUnitKeys : BaseDialogueUnitKeys, IInGameDialogueUnitKeys
    {
        public string GameStartedMessage   { get; } = FormatedKey("InGame_GameStarted_Message");
        public string RequestLetterRequest { get; } = FormatedKey("InGame_Letter_Request");
    }
}