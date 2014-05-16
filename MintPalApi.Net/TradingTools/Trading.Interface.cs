using Jojatekok.MintPalAPI.TradingTools;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Jojatekok.MintPalAPI
{
    public interface ITrading
    {
        /// <summary>Fetches an order identified by its ID.</summary>
        /// <param name="id">The ID of the requested order.</param>
        Task<IOrder> GetOpenOrderAsync(string id);

        /// <summary>Fetches the current open orders in your account, ordered by most recent first and limited to 25 results.</summary>
        Task<IList<IOrder>> GetOpenOrdersAsync();

        /// <summary>Fetches the current open orders for a specific coin, including all the exchange markets, in your account, ordered by most recent first and limited to 25 results.</summary>
        /// <param name="coin">The code of the currency you want to request data about.</param>
        Task<IList<IOrder>> GetOpenOrdersAsync(string coin);

        /// <summary>Fetches the current open orders for a specific coin, including all the exchange markets, in your account, ordered by most recent first.</summary>
        /// <param name="coin">The code of the currency you want to request data about.</param>
        /// <param name="start">The index you want to start fetching data from.</param>
        /// <param name="limit">The number of maximum items to receive.</param>
        Task<IList<IOrder>> GetOpenOrdersAsync(string coin, int start, int limit);

        /// <summary>Fetches the current open orders in your account, ordered by most recent first.</summary>
        /// <param name="limit">The number of maximum items to receive.</param>
        Task<IList<IOrder>> GetOpenOrdersAsync(int limit);

        /// <summary>Fetches the current open orders in your account, ordered by most recent first.</summary>
        /// <param name="start">The index you want to start fetching data from.</param>
        /// <param name="limit">The number of maximum items to receive.</param>
        Task<IList<IOrder>> GetOpenOrdersAsync(int start, int limit);

        /// <summary>Submits a new order to the market.</summary>
        /// <param name="coin">The code of the currency being traded on the market.</param>
        /// <param name="exchange">The code of the currency used as an exchange.</param>
        /// <param name="price">The price to trade your coins at, compared to the exchange.</param>
        /// <param name="amount">The amount of coins you want to trade.</param>
        /// <param name="type">Type of the order.</param>
        Task<IOrder> PostOrderAsync(string coin, string exchange, double price, double amount, OrderType type);

        /// <summary>Submits a new order to the market.</summary>
        /// <param name="coinPair">The currency pair, which consists of the currency being traded on the market, and the exchange's code.</param>
        /// <param name="price">The price to trade your coins at, compared to the exchange.</param>
        /// <param name="amount">The amount of coins you want to trade.</param>
        /// <param name="type">Type of the order.</param>
        Task<IOrder> PostOrderAsync(string coinPair, double price, double amount, OrderType type);

        /// <summary>
        ///     <para>Cancels an open order identified by the order ID.</para>
        ///     <para>Warning: Order cancellations are processed FIFO (First In First Out) alongside new orders, so it may be matched before the cancellation can be processed.</para>
        /// </summary>
        /// <param name="id">The ID of the order to cancel.</param>
        Task DeleteOrderAsync(string id);

        /// <summary>Fetches a trade identified by its ID.</summary>
        /// <param name="id">The ID of the requested trade.</param>
        Task<ITrade> GetTradeAsync(string id);

        /// <summary>Fetches the trades made in your account, ordered by most recent first and limited to 25 results.</summary>
        Task<IList<ITrade>> GetTradesAsync();

        /// <summary>Fetches the trades made in your account for a specific coin, including all the exchange markets, ordered by most recent first and limited to 25 results.</summary>
        /// <param name="coin">The code of the currency you want to request data about.</param>
        Task<IList<ITrade>> GetTradesAsync(string coin);

        /// <summary>Fetches the trades made in your account for a specific coin, including all the exchange markets, ordered by most recent first.</summary>
        /// <param name="coin">The code of the currency you want to request data about.</param>
        /// <param name="start">The index you want to start fetching data from.</param>
        /// <param name="limit">The number of maximum items to receive.</param>
        Task<IList<ITrade>> GetTradesAsync(string coin, int start, int limit);

        /// <summary>Fetches the trades made in your account, ordered by most recent first.</summary>
        /// <param name="limit">The number of maximum items to receive.</param>
        Task<IList<ITrade>> GetTradesAsync(int limit);

        /// <summary>Fetches the trades made in your account, ordered by most recent first.</summary>
        /// <param name="start">The index you want to start fetching data from.</param>
        /// <param name="limit">The number of maximum items to receive.</param>
        Task<IList<ITrade>> GetTradesAsync(int start, int limit);
    }
}
