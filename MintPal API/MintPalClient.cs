using System;
using System.Net.Http;

namespace MintPalAPI
{
    public sealed class MintPalClient : IDisposable
    {
        private HttpClient _httpClient;

        public Markets Markets { get; private set; }

        public MintPalClient()
        {
            _httpClient = new HttpClient { BaseAddress = new Uri("https://api.mintpal.com/v2/", UriKind.Absolute) };

            Markets = new Markets(_httpClient);
        }

        public void Dispose()
        {
            Dispose(true);
        }

        private void Dispose(bool disposing)
        {
            if (disposing) {
                if (_httpClient != null) {
                    _httpClient.Dispose();
                    _httpClient = null;
                }
            }
        }
    }
}
