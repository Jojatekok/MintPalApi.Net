using System;

namespace Jojatekok.MintPalAPI.TradingTools
{
    public interface IOrder
    {
        string IdOrder { get; }

        string Market { get; }
        OrderType Type { get; }

        double PricePerCoin { get; }
        double AmountCoin { get; }
        double AmountTotal { get; }
        double Fee { get; }
        double AmountTotalNet { get; }

        DateTime Time { get; }

        DateTime TimeFormatted { get; }
    }
}
