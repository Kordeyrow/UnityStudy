using CSharpConsoleHangmanGame.GameStates.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpConsoleHangmanGame.GameStates
{
    internal class SharedGameData : ISharedGameData
    {
        public bool Won { get; set; }
    }
}
