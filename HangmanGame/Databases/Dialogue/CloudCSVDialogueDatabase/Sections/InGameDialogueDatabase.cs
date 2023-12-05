using CSharpConsoleHangmanGame.Databases.Dialogue.Interfaces;
using CSharpConsoleHangmanGame.GameSystems.Dialogue.Interfaces.DialogueUnitKeys;

namespace CSharpConsoleHangmanGame.Databases.Dialogue.CloudCSVDialogueDatabase.Sections
{
    internal class InGameDialogueDatabase : IInGameDialogueDatabase
    {
        readonly IInGameDialogueUnitKeys inGameDialogueUnitKeys;
        readonly Section section;

        internal InGameDialogueDatabase(IInGameDialogueUnitKeys inGameDialogueUnitKeys, Section section)
        {
            this.inGameDialogueUnitKeys = inGameDialogueUnitKeys;
            this.section = section;
        }
        public string GameStartedMessage => section.GetText(inGameDialogueUnitKeys.GameStartedMessage);
        public string LetterRequest => section.GetText(inGameDialogueUnitKeys.RequestLetterRequest);
    }
}
