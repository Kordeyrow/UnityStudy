using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharpConsoleHangmanGame.Databases.Dialogue.Interfaces;

namespace CSharpConsoleHangmanGame.GameSystems.Dialogue.Interfaces
{
    internal interface IDialogueDatabase
    {
        IMenuDialogueDatabase MenuDialogueDatabase { get; }
        IInGameDialogueDatabase InGameDialogueDatabase { get; }
        IGameOverDialogueDatabase GameOverDialogueDatabase { get; }
        ICloseGameDialogueDatabase CloseGameDialogueDatabase { get; }
        Task Init();
    }
}
