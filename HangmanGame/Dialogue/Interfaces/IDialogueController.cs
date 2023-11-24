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
        void ShowInputOptions(string[] options);
        string? ReadInput();
        void Clear();
    }
}
