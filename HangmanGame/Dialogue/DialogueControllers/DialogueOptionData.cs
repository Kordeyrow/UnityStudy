using CSharpConsoleHangmanGame.Dialogue.Interfaces;

namespace CSharpConsoleHangmanGame.Dialogue.DialogueControllers
{
    internal class DialogueOptionData : IDialogueOptionData
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
