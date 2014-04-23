using System.Collections.Generic;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace MintPalAPI
{
    public class Markets
    {
        private HttpClient HttpClient { get; set; }

        internal Markets(HttpClient httpClient)
        {
            HttpClient = httpClient;
        }

        public Task<IList<Market>> GetSummaryAsync()
        {
            return ApiGetAsync<IList<Market>>("summary");
        }

        public Task<IList<Market>> GetSummaryAsync(string exchange)
        {
            return ApiGetAsync<IList<Market>>("summary", exchange);
        }

        public Task<Market> GetStatsAsync(string coinPair)
        {
            return ApiGetAsync<Market>("stats", coinPair);
        }

        public Task<Market> GetStatsAsync(string coin, string exchange)
        {
            return ApiGetAsync<Market>("stats", coin, exchange);
        }

        public Task<IList<Trade>> GetTradesAsync(string coin, string exchange)
        {
            return ApiGetAsync<IList<Trade>>("trades", coin, exchange);
        }

        public Task<IList<Order>> GetOrdersAsync(string coin, string exchange, OrderType type)
        {
            return type == OrderType.Buy ?
                   ApiGetAsync<IList<Order>>("orders", coin, exchange, "BUY") :
                   ApiGetAsync<IList<Order>>("orders", coin, exchange, "SELL");
        }

        public Task<IList<MarketChartData>> GetChartDataAsync(string coin, string exchange)
        {
            return ApiGetAsync<IList<MarketChartData>>("chartdata", coin, exchange);
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

            return ApiGetAsync<IList<MarketChartData>>("chartdata", coin, exchange, periodString);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private async Task<T> ApiGetAsync<T>(string command, params string[] parameters)
        {
            return await HttpClient.ApiGetAsync<T>(Helper.ApiUrlMarket + command, parameters);
        }
    }
}
