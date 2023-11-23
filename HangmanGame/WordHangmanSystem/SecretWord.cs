using CSharpConsoleHangmanGame.DialogueSystem.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CSharpConsoleHangmanGame.WordHangmanSystem
{
    internal class SecretWord
    {
        readonly IDialogueController dialogueController;
        readonly char hiddenLetterSymbol = '_';
        readonly string secretWord;
        readonly char[] hiddenLetters;
        string hiddenLettersAsString;
        readonly HashSet<char> hiddenUniqueLetters;

        internal string Word => secretWord;
        internal string HiddenLetters => hiddenLettersAsString;

        internal SecretWord(string word, IDialogueController dialogueController)
        {
            this.dialogueController = dialogueController;
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
