namespace CSharpConsoleHangmanGame.GameSystems.Dialogue.Interfaces.DialogueUnitKeys
{
    internal interface IGameOverDialogueUnitKeys
    {
        string WinMessage { get; }
        string LoseMessage { get; }
        string EndChoiceQuestion { get; }
        string EndChoicePlayAgainOption { get; }
        string EndChoiceExitToMenuOption { get; }
    }
}
