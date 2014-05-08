using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace MintPalAPI.WalletTools
{
    public class Withdrawal : RefreshableObject
    {
        [JsonProperty("id")]
        public long Id { get; private set; }
        [JsonProperty("code")]
        public string Code { get; private set; }
        [JsonProperty("address")]
        public string Address { get; private set; }
        [JsonProperty("amount")]
        public double Amount { get; private set; }
        [JsonProperty("fee")]
        public double Fee { get; private set; }

        [JsonProperty("txid")]
        public string TransactionId { get; private set; }
        [JsonProperty("time")]
        private long TimeUnix {
            set { Time = Helper.UnixTimeStampToDateTime(value); }
        }
        public DateTime Time { get; private set; }

        [JsonProperty("pending")]
        public bool IsPending { get; private set; }

        [JsonProperty("time_formatted")]
        private string TimeFormattedString {
            set { TimeFormatted = DateTime.ParseExact(value, "yyyy-MM-dd HH:mm:ss", Helper.InvariantCulture); }
        }
        public DateTime TimeFormatted { get; private set; }

        [JsonProperty("status")]
        public string Status { get; private set; }

        public override sealed async Task RefreshAsync()
        {
            var wallet = BaseObject as Wallet;
            Debug.Assert(wallet != null);

            var refreshedObject = await wallet.GetWithdrawalAsync(Id);

            Code = refreshedObject.Code;
            Address = refreshedObject.Address;
            Amount = refreshedObject.Amount;
            Fee = refreshedObject.Fee;
            TransactionId = refreshedObject.TransactionId;
            Time = refreshedObject.Time;
            IsPending = refreshedObject.IsPending;
            TimeFormatted = refreshedObject.TimeFormatted;
            Status = refreshedObject.Status;
        }
    }
}
