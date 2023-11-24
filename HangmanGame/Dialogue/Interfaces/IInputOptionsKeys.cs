using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpConsoleHangmanGame.Dialogue.Interfaces
{
    internal interface IInputOptionsKeys
    {
        string Confirm();
        string Cancel();

        string Option1();
        string Option2();
        string Option3();
    }
}