using Optional;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpConsoleHangmanGame.Utils.HttpService.Interfaces
{
    internal interface IHttpService
    {
        Task<Option<string>> GetRequest(string url);
    }
}
