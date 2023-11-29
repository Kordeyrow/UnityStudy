using CSharpConsoleHangmanGame.Debugging.Interfaces;
using CSharpConsoleHangmanGame.Dialogue.Interfaces;
using CSharpConsoleHangmanGame.GameData.Interfaces;
using CSharpConsoleHangmanGame.GameStates.Interfaces;

namespace CSharpConsoleHangmanGame.GameStates.States
{
    internal class MenuState : IGameState
    {
        readonly IDebugLog           debugLog;
        readonly IDialogueController dialogueController;
        readonly IDialogueDatabase   dialogueDatabase;
        readonly IInputOptionsKeys   inputOptionsKeys;
        readonly IConfigs            configs;

        public MenuState(
            IDebugLog           debugLog, 
            IDialogueController dialogueController, 
            IDialogueDatabase   dialogueDatabase,
            IInputOptionsKeys   inputOptionsKeys,
            IConfigs            configs)
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

        public void OnStartGameOption()
        {

        }

        public void OnExitGameOption()
        {

        }

        public IGameState? Update()
        {
            IGameState? returnState = this;

            var db = dialogueDatabase.MenuDialogueDatabase;

            // Show start choise question
            dialogueController.ShowMessage(db.StartChoiseQuestion);

            dialogueController.ReadInputOption(new InputOption[] {
                new InputOption(inputOptionsKeys.Option1(),
                                db.StartChoiseStartGameOption,
                                () => {
                                    OnStartGameOption();
                                    returnState = new InGameState(debugLog,
                                                                  dialogueController,
                                                                  dialogueDatabase,
                                                                  inputOptionsKeys,
                                                                  configs);
                                }
                ),
                new InputOption(inputOptionsKeys.Option2(),
                                db.StartChoiseExitGameOption,
                                () => {
                                    OnExitGameOption();
                                    returnState = null;
                                }
                ),
            });

            return returnState;
        }

        public void Exit()
        {

        }
    }
}