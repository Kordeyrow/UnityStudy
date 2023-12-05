using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpConsoleHangmanGame.GameSystems.Dialogue.Interfaces
{
    internal interface IDialogueOptionsInputKeys
    {
        string ConfirmKey { get; }
        string CancelKey { get; }
        string[] OptionsKeys(int optionsCount);
    }
}