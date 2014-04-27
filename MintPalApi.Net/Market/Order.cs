using Newtonsoft.Json;

namespace MintPalAPI.Market
{
    public class Order
    {
        [JsonProperty("price")]
        public double PricePerCoin { get; private set; }

        [JsonProperty("amount")]
        public double AmountCoin { get; private set; }
        [JsonProperty("total")]
        public double AmountTotal { get; private set; }
    }
}
