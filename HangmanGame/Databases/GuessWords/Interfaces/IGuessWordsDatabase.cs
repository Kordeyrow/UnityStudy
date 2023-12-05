using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpConsoleHangmanGame.Databases.GuessWords.Interfaces
{
    internal interface IGuessWordsDatabase
    {
        string GetRandomEasyWord();
        string GetRandomMediumWord();
        string GetRandomHardWord();
        bool Empty();
    }
}
