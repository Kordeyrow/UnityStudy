using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharpConsoleHangmanGame.DialogueSystem.Databases;
using CSharpConsoleHangmanGame.DialogueSystem.Interfaces;

namespace CSharpConsoleHangmanGame.DialogueSystem
{
    internal class BRDialogueDatabase : BaseDialogueDatabase, IDialogueDatabase
    {
        public BRDialogueDatabase(IDialogueController dialogueController, IInputOptions inputOptions) : base(dialogueController, inputOptions)
        {
        }

        public IMenuDialogueDatabase MenuDialogueDatabase()
        {
            return new BRMenuDialogueDatabase(dialogueController, inputOptions);
        }
    }

    internal class BRMenuDialogueDatabase : BaseDialogueDatabase, IMenuDialogueDatabase
    {
        string GetUserOptionStartGameOrExitMessage = "Bem-vindos, almas condenadas e curiosas, ao infernal e surpreendentemente divertido jogo de Forca! Eu sou seu anfitrião, o Príncipe das Trevas, também conhecido como o mestre das palavras perdidas e mal pronunciadas. Permitam-me apresentar suas infernais opções neste caldeirão de decisões:";
        string StartGameOptionText = "Start Game";
        string ExitGameOptionText = "Exit Game";

        public BRMenuDialogueDatabase(IDialogueController dialogueController, IInputOptions inputOptions) : base(dialogueController, inputOptions)
        {
        }

        public static void ClearCurrentConsoleLine()
        {
            Console.SetCursorPosition(0, Console.CursorTop - 1);
            int currentLineCursor = Console.CursorTop;
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write(new string(' ', Console.BufferWidth));
            Console.SetCursorPosition(0, currentLineCursor);
        }

        public void GetUserOptionStartGameOrExit(Action startGameAction, Action exitGameAction)
        {
            dialogueController.ShowMessage(GetUserOptionStartGameOrExitMessage);
            dialogueController.ShowMessage("");
            dialogueController.ShowInputOptions(
                new string[] {
                    inputOptions.Option1() + ". " + StartGameOptionText,
                    inputOptions.Option2() + ". " + ExitGameOptionText
                }
            );
            dialogueController.ShowMessage("");

            var input = dialogueController.ReadInput();
            if (input == inputOptions.Option1())
            {
                startGameAction();
                return;
            }
            if (input == inputOptions.Option2())
            {
                exitGameAction();
                return;
            }
        }
    }
}