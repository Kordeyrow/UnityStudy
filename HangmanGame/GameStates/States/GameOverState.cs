using CSharpConsoleHangmanGame.Debugging.Interfaces;
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
        readonly IInputOptionsKeys   inputOptionsKeys;
        readonly IConfigs            configs;
        readonly bool                win;

        public GameOverState(IDebugLog           debugLog, 
                             IDialogueController dialogueController,
                             IDialogueDatabase   dialogueDatabase,
                             IInputOptionsKeys   inputOptionsKeys,
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
            IGameState returnState = this;

            // Show results message
            var db = dialogueDatabase.GameOverDialogueDatabase;
            string resultsMsg = win ? db.WinMessage : db.LoseMessage;
            dialogueController.ShowMessage(resultsMsg);

            dialogueController.ReadInputOption(new InputOption[] { 
                new InputOption(inputOptionsKeys.Option1(), 
                                dialogueDatabase.GameOverDialogueDatabase.EndChoicePlayAgainOption,
                                () => {
                                    PlayAgain();
                                    returnState = new InGameState(debugLog,
                                                                  dialogueController,
                                                                  dialogueDatabase,
                                                                  inputOptionsKeys,
                                                                  configs);
                                }
                ),
                new InputOption(inputOptionsKeys.Option2(),
                                dialogueDatabase.GameOverDialogueDatabase.EndChoiceExitToMenuOption,
                                () => {
                                    ExitToMenu();
                                    returnState = new MenuState(debugLog,
                                                                dialogueController,
                                                                dialogueDatabase,
                                                                inputOptionsKeys,
                                                                configs);
                                }
                ),
            });

            return returnState;
        }
    }
}
