namespace Jojatekok.MintPalAPI.MarketTools
{
    public interface IMarket : IRefreshableObject
    {
        int Id { get; }
        string Name { get; }

        string Code { get; }
        string Exchange { get; }

        double PriceLast { get; }
        double PriceYesterday { get; }
        double PriceChange { get; }
        double Price24HourHigh { get; }
        double Price24HourLow { get; }
        double Volume24Hours { get; }

        double OrderTopBuy { get; }
        double OrderTopSell { get; }
        double OrderSpread { get; }
        double OrderSpreadRelative { get; }
    }
}
