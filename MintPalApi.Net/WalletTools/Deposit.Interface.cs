using System;

namespace Jojatekok.MintPalAPI.WalletTools
{
    public interface IDeposit
    {
        string Code { get; }
        string Address { get; }
        double Amount { get; }

        string TransactionId { get; }
        DateTime Time { get; }

        bool IsPending { get; }

        int ConfirmationsDone { get; }
        int ConfirmationsRequired { get; }

        DateTime TimeFormatted { get; }

        string Status { get; }
    }
}
