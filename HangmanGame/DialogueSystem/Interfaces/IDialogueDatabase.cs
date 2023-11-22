using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpConsoleHangmanGame.DialogueSystem.Interfaces
{
    internal interface IDialogueDatabase
    {
        IMenuDialogueDatabase MenuDialogueDatabase();
    }

    internal interface IMenuDialogueDatabase
    {
        void GetUserOptionStartGameOrExit(Action startGameAction, Action exitGameAction);
    }
}
