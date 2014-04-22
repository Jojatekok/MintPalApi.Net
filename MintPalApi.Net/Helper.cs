using Newtonsoft.Json;
using System;
using System.Globalization;

namespace MintPalAPI
{
    static class Helper
    {
        internal static readonly CultureInfo InvariantCulture = CultureInfo.InvariantCulture;

        internal static readonly JsonSerializerSettings JsonSerializerSettings = new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore };

        private const string ApiUrlBase = "https://api.mintpal.com/v2/";
        internal const string ApiUrlMarket = ApiUrlBase + "market/";

        internal static DateTime UnixTimeStampToDateTime(double unixTimeStamp)
        {
            return new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc).AddSeconds(unixTimeStamp);
        }
    }
}
