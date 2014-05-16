using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Jojatekok.MintPalAPI.MarketTools
{
    public class Markets : IMarkets
    {
        private ApiWebClient ApiWebClient { get; set; }

        internal Markets(ApiWebClient apiWebClient)
        {
            ApiWebClient = apiWebClient;
        }

        public async Task<IList<IMarket>> GetSummaryAsync()
        {
            var data = await GetDataAsync<IList<Market>>("summary");
            return new List<IMarket>(data);
        }

        public async Task<IList<IMarket>> GetSummaryAsync(string exchange)
        {
            var data = await GetDataAsync<IList<Market>>("summary", exchange);
            return new List<IMarket>(data);
        }

        public async Task<IMarket> GetStatsAsync(string coin, string exchange)
        {
            var data = await GetDataAsync<Market>("stats", coin, exchange);
            return (IMarket)data;
        }

        public Task<IMarket> GetStatsAsync(string coinPair)
        {
            var coinPairSplit = Helper.SplitCoinPair(coinPair);
            return GetStatsAsync(coinPairSplit[0], coinPairSplit[1]);
        }

        public async Task<IList<ITrade>> GetTradesAsync(string coin, string exchange)
        {
            var data = await GetDataAsync<IList<Trade>>("trades", coin, exchange);
            return new List<ITrade>(data);
        }

        public Task<IList<ITrade>> GetTradesAsync(string coinPair)
        {
            var coinPairSplit = Helper.SplitCoinPair(coinPair);
            return GetTradesAsync(coinPairSplit[0], coinPairSplit[1]);
        }

        public async Task<IList<IOrder>> GetOrdersAsync(string coin, string exchange, OrderType type)
        {
            var data = await (type == OrderType.Buy ?
                             GetDataAsync<IList<Order>>("orders", coin, exchange, "BUY") :
                             GetDataAsync<IList<Order>>("orders", coin, exchange, "SELL"));
            return new List<IOrder>(data);
        }

        public Task<IList<IOrder>> GetOrdersAsync(string coinPair, OrderType type)
        {
            var coinPairSplit = Helper.SplitCoinPair(coinPair);
            return GetOrdersAsync(coinPairSplit[0], coinPairSplit[1], type);
        }

        public async Task<IList<IMarketChartData>> GetChartDataAsync(string coin, string exchange)
        {
            var data = await GetDataAsync<IList<MarketChartData>>("chartdata", coin, exchange);
            return new List<IMarketChartData>(data);
        }

        public Task<IList<IMarketChartData>> GetChartDataAsync(string coinPair)
        {
            var coinPairSplit = Helper.SplitCoinPair(coinPair);
            return GetChartDataAsync(coinPairSplit[0], coinPairSplit[1]);
        }

        public async Task<IList<IMarketChartData>> GetChartDataAsync(string coin, string exchange, MarketPeriod period)
        {
            string periodString;

            switch (period) {
                case MarketPeriod.Hours6:
                    periodString = "6hh";
                    break;

                case MarketPeriod.Hours24:
                    periodString = "1DD";
                    break;

                case MarketPeriod.Days3:
                    periodString = "3DD";
                    break;

                case MarketPeriod.Week:
                    periodString = "7DD";
                    break;

                default:
                    periodString = "MAX";
                    break;
            }

            var data = await GetDataAsync<IList<MarketChartData>>("chartdata", coin, exchange, periodString);
            return new List<IMarketChartData>(data);
        }

        public Task<IList<IMarketChartData>> GetChartDataAsync(string coinPair, MarketPeriod period)
        {
            var coinPairSplit = Helper.SplitCoinPair(coinPair);
            return GetChartDataAsync(coinPairSplit[0], coinPairSplit[1], period);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private Task<T> GetDataAsync<T>(string command, params object[] parameters)
        {
            return ApiWebClient.GetDataAsync<T>(this, false, Helper.ApiUrlPrefixMarket + command, parameters);
        }
    }
}
