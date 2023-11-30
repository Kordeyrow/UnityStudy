using CSharpConsoleHangmanGame.Debugging.Interfaces;
using CSharpConsoleHangmanGame.Dialogue.DialogueControllers;
using CSharpConsoleHangmanGame.Dialogue.Interfaces;
using CSharpConsoleHangmanGame.GameData.Interfaces;
using CSharpConsoleHangmanGame.GameStates.Interfaces;

namespace CSharpConsoleHangmanGame.GameStates.States
{
    internal class MenuState : IGameState
    {
        readonly IDebugLog                 debugLog;
        readonly IDialogueController       dialogueController;
        readonly IDialogueDatabase         dialogueDatabase;
        readonly IDialogueOptionsInputKeys inputOptionsKeys;
        readonly IConfigs                  configs;

        public MenuState(
            IDebugLog                  debugLog, 
            IDialogueController        dialogueController, 
            IDialogueDatabase          dialogueDatabase,
            IDialogueOptionsInputKeys  inputOptionsKeys,
            IConfigs                   configs)
        {
            this.debugLog           = debugLog;
            this.dialogueController = dialogueController;
            this.dialogueDatabase   = dialogueDatabase;
            this.inputOptionsKeys   = inputOptionsKeys;
            this.configs            = configs;
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
                text   : db.StartChoiseStartGameOption,
                action : () =>
                {
                    OnStartGameOptionChosen();
                    returnState = new InGameState(debugLog,
                                                  dialogueController,
                                                  dialogueDatabase,
                                                  inputOptionsKeys,
                                                  configs);
                }
            );

            // Option 2
            inputOptions[1] = new DialogueOptionData(
                text   : db.StartChoiseExitGameOption,
                action : () =>
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