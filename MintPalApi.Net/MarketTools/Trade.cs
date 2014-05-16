using Newtonsoft.Json;
using System;

namespace Jojatekok.MintPalAPI.MarketTools
{
    public class Trade : Order, ITrade
    {
        [JsonProperty("type")]
        public OrderType Type { get; private set; }

        [JsonProperty("time")]
        private double TimeUnix {
            set { Time = Helper.UnixTimeStampToDateTime(value); }
        }
        public DateTime Time { get; private set; }
    }
}
