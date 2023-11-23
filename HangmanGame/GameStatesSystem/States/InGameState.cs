using CSharpConsoleHangmanGame.DialogueSystem.Interfaces;
using CSharpConsoleHangmanGame.GameStatesSystem.Interfaces;
using CSharpConsoleHangmanGame.WordHangmanSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpConsoleHangmanGame.GameStatesSystem.States
{
    internal class InGameState : IGameState
    {
        readonly IDialogueController dialogueController;
        readonly IDialogueDatabase dialogueDatabase;
        SecretWord secretWord;
        Hangman hangman;


        public InGameState(IDialogueController dialogueController, IDialogueDatabase dialogueDatabase)
        {
            this.dialogueController = dialogueController;
            this.dialogueDatabase = dialogueDatabase;
        }

        public void Enter()
        {
            secretWord = new("test", dialogueController);
            hangman = new(dialogueController);
        }

        private bool IsLetter(string? s)
        {
            return (s != null && s.Length == 1 && char.IsLetter(s[0]));
        }

        public IGameState? Update()
        {
            hangman.Draw();
            secretWord.Draw();

            dialogueDatabase.InGameDialogueDatabase().ShowStartGameMsg();

            // Get user try letter
            var input = dialogueDatabase.InGameDialogueDatabase().AskForLetter();
            if (input == null || IsLetter(input) == false)
                return this;
            var letter = input[0];

            // Good letter path (reward)
            if (secretWord.HasLetter(letter))
            {
                if(secretWord.IsLetterRevealed(letter))
                    return this;

                secretWord.RevealLetter(letter);

                if (secretWord.IsComplete() == false)
                    return this;

                // Win
                return new GameOverState(dialogueController, dialogueDatabase, true);
            }

            // Bad letter path (penalty)
            hangman.AddPart();

            if (hangman.IsComplete())
                return new GameOverState(dialogueController, dialogueDatabase, false);

            return this;
        }

        public void Exit()
        {
            
        }
    }
}
