using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpConsoleHangmanGame.GameObjects.Interfaces
{
    internal interface IHangman
    {
        void Init();
        void AddPart();
        bool IsComplete();
        void Draw();
    }
}
