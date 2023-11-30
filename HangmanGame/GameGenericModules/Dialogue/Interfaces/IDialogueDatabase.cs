using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpConsoleHangmanGame.GameGenericModules.Dialogue.Interfaces
{
    internal interface IDialogueDatabase
    {
        IMenuDialogueDatabase MenuDialogueDatabase { get; }
        IInGameDialogueDatabase InGameDialogueDatabase { get; }
        IGameOverDialogueDatabase GameOverDialogueDatabase { get; }
        Task Init();
    }

    internal interface IMenuDialogueDatabase
    {
        string WelcomeMessage { get; }
        string StartChoiseQuestion { get; }
        string StartChoiseStartGameOption { get; }
        string StartChoiseExitGameOption { get; }
    }

    internal interface IInGameDialogueDatabase
    {
        string GameStartedMessage { get; }
        string LetterRequest { get; }
    }

    internal interface IGameOverDialogueDatabase
    {
        string WinMessage { get; }
        string LoseMessage { get; }
        string EndChoiceQuestion { get; }
        string EndChoicePlayAgainOption { get; }
        string EndChoiceExitToMenuOption { get; }
    }
}
