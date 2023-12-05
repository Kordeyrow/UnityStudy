using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpConsoleHangmanGame.GameObjects.Interfaces
{
    internal interface ISecretWord
    {
        void Init(string word);
        bool IsValidLetter(string? s);
        bool HasLetter(char c);
        bool TriedLetter(char c);
        bool IsLetterRevealed(char c);
        void RevealLetter(char c);
        bool IsComplete();
        void Draw();
    }
}
