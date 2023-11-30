using CSharpConsoleHangmanGame.Dialogue.Interfaces;
namespace CSharpConsoleHangmanGame.Dialogue.DialogueOptionsInputKeys
{
    internal class LetterDialogueOptionsInputKeys : IDialogueOptionsInputKeys
    {
        readonly int maxOptionsCount = 26;

        public string ConfirmKey { get; } = "A";
        public string CancelKey { get; } = "b";

        public string[] OptionsKeys(int optionsCount)
        {
            // Not Valid ? -> return empty
            if (optionsCount < 1)
                return Array.Empty<string>();

            // Options
            string[] optionsKeys = new string[optionsCount];

            // Convert the integer to its corresponding ASCII uppercase letter
            for (int i = 0; i < optionsKeys.Length && optionsKeys.Length < maxOptionsCount; i++)
                optionsKeys[i] = ((char)(65 + i)).ToString();

            return optionsKeys;
        }
    }
}
