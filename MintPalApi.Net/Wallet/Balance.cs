using Newtonsoft.Json;

namespace MintPalAPI.Wallet
{
    public class Balance
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
    }
}
