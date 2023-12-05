using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpConsoleHangmanGame.GameSystems.Dialogue.Interfaces
{
    internal interface IDialogueController
    {
        void ShowMessage(string? text);
        void ShowRawText(string? text);
        void ShowRawLine(string? text);
        bool ShowOptionsAndExecuteChosen(IDialogueOptionData[] options);
        string? ReadInput();
        void JumpLine();
        void WaitForEnterOrEspaceInput();
        void Clear();
    }
}
