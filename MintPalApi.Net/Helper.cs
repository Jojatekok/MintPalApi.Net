using Newtonsoft.Json;
using System;
using System.Globalization;
using System.Net.Http;
using System.Threading.Tasks;

namespace MintPalAPI
{
    static class Helper
    {
        internal const string ApiUrlBase = "https://api.mintpal.com/";
        private const string ApiUrlVersionString = "v2/";
        internal const string ApiUrlMarket = ApiUrlBase + ApiUrlVersionString + "market/";
        internal const string ApiUrlWallet = ApiUrlBase + ApiUrlVersionString + "wallet/";

        internal static readonly CultureInfo InvariantCulture = CultureInfo.InvariantCulture;
        private static readonly JsonSerializerSettings JsonSerializerSettings = new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore };

        internal static async Task<T> ApiGetAsync<T>(this HttpClient httpClient, string command, params string[] parameters)
        {
            var relativeUrl = command;
            if (parameters.Length != 0) {
                relativeUrl += "/" + string.Join("/", parameters);
            }

            var jsonString = await httpClient.GetStringAsync(relativeUrl);
            return JsonConvert.DeserializeObject<JsonResponse<T>>(jsonString, JsonSerializerSettings).Data;
        }

        internal static async Task<T> ApiGetAsync<T>(this HttpClient httpClient, Authenticator authenticator, string command, params string[] parameters)
        {
            var relativeUrl = command;
            if (parameters.Length != 0) {
                relativeUrl += "/" + string.Join("/", parameters);
            }

            relativeUrl = authenticator.GetUrl(httpClient.BaseAddress + relativeUrl);
            var jsonString = await httpClient.GetStringAsync(relativeUrl);
            return JsonConvert.DeserializeObject<JsonResponse<T>>(jsonString, JsonSerializerSettings).Data;
        }

        internal static DateTime UnixTimeStampToDateTime(double unixTimeStamp)
        {
            return new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc).AddSeconds(unixTimeStamp);
        }

        internal static double DateTimeToUnixTimeStamp(DateTime dateTime)
        {
            return dateTime.Subtract(new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc)).TotalSeconds;
        }
    }
}
