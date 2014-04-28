using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace MintPalAPI.TradingTools
{
    public class Trading
    {
        private ApiWebClient ApiWebClient { get; set; }

        internal Trading(ApiWebClient apiWebClient)
        {
            ApiWebClient = apiWebClient;
        }

        public Task<Order> GetOpenOrderAsync(string id)
        {
            return GetDataAsync<Order>("order", id);
        }

        public Task<IList<Order>> GetOpenOrdersAsync()
        {
            return GetDataAsync<IList<Order>>("orders");
        }

        public Task<IList<Order>> GetOpenOrdersAsync(string coin)
        {
            return GetDataAsync<IList<Order>>("orders", coin);
        }

        public Task<IList<Order>> GetOpenOrdersAsync(string coin, int start, int limit)
        {
            return GetDataAsync<IList<Order>>("orders", coin, start, limit);
        }

        public Task<IList<Order>> GetOpenOrdersAsync(int limit)
        {
            return GetOpenOrdersAsync("ALL", 0, limit);
        }

        public Task<IList<Order>> GetOpenOrdersAsync(int start, int limit)
        {
            return GetOpenOrdersAsync("ALL", start, limit);
        }

        public Task<Order> PostOrderAsync(string coin, string exchange, double price, double amount, OrderType type)
        {
            var postData = new Dictionary<string, object>(2) {
                { "coin", coin },
                { "exchange", exchange },
                { "price", price.ToStringUniform() },
                { "amount", amount.ToStringUniform() },
                { "type", (byte)type },
            };

            return PostDataAsync<Order>("order", postData);
        }

        public Task DeleteOrderAsync(string id)
        {
            return DeleteDataAsync("order", id);
        }

        public Task<Trade> GetTradeAsync(string id)
        {
            return GetDataAsync<Trade>("trade", id);
        }

        public Task<IList<Trade>> GetTradesAsync()
        {
            return GetDataAsync<IList<Trade>>("trades");
        }

        public Task<IList<Trade>> GetTradesAsync(string coin)
        {
            return GetDataAsync<IList<Trade>>("trades", coin);
        }

        public Task<IList<Trade>> GetTradesAsync(string coin, int start, int limit)
        {
            return GetDataAsync<IList<Trade>>("trades", coin, start, limit);
        }

        public Task<IList<Trade>> GetTradesAsync(int limit)
        {
            return GetTradesAsync("ALL", 0, limit);
        }

        public Task<IList<Trade>> GetTradesAsync(int start, int limit)
        {
            return GetTradesAsync("ALL", start, limit);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private async Task<T> GetDataAsync<T>(string command, params object[] parameters)
        {
            return await ApiWebClient.GetDataAsync<T>(true, Helper.ApiUrlPrefixTrading + command, parameters);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private async Task DeleteDataAsync(string command, params object[] parameters)
        {
            await ApiWebClient.DeleteDataAsync(Helper.ApiUrlPrefixTrading + command, parameters);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private async Task<T> PostDataAsync<T>(string command, Dictionary<string, object> postData)
        {
            return await ApiWebClient.PostDataAsync<T>(Helper.ApiUrlPrefixTrading + command, postData);
        }
    }
}
