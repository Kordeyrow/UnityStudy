namespace CSharpConsoleHangmanGame.Databases.Dialogue.CloudCSVDialogueDatabase.Sections
{
    internal class DialogueSections
    {
        private readonly string MenuKey = FormatedSectionTitle("Menu");
        private readonly string InGameKey = FormatedSectionTitle("InGame");
        private readonly string GameOverKey = FormatedSectionTitle("GameOver");
        private readonly string CloseGameKey = FormatedSectionTitle("CloseGame");

        internal Section Menu { get; }
        internal Section InGame { get; }
        internal Section GameOver { get; }
        internal Section CloseGame { get; }
        internal Dictionary<string, Section> SectionByName { get; set; }

        internal DialogueSections()
        {
            SectionByName = new Dictionary<string, Section>
            {
                { MenuKey, Menu = new Section(FormatedSectionTitle(MenuKey)) },
                { InGameKey, InGame = new Section(FormatedSectionTitle(InGameKey)) },
                { GameOverKey, GameOver = new Section(FormatedSectionTitle(GameOverKey)) },
                { CloseGameKey, CloseGame = new Section(FormatedSectionTitle(CloseGameKey)) }
            };
        }

        // TODO: remove duplicated method
        internal static string FormatedSectionTitle(string s) => s.ToLower().Replace(" ", "");
    }
}
