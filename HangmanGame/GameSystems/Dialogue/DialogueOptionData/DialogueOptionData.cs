using CSharpConsoleHangmanGame.GameSystems.Dialogue.Interfaces;

namespace CSharpConsoleHangmanGame.GameSystems.Dialogue.DialogueOptionData
{
    internal struct DialogueOptionData : IDialogueOptionData
    {
        public string Text { get; }
        public Action Action { get; }

        public DialogueOptionData(string text, Action action)
        {
            Text = text;
            Action = action;
        }
    }
}
