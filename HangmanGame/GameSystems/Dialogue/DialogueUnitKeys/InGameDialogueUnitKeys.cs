using CSharpConsoleHangmanGame.GameSystems.Dialogue.Interfaces.DialogueUnitKeys;

namespace CSharpConsoleHangmanGame.GameSystems.Dialogue.DialogueUnitKeys
{
    internal class InGameDialogueUnitKeys : BaseDialogueUnitKeys, IInGameDialogueUnitKeys
    {
        public string GameStartedMessage   { get; } = FormatedKey("InGame_GameStarted_Message");
        public string RequestLetterRequest { get; } = FormatedKey("InGame_Letter_Request");
    }
}