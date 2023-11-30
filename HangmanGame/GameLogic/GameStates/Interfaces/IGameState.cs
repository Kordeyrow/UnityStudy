namespace CSharpConsoleHangmanGame.GameLogic.GameStates.Interfaces
{
    internal interface IGameState
    {
        void Enter();
        void Exit();
        IGameState? Update();
    }
}
