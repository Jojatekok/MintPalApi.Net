using Newtonsoft.Json;
using System;

namespace MintPalAPI
{
    public class Trade
    {
        [JsonProperty("type")]
        public OrderType Type { get; private set; }

        [JsonProperty("price")]
        public double Price { get; private set; }

        [JsonProperty("amount")]
        public double AmountCoin { get; private set; }
        [JsonProperty("total")]
        public double AmountTotal { get; private set; }

        [JsonProperty("time")]
        private double TimeUnix { get; set; }
        public DateTime Time {
            get { return Helper.UnixTimeStampToDateTime(TimeUnix); }
        }
    }
}
