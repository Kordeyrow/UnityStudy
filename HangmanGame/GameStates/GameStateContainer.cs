using CSharpConsoleHangmanGame.GameStates.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpConsoleHangmanGame.GameStates
{
    internal class GameStateContainer : IGameStateContainer
    {
        IGameState gameState;
        IGameState IGameStateContainer.GameState => gameState;
        bool initialized = false;

        internal void Init(IGameState gameState)
        {
            if (initialized)
                return;

            this.gameState = gameState;
            initialized = true;
        }
    }
}
