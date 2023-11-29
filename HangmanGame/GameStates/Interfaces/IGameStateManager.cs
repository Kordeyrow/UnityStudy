namespace CSharpConsoleHangmanGame.GameStates.Interfaces
{
    internal interface IGameStateManager
    {
        void Start();
        bool HasState();
        void UpdateCurrentState();
    }
}
