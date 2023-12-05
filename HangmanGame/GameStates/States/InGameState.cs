using CSharpConsoleHangmanGame.GameSystems.Dialogue.Interfaces;
using CSharpConsoleHangmanGame.GameStates.Interfaces;
using CSharpConsoleHangmanGame.GameObjects.Interfaces;
using CSharpConsoleHangmanGame.Databases.GuessWords.Interfaces;
using CSharpConsoleHangmanGame.Databases.Dialogue.Interfaces;

namespace CSharpConsoleHangmanGame.GameStates.States
{
    internal class InGameState : IGameState
    {
        readonly IDialogueController dialogueController;
        readonly IInGameDialogueDatabase inGameDB;
        readonly IGameStateContainer gameOverGameStateContainer;
        readonly IGuessWordsDatabase wordsDatabase;
        readonly ISharedGameData sharedGameData;
        readonly IHangman hangman;
        readonly ISecretWord secretWord;

        IGameState currentState;

        /// ( Show start welcome message ) 
        ///
        public InGameState(
            IDialogueController dialogueController,
            IInGameDialogueDatabase inGameDialogueDatabase,
            IGameStateContainer gameOverGameStateContainer,
            IGuessWordsDatabase wordsDatabase,
            ISharedGameData sharedGameData,
            IHangman hangman,
            ISecretWord secretWord)
        {
            this.dialogueController = dialogueController;
            this.inGameDB = inGameDialogueDatabase;
            this.gameOverGameStateContainer = gameOverGameStateContainer;
            this.sharedGameData = sharedGameData;
            this.wordsDatabase = wordsDatabase;
            this.hangman = hangman;
            this.secretWord = secretWord;
        }

        void IGameState.Enter()
        {
            currentState = this;

            /// ( Init secretWord, hangman ) 
            ///
            var randomWord = wordsDatabase.GetRandomMediumWord();
            secretWord.Init(randomWord);
            hangman.Init();

            /// ( Show game started message ) 
            ///
            dialogueController.ShowMessage(inGameDB.GameStartedMessage);
            dialogueController.WaitForEnterOrEspaceInput();
        }

        void IGameState.Exit()
        {

        }

        IGameState IGameState.Update()
        {
            /// ( Show letter request ) 
            ///
            dialogueController.ShowMessage(inGameDB.LetterRequest);

            /// ( Draw game ) 
            ///
            secretWord.Draw();
            hangman.Draw();

            /// ( Read letter input ) 
            ///
            var input = dialogueController.ReadInput();
            if (secretWord.IsValidLetter(input) == false)
                return currentState;

            var letter = input[0];

            if (secretWord.TriedLetter(letter))
                return currentState;

            /// ( Correct letter (reward) ) 
            ///
            if (secretWord.HasLetter(letter))
            {
                /// ( Ignore revealed letter ) 
                ///
                if (secretWord.IsLetterRevealed(letter))
                    return currentState;

                /// ( Reveal letter ) 
                ///
                secretWord.RevealLetter(letter);

                /// ( Won ? -> GameOver state ) 
                ///
                if (secretWord.IsComplete())
                    GameOver(won: true);
            }
            else
            {
                /// ( Wrong letter, Apply penalty ) 
                ///
                hangman.AddPart();

                /// ( Lost ? -> GameOver state ) 
                ///
                if (hangman.IsComplete())
                    GameOver(won: false);
            }

            return currentState;
        }

        void GameOver(bool won)
        {
            sharedGameData.Won = won;
            currentState = gameOverGameStateContainer.GameState;
        }
    }
}
