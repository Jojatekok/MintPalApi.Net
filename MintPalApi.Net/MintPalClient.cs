using System;
using System.Net.Http;

namespace MintPalAPI
{
    public sealed class MintPalClient : IDisposable
    {
        private HttpClient _httpClient;

        public Authenticator Authenticator { get; private set; }

        public Markets Markets { get; private set; }
        public Wallet Wallet { get; private set; }

        public MintPalClient(string publicApiKey, string privateApiKey)
        {
            _httpClient = new HttpClient { BaseAddress = new Uri(Helper.ApiUrlBase, UriKind.Absolute) };

            Authenticator = new Authenticator(_httpClient, publicApiKey, privateApiKey);

            Markets = new Markets(_httpClient);
            Wallet = new Wallet(_httpClient, Authenticator);
        }

        public MintPalClient() : this(null, null)
        {

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
