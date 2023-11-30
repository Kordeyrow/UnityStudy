using CSharpConsoleHangmanGame.GameLogic.GameStates.Interfaces;
using CSharpConsoleHangmanGame.ServicesContainers;
using CSharpConsoleHangmanGame.ServicesContainers.Interfaces;

namespace CSharpConsoleHangmanGame
{
    internal class Game
    {
        IServicesContainer servicesContainer;
        IGameStateManager gameStateManager;

        internal async Task Init()
        {
            servicesContainer = new TestAServicesContainer();

            // Some services (like database) needs Init out of constructor to use await for api request
            await servicesContainer.Init();

            gameStateManager = servicesContainer.GameStateManager;
        }

        internal void Run()
        {
            gameStateManager.Start();

            while (gameStateManager.HasState())
            {
                gameStateManager.UpdateCurrentState();
            }
        }
    }
}
