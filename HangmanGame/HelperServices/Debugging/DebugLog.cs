using CSharpConsoleHangmanGame.HelperServices.Debugging.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpConsoleHangmanGame.HelperServices.Debugging
{
    internal class DebugLog : IDebugLog
    {
        void IDebugLog.Print(string? message)
        {
            Console.WriteLine(message);
        }

        void IDebugLog.Warn(string? message)
        {
            Console.WriteLine(message);
        }
    }
}
