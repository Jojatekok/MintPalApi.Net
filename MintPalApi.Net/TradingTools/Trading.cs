using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Jojatekok.MintPalAPI.TradingTools
{
    public class Trading :ITrading
    {
        private ApiWebClient ApiWebClient { get; set; }

        internal Trading(ApiWebClient apiWebClient)
        {
            ApiWebClient = apiWebClient;
        }

        public async Task<IOrder> GetOpenOrderAsync(string id)
        {
            var data = await GetDataAsync<Order>("order", id);
            return (IOrder)data;
        }

        public async Task<IList<IOrder>> GetOpenOrdersAsync()
        {
            var data = await GetDataAsync<IList<Order>>("orders");
            return new List<IOrder>(data);
        }

        public async Task<IList<IOrder>> GetOpenOrdersAsync(string coin)
        {
            var data = await GetDataAsync<IList<Order>>("orders", coin);
            return new List<IOrder>(data);
        }

        public async Task<IList<IOrder>> GetOpenOrdersAsync(string coin, int start, int limit)
        {
            var data = await GetDataAsync<IList<Order>>("orders", coin, start, limit);
            return new List<IOrder>(data);
        }

        public async Task<IList<IOrder>> GetOpenOrdersAsync(int limit)
        {
            var data = await GetOpenOrdersAsync("ALL", 0, limit);
            return new List<IOrder>(data);
        }

        public Task<IList<IOrder>> GetOpenOrdersAsync(int start, int limit)
        {
            return GetOpenOrdersAsync("ALL", start, limit);
        }

        public async Task<IOrder> PostOrderAsync(string coin, string exchange, double price, double amount, OrderType type)
        {
            var postData = new Dictionary<string, object>(2) {
                { "coin", coin },
                { "exchange", exchange },
                { "price", price.ToStringUniform() },
                { "amount", amount.ToStringUniform() },
                { "type", (byte)type },
            };

            var data = await PostDataAsync<Order>("order", postData);
            return (IOrder)data;
        }

        public Task<IOrder> PostOrderAsync(string coinPair, double price, double amount, OrderType type)
        {
            var coinPairSplit = Helper.SplitCoinPair(coinPair);
            return PostOrderAsync(coinPairSplit[0], coinPairSplit[0], price, amount, type);
        }

        public Task DeleteOrderAsync(string id)
        {
            return DeleteDataAsync("order", id);
        }

        public async Task<ITrade> GetTradeAsync(string id)
        {
            var data = await GetDataAsync<Trade>("trade", id);
            return (ITrade)data;
        }

        public async Task<IList<ITrade>> GetTradesAsync()
        {
            var data = await GetDataAsync<IList<Trade>>("trades");
            return new List<ITrade>(data);
        }

        public async Task<IList<ITrade>> GetTradesAsync(string coin)
        {
            var data = await GetDataAsync<IList<Trade>>("trades", coin);
            return new List<ITrade>(data);
        }

        public async Task<IList<ITrade>> GetTradesAsync(string coin, int start, int limit)
        {
            var data = await GetDataAsync<IList<Trade>>("trades", coin, start, limit);
            return new List<ITrade>(data);
        }

        public Task<IList<ITrade>> GetTradesAsync(int limit)
        {
            return GetTradesAsync("ALL", 0, limit);
        }

        public Task<IList<ITrade>> GetTradesAsync(int start, int limit)
        {
            return GetTradesAsync("ALL", start, limit);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private Task<T> GetDataAsync<T>(string command, params object[] parameters)
        {
            return ApiWebClient.GetDataAsync<T>(this, true, Helper.ApiUrlPrefixTrading + command, parameters);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private Task DeleteDataAsync(string command, params object[] parameters)
        {
            return ApiWebClient.DeleteDataAsync(Helper.ApiUrlPrefixTrading + command, parameters);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private Task<T> PostDataAsync<T>(string command, Dictionary<string, object> postData)
        {
            return ApiWebClient.PostDataAsync<T>(this, Helper.ApiUrlPrefixTrading + command, postData);
        }
    }
}
