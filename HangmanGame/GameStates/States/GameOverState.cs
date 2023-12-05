using CSharpConsoleHangmanGame.GameSystems.Dialogue.Interfaces;
using CSharpConsoleHangmanGame.GameStates.Interfaces;
using CSharpConsoleHangmanGame.Databases.Dialogue.Interfaces;
using CSharpConsoleHangmanGame.GameSystems.Dialogue.DialogueOptionData;

namespace CSharpConsoleHangmanGame.GameStates.States
{
    internal class GameOverState : IGameState
    {
        readonly IDialogueController dialogueController;
        readonly IGameOverDialogueDatabase gameOverDB;
        readonly IGameStateContainer playAgainGameStateContainer;
        readonly IGameStateContainer exitGameStateContainer;
        readonly ISharedGameData sharedGameData;
        readonly IDialogueOptionData[] endChoiceInputOptions;

        IGameState currentState;

        public GameOverState(
            IDialogueController dialogueController,
            IGameOverDialogueDatabase gameOverDB,
            IGameStateContainer playAgainGameStateContainer,
            IGameStateContainer exitGameStateContainer,
            ISharedGameData sharedGameData)
        {
            this.dialogueController = dialogueController;
            this.gameOverDB = gameOverDB;
            this.playAgainGameStateContainer = playAgainGameStateContainer;
            this.exitGameStateContainer = exitGameStateContainer;

            this.endChoiceInputOptions = new IDialogueOptionData[] {

                /// ( Option 1 PlayAgain ) 
                ///
                new DialogueOptionData(text: gameOverDB.EndChoicePlayAgainOption,
                    action: PlayAgain),

                /// ( Option 2 ExitToMenu  ) 
                ///
                new DialogueOptionData(text: gameOverDB.EndChoiceExitToMenuOption,
                    action: ExitToMenu)
            };
            this.sharedGameData = sharedGameData;
        }

        void IGameState.Enter()
        {
            currentState = this;

            /// ( Show results message ) 
            ///
            string resultsMsg = sharedGameData.Won ? gameOverDB.WinMessage : gameOverDB.LoseMessage;
            dialogueController.ShowMessage(resultsMsg);
            dialogueController.WaitForEnterOrEspaceInput();
        }

        void IGameState.Exit()
        {

        }

        IGameState? IGameState.Update()
        {
            /// ( Show EndChoice question ) 
            ///
            dialogueController.ShowMessage(gameOverDB.EndChoiceQuestion);

            /// ( Execute chosen option ) 
            ///
            dialogueController.ShowOptionsAndExecuteChosen(endChoiceInputOptions);

            return currentState;
        }

        internal void PlayAgain()
        {
            currentState = playAgainGameStateContainer.GameState;
        }

        internal void ExitToMenu()
        {
            currentState = exitGameStateContainer.GameState;
        }
    }
}
