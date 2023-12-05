namespace CSharpConsoleHangmanGame.Databases.Dialogue.Interfaces
{
    internal interface IGameOverDialogueDatabase
    {
        string WinMessage { get; }
        string LoseMessage { get; }
        string EndChoiceQuestion { get; }
        string EndChoicePlayAgainOption { get; }
        string EndChoiceExitToMenuOption { get; }
    }
}
