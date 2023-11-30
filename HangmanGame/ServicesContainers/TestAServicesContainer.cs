using CSharpConsoleHangmanGame.ServicesContainers.Interfaces;
using CSharpConsoleHangmanGame.HelperServices.Debugging.Interfaces;
using CSharpConsoleHangmanGame.GameGenericModules.Dialogue.Interfaces;
using CSharpConsoleHangmanGame.GameLogic.GameStates.Interfaces;
using CSharpConsoleHangmanGame.HelperServices.Debugging;
using CSharpConsoleHangmanGame.GameGenericModules.Dialogue.DialogueUnitKeys;
using CSharpConsoleHangmanGame.GameGenericModules.Dialogue.Databases.CloudCSVDialogueDatabase;
using CSharpConsoleHangmanGame.GameGenericModules.Dialogue.DialogueOptionsInputKeys;
using CSharpConsoleHangmanGame.GameGenericModules.Dialogue.DialogueControllers;
using CSharpConsoleHangmanGame.GameLogic.GameStates.States;
using CSharpConsoleHangmanGame.GameLogic.GameStates;
using CSharpConsoleHangmanGame.GameData.Interfaces;
using CSharpConsoleHangmanGame.GameData;

namespace CSharpConsoleHangmanGame.ServicesContainers
{
    internal class TestAServicesContainer : IServicesContainer
    {
        public IDebugLog                 DebugLog { get; private set; }
        public IDialogueOptionsInputKeys DialogueOptionsInputKeys { get; private set; }
        public IDialogueController       DialogueController { get; private set; }
        public IConfigs                  Configs { get; private set; }
        public IDialogueUnitKeys         DialogueUnitKeys { get; private set; }
        public IDialogueDatabase         DialogueDatabase { get; private set; }
        public IGameState                InitialGameState { get; private set; }
        public IGameStateManager         GameStateManager { get; private set; }

        public async Task Init()
        {
            DebugLog = new DebugLog();
            Configs  = new Configs(DebugLog);

            DialogueUnitKeys = new DialogueUnitKeys();
            DialogueDatabase = new CloudCSVDialogueDatabase(DebugLog,
                                                            Configs.DialogueDatabaseURL, 
                                                            DialogueUnitKeys);
            await DialogueDatabase.Init();

            DialogueOptionsInputKeys   = new NumberDialogueOptionsInputKeys();
            DialogueController = new ConsoleDialogueController(DialogueOptionsInputKeys);
            InitialGameState   = new MenuState(DebugLog, 
                                               DialogueController, 
                                               DialogueDatabase,
                                               Configs);

            GameStateManager = new GameStateManager(DialogueController, InitialGameState);
        }
    }
}