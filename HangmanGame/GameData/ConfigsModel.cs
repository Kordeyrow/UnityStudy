using System;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
    
namespace CSharpConsoleHangmanGame.GameData
{
    internal class ConfigsModel
    {
        public string Language { get; set; }
        public PathsModel Paths { get; set; }
        public URLsModel URLs { get; set; }

        internal class PathsModel
        {
            public string WordsFilePath { get; set; }
        }

        internal class URLsModel
        {
            public string DialogueDataBase { get; set; }
        }
    }
}
