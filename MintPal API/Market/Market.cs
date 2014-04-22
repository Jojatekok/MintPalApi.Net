using Newtonsoft.Json;
using System;

namespace MintPalAPI
{
    public class Market
    {
        [JsonProperty("market_id")]
        public int Id { get; private set; }
        public string Name {
            get { return Code + "/" + Exchange; }
        }

        [JsonProperty("code")]
        public string Code { get; private set; }
        [JsonProperty("exchange")]
        public string Exchange { get; private set; }

        [JsonProperty("last_price")]
        public double PriceLast { get; private set; }
        [JsonProperty("yesterday_price")]
        public double PriceYesterday { get; private set; }
        [JsonProperty("change")]
        public double PriceChange { get; private set; }
        [JsonProperty("24hhigh")]
        public double Price24HourHigh { get; private set; }
        [JsonProperty("24hlow")]
        public double Price24HourLow { get; private set; }
        [JsonProperty("24hvol")]
        public double Volume24Hours { get; private set; }

        [JsonProperty("top_bid")]
        public double OrderTopBuy { get; private set; }
        [JsonProperty("top_ask")]
        public double OrderTopSell { get; private set; }
        public double OrderSpread {
            get { return OrderTopSell - OrderTopBuy; }
        }
        public double OrderSpreadRelative {
            get { return OrderTopSell / OrderTopBuy - 1; }
        }

        public Market()
        {

        }

        public Market(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) {
                throw new ArgumentNullException("name");
            }

            var nameSplit = name.Split('/');

            if (nameSplit.Length < 2) {
                throw new ArgumentException("The string format of the provided exchange pair is invalid.", "name");
            }

            Code = nameSplit[0];
            Exchange = nameSplit[1];
        }
    }
}
