using System;

namespace Jojatekok.MintPalAPI.MarketTools
{
    public interface IMarketChartData
    {
        DateTime Time { get; }

        double Open { get; }
        double Close { get; }

        double High { get; }
        double Low { get; }

        double VolumeExchange { get; }
        double VolumeCoin { get; }
    }
}
