using CSharpConsoleHangmanGame.GameData.Interfaces;
using CSharpConsoleHangmanGame.GameSystems.Dialogue.DialogueControllers;
using CSharpConsoleHangmanGame.GameSystems.Dialogue.Interfaces;
using CSharpConsoleHangmanGame.Utils.Debugging.Interfaces;
using CSharpConsoleHangmanGame.GameFlow.Interfaces;

namespace CSharpConsoleHangmanGame.GameFlow.States
{
    internal class MenuState : IGameState
    {
        readonly IDebugLog debugLog;
        readonly IDialogueController dialogueController;
        readonly IMenuDialogueDatabase menuDialogueDatabase;
        readonly IGameConfigs configs;
        readonly IGameState startGameState;
        readonly IDialogueOptionData[] inputOptions;

        IGameState? currentState;

        public MenuState(
            IDebugLog debugLog,
            IDialogueController dialogueController,
            IMenuDialogueDatabase menuDialogueDatabase,
            IGameConfigs configs,
            IGameState startGameState,
            IGameState exitGameState)
        {
            this.debugLog = debugLog;
            this.dialogueController = dialogueController;
            this.menuDialogueDatabase = menuDialogueDatabase;
            this.configs = configs;
            this.startGameState = startGameState;

            // StartChoice options
            inputOptions = new DialogueOptionData[2];

            // Option 1 StartGame
            inputOptions[0] = new DialogueOptionData(
                text: menuDialogueDatabase.StartChoiseStartGameOption,
                action: StartGame);

            // Option 2 ExitGamen
            inputOptions[1] = new DialogueOptionData(
                text: menuDialogueDatabase.StartChoiseExitGameOption,
                action: ExitGame);
        }

        void IGameState.Enter()
        {
            currentState = this;

            // Show start welcome message
            dialogueController.ShowMessage(menuDialogueDatabase.WelcomeMessage);
        }

        void IGameState.Exit()
        {

        }

        public IGameState? Update()
        {
            // Show StartChoice question
            dialogueController.ShowMessage(menuDialogueDatabase.StartChoiseQuestion);

            // Execute chosen option
            dialogueController.ShowOptionsAndExecuteChosen(inputOptions);

            return currentState;
        }

        void StartGame()
        {
            currentState = startGameState;
        }

        void ExitGame()
        {
            currentState = null;
        }
    }
}