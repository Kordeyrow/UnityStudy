using CSharpConsoleHangmanGame.GameGenericModules.Dialogue.Interfaces;

namespace CSharpConsoleHangmanGame.GameGenericModules.Dialogue.Databases.CloudCSVDialogueDatabase
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
