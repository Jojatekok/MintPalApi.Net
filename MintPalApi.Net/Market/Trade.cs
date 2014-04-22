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
        public double TimeUnix { get; private set; }
        public DateTime Time {
            get { return Helper.UnixTimeStampToDateTime(TimeUnix); }
        }
    }
}
