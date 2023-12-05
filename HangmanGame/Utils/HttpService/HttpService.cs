using CSharpConsoleHangmanGame.Utils.Debugging.Interfaces;
using CSharpConsoleHangmanGame.Utils.HttpService.Interfaces;
using Optional;

namespace CSharpConsoleHangmanGame.Utils.HttpService
{
    internal class HttpService : IHttpService
    {
        readonly IDebugLog debugLog;

        public HttpService(IDebugLog debugLog)
        {
            this.debugLog = debugLog;
        }

        async Task<Option<string>> IHttpService.GetRequest(string url)
        {
            using (HttpClient client = new())
            {
                try
                {
                    HttpResponseMessage response = await client.GetAsync(url);
                    response.EnsureSuccessStatusCode();
                    return Option.Some(await response.Content.ReadAsStringAsync());
                }
                catch (Exception e)
                {
                    debugLog.Warn($"Error: Get Request exception: {e.Message}");
                }
            }
            return Option.None<string>();
        }
    }
}
