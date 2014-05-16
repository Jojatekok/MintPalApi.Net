using Newtonsoft.Json;

namespace Jojatekok.MintPalAPI.MarketTools
{
    public class Order : IOrder
    {
        [JsonProperty("price")]
        public double PricePerCoin { get; private set; }

        [JsonProperty("amount")]
        public double AmountCoin { get; private set; }
        [JsonProperty("total")]
        public double AmountTotal { get; private set; }
    }
}
