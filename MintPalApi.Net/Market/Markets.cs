using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace MintPalAPI
{
    public class Markets
    {
        private HttpClient HttpClient { get; set; }

        public Markets(HttpClient httpClient)
        {
            HttpClient = httpClient;
        }

        public Task<IList<Market>> GetSummaryAsync()
        {
            return RequestAsync<IList<Market>>("summary");
        }

        public Task<IList<Market>> GetSummaryAsync(string exchange)
        {
            return RequestAsync<IList<Market>>("summary/" + exchange);
        }

        public Task<Market> GetStatsAsync(string coinPair)
        {
            return RequestAsync<Market>("stats/" + coinPair);
        }

        public Task<Market> GetStatsAsync(string coin, string exchange)
        {
            return RequestAsync<Market>("stats/" + coin + "/" + exchange);
        }

        public Task<IList<Trade>> GetTradesAsync(string coin, string exchange)
        {
            return RequestAsync<IList<Trade>>("trades/" + coin + "/" + exchange);
        }

        public Task<IList<Order>> GetOrdersAsync(string coin, string exchange, OrderType type)
        {
            return type == OrderType.Buy ?
                   RequestAsync<IList<Order>>("orders/" + coin + "/" + exchange + "/" + "BUY") :
                   RequestAsync<IList<Order>>("orders/" + coin + "/" + exchange + "/" + "SELL");
        }

        public Task<IList<MarketChartData>> GetChartDataAsync(string coin, string exchange)
        {
            return RequestAsync<IList<MarketChartData>>("chartdata/" + coin + "/" + exchange);
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

            return RequestAsync<IList<MarketChartData>>("chartdata/" + coin + "/" + exchange + "/" + periodString);
        }

        private async Task<T> RequestAsync<T>(string relativeUrl)
        {
            var jsonString = await HttpClient.GetStringAsync(Helper.ApiUrlMarket + relativeUrl);
            return JsonConvert.DeserializeObject<JsonResponse<T>>(jsonString, Helper.JsonSerializerSettings).Data;
        }
    }
}
