using Newtonsoft.Json;

namespace MintPalAPI.Trading
{
    public class Trade : Order
    {
        [JsonProperty("trade_id")]
        public string IdTrade { get; private set; }
    }
}
