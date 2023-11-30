using CSharpConsoleHangmanGame;

var game = new Game();

// For api requests
await game.Init();

game.Run();
