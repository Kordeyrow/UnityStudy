using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpConsoleHangmanGame.GameData.Interfaces
{
    internal interface IConfigs
    {
        string Language { get; }
        string WordsFilePath { get; }
        string DialogueDatabaseURL { get; }
    }
}
