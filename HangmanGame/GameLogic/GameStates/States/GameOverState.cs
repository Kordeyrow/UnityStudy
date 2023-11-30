using CSharpConsoleHangmanGame.GameData.Interfaces;
using CSharpConsoleHangmanGame.GameGenericModules.Dialogue.DialogueControllers;
using CSharpConsoleHangmanGame.GameGenericModules.Dialogue.Interfaces;
using CSharpConsoleHangmanGame.GameLogic.GameStates.Interfaces;
using CSharpConsoleHangmanGame.HelperServices.Debugging.Interfaces;

namespace CSharpConsoleHangmanGame.GameLogic.GameStates.States
{
    internal class GameOverState : IGameState
    {
        readonly IDebugLog debugLog;
        readonly IDialogueController dialogueController;
        readonly IDialogueDatabase dialogueDatabase;
        readonly IConfigs configs;
        readonly bool win;

        public GameOverState(IDebugLog debugLog,
                             IDialogueController dialogueController,
                             IDialogueDatabase dialogueDatabase,
                             IConfigs configs,
                             bool win)
        {
            this.debugLog = debugLog;
            this.dialogueController = dialogueController;
            this.dialogueDatabase = dialogueDatabase;
            this.configs = configs;
            this.win = win;
        }

        public void Enter()
        {

        }

        public void Exit()
        {

        }

        public IGameState? Update()
        {
            IGameState returnState = this;

            // Dialogue Database
            var db = dialogueDatabase.GameOverDialogueDatabase;

            // Show results message
            string resultsMsg = win ? db.WinMessage : db.LoseMessage;
            dialogueController.ShowMessage(resultsMsg);

            // Show EndChoice question
            dialogueController.ShowMessage(db.EndChoiceQuestion);

            // EndChoice options
            var inputOptions = new DialogueOptionData[2];

            // Option 1
            inputOptions[0] = new DialogueOptionData(
                text: db.EndChoicePlayAgainOption,
                action: () =>
                {
                    OnPlayAgainOptionChosen();
                    returnState = new InGameState(debugLog,
                                                  dialogueController,
                                                  dialogueDatabase,
                                                  configs);
                }
            );

            // Option 2
            inputOptions[1] = new DialogueOptionData(
                text: db.EndChoiceExitToMenuOption,
                action: () =>
                {
                    OnExitToMenuOptionChosen();
                    returnState = new MenuState(debugLog,
                                                dialogueController,
                                                dialogueDatabase,
                                                configs);
                }
            );

            // Execute chosen option
            dialogueController.ShowOptionsAndExecuteChosen(inputOptions);

            return returnState;
        }

        internal void OnPlayAgainOptionChosen()
        {

        }

        internal void OnExitToMenuOptionChosen()
        {

        }
    }
}
