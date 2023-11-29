using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpConsoleHangmanGame.Dialogue.Databases
{
    internal interface IDialogueUnitKeys
    {
        IMenuDialogueUnitKeys MenuDialogueUnitKeys { get; }
        IInGameDialogueUnitKeys InGameDialogueUnitKeys { get; }
        IGameOverDialogueUnitKeys GameOverDialogueUnitKeys { get; }
    }

    internal interface IMenuDialogueUnitKeys
    {
        string WelcomeMessage { get; }
        string StartChoiceQuestion { get; }
        string StartChoiceStartGameOption { get; }
        string StartChoiceExitGameOption { get; }
    }

    internal interface IInGameDialogueUnitKeys
    {
        string GameStartedMessage { get; }
        string RequestLetterRequest { get; }
    }

    internal interface IGameOverDialogueUnitKeys
    {
        string WinMessage { get; }
        string LoseMessage { get; }
        string EndChoiceQuestion { get; }
        string EndChoicePlayAgainOption { get; }
        string EndChoiceExitToMenuOption { get; }
    }
}
