using CSharpConsoleHangmanGame.Dialogue.Interfaces;
using CSharpConsoleHangmanGame.GameStates.Interfaces;

namespace CSharpConsoleHangmanGame.GameStates
{
    internal class GameStateManager : IGameStateManager
    {
        readonly IDialogueController dialogueController;
        readonly TimeSpan userInputEffectDelay = new(0, 0, 0, 0, 100);
        IGameState? currentState;

        internal GameStateManager(IDialogueController dialogueController, IGameState initialState)
        {
            this.dialogueController = dialogueController;
            this.currentState = initialState;
        }

        public void Start()
        {
            currentState?.Enter();
        }

        public bool HasState()
        {
            return currentState != null;
        }

        internal void ChangeState(IGameState? newState)
        {
            currentState?.Exit();
            currentState = newState;
            currentState?.Enter();
        }

        public void UpdateCurrentState()
        {
            // Has state ?
            if (currentState == null)
                return;

            // Update state
            var nextState = currentState.Update();

            // Game feel: next "game frame" delay, clear dialogue delay
            WaitDuration(userInputEffectDelay);
            dialogueController.Clear();

            // Next state
            if (nextState != currentState)
                ChangeState(nextState);
        }

        internal static void WaitDuration(TimeSpan timeout)
        {
            Thread.Sleep(timeout);
        }
    }
}