using Newtonsoft.Json;

namespace Jojatekok.MintPalAPI.TradingTools
{
    public class Trade : Order, ITrade
    {
        [JsonProperty("trade_id")]
        public string IdTrade { get; private set; }
    }
}
