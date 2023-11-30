namespace CSharpConsoleHangmanGame.Dialogue.Databases.CloudCSVDialogueDatabase
{
    internal class DialogueSections
    {
        internal Section Menu { get; set; }
        internal Section InGame { get; set; }
        internal Section GameOver { get; set; }

        internal DialogueSections()
        {
            Menu = new Section(FormatedSectionTitle("menu"));
            InGame = new Section(FormatedSectionTitle("inGame"));
            GameOver = new Section(FormatedSectionTitle("gameOver"));
        }

        // TODO: remove duplicated method
        internal static string FormatedSectionTitle(string s) => s.ToLower().Replace(" ", "");
    }
}
