using CSharpConsoleHangmanGame.DialogueSystem.Interfaces;
using CSharpConsoleHangmanGame.GameStatesSystem.Interfaces;
using CSharpConsoleHangmanGame.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpConsoleHangmanGame.GameStatesSystem.States
{
    internal class MenuState : IGameState
    {
        readonly IDialogueController dialogueController;
        readonly IDialogueDatabase dialogueDatabase;

        public MenuState(IDialogueController dialogueController, IDialogueDatabase dialogueDatabase)
        {
            this.dialogueController = dialogueController;
            this.dialogueDatabase = dialogueDatabase;
        }

        public void StartGame()
        {
            dialogueController.ShowMessage("StartGame()");
        }

        public void ExitGame()
        {
            dialogueController.ShowMessage("ExitGame()");
        }

        public void Enter()
        {
            dialogueController.ShowMessage("Enter()");
        }

        public void Exit()
        {
            dialogueController.ShowMessage("Exiting Menu State.");
        }

        public IGameState Update()
        {
            dialogueDatabase.MenuDialogueDatabase().GetUserOptionStartGameOrExit(
                () =>
                {
                    StartGame();
                },
                () =>
                {
                    ExitGame();
                }
            );
            return this;
        }
    }
}