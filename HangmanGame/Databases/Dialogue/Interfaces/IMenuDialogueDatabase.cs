namespace CSharpConsoleHangmanGame.Databases.Dialogue.Interfaces
{
    internal interface IMenuDialogueDatabase
    {
        string WelcomeMessage { get; }
        string StartChoiseQuestion { get; }
        string StartChoiseStartGameOption { get; }
        string StartChoiseExitGameOption { get; }
    }
}
