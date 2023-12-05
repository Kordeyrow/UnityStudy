using CSharpConsoleHangmanGame.GameObjects.Interfaces;
using CSharpConsoleHangmanGame.GameSystems.Dialogue.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpConsoleHangmanGame.GameObjects
{
    internal class Hangman : IHangman
    {
        readonly IHangman thisIHangman;
        readonly IDialogueController dialogueController;
        readonly string[] partsSymbols = new string[] { "   O", "\n --", "|", "--", "\n  /", " \\" };
        readonly int totalParts;
        int currentParts = 0;
        string currentPartsSymbols = "";

        internal Hangman(IDialogueController dialogueController)
        {
            thisIHangman = this;
            this.dialogueController = dialogueController;
            totalParts = partsSymbols.Length;
        }

        void IHangman.Init()
        {
            currentParts = 0;
            currentPartsSymbols = "";
        }

        bool IHangman.IsComplete()
        {
            return currentParts >= totalParts;
        }

        void IHangman.AddPart()
        {
            if (thisIHangman.IsComplete())
                return;

            currentParts += 1;
            currentPartsSymbols += partsSymbols[currentParts - 1];
        }

        void IHangman.Draw()
        {
            dialogueController.ShowRawLine(currentPartsSymbols);
            dialogueController.JumpLine();
        }
    }
}
