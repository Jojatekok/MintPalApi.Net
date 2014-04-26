using Newtonsoft.Json;
using System;

namespace MintPalAPI
{
    public class Withdrawal
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
        private string TimeFormattedString { get; set; }
        public DateTime TimeFormatted {
            get { return DateTime.ParseExact(TimeFormattedString, "yyyy-MM-dd HH:mm:ss", Helper.InvariantCulture); }
        }

        [JsonProperty("status")]
        public string Status { get; private set; }
    }
}
