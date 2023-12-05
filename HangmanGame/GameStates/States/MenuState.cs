using CSharpConsoleHangmanGame.GameSystems.Dialogue.Interfaces;
using CSharpConsoleHangmanGame.GameStates.Interfaces;
using CSharpConsoleHangmanGame.Databases.Dialogue.Interfaces;
using CSharpConsoleHangmanGame.GameSystems.Dialogue.DialogueOptionData;

namespace CSharpConsoleHangmanGame.GameStates.States
{
    internal class MenuState : IGameState
    {
        readonly IDialogueController dialogueController;
        readonly IMenuDialogueDatabase menuDialogueDatabase;
        readonly IGameStateContainer startGameStateContainer;
        readonly IGameStateContainer closeGameStateContainer;
        readonly IDialogueOptionData[] startChoiceInputOptions;

        IGameState currentState;

        public MenuState(
            IDialogueController dialogueController,
            IMenuDialogueDatabase menuDB,
            IGameStateContainer startGameStateContainer,
            IGameStateContainer closeGameStateContainer)
        {
            this.dialogueController = dialogueController;
            this.menuDialogueDatabase = menuDB;
            this.startGameStateContainer = startGameStateContainer;
            this.closeGameStateContainer = closeGameStateContainer;

            this.startChoiceInputOptions = new IDialogueOptionData[] {

                /// ( Option 1 StartGame ) 
                /// 
                new DialogueOptionData(text: menuDB.StartChoiseStartGameOption,
                    action: StartGame),

                /// ( Option 2 ExitGame ) 
                ///
                new DialogueOptionData(text: menuDB.StartChoiseExitGameOption,
                    action: ExitGame)
            };
        }

        void IGameState.Enter()
        {
            currentState = this;

            /// ( Show start welcome message ) 
            ///
            dialogueController.ShowMessage(menuDialogueDatabase.WelcomeMessage);
            dialogueController.WaitForEnterOrEspaceInput();
        }

        void IGameState.Exit()
        {

        }

        IGameState IGameState.Update()
        {
            /// ( Show StartChoice question ) 
            ///
            dialogueController.ShowMessage(menuDialogueDatabase.StartChoiseQuestion);

            /// ( Show Options, Read InputOption and Execute chosen option ) 
            ///
            dialogueController.ShowOptionsAndExecuteChosen(startChoiceInputOptions);

            return currentState;
        }

        void StartGame()
        {
            currentState = startGameStateContainer.GameState;
        }

        void ExitGame()
        {
            currentState = closeGameStateContainer.GameState;
        }
    }
}