using CSharpConsoleHangmanGame.GameSystems.Dialogue.Interfaces;
using CSharpConsoleHangmanGame.GameSystems.Dialogue.Interfaces.DialogueUnitKeys;

namespace CSharpConsoleHangmanGame.GameSystems.Dialogue.DialogueUnitKeys
{
    internal class DialogueUnitKeys : IDialogueUnitKeys
    {
        public IMenuDialogueUnitKeys MenuDialogueUnitKeys           { get; } = new MenuDialogueUnitKeys();
        public IInGameDialogueUnitKeys InGameDialogueUnitKeys       { get; } = new InGameDialogueUnitKeys();
        public IGameOverDialogueUnitKeys GameOverDialogueUnitKeys   { get; } = new GameOverDialogueUnitKeys();
        public ICloseGameDialogueUnitKeys CloseGameDialogueUnitKeys { get; } = new CloseGameDialogueUnitKeys();
    }
}