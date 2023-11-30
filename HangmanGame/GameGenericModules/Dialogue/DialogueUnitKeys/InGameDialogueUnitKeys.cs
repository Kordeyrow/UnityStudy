using CSharpConsoleHangmanGame.GameGenericModules.Dialogue.Interfaces;

namespace CSharpConsoleHangmanGame.GameGenericModules.Dialogue.DialogueUnitKeys
{
    internal class InGameDialogueUnitKeys : BaseDialogueUnitKeys, IInGameDialogueUnitKeys
    {
        public string GameStartedMessage { get; } = FormatedKey("InGame_GameStarted_Message");
        public string RequestLetterRequest { get; } = FormatedKey("InGame_Letter_Request");
    }
}