using Newtonsoft.Json;

namespace MintPalAPI.TradingTools
{
    public class Trade : Order
    {
        [JsonProperty("trade_id")]
        public string IdTrade { get; private set; }
    }
}
