using System;

namespace Jojatekok.MintPalAPI.WalletTools
{
    public interface IWithdrawal : IRefreshableObject
    {
        long Id { get; }
        string Code { get; }
        string Address { get; }
        double Amount { get; }
        double Fee { get; }

        string TransactionId { get; }
        DateTime Time { get; }

        bool IsPending { get; }

        DateTime TimeFormatted { get; }

        string Status { get; }
    }
}
