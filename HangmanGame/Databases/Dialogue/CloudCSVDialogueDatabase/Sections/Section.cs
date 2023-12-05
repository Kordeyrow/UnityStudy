namespace CSharpConsoleHangmanGame.Databases.Dialogue.CloudCSVDialogueDatabase.Sections
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
            if (dialogueUnits.ContainsKey(key))
                return;
            dialogueUnits.Add(key, value);
        }

        internal string GetText(string key)
        {
            var text = dialogueUnits.GetValueOrDefault(key) ?? "";
            return text;
        }
    }
}
