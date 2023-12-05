namespace CSharpConsoleHangmanGame.GameStates.Interfaces
{
    internal interface IGameStateManager
    {
        void Start();
        bool CloseGameState();
        void UpdateCurrentState();
        void End();
    }
}
