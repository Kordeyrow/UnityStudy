using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharpConsoleHangmanGame.GameStatesSystem.Interfaces;

namespace CSharpConsoleHangmanGame.GameStatesSystem
{
    internal class StateManager
    {
        private IGameState? currentState;

        internal bool HasState()
        {
            return currentState != null;
        }

        internal StateManager(IGameState currentState)
        {
            this.currentState = currentState;
            this.currentState.Enter();
        }

        internal void ChangeState(IGameState newState)
        {
            currentState?.Exit();
            currentState = newState;
            currentState?.Enter();
        }

        internal void Update()
        {
            if (currentState == null)
                return;

            IGameState nextState = currentState.Update();
            if (nextState != null && nextState != currentState)
            {
                ChangeState(nextState);
            }
        }
    }
}