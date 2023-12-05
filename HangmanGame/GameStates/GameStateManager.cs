using CSharpConsoleHangmanGame.GameSystems.Dialogue.Interfaces;
using CSharpConsoleHangmanGame.GameStates.Interfaces;

namespace CSharpConsoleHangmanGame.GameStates
{
    internal class GameStateManager : IGameStateManager
    {
        readonly IDialogueController dialogueController;
        readonly TimeSpan userInputEffectDelay = new(0, 0, 0, 0, 100);
        IGameState currentState;

        internal GameStateManager(
            IDialogueController dialogueController, 
            IGameState initialState)
        {
            this.dialogueController = dialogueController;
            currentState = initialState;
        }

        public void Start()
        {
            currentState.Enter();
        }

        public bool CloseGameState()
        {
            return currentState is ICloseGameState;
        }

        public void UpdateCurrentState()
        {
            // Update state
            var nextState = currentState.Update();

            // Game feel: next "game frame" delay, clear dialogue delay
            WaitDuration(userInputEffectDelay);
            dialogueController.Clear();

            // Next state
            if (nextState != currentState)
                ChangeState(nextState);
        }

        internal void ChangeState(IGameState newState)
        {
            currentState.Exit();
            currentState = newState;
            currentState.Enter();
        }

        internal static void WaitDuration(TimeSpan timeout)
        {
            Thread.Sleep(timeout);
        }

        public void End()
        {
            //dialogueController.ReadInput();
        }
    }
}