using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpConsoleHangmanGame.Dialogue.Interfaces
{
    internal interface IDialogueDatabase
    {
        IMenuDialogueDatabase MenuDialogueDatabase();
        IInGameDialogueDatabase InGameDialogueDatabase();
        IGameOverDialogueDatabase GameOverDialogueDatabase();
    }

    internal interface IMenuDialogueDatabase
    {
        void AskUserOptionStartGameOrExitGame(Action startGameAction, Action exitGameAction);
    }

    internal interface IInGameDialogueDatabase
    {
        void ShowStartGameMsg();
        string? AskForLetter();
    }

    internal interface IGameOverDialogueDatabase
    {
        void ShowResultsMsg(bool win);
        void AskUserOptionPlayAgainOrExitToMenu(Action playAgainAction, Action exitToMenuAction);
    }
}
