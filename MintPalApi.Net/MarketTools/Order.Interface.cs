namespace Jojatekok.MintPalAPI.MarketTools
{
    public interface IOrder
    {
        double PricePerCoin { get; }

        double AmountCoin { get; }
        double AmountTotal { get; }
    }
}
