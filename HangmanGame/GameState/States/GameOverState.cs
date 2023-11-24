using CSharpConsoleHangmanGame.Debugging.Interfaces;
using CSharpConsoleHangmanGame.Dialogue.Interfaces;
using CSharpConsoleHangmanGame.GameState.Interfaces;

namespace CSharpConsoleHangmanGame.GameState.States
{
    internal class GameOverState : IGameState
    {
        readonly IDebugLog debugLog;
        readonly IDialogueController dialogueController;
        readonly IDialogueDatabase dialogueDatabase;
        readonly bool win;

        public GameOverState(IDebugLog debugLog, IDialogueController dialogueController, IDialogueDatabase dialogueDatabase, bool win)
        {
            this.debugLog = debugLog;
            this.dialogueController = dialogueController;
            this.dialogueDatabase = dialogueDatabase;
            this.win = win;
        }

        internal void PlayAgain()
        {

        }

        internal void ExitToMenu()
        {

        }

        public void Enter()
        {
        }

        public void Exit()
        {

        }

        public IGameState? Update()
        {
            dialogueDatabase.GameOverDialogueDatabase().ShowResultsMsg(win);
            IGameState? returnState = this;
            dialogueDatabase.GameOverDialogueDatabase().AskUserOptionPlayAgainOrExitToMenu(
                () =>
                {
                    PlayAgain();
                    returnState = new InGameState(debugLog, dialogueController, dialogueDatabase);
                },
                () => {
                    ExitToMenu();
                    returnState = new MenuState(debugLog, dialogueController, dialogueDatabase);
                }
            );

            return returnState;
        }
    }
}
