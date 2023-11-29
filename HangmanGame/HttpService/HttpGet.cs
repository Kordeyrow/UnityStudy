using CSharpConsoleHangmanGame.Debugging;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpConsoleHangmanGame.HttpService
{
    internal class HttpGet
    {
        internal async Task<string> GetRequest(string url)
        {
            using (HttpClient client = new())
            {
                try
                {
                    HttpResponseMessage response = await client.GetAsync(url);
                    response.EnsureSuccessStatusCode();
                    return await response.Content.ReadAsStringAsync();
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Get Request exception: {e.Message}");
                }
            }
            return "";
        }
    }
}
