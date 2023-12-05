using CSharpConsoleHangmanGame;
using CSharpConsoleHangmanGame.AppSettings;
using CSharpConsoleHangmanGame.ServicesContainers;
using Optional.Unsafe;

/// ( AppSettings ) 
/// 
var appsettingsFilePath = "Game Settings/appsettings.json";
var appSettings = new AppSettings(appsettingsFilePath);

if (appSettings.GameConfigsOpt.HasValue == false)
{
    Console.WriteLine($"\nTerminating Program.");
    Console.ReadLine();
    return;
}

/// ( Services ) 
/// 
var servicesContainer = new TestAServicesContainer();
await servicesContainer.Init(appSettings.GameConfigsOpt.ValueOrDefault());
servicesContainer.GameStateManager.MatchNone(() =>
{
    Console.WriteLine($"\nTerminating Program.");
    Console.ReadLine();
});

/// ( GameStateManager ) 
/// 
servicesContainer.GameStateManager.MatchSome(gameStateManager =>
{
    var game = new Game(gameStateManager);
    game.Run();
});