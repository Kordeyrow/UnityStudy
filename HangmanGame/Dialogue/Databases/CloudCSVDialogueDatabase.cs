using CSharpConsoleHangmanGame.Debugging;
using CSharpConsoleHangmanGame.Dialogue.Databases;
using CSharpConsoleHangmanGame.Dialogue.Interfaces;
using CSharpConsoleHangmanGame.HttpService;

namespace CSharpConsoleHangmanGame.Dialogue
{
    internal class CloudCSVDialogueDatabase : IDialogueDatabase
    {
        //readonly string url = "https://docs.google.com/spreadsheets/u/0/d/1g_fUTHTC-jp19mf_K61NgTANUyR3xrmVZiGN25DH46Y/export?format=csv&id=1g_fUTHTC-jp19mf_K61NgTANUyR3xrmVZiGN25DH46Y&gid=0";
        readonly string url;
        readonly IDialogueUnitKeys dialogueUnitKeys;
        DialogueSections dialogueSections;

        public IMenuDialogueDatabase MenuDialogueDatabase { get; private set; }
        public IInGameDialogueDatabase InGameDialogueDatabase { get; private set; }
        public IGameOverDialogueDatabase GameOverDialogueDatabase { get; private set; }

        internal CloudCSVDialogueDatabase(string url, IDialogueUnitKeys dialogueUnitKeys)
        {
            this.url = url;
            this.dialogueUnitKeys = dialogueUnitKeys;
        }

        public async Task Init()
        {
            HttpGet get = new();
            var csvRawData = await get.GetRequest(url);
            dialogueSections = GetDialogueSectionsFromRawCSV(csvRawData);

            MenuDialogueDatabase = new MenuDialogueDatabase(dialogueUnitKeys.MenuDialogueUnitKeys, dialogueSections.Menu);
            InGameDialogueDatabase = new InGameDialogueDatabase(dialogueUnitKeys.InGameDialogueUnitKeys, dialogueSections.InGame);
            GameOverDialogueDatabase = new GameOverDialogueDatabase(dialogueUnitKeys.GameOverDialogueUnitKeys, dialogueSections.GameOver);
        }

        // TODO: remove duplicated method
        internal static string FormatedSectionTitle(string s) => s.ToLower().Replace(" ", "");

        DialogueSections GetDialogueSectionsFromRawCSV(string csvData)
        {
            // Init Dialogue Sections
            var dialogueSections = new DialogueSections();
            var sectionsList = new List<Section>()
            {
                dialogueSections.Menu,
                dialogueSections.InGame,
                dialogueSections.GameOver
            };
            var sections = new Dictionary<string, Section>();
            foreach (var section in sectionsList)
                sections.Add(section.Name, section);

            // Check every cell to find sections (by title)
            // Then add all Dialogue Units from found section
            string[] rows = csvData.Split("\n");
            string emptyCell = "";
            char cellSplitChar = ',';

            // Format cells texts
            Dictionary<char, string> substituteCharsPairs = new()
            {
                { '"', "" },
                { ';', "," }
            };

            // Traverse rows
            for (int rowId = 0; rowId < rows.Length; rowId++)
            {
                // Get row
                var row = rows[rowId];
                var rawCellsTxts = row.Split(cellSplitChar);

                // Traverse columns
                for (int columnId = 0; columnId < rawCellsTxts.Length; columnId++)
                {
                    // Get cell
                    var cellTxt = FormatedSectionTitle(rawCellsTxts[columnId]);

                    // Found section title ?
                    if (sections.ContainsKey(cellTxt) == false)
                        continue;
                    var currentSection = sections[cellTxt];

                    // Add all Dialogue Units from current section
                    // Keys below [title column], Values (Text) below [title column + 1]
                    var offset = 1;
                    for (int currentRowId = rowId +1 +offset; currentRowId < rows.Length; currentRowId++)
                    {
                        string[] rawRowCellsTxts = rows[currentRowId].Split(cellSplitChar);

                        // Format cell text
                        string[] formatedRowCellsTxts = (string[]) rawRowCellsTxts.Clone();
                        for (int i = 0; i < rawRowCellsTxts.Length; i++)
                            foreach (var substituteCharsPair in substituteCharsPairs)
                                formatedRowCellsTxts[i] = formatedRowCellsTxts[i].Replace(substituteCharsPair.Key.ToString(), substituteCharsPair.Value);

                        // Not valid key cell ? -> break (traversing section)
                        string dialogueUnitKey = formatedRowCellsTxts[columnId].Trim().ToLower();
                        var cellIsKeyFromCurrentSection = columnId <= formatedRowCellsTxts.Length - 2
                                                          && dialogueUnitKey != emptyCell;
                        if (cellIsKeyFromCurrentSection == false)
                            break;

                        // Valid value cell ? -> Add
                        string dialogueUnitValue = formatedRowCellsTxts[columnId + 1].Trim();
                        var valueCellHasValue = dialogueUnitValue != emptyCell;
                        if (valueCellHasValue)
                        {
                            currentSection.AddDialogueUnit(dialogueUnitKey, dialogueUnitValue);
                        }
                    }
                }
            }

            return dialogueSections;
        }
    }

