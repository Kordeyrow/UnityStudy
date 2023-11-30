using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpConsoleHangmanGame.GameGenericModules.Dialogue.Interfaces
{
    internal interface IDialogueController
    {
        void ShowMessage(string? text);
        bool ShowOptionsAndExecuteChosen(IDialogueOptionData[] options);
        string? ReadInput();
        void JumpLine();
        void Clear();
    }
}
