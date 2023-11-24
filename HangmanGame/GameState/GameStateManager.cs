using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharpConsoleHangmanGame.Dialogue.Interfaces;
using CSharpConsoleHangmanGame.GameState.Interfaces;

namespace CSharpConsoleHangmanGame.GameState
{
    internal class GameStateManager
    {
        readonly IDialogueController dialogueController;
        readonly TimeSpan userInputEffectDelay = new(0, 0, 0, 0, 100);
        IGameState? currentState;

        internal GameStateManager(IDialogueController dialogueController, IGameState initialState)
        {
            this.dialogueController = dialogueController;
            this.currentState = initialState;
        }

        internal void Start()
        {
            currentState?.Enter();
        }

        internal bool HasState()
        {
            return currentState != null;
        }

        internal void ChangeState(IGameState? newState)
        {
            currentState?.Exit();
            currentState = newState;
            currentState?.Enter();
        }

        internal void UpdateCurrentState()
        {
            // Has state ?
            if (currentState == null)
                return;

            // Update state
            var nextState = currentState.Update();

            // Next state
            if (nextState != currentState)
                ChangeState(nextState);

            // Game feel: clear dialogue delay
            WaitDuration(userInputEffectDelay);
            dialogueController.Clear();
        }

        internal static void WaitDuration(TimeSpan timeout)
        {
            Thread.Sleep(timeout);
        }
    }
}