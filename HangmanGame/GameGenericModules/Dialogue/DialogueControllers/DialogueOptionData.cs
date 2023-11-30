using CSharpConsoleHangmanGame.GameGenericModules.Dialogue.Interfaces;

namespace CSharpConsoleHangmanGame.GameGenericModules.Dialogue.DialogueControllers
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
