using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpConsoleHangmanGame.GameSystems.Dialogue.Interfaces
{
    internal interface IDialogueOptionData
    {
        string Text { get; }
        Action Action { get; }
    }
}
