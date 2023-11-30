using CSharpConsoleHangmanGame.GameGenericModules.Dialogue.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpConsoleHangmanGame.GameLogic.SecretWordHangman
{
    internal class Hangman
    {
        readonly IDialogueController dialogueController;
        readonly string[] partsSymbols = new string[] { "O", "\n --", "|", "--", "\n  /", " \\" };
        readonly int totalParts;
        int currentParts = 0;
        string currentPartsSymbols = "";

        internal Hangman(IDialogueController dialogueController)
        {
            this.dialogueController = dialogueController;
            totalParts = partsSymbols.Length;
        }

        internal void Init()
        {
            currentParts = 0;
            currentPartsSymbols = "";
        }

        internal void AddPart()
        {
            if (IsComplete())
                return;

            currentParts += 1;
            currentPartsSymbols += partsSymbols[currentParts - 1];
        }

        internal bool IsComplete()
        {
            return currentParts >= totalParts;
        }

        internal void Draw()
        {
            dialogueController.ShowMessage(currentPartsSymbols);
        }
    }
}
