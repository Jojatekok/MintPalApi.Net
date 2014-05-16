using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Jojatekok.MintPalAPI.WalletTools
{
    public class Wallet : IWallet
    {
        private ApiWebClient ApiWebClient { get; set; }

        internal Wallet(ApiWebClient apiWebClient)
        {
            ApiWebClient = apiWebClient;
        }

        public async Task<IBalance> GetBalanceAsync(string coin)
        {
            var data = await GetDataAsync<Balance>("balances", coin);
            return (IBalance)data;
        }

        public async Task<IList<IBalance>> GetBalancesAsync()
        {
            var data = await GetDataAsync<IList<Balance>>("balances");
            return new List<IBalance>(data);
        }

        public async Task<IList<IDeposit>> GetDepositsAsync()
        {
            var data = await GetDataAsync<IList<Deposit>>("deposits");
            return new List<IDeposit>(data);
        }

        public async Task<IList<IDeposit>> GetDepositsAsync(string coin)
        {
            var data = await GetDataAsync<IList<Deposit>>("deposits", coin);
            return new List<IDeposit>(data);
        }

        public async Task<IList<IDeposit>> GetDepositsAsync(string coin, int start, int limit)
        {
            var data = await GetDataAsync<IList<Deposit>>("deposits", coin, start, limit);
            return new List<IDeposit>(data);
        }

        public Task<IList<IDeposit>> GetDepositsAsync(int limit)
        {
            return GetDepositsAsync("ALL", 0, limit);
        }

        public Task<IList<IDeposit>> GetDepositsAsync(int start, int limit)
        {
            return GetDepositsAsync("ALL", start, limit);
        }

        public Task<string> GetDepositAddressAsync(string coin)
        {
            return GetDataAsync<string>("depositaddress", coin);
        }

        public Task<string> GetDepositAddressAsync(string coin, bool createNew)
        {
            return createNew ?
                   GetDataAsync<string>("newdepositaddress", coin) :
                   GetDepositAddressAsync(coin);
        }

        public async Task<IWithdrawal> GetWithdrawalAsync(long id)
        {
            var data = await GetDataAsync<Withdrawal>("withdrawal", id);
            return (IWithdrawal)data;
        }

        public async Task<IList<IWithdrawal>> GetWithdrawalsAsync()
        {
            var data = await GetDataAsync<IList<Withdrawal>>("withdrawals");
            return new List<IWithdrawal>(data);
        }

        public async Task<IList<IWithdrawal>> GetWithdrawalsAsync(string coin)
        {
            var data = await GetDataAsync<IList<Withdrawal>>("withdrawals", coin);
            return new List<IWithdrawal>(data);
        }

        public async Task<IList<IWithdrawal>> GetWithdrawalsAsync(string coin, int start, int limit)
        {
            var data = await GetDataAsync<IList<Withdrawal>>("withdrawals", coin, start, limit);
            return new List<IWithdrawal>(data);
        }

        public Task<IList<IWithdrawal>> GetWithdrawalsAsync(int limit)
        {
            return GetWithdrawalsAsync("ALL", 0, limit);
        }

        public Task<IList<IWithdrawal>> GetWithdrawalsAsync(int start, int limit)
        {
            return GetWithdrawalsAsync("ALL", start, limit);
        }

        public async Task<IWithdrawal> PostWithdrawalRequestAsync(string address, double amount)
        {
            var postData = new Dictionary<string, object>(2) {
                { "address", address },
                { "amount", amount.ToStringUniform() }
            };

            var data = await PostDataAsync<Withdrawal>("withdraw", postData);
            return (IWithdrawal)data;
        }

        public Task DeleteWithdrawalRequestAsync(int id)
        {
            return DeleteDataAsync("withdraw", id);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private Task<T> GetDataAsync<T>(string command, params object[] parameters)
        {
            return ApiWebClient.GetDataAsync<T>(this, true, Helper.ApiUrlPrefixWallet + command, parameters);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private Task DeleteDataAsync(string command, params object[] parameters)
        {
            return ApiWebClient.DeleteDataAsync(Helper.ApiUrlPrefixWallet + command, parameters);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private Task<T> PostDataAsync<T>(string command, Dictionary<string, object> postData)
        {
            return ApiWebClient.PostDataAsync<T>(this, Helper.ApiUrlPrefixWallet + command, postData);
        }
    }
}
