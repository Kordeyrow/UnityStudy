using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpConsoleHangmanGame.GameLogic.SecretWordHangman.Interfaces
{
    internal interface IWordsDatabase
    {
        string GetRandomEasyWord();
        string GetRandomMediumWord();
        string GetRandomHardWord();
    }
}