    internal class MenuDialogueDatabase : IMenuDialogueDatabase
    {
        readonly IMenuDialogueUnitKeys menuDialogueUnitKeys;
        readonly Section section;

        internal MenuDialogueDatabase(IMenuDialogueUnitKeys menuDialogueUnitKeys, Section section)
        {
            this.menuDialogueUnitKeys = menuDialogueUnitKeys;
            this.section = section;
        }

        public string WelcomeMessage             => section.GetText(menuDialogueUnitKeys.WelcomeMessage);
        public string StartChoiseQuestion        => section.GetText(menuDialogueUnitKeys.StartChoiceQuestion);
        public string StartChoiseStartGameOption => section.GetText(menuDialogueUnitKeys.StartChoiceStartGameOption);
        public string StartChoiseExitGameOption  => section.GetText(menuDialogueUnitKeys.StartChoiceExitGameOption);
    }

    internal class InGameDialogueDatabase : IInGameDialogueDatabase
    {
        readonly IInGameDialogueUnitKeys inGameDialogueUnitKeys;
        readonly Section section;

        internal InGameDialogueDatabase(IInGameDialogueUnitKeys inGameDialogueUnitKeys, Section section)
        {
            this.inGameDialogueUnitKeys = inGameDialogueUnitKeys;
            this.section = section;
        }
        public string GameStartedMessage => section.GetText(inGameDialogueUnitKeys.GameStartedMessage); 
        public string LetterRequest      => section.GetText(inGameDialogueUnitKeys.RequestLetterRequest);
    }

    internal class GameOverDialogueDatabase : IGameOverDialogueDatabase
    {
        readonly IGameOverDialogueUnitKeys gameOverDialogueUnitKeys;
        readonly Section section;

        internal GameOverDialogueDatabase(IGameOverDialogueUnitKeys gameOverDialogueUnitKeys, Section section)
        {
            this.gameOverDialogueUnitKeys = gameOverDialogueUnitKeys;
            this.section = section;
        }

        public string WinMessage                => section.GetText(gameOverDialogueUnitKeys.WinMessage);
        public string LoseMessage               => section.GetText(gameOverDialogueUnitKeys.LoseMessage);
        public string EndChoiceQuestion         => section.GetText(gameOverDialogueUnitKeys.EndChoiceQuestion);
        public string EndChoicePlayAgainOption  => section.GetText(gameOverDialogueUnitKeys.EndChoicePlayAgainOption);
        public string EndChoiceExitToMenuOption => section.GetText(gameOverDialogueUnitKeys.EndChoiceExitToMenuOption);
    }

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
