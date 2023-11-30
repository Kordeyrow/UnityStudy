namespace CSharpConsoleHangmanGame.GameLogic.GameStates.Interfaces
{
    internal interface IGameStateManager
    {
        void Start();
        bool HasState();
        void UpdateCurrentState();
    }
}
