using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpConsoleHangmanGame.Dialogue.Interfaces
{
    internal interface IDialogueController
    {
        void ShowMessage(string? text);
        bool ReadInputOption(InputOption[] options);
        string? ReadInput();
        void JumpLine();
        void Clear();
    }

    internal class InputOption
    {
        public string Key { get; }
        public string Value { get; }
        public Action Action { get; }

        public InputOption(string key, string value, Action action)
        {
            Key = key;
            Value = value;
            Action = action;
        }
    }
}
