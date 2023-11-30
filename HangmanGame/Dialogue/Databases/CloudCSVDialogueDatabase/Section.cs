namespace CSharpConsoleHangmanGame.Dialogue.Databases.CloudCSVDialogueDatabase
{
    internal class Section
    {
        internal string Name { get; private set; }
        readonly Dictionary<string, string> dialogueUnits;

        internal Section(string name)
        {
            Name = name;
            dialogueUnits = new Dictionary<string, string>();
        }

        internal void AddDialogueUnit(string key, string value)
        {
            dialogueUnits.Add(key, value);
        }

        internal string GetText(string key)
        {
            var text = dialogueUnits.GetValueOrDefault(key) ?? "";
            return text;
        }
    }
}
