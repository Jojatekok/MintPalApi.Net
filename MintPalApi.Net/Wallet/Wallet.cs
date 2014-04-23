using System.Collections.Generic;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace MintPalAPI
{
    public class Wallet
    {
        private HttpClient HttpClient { get; set; }
        private Authenticator Authenticator { get; set; }

        internal Wallet(HttpClient httpClient, Authenticator authenticator)
        {
            HttpClient = httpClient;
            Authenticator = authenticator;
        }

        public Task<Balance> GetBalanceAsync(string coin)
        {
            return ApiGetAsync<Balance>("balances", coin);
        }

        public Task<IList<Balance>> GetBalancesAsync()
        {
            return ApiGetAsync<IList<Balance>>("balances");
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private async Task<T> ApiGetAsync<T>(string command, params string[] parameters)
        {
            return await HttpClient.ApiGetAsync<T>(Authenticator, Helper.ApiUrlMarket + command, parameters);
        }
    }
}
