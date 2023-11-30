using CSharpConsoleHangmanGame.Debugging.Interfaces;
using CSharpConsoleHangmanGame.Dialogue.DialogueControllers;
using CSharpConsoleHangmanGame.Dialogue.Interfaces;
using CSharpConsoleHangmanGame.GameData.Interfaces;
using CSharpConsoleHangmanGame.GameStates.Interfaces;

namespace CSharpConsoleHangmanGame.GameStates.States
{
    internal class GameOverState : IGameState
    {
        readonly IDebugLog           debugLog;
        readonly IDialogueController dialogueController;
        readonly IDialogueDatabase   dialogueDatabase;
        readonly IDialogueOptionsInputKeys   inputOptionsKeys;
        readonly IConfigs            configs;
        readonly bool                win;

        public GameOverState(IDebugLog           debugLog, 
                             IDialogueController dialogueController,
                             IDialogueDatabase   dialogueDatabase,
                             IDialogueOptionsInputKeys   inputOptionsKeys,
                             IConfigs            configs,
                             bool                win)
        {
            this.debugLog = debugLog;
            this.dialogueController = dialogueController;
            this.dialogueDatabase = dialogueDatabase;
            this.inputOptionsKeys = inputOptionsKeys;
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
                text   : db.EndChoicePlayAgainOption, 
                action : () => 
                {
                    OnPlayAgainOptionChosen();
                    returnState = new InGameState(debugLog,
                                                  dialogueController,
                                                  dialogueDatabase,
                                                  inputOptionsKeys,
                                                  configs);
                }
            );

            // Option 2
            inputOptions[1] = new DialogueOptionData(
                text   : db.EndChoiceExitToMenuOption,
                action : () =>
                {
                    OnExitToMenuOptionChosen();
                    returnState = new MenuState(debugLog,
                                                dialogueController,
                                                dialogueDatabase,
                                                inputOptionsKeys,
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
