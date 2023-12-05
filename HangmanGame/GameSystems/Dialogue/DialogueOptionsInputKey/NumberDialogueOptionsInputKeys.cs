using CSharpConsoleHangmanGame.GameSystems.Dialogue.Interfaces;

namespace CSharpConsoleHangmanGame.GameSystems.Dialogue.DialogueOptionsInputKey
{
    internal struct NumberDialogueOptionsInputKeys : IDialogueOptionsInputKeys
    {
        public NumberDialogueOptionsInputKeys() { }

        string IDialogueOptionsInputKeys.ConfirmKey { get; } = "1";
        string IDialogueOptionsInputKeys.CancelKey { get; } = "2";

        string[] IDialogueOptionsInputKeys.OptionsKeys(int optionsCount)
        {
            string[] optionsKeys = new string[optionsCount];

            // Convert the integer to string
            for (int i = 0; i < optionsKeys.Length; i++)
                optionsKeys[i] = (i + 1).ToString();

            return optionsKeys;
        }
    }
}
