using CSharpConsoleHangmanGame.DialogueSystem;
using CSharpConsoleHangmanGame.DialogueSystem.Interfaces;
using CSharpConsoleHangmanGame.DialogueSystem.InputOptions;
using CSharpConsoleHangmanGame.GameStatesSystem;
using CSharpConsoleHangmanGame.GameStatesSystem.Interfaces;
using CSharpConsoleHangmanGame.GameStatesSystem.States;
using CSharpConsoleHangmanGame.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpConsoleHangmanGame
{
    internal class Game
    {
        readonly StateManager stateManager;
        readonly TimeSpan userInputEffectDelay = new(0,0,0,0,100);
        readonly IDialogueController dialogueController;

        internal Game()
        {
            // Controlls Input and Output to communicate with User
            dialogueController = new ConsoleDialogueController();

            // Has all the options keys that User can type
            IInputOptions inputOptions = new NumberInputOptions();

            // Has all the messages to User
            IDialogueDatabase dialogueDatabase = new BRDialogueDatabase(dialogueController, inputOptions);

            // Game State
            IGameState initialGameState = new MenuState(dialogueController, dialogueDatabase);
            this.stateManager = new StateManager(initialGameState);
        }

        internal void Run()
        {
            while (stateManager.HasState())
            {
                stateManager.Update();
                WaitDuration(userInputEffectDelay);
                dialogueController.Clear();
            }
        }

        internal static void WaitDuration(TimeSpan timeout)
        {
            Thread.Sleep(timeout);
        }
    }
}
