using CSharpConsoleHangmanGame.DialogueSystem.Interfaces;
using CSharpConsoleHangmanGame.GameStatesSystem.Interfaces;

namespace CSharpConsoleHangmanGame.GameStatesSystem.States
{
    internal class GameOverState : IGameState
    {
        readonly IDialogueController dialogueController;
        readonly IDialogueDatabase dialogueDatabase;
        readonly bool win;

        public GameOverState(IDialogueController dialogueController, IDialogueDatabase dialogueDatabase, bool win)
        {
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
                    returnState = new InGameState(dialogueController, dialogueDatabase);
                },
                () => {
                    ExitToMenu();
                    returnState = new MenuState(dialogueController, dialogueDatabase);
                }
            );

            return returnState;
        }
    }
}
