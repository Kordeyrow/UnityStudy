using CSharpConsoleHangmanGame.GameSystems.Dialogue.Interfaces.DialogueUnitKeys;

namespace CSharpConsoleHangmanGame.GameSystems.Dialogue.DialogueUnitKeys
{
    internal class CloseGameDialogueUnitKeys : BaseDialogueUnitKeys, ICloseGameDialogueUnitKeys
    {
        public string EndMessage { get; } = FormatedKey("CloseGame_End_Message");
    }
}