using CSharpConsoleHangmanGame.GameStates.Interfaces;
using Optional;
using CSharpConsoleHangmanGame.AppSettings.Model.Sections;

namespace CSharpConsoleHangmanGame.ServicesContainers.Interfaces
{
    internal interface IServicesContainer
    {
        Option<IGameStateManager> GameStateManager { get; }
        Task Init(GameConfigsModel appSettings);
    }
}
