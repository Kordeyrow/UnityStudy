using Optional;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpConsoleHangmanGame.Utils.FileManaging.Interfaces
{
    internal interface IFileReader
    {
        Option<T> GetObjectFromJsonFileInRoot<T>(string filePath);
        Option<string> ReadFileInRoot(string filePath);
    }
}
