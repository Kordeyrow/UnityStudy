using CSharpConsoleHangmanGame.GameData.Interfaces;
using CSharpConsoleHangmanGame.GameGenericModules.Dialogue.DialogueControllers;
using CSharpConsoleHangmanGame.GameGenericModules.Dialogue.Interfaces;
using CSharpConsoleHangmanGame.GameLogic.GameStates.Interfaces;
using CSharpConsoleHangmanGame.HelperServices.Debugging.Interfaces;

namespace CSharpConsoleHangmanGame.GameLogic.GameStates.States
{
    internal class MenuState : IGameState
    {
        readonly IDebugLog debugLog;
        readonly IDialogueController dialogueController;
        readonly IDialogueDatabase dialogueDatabase;
        readonly IConfigs configs;

        public MenuState(
            IDebugLog debugLog,
            IDialogueController dialogueController,
            IDialogueDatabase dialogueDatabase,
            IConfigs configs)
        {
            this.debugLog = debugLog;
            this.dialogueController = dialogueController;
            this.dialogueDatabase = dialogueDatabase;
            this.configs = configs;
        }

        public void Enter()
        {
            var db = dialogueDatabase.MenuDialogueDatabase;

            // Show start welcome message
            dialogueController.ShowMessage(db.WelcomeMessage);
        }

        public void Exit()
        {

        }

        public void OnStartGameOptionChosen()
        {

        }

        public void OnExitGameOptionChosen()
        {

        }

        public IGameState? Update()
        {
            IGameState? returnState = this;

            // Dialogue Database
            var db = dialogueDatabase.MenuDialogueDatabase;

            // Show StartChoice question
            dialogueController.ShowMessage(db.StartChoiseQuestion);

            // StartChoice options
            var inputOptions = new DialogueOptionData[2];

            // Option 1
            inputOptions[0] = new DialogueOptionData(
                text: db.StartChoiseStartGameOption,
                action: () =>
                {
                    OnStartGameOptionChosen();
                    returnState = new InGameState(debugLog,
                                                  dialogueController,
                                                  dialogueDatabase,
                                                  configs);
                }
            );

            // Option 2
            inputOptions[1] = new DialogueOptionData(
                text: db.StartChoiseExitGameOption,
                action: () =>
                {
                    OnExitGameOptionChosen();
                    returnState = null;
                }
            );

            // Execute chosen option
            dialogueController.ShowOptionsAndExecuteChosen(inputOptions);

            return returnState;
        }
    }
}