using CSharpConsoleHangmanGame.GameGenericModules.Dialogue.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpConsoleHangmanGame.GameGenericModules.Dialogue.DialogueOptionsInputKeys
{
    internal class NumberDialogueOptionsInputKeys : IDialogueOptionsInputKeys
    {
        public string ConfirmKey { get; } = "1";
        public string CancelKey { get; } = "2";

        public string[] OptionsKeys(int optionsCount)
        {
            string[] optionsKeys = new string[optionsCount];

            // Convert the integer to string
            for (int i = 0; i < optionsKeys.Length; i++)
                optionsKeys[i] = (i + 1).ToString();

            return optionsKeys;
        }
    }
}
