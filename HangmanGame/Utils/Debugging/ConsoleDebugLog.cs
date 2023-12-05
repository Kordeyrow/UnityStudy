using CSharpConsoleHangmanGame.Utils.Debugging.Interfaces;

namespace CSharpConsoleHangmanGame.Utils.Debugging
{
    internal class ConsoleDebugLog : IDebugLog
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
