using CSharpConsoleHangmanGame.Dialogue.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpConsoleHangmanGame.Dialogue.InputOptionsKeys
{
    internal class NumberInputOptionsKeys : IInputOptionsKeys
    {
        public string Confirm()
        {
            return "1";
        }

        public string Cancel()
        {
            return "2";
        }

        public string Option1()
        {
            return "1";
        }

        public string Option2()
        {
            return "2";
        }

        public string Option3()
        {
            return "3";
        }
    }
}
