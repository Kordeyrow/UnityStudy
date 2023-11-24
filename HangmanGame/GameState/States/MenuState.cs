using CSharpConsoleHangmanGame.Debugging;
using CSharpConsoleHangmanGame.Debugging.Interfaces;
using CSharpConsoleHangmanGame.Dialogue.Interfaces;
using CSharpConsoleHangmanGame.GameState.Interfaces;

namespace CSharpConsoleHangmanGame.GameState.States
{
    internal class MenuState : IGameState
    {
        readonly IDebugLog debugLog;
        readonly IDialogueController dialogueController;
        readonly IDialogueDatabase dialogueDatabase;

        public MenuState(IDebugLog debugLog, IDialogueController dialogueController, IDialogueDatabase dialogueDatabase)
        {
            this.debugLog = debugLog;
            this.dialogueController = dialogueController;
            this.dialogueDatabase = dialogueDatabase;
        }

        public void StartGame()
        {
            /*dialogueController.ShowMessage("StartGame()");*/
        }

        public void ExitGame()
        {
            /*dialogueController.ShowMessage("ExitGame()");*/
        }

        public void Enter()
        {
            /*dialogueController.ShowMessage("Enter()");*/
        }

        public void Exit()
        {
            /*dialogueController.ShowMessage("Exiting Menu State.");*/
        }

        public IGameState? Update()
        {
            IGameState? returnState = this;
            dialogueDatabase.MenuDialogueDatabase().AskUserOptionStartGameOrExitGame(
                () => {
                    StartGame();
                    returnState = new InGameState(debugLog, dialogueController, dialogueDatabase);
                },
                () => {
                    ExitGame();
                    returnState = null;
                }
            );

            return returnState;
        }
    }
}