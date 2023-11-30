using CSharpConsoleHangmanGame.GameGenericModules.Dialogue.Interfaces;

namespace CSharpConsoleHangmanGame.GameGenericModules.Dialogue.DialogueUnitKeys
{
    internal class DialogueUnitKeys : IDialogueUnitKeys
    {
        public IMenuDialogueUnitKeys MenuDialogueUnitKeys => new MenuDialogueUnitKeys();
        public IInGameDialogueUnitKeys InGameDialogueUnitKeys => new InGameDialogueUnitKeys();
        public IGameOverDialogueUnitKeys GameOverDialogueUnitKeys => new GameOverDialogueUnitKeys();
    }
}