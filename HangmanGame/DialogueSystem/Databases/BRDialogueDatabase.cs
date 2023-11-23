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

        public IGameOverDialogueDatabase GameOverDialogueDatabase()
        {
            return new BRGameOverDialogueDatabase(dialogueController, inputOptions);
        }

        public IInGameDialogueDatabase InGameDialogueDatabase()
        {
            return new BRInGameDialogueDatabase(dialogueController, inputOptions);
        }

        public IMenuDialogueDatabase MenuDialogueDatabase()
        {
            return new BRMenuDialogueDatabase(dialogueController, inputOptions);
        }
    }

    internal class BRMenuDialogueDatabase : BaseDialogueDatabase, IMenuDialogueDatabase
    {

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

        readonly string getUserOptionStartGameOrExitMessage = "Bem-vindos, almas condenadas e curiosas, ao infernal e surpreendentemente divertido jogo de Forca! Eu sou seu anfitrião, o Príncipe das Trevas, também conhecido como o mestre das palavras perdidas e mal pronunciadas. Permitam-me apresentar suas infernais opções neste caldeirão de decisões:";
        readonly string startGameOptionText = "Start Game";
        readonly string exitGameOptionText = "Exit Game";
        public void AskUserOptionStartGameOrExitGame(Action startGameAction, Action exitGameAction)
        {
            dialogueController.ShowMessage(getUserOptionStartGameOrExitMessage);
            dialogueController.ShowMessage("");
            dialogueController.ShowInputOptions(
                new string[] {
                    inputOptions.Option1() + ". " + startGameOptionText,
                    inputOptions.Option2() + ". " + exitGameOptionText
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

    internal class BRInGameDialogueDatabase : BaseDialogueDatabase, IInGameDialogueDatabase
    {
        public BRInGameDialogueDatabase(IDialogueController dialogueController, IInputOptions inputOptions) : base(dialogueController, inputOptions)
        {
        }

        readonly string startGameMsg = "Começou!";
        public void ShowStartGameMsg()
        {
            dialogueController.ShowMessage(startGameMsg);
            dialogueController.ShowMessage("");
        }

        readonly string askForLetterMsg = "Chute uma letra!";
        public string? AskForLetter()
        {
            dialogueController.ShowMessage(askForLetterMsg);

            return dialogueController.ReadInput();
        }
    }

    internal class BRGameOverDialogueDatabase : BaseDialogueDatabase, IGameOverDialogueDatabase
    {
        public BRGameOverDialogueDatabase(IDialogueController dialogueController, IInputOptions inputOptions) : base(dialogueController, inputOptions)
        {
        }

        readonly string winMsg = "Ganhou!";
        readonly string loseMsg = "Perdeu!";
        public void ShowResultsMsg(bool win)
        {
            if (win)
                dialogueController.ShowMessage(winMsg);
            else
                dialogueController.ShowMessage(loseMsg);
        }

        readonly string askUserOptionPlayAgainOrExitToMenuMessage = "Jogar de novo ou ir para menu?";
        readonly string playAgainOptionText = "Jogar de novo!";
        readonly string exitToMenuOptionText = "Voltar para o menu";
        public void AskUserOptionPlayAgainOrExitToMenu(Action playAgainAction, Action exitToMenuAction)
        {
            dialogueController.ShowMessage(askUserOptionPlayAgainOrExitToMenuMessage);
            dialogueController.ShowMessage("");
            dialogueController.ShowInputOptions(
                new string[] {
                    inputOptions.Option1() + ". " + playAgainOptionText,
                    inputOptions.Option2() + ". " + exitToMenuOptionText
                }
            );
            dialogueController.ShowMessage("");

            var input = dialogueController.ReadInput();
            if (input == inputOptions.Option1())
            {
                playAgainAction();
                return;
            }
            if (input == inputOptions.Option2())
            {
                exitToMenuAction();
                return;
            }
        }
    }
}