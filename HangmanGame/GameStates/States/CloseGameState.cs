using CSharpConsoleHangmanGame.Databases.Dialogue.Interfaces;
using CSharpConsoleHangmanGame.GameStates.Interfaces;
using CSharpConsoleHangmanGame.GameSystems.Dialogue.Interfaces;

namespace CSharpConsoleHangmanGame.GameStates.States
{
    internal class CloseGameState : IGameState, ICloseGameState
    {
        readonly IDialogueController dialogueController;
        readonly ICloseGameDialogueDatabase closeGameDB;

        public CloseGameState(
            IDialogueController dialogueController,
            ICloseGameDialogueDatabase closeGameDB)
        {
            this.dialogueController = dialogueController;
            this.closeGameDB = closeGameDB;
        }

        public void Enter()
        {
            /// ( Show end message ) 
            ///
            dialogueController.ShowMessage(closeGameDB.EndMessage);
            dialogueController.WaitForEnterOrEspaceInput();
        }

        public void Exit()
        {

        }

        public IGameState Update()
        {
            return this;
        }
    }
}
