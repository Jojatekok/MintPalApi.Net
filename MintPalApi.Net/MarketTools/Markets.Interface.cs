using Jojatekok.MintPalAPI.MarketTools;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Jojatekok.MintPalAPI
{
    public interface IMarkets
    {
        /// <summary>Gets a data summary of the markets available.</summary>
        /// <remarks>On the server side, this data refreshes once a minute.</remarks>
        Task<IList<IMarket>> GetSummaryAsync();

        /// <summary>Gets a data summary of the markets available on a specific exchange currency.</summary>
        /// <param name="exchange">The code of the currency used as an exchange.</param>
        /// <remarks>On the server side, this data refreshes once a minute.</remarks>
        Task<IList<IMarket>> GetSummaryAsync(string exchange);

        /// <summary>Gets data of a specific market.</summary>
        /// <param name="coin">The code of the currency being traded on the market.</param>
        /// <param name="exchange">The code of the currency used as an exchange.</param>
        /// <remarks>On the server side, this data refreshes once a minute.</remarks>
        Task<IMarket> GetStatsAsync(string coin, string exchange);

        /// <summary>Gets data of a specific market.</summary>
        /// <param name="coinPair">The currency pair, which consists of the currency being traded on the market, and the exchange's code.</param>
        /// <remarks>On the server side, this data refreshes once a minute.</remarks>
        Task<IMarket> GetStatsAsync(string coinPair);

        /// <summary>Fetches the last 100 trades for a given market.</summary>
        /// <param name="coin">The code of the currency being traded on the market.</param>
        /// <param name="exchange">The code of the currency used as an exchange.</param>
        Task<IList<ITrade>> GetTradesAsync(string coin, string exchange);

        /// <summary>Fetches the last 100 trades for a given market.</summary>
        /// <param name="coinPair">The currency pair, which consists of the currency being traded on the market, and the exchange's code.</param>
        Task<IList<ITrade>> GetTradesAsync(string coinPair);

        /// <summary>Fetches the 50 best priced orders of a given type for a given market.</summary>
        /// <param name="coin">The code of the currency being traded on the market.</param>
        /// <param name="exchange">The code of the currency used as an exchange.</param>
        /// <param name="type">Type of the orders to fetch.</param>
        Task<IList<IOrder>> GetOrdersAsync(string coin, string exchange, OrderType type);

        /// <summary>Fetches the 50 best priced orders of a given type for a given market.</summary>
        /// <param name="coinPair">The currency pair, which consists of the currency being traded on the market, and the exchange's code.</param>
        /// <param name="type">Type of the orders to fetch.</param>
        Task<IList<IOrder>> GetOrdersAsync(string coinPair, OrderType type);

        /// <summary>Fetches the chart data that MintPal uses for their candlestick graphs for a market view of 6 hours.</summary>
        /// <param name="coin">The code of the currency being traded on the market.</param>
        /// <param name="exchange">The code of the currency used as an exchange.</param>
        Task<IList<IMarketChartData>> GetChartDataAsync(string coin, string exchange);

        /// <summary>Fetches the chart data that MintPal uses for their candlestick graphs for a market view of 6 hours.</summary>
        /// <param name="coinPair">The currency pair, which consists of the currency being traded on the market, and the exchange's code.</param>
        Task<IList<IMarketChartData>> GetChartDataAsync(string coinPair);

        /// <summary>Fetches the chart data that MintPal uses for their candlestick graphs for a market view of a given time period.</summary>
        /// <param name="coin">The code of the currency being traded on the market.</param>
        /// <param name="exchange">The code of the currency used as an exchange.</param>
        /// <param name="period">The time interval to request information about.</param>
        Task<IList<IMarketChartData>> GetChartDataAsync(string coin, string exchange, MarketPeriod period);

        /// <summary>Fetches the chart data that MintPal uses for their candlestick graphs for a market view of a given time period.</summary>
        /// <param name="coinPair">The currency pair, which consists of the currency being traded on the market, and the exchange's code.</param>
        /// <param name="period">The time interval to request information about.</param>
        Task<IList<IMarketChartData>> GetChartDataAsync(string coinPair, MarketPeriod period);
    }
}
