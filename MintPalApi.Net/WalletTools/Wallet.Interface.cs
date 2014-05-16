using Jojatekok.MintPalAPI.WalletTools;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Jojatekok.MintPalAPI
{
    public interface IWallet
    {
        /// <summary>Fetches the balance for a specific coin, split down into available balance, pending deposits, pending withdrawals and held for orders.</summary>
        /// <param name="coin">The code of the currency you want to request data about.</param>
        Task<IBalance> GetBalanceAsync(string coin);

        /// <summary>Fetches all the balances in your account, split down into available balance, pending deposits, pending withdrawals and held for orders.</summary>
        Task<IList<IBalance>> GetBalancesAsync();

        /// <summary>Fetches the deposits made into your account, including pending and confirmed ones, ordered by most recent first and limited to 25 results.</summary>
        Task<IList<IDeposit>> GetDepositsAsync();

        /// <summary>Fetches the deposits made into your account for a specific coin, including pending and confirmed ones, ordered by most recent first and limited to 25 results.</summary>
        /// <param name="coin">The code of the currency you want to request data about.</param>
        Task<IList<IDeposit>> GetDepositsAsync(string coin);

        /// <summary>Fetches the deposits made into your account for a specific coin, including pending and confirmed ones, ordered by most recent first.</summary>
        /// <param name="coin">The code of the currency you want to request data about.</param>
        /// <param name="start">The index you want to start fetching data from.</param>
        /// <param name="limit">The number of maximum items to receive.</param>
        Task<IList<IDeposit>> GetDepositsAsync(string coin, int start, int limit);

        /// <summary>Fetches the deposits made into your account, including pending and confirmed ones, ordered by most recent first.</summary>
        /// <param name="limit">The number of maximum items to receive.</param>
        Task<IList<IDeposit>> GetDepositsAsync(int limit);

        /// <summary>Fetches the deposits made into your account, including pending and confirmed ones, ordered by most recent first.</summary>
        /// <param name="start">The index you want to start fetching data from.</param>
        /// <param name="limit">The number of maximum items to receive.</param>
        Task<IList<IDeposit>> GetDepositsAsync(int start, int limit);

        /// <summary>Fetches the deposit address for the specified coin.</summary>
        /// <param name="coin">The code of the currency you want to request data about.</param>
        Task<string> GetDepositAddressAsync(string coin);

        /// <summary>Fetches the deposit address for the specified coin.</summary>
        /// <param name="coin">The code of the currency you want to request data about.</param>
        /// <param name="createNew">Returns a newly-generated address whether this parameter is set to true.</param>
        Task<string> GetDepositAddressAsync(string coin, bool createNew);

        /// <summary>Fetches the details of a single withdrawal identified by its ID.</summary>
        /// <param name="id">The ID of the requested withdrawal.</param>
        Task<IWithdrawal> GetWithdrawalAsync(long id);

        /// <summary>Fetches the withdrawals made from your account, including pending and confirmed ones, ordered by most recent first and limited to 25 results.</summary>
        Task<IList<IWithdrawal>> GetWithdrawalsAsync();

        /// <summary>Fetches the withdrawals made from your account for a specific coin, including pending and confirmed ones, ordered by most recent first and limited to 25 results.</summary>
        /// <param name="coin">The code of the currency you want to request data about.</param>
        Task<IList<IWithdrawal>> GetWithdrawalsAsync(string coin);

        /// <summary>Fetches the withdrawals made from your account for a specific coin, including pending and confirmed ones, ordered by most recent first.</summary>
        /// <param name="coin">The code of the currency you want to request data about.</param>
        /// <param name="start">The index you want to start fetching data from.</param>
        /// <param name="limit">The number of maximum items to receive.</param>
        Task<IList<IWithdrawal>> GetWithdrawalsAsync(string coin, int start, int limit);

        /// <summary>Fetches the withdrawals made from your account, including pending and confirmed ones, ordered by most recent first.</summary>
        /// <param name="limit">The number of maximum items to receive.</param>
        Task<IList<IWithdrawal>> GetWithdrawalsAsync(int limit);

        /// <summary>Fetches the withdrawals made from your account, including pending and confirmed ones, ordered by most recent first.</summary>
        /// <param name="start">The index you want to start fetching data from.</param>
        /// <param name="limit">The number of maximum items to receive.</param>
        Task<IList<IWithdrawal>> GetWithdrawalsAsync(int start, int limit);

        /// <summary>
        ///     <para>Submits a withdrawal request.</para>
        ///     <para>Note: Withdrawals require e-mail confirmation to process.</para>
        /// </summary>
        /// <param name="address">The address you wish to withdraw to.</param>
        /// <param name="amount">
        ///     <para>The amount you wish to withdraw.</para>
        ///     <para>Note: A withdrawal fee will be applied to this amount.</para>
        /// </param>
        Task<IWithdrawal> PostWithdrawalRequestAsync(string address, double amount);

        /// <summary>
        ///     <para>Cancels a withdrawal request identified by the its ID.</para>
        ///     <para>Note: You can only cancel unconfirmed and unsuccessful withdrawals.</para>
        /// </summary>
        /// <param name="id">The ID of the withdrawal to cancel.</param>
        Task DeleteWithdrawalRequestAsync(int id);
    }
}
