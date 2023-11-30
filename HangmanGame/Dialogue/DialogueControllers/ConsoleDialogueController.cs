using CSharpConsoleHangmanGame.Dialogue.Databases;
using CSharpConsoleHangmanGame.Dialogue.Interfaces;

namespace CSharpConsoleHangmanGame.Dialogue
{
    internal class ConsoleDialogueController : IDialogueController
    {
        IDialogueOptionsInputKeys inputOptionsKeys;

        public ConsoleDialogueController(IDialogueOptionsInputKeys inputOptionsKeys)
        {
            this.inputOptionsKeys = inputOptionsKeys;
        }

        public void ShowMessage(string? text)
        {
            var finalText = AddPrefix(AddSpace(text));
            Console.WriteLine(finalText);
        }

        public string? ReadInput()
        {
            return Console.ReadLine();
        }

        public void Clear()
        {
            Console.Clear();
        }

        //public void ClearLastLine()
        //{
        //    Console.SetCursorPosition(0, Console.CursorTop - 1);
        //    int currentLineCursor = Console.CursorTop;
        //    Console.SetCursorPosition(0, Console.CursorTop);
        //    Console.Write(new string(' ', Console.BufferWidth));
        //    Console.SetCursorPosition(0, currentLineCursor);
        //}

        public static string? AddSpace(string? text)
        {
            if (text != null && text != "")
                text = " " + text;
            return text;
        }

        public static string? AddPrefix(string? text)
        {
            if (text != null && text != "")
                text = "> " + text;
            return text;
        }

        public void JumpLine()
        {
            ShowMessage("");
        }

        public bool ShowOptionsAndExecuteChosen(IDialogueOptionData[] options)
        {
            // Show options
            var optionKeyValueSeparator = ". ";

            var inputOptionsKeys = this.inputOptionsKeys.OptionsKeys(options.Length);

            for (int i = 0; i < inputOptionsKeys.Length; i++)
            {
                var option = options[i];
                var fullOptionText = AddSpace(inputOptionsKeys[i] + optionKeyValueSeparator + option.Text);
                ShowMessage(fullOptionText);
            }
            
            JumpLine();
            
            // Get input
            var rawInput = ReadInput();
            if (rawInput == null)
                return false;
            var input = rawInput.ToLower();

            // Execute chosen option
            for (int i = 0; i < inputOptionsKeys.Length; i++)
            {
                if (input.ToLower() == inputOptionsKeys[i].ToLower())
                {
                    options[i].Action();
                    return true;
                }
            }
            return false;
        }
    }
}
