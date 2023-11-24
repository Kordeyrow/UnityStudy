using CSharpConsoleHangmanGame.Dialogue;
using CSharpConsoleHangmanGame.Dialogue.Interfaces;
using CSharpConsoleHangmanGame.Dialogue.InputOptionsKeys;
using CSharpConsoleHangmanGame.GameState;
using CSharpConsoleHangmanGame.GameState.Interfaces;
using CSharpConsoleHangmanGame.GameState.States;
using CSharpConsoleHangmanGame.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharpConsoleHangmanGame.Debugging.Interfaces;
using CSharpConsoleHangmanGame.Debugging;

namespace CSharpConsoleHangmanGame
{
    internal class Game
    {
        readonly GameStateManager gameStateManager;

        internal Game()
        {
            // Output messages for developer
            IDebugLog debugLog = new DebugLog();

            // Dialogue I/O: game Output / player Input
            IDialogueController dialogueController = new ConsoleDialogueController();

            // Player input options keys
            IInputOptionsKeys inputOptions = new NumberInputOptionsKeys();

            // Dialogue database (by language)
            IDialogueDatabase dialogueDatabase = new BRDialogueDatabase(dialogueController, inputOptions);

            // Game State
            IGameState initialGameState = new MenuState(debugLog, dialogueController, dialogueDatabase);
            gameStateManager = new GameStateManager(dialogueController, initialGameState);
        }

        internal void Run()
        {
            gameStateManager.Start();

            while (gameStateManager.HasState())
            {
                gameStateManager.UpdateCurrentState();
            }
        }
    }
}
