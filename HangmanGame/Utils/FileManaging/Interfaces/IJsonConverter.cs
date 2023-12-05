using Optional;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpConsoleHangmanGame.Utils.FileManaging.Interfaces
{
    internal interface IJsonConverter
    {
        Option<T> FromJson<T>(string jsonToDeserialize);
        Option<string> ToJson<T>(T objectToSerialize);
    }
}
