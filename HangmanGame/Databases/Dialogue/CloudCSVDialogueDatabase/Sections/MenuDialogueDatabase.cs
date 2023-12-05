using CSharpConsoleHangmanGame.Databases.Dialogue.Interfaces;
using CSharpConsoleHangmanGame.GameSystems.Dialogue.Interfaces.DialogueUnitKeys;

namespace CSharpConsoleHangmanGame.Databases.Dialogue.CloudCSVDialogueDatabase.Sections
{
    internal class MenuDialogueDatabase : IMenuDialogueDatabase
    {
        readonly IMenuDialogueUnitKeys menuDialogueUnitKeys;
        readonly Section section;

        internal MenuDialogueDatabase(IMenuDialogueUnitKeys menuDialogueUnitKeys, Section section)
        {
            this.menuDialogueUnitKeys = menuDialogueUnitKeys;
            this.section = section;
        }

        public string WelcomeMessage => section.GetText(menuDialogueUnitKeys.WelcomeMessage);
        public string StartChoiseQuestion => section.GetText(menuDialogueUnitKeys.StartChoiceQuestion);
        public string StartChoiseStartGameOption => section.GetText(menuDialogueUnitKeys.StartChoiceStartGameOption);
        public string StartChoiseExitGameOption => section.GetText(menuDialogueUnitKeys.StartChoiceExitGameOption);
    }
}
