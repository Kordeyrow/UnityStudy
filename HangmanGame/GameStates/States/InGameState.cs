using CSharpConsoleHangmanGame.Debugging.Interfaces;
using CSharpConsoleHangmanGame.Dialogue.Interfaces;
using CSharpConsoleHangmanGame.GameData.Interfaces;
using CSharpConsoleHangmanGame.GameStates.Interfaces;
using CSharpConsoleHangmanGame.SecretWordHangman;

namespace CSharpConsoleHangmanGame.GameStates.States
{
    internal class InGameState : IGameState
    {
        readonly IDebugLog           debugLog;
        readonly IDialogueController dialogueController;
        readonly IDialogueDatabase   dialogueDatabase;
        readonly IInputOptionsKeys   inputOptionsKeys;
        readonly WordsDatabase       wordsDatabase;
        readonly IConfigs            configs;
        private SecretWord           secretWord;
        private Hangman              hangman;

        // TODO: get WordsFilePath directly
        public InGameState(IDebugLog           debugLog, 
                           IDialogueController dialogueController, 
                           IDialogueDatabase   dialogueDatabase,
                           IInputOptionsKeys   inputOptionsKeys,
                           IConfigs            configs)
        {
            this.debugLog           = debugLog;
            this.dialogueController = dialogueController;
            this.dialogueDatabase   = dialogueDatabase;
            this.inputOptionsKeys = inputOptionsKeys;
            this.configs            = configs;
            this.wordsDatabase      = new WordsDatabase(debugLog, configs.WordsFilePath);
            this.secretWord         = new(dialogueController);
            this.hangman            = new(dialogueController);
        }

        public void Enter()
        {
            // Init secretWord, hangman
            var randomWord = wordsDatabase.GetRandomMediumWord();
            secretWord.Init(randomWord);
            hangman.Init();

            var db = dialogueDatabase.InGameDialogueDatabase;

            // Show game started message
            dialogueController.ShowMessage(db.GameStartedMessage);
        }

        public IGameState? Update()
        {
            var db = dialogueDatabase.InGameDialogueDatabase;


            // Ask user for letter
            dialogueController.ShowMessage(db.LetterRequest);

            // Draw game
            secretWord.Draw();
            hangman.Draw();

            var input = dialogueController.ReadInput();
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
                    return new GameOverState(debugLog, 
                                             dialogueController, 
                                             dialogueDatabase,
                                             inputOptionsKeys,
                                             configs,
                                             true);

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
                    return new GameOverState(debugLog, 
                                             dialogueController, 
                                             dialogueDatabase,
                                             inputOptionsKeys,
                                             configs, 
                                             false);

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
