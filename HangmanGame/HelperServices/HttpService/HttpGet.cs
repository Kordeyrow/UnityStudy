using CSharpConsoleHangmanGame.HelperServices.Debugging.Interfaces;

namespace CSharpConsoleHangmanGame.HelperServices.HttpService
{
    internal class HttpGet
    {
        readonly IDebugLog debugLog;

        public HttpGet(IDebugLog debugLog)
        {
            this.debugLog = debugLog;
        }

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
                    debugLog.Warn($"Get Request exception: {e.Message}");
                }
            }
            return "";
        }
    }
}
