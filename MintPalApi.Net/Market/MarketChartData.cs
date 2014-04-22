using Newtonsoft.Json;
using System;

namespace MintPalAPI
{
    public class MarketChartData
    {
        [JsonProperty("date")]
        public string DateTimeString { get; private set; }
        public DateTime DateTime {
            get { return DateTime.ParseExact(DateTimeString, "yyyy-MM-dd HH:mm", Helper.InvariantCulture); }
        }

        [JsonProperty("open")]
        public double Open { get; private set; }
        [JsonProperty("close")]
        public double Close { get; private set; }

        [JsonProperty("high")]
        public double High { get; private set; }
        [JsonProperty("low")]
        public double Low { get; private set; }

        [JsonProperty("exchange_volume")]
        public double VolumeExchange { get; private set; }
        [JsonProperty("coin_volume")]
        public double VolumeCoin { get; private set; }
    }
}
