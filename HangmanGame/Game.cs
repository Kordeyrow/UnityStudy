using CSharpConsoleHangmanGame.GameStates.Interfaces;

namespace CSharpConsoleHangmanGame
{
    internal class Game
    {
        readonly IGameStateManager gameStateManager;

        public Game(IGameStateManager gameStateManager)
        {
            this.gameStateManager = gameStateManager;
        }

        internal void Run()
        {
            gameStateManager.Start();

            while (gameStateManager.CloseGameState() == false)
            {
                gameStateManager.UpdateCurrentState();
            }

            gameStateManager.End();
        }
    }
}
