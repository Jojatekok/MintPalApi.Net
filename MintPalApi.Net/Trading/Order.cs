using Newtonsoft.Json;
using System;

namespace MintPalAPI.Trading
{
    public class Order
    {
        [JsonProperty("order_id")]
        public string IdOrder { get; private set; }

        [JsonProperty("market")]
        public string Market { get; private set; }
        [JsonProperty("type")]
        private string TypeString {
            set {
                switch (value) {
                    case "BUY":
                        Type = OrderType.Buy;
                        break;

                    case "SELL":
                        Type = OrderType.Sell;
                        break;
                }
            }
        }
        public OrderType Type { get; private set; }

        [JsonProperty("price")]
        public double PricePerCoin { get; private set; }
        [JsonProperty("amount")]
        public double AmountCoin { get; private set; }
        [JsonProperty("total")]
        public double AmountTotal { get; private set; }
        [JsonProperty("fee")]
        public double Fee { get; private set; }
        [JsonProperty("net_total")]
        public double AmountTotalNet { get; private set; }

        [JsonProperty("time")]
        private double TimeUnix {
            set { Time = Helper.UnixTimeStampToDateTime(value); }
        }
        public DateTime Time { get; private set; }

        [JsonProperty("time_formatted")]
        private string TimeFormattedString {
            set { TimeFormatted = DateTime.ParseExact(value, "yyyy-MM-dd HH:mm:ss", Helper.InvariantCulture); }
        }
        public DateTime TimeFormatted { get; private set; }
    }
}
