using CSharpConsoleHangmanGame.Dialogue.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpConsoleHangmanGame.Dialogue.Databases
{
    internal abstract class BaseDialogueDatabase
    {
        protected readonly IDialogueController dialogueController;
        protected readonly IInputOptionsKeys inputOptions;

        protected BaseDialogueDatabase(IDialogueController dialogueController, IInputOptionsKeys inputOptions)
        {
            this.dialogueController = dialogueController;
            this.inputOptions = inputOptions;
        }
    }
}
