using CSharpConsoleHangmanGame.Debugging;
using CSharpConsoleHangmanGame.Debugging.Interfaces;
using CSharpConsoleHangmanGame.Dialogue.Interfaces;
using CSharpConsoleHangmanGame.FileManaging;
using CSharpConsoleHangmanGame.GameState.Interfaces;
using CSharpConsoleHangmanGame.SecretWordHangman;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CSharpConsoleHangmanGame.GameState.States
{
    internal class InGameState : IGameState
    {
        readonly IDebugLog debugLog;
        readonly IDialogueController dialogueController;
        readonly IDialogueDatabase dialogueDatabase;
        readonly WordsDatabase wordsDatabase;
        SecretWord secretWord;
        Hangman hangman;


        public InGameState(IDebugLog debugLog, IDialogueController dialogueController, IDialogueDatabase dialogueDatabase)
        {
            this.debugLog = debugLog;
            this.dialogueController = dialogueController;
            this.dialogueDatabase = dialogueDatabase;
            wordsDatabase = new WordsDatabase(debugLog);
            secretWord = new(dialogueController);
            hangman = new(dialogueController);
        }

        public void Enter()
        {
            // Init secretWord, hangman
            var randomWord = wordsDatabase.GetRandomMediumWord();
            secretWord.Init(randomWord);
            hangman.Init();
        }

        public IGameState? Update()
        {
            // Draw
            hangman.Draw();
            secretWord.Draw();

            // Dialogue
            dialogueDatabase.InGameDialogueDatabase().ShowStartGameMsg();

            // Get user try letter
            var input = dialogueDatabase.InGameDialogueDatabase().AskForLetter();
            if (input == null || IsLetter(input) == false)
                return this;
            var letter = input[0];

            // Good letter (reward)
            if (secretWord.HasLetter(letter))
            {
                // Ignore letter ?
                if (secretWord.IsLetterRevealed(letter))
                    return this;

                // Reveal letter
                secretWord.RevealLetter(letter);

                // Win ?
                if (secretWord.IsComplete())
                    return new GameOverState(debugLog, dialogueController, dialogueDatabase, true);

                // Continue
                return this;
            }
            // Bad letter (penalty)
            else
            {
                // Apply penalty
                hangman.AddPart();

                // Lose ?
                if (hangman.IsComplete())
                    return new GameOverState(debugLog, dialogueController, dialogueDatabase, false);

                // Continue
                return this;
            }
        }

        public void Exit()
        {

        }

        internal void NewSecretWord()
        {

        }

        private static bool IsLetter(string? s)
        {
            return (s != null && s.Length == 1 && char.IsLetter(s[0]));
        }
    }
}
