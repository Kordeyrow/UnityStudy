using CSharpConsoleHangmanGame.GameSystems.Dialogue.Interfaces;

namespace CSharpConsoleHangmanGame.GameSystems.Dialogue.DialogueController
{
    internal class ConsoleDialogueController : IDialogueController
    {
        readonly IDialogueController thisIDialogueController;
        readonly IDialogueOptionsInputKeys inputOptionsKeys;
        const string messagePrefix = "- ";
        readonly static string optionPrefix = "  > ";
        readonly static string continuePrefix = " ...";
        readonly static string userInputPrefix = " : ";

        public ConsoleDialogueController(IDialogueOptionsInputKeys inputOptionsKeys)
        {
            thisIDialogueController = this;
            this.inputOptionsKeys = inputOptionsKeys;
        }

        void IDialogueController.ShowRawText(string? text)
        {
            Console.Write(text);
        }

        void IDialogueController.ShowRawLine(string? text)
        {
            Console.WriteLine(text);
        }

        void IDialogueController.ShowMessage(string? text)
        {
            var finalText = AddSpace(AddPrefix(text));
            thisIDialogueController.ShowRawLine(finalText);
            Console.WriteLine("");
        }

        string? IDialogueController.ReadInput()
        {
            thisIDialogueController.ShowRawText(userInputPrefix);
            return Console.ReadLine();
        }

        void IDialogueController.Clear()
        {
            Console.Clear();
        }

        void IDialogueController.JumpLine()
        {
            thisIDialogueController.ShowRawLine("");
        }

        bool IDialogueController.ShowOptionsAndExecuteChosen(IDialogueOptionData[] options)
        {
            // Show options
            var optionKeyValueSeparator = ". ";

            var inputOptionsKeys = this.inputOptionsKeys.OptionsKeys(options.Length);

            for (int i = 0; i < inputOptionsKeys.Length; i++)
            {
                var option = options[i];
                var msg = inputOptionsKeys[i] + optionKeyValueSeparator + option.Text;
                var finalText = AddSpace(AddPrefix(msg, optionPrefix));
                thisIDialogueController.ShowRawLine(finalText);
            }

            thisIDialogueController.JumpLine();

            // Get input
            var rawInput = thisIDialogueController.ReadInput();
            if (rawInput == null)
                return false;
            var input = rawInput.ToLower();

            // Execute chosen option

            // TODO: use dict

            for (int i = 0; i < inputOptionsKeys.Length; i++)
            {
                if (input == inputOptionsKeys[i].ToLower())
                {
                    options[i].Action();
                    return true;
                }
            }
            return false;
        }

        public void ClearCurrentLine()
        {
            //Console.SetCursorPosition(0, Console.CursorTop - 1);
            int currentLineCursor = Console.CursorTop;
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write(new string(' ', Console.BufferWidth));
            Console.SetCursorPosition(0, currentLineCursor);
        }

        static string? AddSpace(string? text)
        {
            if (text != null && text != "")
                text = " " + text;
            return text;
        }

        static string? AddPrefix(string? text, string prefix = messagePrefix)
        {
            if (text != null && text != "")
                text = prefix + text;
            return text;
        }

        public void WaitForEnterOrEspaceInput()
        {
            thisIDialogueController.ShowRawText(continuePrefix);
            while (true)
            {
                var key = Console.ReadKey(true).Key;
                if (key == ConsoleKey.Enter || key == ConsoleKey.Spacebar)
                    break;
            }
            ClearCurrentLine();
        }
    }
}
