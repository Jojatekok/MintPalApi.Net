using System;

namespace Jojatekok.MintPalAPI.MarketTools
{
    public interface ITrade : IOrder
    {
        OrderType Type { get; }

        DateTime Time { get; }
    }
}
