using Newtonsoft.Json;
using System;

namespace MintPalAPI.Wallet
{
    public class Deposit
    {
        [JsonProperty("code")]
        public string Code { get; private set; }
        [JsonProperty("address")]
        public string Address { get; private set; }
        [JsonProperty("amount")]
        public double Amount { get; private set; }

        [JsonProperty("txid")]
        public string TransactionId { get; private set; }
        [JsonProperty("time")]
        private long TimeUnix {
            set { Time = Helper.UnixTimeStampToDateTime(value); }
        }
        public DateTime Time { get; private set; }

        [JsonProperty("pending")]
        public bool IsPending { get; private set; }

        [JsonProperty("confirms")]
        public int ConfirmationsDone { get; private set; }
        [JsonProperty("req_confirms")]
        public int ConfirmationsRequired { get; private set; }

        [JsonProperty("time_formatted")]
        private string TimeFormattedString {
            set { TimeFormatted = DateTime.ParseExact(value, "yyyy-MM-dd HH:mm:ss", Helper.InvariantCulture); }
        }
        public DateTime TimeFormatted { get; private set; }

        [JsonProperty("status")]
        public string Status { get; private set; }
    }
}
