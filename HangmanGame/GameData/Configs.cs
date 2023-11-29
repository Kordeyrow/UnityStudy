using CSharpConsoleHangmanGame.Debugging.Interfaces;
using CSharpConsoleHangmanGame.FileManaging;
using CSharpConsoleHangmanGame.GameData.Interfaces;
using CSharpConsoleHangmanGame.SecretWordHangman;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpConsoleHangmanGame.GameData
{
    internal class Configs : IConfigs
    {
        readonly string configsFilePath = "GameData/BuildGameData/configs.txt";
        readonly ConfigsModel configsModel;

        public string Language => configsModel.Language;
        public string WordsFilePath => configsModel.Paths.WordsFilePath;
        public string DialogueDatabaseURL => configsModel.URLs.DialogueDataBase;

        internal Configs(IDebugLog debugLog)
        {
            var fileReader = new FileReader(debugLog);
            var readObj = fileReader.GetObjectFromJsonFileInRoot<ConfigsModel>(configsFilePath);
            configsModel = readObj ?? new ConfigsModel();
        }
    }
}
