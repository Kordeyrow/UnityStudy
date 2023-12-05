using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharpConsoleHangmanGame.GameSystems.Dialogue.Interfaces.DialogueUnitKeys;

namespace CSharpConsoleHangmanGame.GameSystems.Dialogue.Interfaces
{
    internal interface IDialogueUnitKeys
    {
        IMenuDialogueUnitKeys MenuDialogueUnitKeys { get; }
        IInGameDialogueUnitKeys InGameDialogueUnitKeys { get; }
        IGameOverDialogueUnitKeys GameOverDialogueUnitKeys { get; }
        ICloseGameDialogueUnitKeys CloseGameDialogueUnitKeys { get; }
    }
}
