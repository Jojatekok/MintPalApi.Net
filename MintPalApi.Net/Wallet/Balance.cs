using Newtonsoft.Json;
using System.Diagnostics;
using System.Threading.Tasks;

namespace MintPalAPI.WalletTools
{
    public class Balance : RefreshableObject
    {
        [JsonProperty("id")]
        public int Id { get; private set; }
        [JsonProperty("name")]
        public string Name { get; private set; }
        [JsonProperty("code")]
        public string Code { get; private set; }

        [JsonProperty("balance_available")]
        public double FundsAvailable { get; private set; }
        [JsonProperty("balance_pending_deposit")]
        public double FundsPendingDeposits { get; private set; }
        [JsonProperty("balance_pending_withdraw")]
        public double FundsPendingWithdrawals { get; private set; }
        [JsonProperty("balance_held")]
        public double FundsHeld { get; private set; }

        public override sealed async Task RefreshAsync()
        {
            var wallet = BaseObject as Wallet;
            Debug.Assert(wallet != null);

            var refreshedObject = await wallet.GetBalanceAsync(Code);

            Id = refreshedObject.Id;
            Name = refreshedObject.Name;
            FundsAvailable = refreshedObject.FundsAvailable;
            FundsPendingDeposits = refreshedObject.FundsPendingDeposits;
            FundsPendingWithdrawals = refreshedObject.FundsPendingWithdrawals;
            FundsHeld = refreshedObject.FundsHeld;
        }
    }
}
