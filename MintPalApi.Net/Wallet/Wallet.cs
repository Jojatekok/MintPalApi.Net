using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace MintPalAPI
{
    public class Wallet
    {
        private ApiWebClient ApiWebClient { get; set; }

        internal Wallet(ApiWebClient apiWebClient)
        {
            ApiWebClient = apiWebClient;
        }

        public Task<Balance> GetBalanceAsync(string coin)
        {
            return GetDataAsync<Balance>("balances", coin);
        }

        public Task<IList<Balance>> GetBalancesAsync()
        {
            return GetDataAsync<IList<Balance>>("balances");
        }

        public Task<IList<Deposit>> GetDepositsAsync()
        {
            return GetDataAsync<IList<Deposit>>("deposits");
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private async Task<T> GetDataAsync<T>(string command, params string[] parameters)
        {
            return await ApiWebClient.GetDataAsync<T>(true, Helper.ApiUrlPrefixMarket + command, parameters);
        }
    }
}
