using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpConsoleHangmanGame.HelperServices.Debugging.Interfaces
{
    internal interface IDebugLog
    {
        internal void Print(string? message);
        internal void Warn(string? message);
    }
}
