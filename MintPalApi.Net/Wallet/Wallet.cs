using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace MintPalAPI.WalletTools
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

        public Task<IList<Deposit>> GetDepositsAsync(string coin)
        {
            return GetDataAsync<IList<Deposit>>("deposits", coin);
        }

        public Task<IList<Deposit>> GetDepositsAsync(string coin, int start, int limit)
        {
            return GetDataAsync<IList<Deposit>>("deposits", coin, start, limit);
        }

        public Task<IList<Deposit>> GetDepositsAsync(int limit)
        {
            return GetDepositsAsync("ALL", 0, limit);
        }

        public Task<IList<Deposit>> GetDepositsAsync(int start, int limit)
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

        public Task<Withdrawal> GetWithdrawalAsync(int id)
        {
            return GetDataAsync<Withdrawal>("withdrawal", id);
        }

        public Task<IList<Withdrawal>> GetWithdrawalsAsync()
        {
            return GetDataAsync<IList<Withdrawal>>("withdrawals");
        }

        public Task<IList<Withdrawal>> GetWithdrawalsAsync(string coin)
        {
            return GetDataAsync<IList<Withdrawal>>("withdrawals", coin);
        }

        public Task<IList<Withdrawal>> GetWithdrawalsAsync(string coin, int start, int limit)
        {
            return GetDataAsync<IList<Withdrawal>>("withdrawals", coin, start, limit);
        }

        public Task<IList<Withdrawal>> GetWithdrawalsAsync(int limit)
        {
            return GetWithdrawalsAsync("ALL", 0, limit);
        }

        public Task<IList<Withdrawal>> GetWithdrawalsAsync(int start, int limit)
        {
            return GetWithdrawalsAsync("ALL", start, limit);
        }

        public Task<Withdrawal> PostWithdrawalRequestAsync(string address, double amount)
        {
            var postData = new Dictionary<string, object>(2) {
                { "address", address },
                { "amount", amount.ToStringUniform() }
            };

            return PostDataAsync<Withdrawal>("withdraw", postData);
        }

        public Task DeleteWithdrawalRequestAsync(int id)
        {
            return DeleteDataAsync("withdraw", id);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private Task<T> GetDataAsync<T>(string command, params object[] parameters)
        {
            return ApiWebClient.GetDataAsync<T>(true, Helper.ApiUrlPrefixWallet + command, parameters);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private Task DeleteDataAsync(string command, params object[] parameters)
        {
            return ApiWebClient.DeleteDataAsync(Helper.ApiUrlPrefixWallet + command, parameters);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private Task<T> PostDataAsync<T>(string command, Dictionary<string, object> postData)
        {
            return ApiWebClient.PostDataAsync<T>(Helper.ApiUrlPrefixWallet + command, postData);
        }
    }
}
