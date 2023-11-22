using CSharpConsoleHangmanGame.DialogueSystem;
using CSharpConsoleHangmanGame.DialogueSystem.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace CSharpConsoleHangmanGame.IO
{
    internal class ConsoleDialogueController : IDialogueController 
    {
        public void ShowInputOptions(string[] options)
        {
            foreach (var option in options)
            {
                var finalText = AddSpace(option);
                Console.WriteLine(finalText);
            }
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
    }
}
