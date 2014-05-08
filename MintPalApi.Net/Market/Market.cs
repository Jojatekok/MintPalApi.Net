using Newtonsoft.Json;
using System.Diagnostics;
using System.Threading.Tasks;

namespace MintPalAPI.MarketTools
{
    public class Market : RefreshableObject
    {
        [JsonProperty("market_id")]
        public int Id { get; private set; }
        public string Name {
            get { return Code + "/" + Exchange; }

            set {
                var nameSplit = Helper.SplitExchangePair(value);

                Code = nameSplit[0];
                Exchange = nameSplit[1];
            }
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

        public Market(Markets baseObject)
        {
            BaseObject = baseObject;
        }

        public override sealed async Task RefreshAsync()
        {
            var markets = BaseObject as Markets;
            Debug.Assert(markets != null);
            
            var refreshedObject = await markets.GetStatsAsync(Code, Exchange);

            Id = refreshedObject.Id;
            PriceLast = refreshedObject.PriceLast;
            PriceYesterday = refreshedObject.PriceYesterday;
            PriceChange = refreshedObject.PriceChange;
            Price24HourHigh = refreshedObject.Price24HourHigh;
            Price24HourLow = refreshedObject.Price24HourLow;
            Volume24Hours = refreshedObject.Volume24Hours;
            OrderTopBuy = refreshedObject.OrderTopBuy;
            OrderTopSell = refreshedObject.OrderTopSell;
        }
    }
}
