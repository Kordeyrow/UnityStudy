using CSharpConsoleHangmanGame.DialogueSystem.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpConsoleHangmanGame.DialogueSystem.Databases
{
    internal abstract class BaseDialogueDatabase
    {
        protected readonly IDialogueController dialogueController;
        protected readonly IInputOptions inputOptions;

        protected BaseDialogueDatabase(IDialogueController dialogueController, IInputOptions inputOptions)
        {
            this.dialogueController = dialogueController;
            this.inputOptions = inputOptions;
        }
    }
}
