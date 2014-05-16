namespace Jojatekok.MintPalAPI.WalletTools
{
    public interface IBalance : IRefreshableObject
    {
        int Id { get; }
        string Name { get; }
        string Code { get; }

        double FundsAvailable { get; }
        double FundsPendingDeposits { get; }
        double FundsPendingWithdrawals { get; }
        double FundsHeld { get; }
    }
}
