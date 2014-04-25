using Newtonsoft.Json;
using System;

namespace MintPalAPI
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
        public double TimeUnix { get; private set; }

        [JsonProperty("pending")]
        public bool IsPending { get; private set; }

        [JsonProperty("confirms")]
        public int ConfirmationsDone { get; private set; }
        [JsonProperty("req_confirms")]
        public int ConfirmationsRequired { get; private set; }

        [JsonProperty("time_formatted")]
        private string TimeFormattedString { get; set; }
        public DateTime TimeFormatted {
            get { return DateTime.ParseExact(TimeFormattedString, "yyyy-MM-dd HH:mm:ss", Helper.InvariantCulture); }
        }

        [JsonProperty("status")]
        public string Status { get; private set; }
    }
}
