using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace MintPalAPI.MarketTools
{
    public class Markets
    {
        private ApiWebClient ApiWebClient { get; set; }

        internal Markets(ApiWebClient apiWebClient)
        {
            ApiWebClient = apiWebClient;
        }

        public Task<IList<Market>> GetSummaryAsync()
        {
            return GetDataAsync<IList<Market>>("summary");
        }

        public Task<IList<Market>> GetSummaryAsync(string exchange)
        {
            return GetDataAsync<IList<Market>>("summary", exchange);
        }

        public Task<Market> GetStatsAsync(string coinPair)
        {
            return GetDataAsync<Market>("stats", coinPair);
        }

        public Task<Market> GetStatsAsync(string coin, string exchange)
        {
            return GetDataAsync<Market>("stats", coin, exchange);
        }

        public Task<IList<Trade>> GetTradesAsync(string coin, string exchange)
        {
            return GetDataAsync<IList<Trade>>("trades", coin, exchange);
        }

        public Task<IList<Order>> GetOrdersAsync(string coin, string exchange, OrderType type)
        {
            return type == OrderType.Buy ?
                   GetDataAsync<IList<Order>>("orders", coin, exchange, "BUY") :
                   GetDataAsync<IList<Order>>("orders", coin, exchange, "SELL");
        }

        public Task<IList<MarketChartData>> GetChartDataAsync(string coin, string exchange)
        {
            return GetDataAsync<IList<MarketChartData>>("chartdata", coin, exchange);
        }

        public Task<IList<MarketChartData>> GetChartDataAsync(string coin, string exchange, MarketPeriod period)
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

            return GetDataAsync<IList<MarketChartData>>("chartdata", coin, exchange, periodString);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private Task<T> GetDataAsync<T>(string command, params object[] parameters)
        {
            return ApiWebClient.GetDataAsync<T>(this, false, Helper.ApiUrlPrefixMarket + command, parameters);
        }
    }
}
