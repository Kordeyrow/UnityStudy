namespace CSharpConsoleHangmanGame.Databases.Dialogue.Interfaces
{
    internal interface IInGameDialogueDatabase
    {
        string GameStartedMessage { get; }
        string LetterRequest { get; }
    }
}
