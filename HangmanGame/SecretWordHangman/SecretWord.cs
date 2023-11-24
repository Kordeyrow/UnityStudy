using CSharpConsoleHangmanGame.Dialogue.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CSharpConsoleHangmanGame.SecretWordHangman
{
    internal class SecretWord
    {
        readonly IDialogueController dialogueController;
        readonly char hiddenLetterSymbol = '_';
        string secretWord;
        char[] hiddenLetters;
        HashSet<char> hiddenUniqueLetters;
        string hiddenLettersAsString;

        internal string Word => secretWord;
        internal string HiddenLetters => hiddenLettersAsString;

        internal SecretWord(IDialogueController dialogueController)
        {
            this.dialogueController = dialogueController;
        }

        internal void Init(string word)
        {
            secretWord = word.ToLower();
            hiddenLetters = new string(hiddenLetterSymbol, word.Length).ToCharArray();
            hiddenLettersAsString = CharArrayToSpacedString(hiddenLetters);
            hiddenUniqueLetters = new HashSet<char>(secretWord);
        }

        internal static string CharArrayToSpacedString(char[] a)
        {
            return string.Join(" ", a);
        }

        internal bool HasLetter(char letter)
        {
            return hiddenUniqueLetters.Contains(letter);
        }

        internal bool IsLetterRevealed(char letter)
        {
            return hiddenUniqueLetters.Contains(letter) == false;
        }

        internal void RevealLetter(char letter)
        {
            hiddenUniqueLetters.Remove(letter);

            for (int i = 0; i < secretWord.Length; i++)
            {
                if (secretWord[i] == letter)
                {
                    hiddenLetters[i] = letter;
                }
            }
            hiddenLettersAsString = CharArrayToSpacedString(hiddenLetters);
        }

        internal bool IsComplete()
        {
            return hiddenUniqueLetters.Count == 0;
        }

        internal void Draw()
        {
            dialogueController.ShowMessage(hiddenLettersAsString);
        }
    }
}
