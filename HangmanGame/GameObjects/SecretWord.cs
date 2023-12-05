using CSharpConsoleHangmanGame.GameObjects.Interfaces;
using CSharpConsoleHangmanGame.GameSystems.Dialogue.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CSharpConsoleHangmanGame.GameObjects
{
    internal class SecretWord : ISecretWord
    {
        readonly IDialogueController dialogueController;
        readonly char hiddenLetterSymbol = '_';
        string secretWord;
        char[] hiddenLetters;
        HashSet<char> triedLetters;
        HashSet<char> uniqueLetters;
        HashSet<char> hiddenUniqueLetters;
        string hiddenLettersAsString;

        internal SecretWord(IDialogueController dialogueController)
        {
            this.dialogueController = dialogueController;
        }

        void ISecretWord.Init(string word)
        {
            secretWord = word.ToLower();
            hiddenLetters = new string(hiddenLetterSymbol, word.Length).ToCharArray();
            hiddenLettersAsString = CharArrayToSpacedString(hiddenLetters);
            uniqueLetters = new HashSet<char>(secretWord);
            hiddenUniqueLetters = new HashSet<char>(secretWord);
            triedLetters = new HashSet<char>();
        }

        bool ISecretWord.IsValidLetter(string? s)
        {
            return s != null && s.Length == 1 && char.IsLetter(s[0]);
        }

        bool ISecretWord.HasLetter(char letter)
        {
            return uniqueLetters.Contains(letter);
        }

        bool ISecretWord.TriedLetter(char letter)
        {
            if (triedLetters.Contains(letter))
                return true;

            triedLetters.Add(letter);

            return false;
        }

        bool ISecretWord.IsLetterRevealed(char letter)
        {
            return hiddenUniqueLetters.Contains(letter) == false;
        }

        void ISecretWord.RevealLetter(char letter)
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

        bool ISecretWord.IsComplete()
        {
            return hiddenUniqueLetters.Count == 0;
        }

        void ISecretWord.Draw()
        {
            dialogueController.ShowMessage(hiddenLettersAsString);
        }

        static string CharArrayToSpacedString(char[] a)
        {
            return string.Join(" ", a);
        }
    }
}
