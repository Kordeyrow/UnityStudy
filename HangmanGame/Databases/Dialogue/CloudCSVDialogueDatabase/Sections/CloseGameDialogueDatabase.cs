using CSharpConsoleHangmanGame.Databases.Dialogue.Interfaces;
using CSharpConsoleHangmanGame.GameSystems.Dialogue.Interfaces.DialogueUnitKeys;

namespace CSharpConsoleHangmanGame.Databases.Dialogue.CloudCSVDialogueDatabase.Sections
{
    internal class CloseGameDialogueDatabase : ICloseGameDialogueDatabase
    {
        readonly ICloseGameDialogueUnitKeys closeGameDialogueUnitKeys;
        readonly Section section;

        internal CloseGameDialogueDatabase(
            ICloseGameDialogueUnitKeys closeGameDialogueUnitKeys,
            Section section)
        {
            this.closeGameDialogueUnitKeys = closeGameDialogueUnitKeys;
            this.section = section;
        }

        public string EndMessage => section.GetText(closeGameDialogueUnitKeys.EndMessage);
    }
}