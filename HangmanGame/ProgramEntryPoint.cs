using CSharpConsoleHangmanGame;

var game = new Game();

// For http requests
await game.Init();

game.Run();
