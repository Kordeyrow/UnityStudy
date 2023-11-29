using CSharpConsoleHangmanGame.Dialogue.Interfaces;

namespace CSharpConsoleHangmanGame.Dialogue
{
    internal class ConsoleDialogueController : IDialogueController
    {
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

        public bool ReadInputOption(InputOption[] options)
        {
            // Show options
            var optionKeyValueSeparator = ". ";
            foreach (var option in options)
            {
                var fullOptionText = AddSpace(option.Key + optionKeyValueSeparator + option.Value);
                ShowMessage(fullOptionText);
            }
            
            JumpLine();
            
            // Get input
            var rawInput = ReadInput();
            if (rawInput == null)
                return false;
            var input = rawInput.ToLower();

            // Execute action of chosen option
            foreach (var option in options)
            {
                if (input == option.Key.ToLower())
                {
                    option.Action();
                    return true;
                }
            }
            return false;
        }
    }
}
