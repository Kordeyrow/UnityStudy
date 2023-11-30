using CSharpConsoleHangmanGame.Debugging.Interfaces;
using CSharpConsoleHangmanGame.Debugging;
using CSharpConsoleHangmanGame.Dialogue.DialogueOptionsInputKeys;
using CSharpConsoleHangmanGame.Dialogue.Interfaces;
using CSharpConsoleHangmanGame.Dialogue;
using CSharpConsoleHangmanGame.GameData;
using CSharpConsoleHangmanGame.GameStates.Interfaces;
using CSharpConsoleHangmanGame.GameStates.States;
using CSharpConsoleHangmanGame.GameStates;
using CSharpConsoleHangmanGame.Dialogue;
using CSharpConsoleHangmanGame.Dialogue.Databases;
using CSharpConsoleHangmanGame.GameData.Interfaces;
using CSharpConsoleHangmanGame.ServicesContainers.Interfaces;
using CSharpConsoleHangmanGame.Dialogue.DialogueUnitKeys;
using CSharpConsoleHangmanGame.Dialogue.Databases.CloudCSVDialogueDatabase;

namespace CSharpConsoleHangmanGame.ServicesContainers
{
    internal class TestBServicesContainer : IServicesContainer
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
            Configs = new Configs(DebugLog);

            DialogueUnitKeys = new DialogueUnitKeys();
            DialogueDatabase = new CloudCSVDialogueDatabase(Configs.DialogueDatabaseURL,
                                                            DialogueUnitKeys);
            await DialogueDatabase.Init();

            DialogueOptionsInputKeys = new NumberDialogueOptionsInputKeys();
            DialogueController       = new ConsoleDialogueController(DialogueOptionsInputKeys);
            InitialGameState         = new MenuState(DebugLog,
                                                     DialogueController,
                                                     DialogueDatabase,
                                                     DialogueOptionsInputKeys,
                                                     Configs);

            GameStateManager = new GameStateManager(DialogueController, InitialGameState);
        }
    }
}
