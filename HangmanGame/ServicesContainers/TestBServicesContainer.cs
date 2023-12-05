using CSharpConsoleHangmanGame.ServicesContainers.Interfaces;
using CSharpConsoleHangmanGame.Utils.Debugging;
using CSharpConsoleHangmanGame.GameSystems.Dialogue.DialogueUnitKeys;
using CSharpConsoleHangmanGame.GameSystems.Dialogue.DialogueOptionsInputKey;
using CSharpConsoleHangmanGame.GameSystems.Dialogue.DialogueController;
using CSharpConsoleHangmanGame.GameStates.Interfaces;
using CSharpConsoleHangmanGame.GameStates.States;
using CSharpConsoleHangmanGame.GameStates;
using CSharpConsoleHangmanGame.Utils.HttpService;
using CSharpConsoleHangmanGame.GameObjects;
using CSharpConsoleHangmanGame.Utils.FileManaging;
using CSharpConsoleHangmanGame.Utils.Debugging.Interfaces;
using CSharpConsoleHangmanGame.Databases.GuessWords;
using CSharpConsoleHangmanGame.Databases.GuessWords.Interfaces;
using CSharpConsoleHangmanGame.Databases.Dialogue.CloudCSVDialogueDatabase;
using Optional;
using CSharpConsoleHangmanGame.AppSettings.Model.Sections;

namespace CSharpConsoleHangmanGame.ServicesContainers
{
    internal class TestBServicesContainer : IServicesContainer
    {
        public Option<IGameStateManager> GameStateManager { get; private set; }

        public async Task Init(GameConfigsModel gameConfig)
        {
            /// ( Debug ) 
            IDebugLog debugLog = new ConsoleDebugLog();

            /// ( Json Converter ) 
            var jsonConverter = new JsonConverter(debugLog);

            /// ( File Reader ) 
            var fileReader = new FileReader(
                debugLog,
                jsonConverter);

            /// ( Http Service ) 
            var httpService = new HttpService(debugLog);

            /// ( Dialogue Database ) 
            /// 
            var dialogueUnitKeys = new DialogueUnitKeys();

            var dialogueDatabase = new CloudCSVDialogueDatabase(
                debugLog,
                httpService,
                dialogueUnitKeys,
                gameConfig.DialogueInfo.DatabaseURL,
                gameConfig.DialogueInfo.CurrentLanguageID);
            await dialogueDatabase.Init();

            if (dialogueDatabase.Empty)
            {
                debugLog.Warn("Error: Empty DialogueDatabase");
                return;
            }

            /// ( Dialogue Controller ) 
            /// 
            var dialogueOptionsInputKeys = new LetterDialogueOptionsInputKeys();
            var dialogueController = new ConsoleDialogueController(dialogueOptionsInputKeys);

            /// ( GameState Containers ) 
            /// 
            var menuGameStateContainer = new GameStateContainer();
            var inGameStateContainer = new GameStateContainer();
            var gameOverGameStateContainer = new GameStateContainer();
            var closeGameStateContainer = new GameStateContainer();

            /// ( Shared GameData ) 
            /// 
            var sharedGameData = new SharedGameData();

            /// ( GameState: MENU ) 
            /// 
            var menuDialogueDatabase = dialogueDatabase.MenuDialogueDatabase;
            var menuGameState = new MenuState(
                dialogueController,
                menuDialogueDatabase,
                inGameStateContainer,
                closeGameStateContainer);

            /// ( GameState: IN GAME ) 
            /// 
            IGuessWordsDatabase wordsDatabase = new GuessWordsDatabase(
                fileReader,
                gameConfig.GuessWordsInfo.DatabaseFilePath);
            if (wordsDatabase.Empty())
            {
                debugLog.Warn("Error: Empty WordsDatabase");
                return;
            }
            var hangman = new Hangman(dialogueController);
            var secretWord = new SecretWord(dialogueController);
            var inGameState = new InGameState(
                dialogueController,
                dialogueDatabase.InGameDialogueDatabase,
                gameOverGameStateContainer,
                wordsDatabase,
                sharedGameData,
                hangman,
                secretWord);

            /// ( GameState: GAME OVER ) 
            /// 
            var gameOver = new GameOverState(
                dialogueController,
                dialogueDatabase.GameOverDialogueDatabase,
                inGameStateContainer,
                menuGameStateContainer,
                sharedGameData);

            /// ( GameState: CLOSE ) 
            /// 
            var closeGameState = new CloseGameState(
                dialogueController,
                dialogueDatabase.CloseGameDialogueDatabase);

            /// ( Init Containers ) 
            /// 
            menuGameStateContainer.Init(menuGameState);
            inGameStateContainer.Init(inGameState);
            gameOverGameStateContainer.Init(gameOver);
            closeGameStateContainer.Init(closeGameState);

            /// ( Start GameStateManager ) 
            /// 
            var gameState = new GameStateManager(
                dialogueController,
                menuGameState);
            GameStateManager = Option.Some<IGameStateManager>(gameState);
        }
    }
}
