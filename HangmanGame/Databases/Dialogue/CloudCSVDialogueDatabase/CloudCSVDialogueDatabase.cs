using CSharpConsoleHangmanGame.Databases.Dialogue.CloudCSVDialogueDatabase.Sections;
using CSharpConsoleHangmanGame.Databases.Dialogue.Interfaces;
using CSharpConsoleHangmanGame.GameSystems.Dialogue.Interfaces;
using CSharpConsoleHangmanGame.Utils.Debugging.Interfaces;
using CSharpConsoleHangmanGame.Utils.HttpService.Interfaces;
using Optional;

namespace CSharpConsoleHangmanGame.Databases.Dialogue.CloudCSVDialogueDatabase
{
    internal class CloudCSVDialogueDatabase : IDialogueDatabase
    {
        readonly string url;
        readonly string languageId;
        readonly IDebugLog debugLog;
        readonly IHttpService httpService;
        readonly IDialogueUnitKeys dialogueUnitKeys;
        DialogueSections dialogueSections;

        public IMenuDialogueDatabase MenuDialogueDatabase { get; private set; }
        public IInGameDialogueDatabase InGameDialogueDatabase { get; private set; }
        public IGameOverDialogueDatabase GameOverDialogueDatabase { get; private set; }
        public ICloseGameDialogueDatabase CloseGameDialogueDatabase { get; private set; }
        internal bool Empty { get; private set; } = true;


        readonly int rowsBetweenTitleAndFirstId = 1;
        readonly char cellSplitChar = ',';
        readonly string emptyCell = "";
        Dictionary<char, string> substituteCharsPairs = new()
            {
                { '"', "" },
                { ';', "," }
            };

        internal CloudCSVDialogueDatabase(
            IDebugLog debugLog,
            IHttpService httpService,
            IDialogueUnitKeys dialogueUnitKeys,
            string url,
            string languageId)
        {
            this.debugLog = debugLog;
            this.httpService = httpService;
            this.url = url;
            this.dialogueUnitKeys = dialogueUnitKeys;
            this.languageId = languageId;
        }

        public async Task Init()
        {
            var csvRawDataOpt = await httpService.GetRequest(url);
            csvRawDataOpt.MatchSome(csvRawData =>
            {
                dialogueSections = GetDialogueSectionsFromRawCSV(csvRawData);

                MenuDialogueDatabase = new MenuDialogueDatabase(dialogueUnitKeys.MenuDialogueUnitKeys, dialogueSections.Menu);
                InGameDialogueDatabase = new InGameDialogueDatabase(dialogueUnitKeys.InGameDialogueUnitKeys, dialogueSections.InGame);
                GameOverDialogueDatabase = new GameOverDialogueDatabase(dialogueUnitKeys.GameOverDialogueUnitKeys, dialogueSections.GameOver);
                CloseGameDialogueDatabase = new CloseGameDialogueDatabase(dialogueUnitKeys.CloseGameDialogueUnitKeys, dialogueSections.CloseGame);
            });
        }

        DialogueSections GetDialogueSectionsFromRawCSV(string csvData)
        {
            // Init Dialogue Sections
            var dialogueSections = new DialogueSections();

            // Check every cell to find sections (by title)
            // Then add all Dialogue Units from found section
            string[] rows = SplitByLine(csvData);
            var languageIdCellOpt = FindLanguageIDCell(rows);
            languageIdCellOpt.MatchSome(cell =>
            {
                foreach (var nameSection in dialogueSections.SectionByName)
                {
                    var name = nameSection.Key;
                    var section = nameSection.Value;
                    var sectionCellOpt = FindSectionTitleCell(rows, name, cell.RowId + 1, cell.ColId);
                    sectionCellOpt.MatchSome(cell =>
                    {
                        FillSection(section, rows, cell.RowId + 1, cell.ColId);
                    });
                }
            });

            return dialogueSections;
        }

        void FillSection(Section section, string[] rows, int startRow, int colId)
        {
            // Add all Dialogue Units from current section
            // Keys below [title column], Values (Text) below [title column + 1]
            for (int currentRowId = startRow + rowsBetweenTitleAndFirstId; currentRowId < rows.Length; currentRowId++)
            {
                string[] rawRowCellsTxts = rows[currentRowId].Split(cellSplitChar);

                // Format cell text
                string[] formatedRowCellsTxts = (string[])rawRowCellsTxts.Clone();
                for (int i = 0; i < rawRowCellsTxts.Length; i++)
                    foreach (var substituteCharsPair in substituteCharsPairs)
                        formatedRowCellsTxts[i] = formatedRowCellsTxts[i].Replace(substituteCharsPair.Key.ToString(), substituteCharsPair.Value);

                // Not valid key cell ? -> break (traversing section)
                string dialogueUnitKey = formatedRowCellsTxts[colId].Trim().ToLower();
                var cellIsKeyFromCurrentSection = colId <= formatedRowCellsTxts.Length - 2
                                                  && dialogueUnitKey != emptyCell;
                if (cellIsKeyFromCurrentSection == false)
                    break;

                // Valid value cell ? -> Add
                string dialogueUnitValue = formatedRowCellsTxts[colId + 1].Trim();
                var valueCellHasValue = dialogueUnitValue != emptyCell;
                if (valueCellHasValue)
                {
                    if (Empty)
                        Empty = false;
                    section.AddDialogueUnit(dialogueUnitKey, dialogueUnitValue);
                }
            }
        }

        Option<CSVCell> FindLanguageIDCell(string[] rows)
        {
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

                    // Found language id ?
                    if (cellTxt == languageId)
                        return Option.Some(new CSVCell(rowId, columnId));
                }
            }

            debugLog.Warn("Error: Dialogue Database: LanguageID not found!");

            return Option.None<CSVCell>();
        }

        Option<CSVCell> FindSectionTitleCell(string[] rows, string sectionName, int startRowId, int fixedColId)
        {
            for (int rowId = startRowId; rowId < rows.Length; rowId++)
            {
                // Get row
                var row = rows[rowId];
                var rawCellsTxts = row.Split(cellSplitChar);

                if (rawCellsTxts.Length <= fixedColId)
                    continue;

                // Get cell
                var cellTxt = FormatedSectionTitle(rawCellsTxts[fixedColId]);

                // Found language id ?
                if (cellTxt == sectionName)
                    return Option.Some(new CSVCell(rowId, fixedColId));
            }

            return Option.None<CSVCell>();
        }

        // TODO: remove duplicated method
        internal static string FormatedSectionTitle(string s) => s.ToLower().Replace(" ", "");

        internal static string[] SplitByLine(string s) => s.Split("\n");
    }
}
