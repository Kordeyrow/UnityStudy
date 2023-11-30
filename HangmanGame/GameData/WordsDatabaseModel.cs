using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpConsoleHangmanGame.GameData
{
    internal class WordsDatabaseModel
    {
        public WordsModel Words { get; set; }

        public class WordsModel
        {
            public string[] Easy { get; set; }
            public string[] Medium { get; set; }
            public string[] Hard { get; set; }
        }
    }
}
