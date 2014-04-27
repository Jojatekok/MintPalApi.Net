using Newtonsoft.Json;
using System;

namespace MintPalAPI.Market
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
        private double TimeUnix {
            set { Time = Helper.UnixTimeStampToDateTime(value); }
        }
        public DateTime Time { get; private set; }
    }
}
