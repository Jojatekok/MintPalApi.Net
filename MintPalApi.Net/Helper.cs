using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Net;
using System.Reflection;
using System.Threading.Tasks;

namespace MintPalAPI
{
    static class Helper
    {
        internal const string ApiUrlBase = "https://api.mintpal.com/";
        private const string ApiUrlVersionString = "v2/";
        internal const string ApiUrlPrefixMarket = ApiUrlVersionString + "market/";
        internal const string ApiUrlPrefixTrading = ApiUrlVersionString + "trading/";
        internal const string ApiUrlPrefixWallet = ApiUrlVersionString + "wallet/";

        internal static readonly string AssemblyVersion = Assembly.GetExecutingAssembly().GetName().Version.ToString(3);

        internal static readonly CultureInfo InvariantCulture = CultureInfo.InvariantCulture;

        internal static async Task<string> GetResponseStringAsync(this HttpWebRequest request)
        {
            using (var response = await request.GetResponseAsync()) {
                using (var stream = response.GetResponseStream()) {
                    if (stream == null) return null; // TODO: Throw Exception

                    using (var reader = new StreamReader(stream)) {
                        return await reader.ReadToEndAsync();
                    }
                }
            }
        }

        internal static string ToStringUniform(this double value)
        {
            return value.ToString("0.########", InvariantCulture);
        }

        internal static string ToHttpPostString(this Dictionary<string, object> dictionary)
        {
            var output = string.Empty;
            foreach (var entry in dictionary)
            {
                var valueString = entry.Value as string;
                if (valueString == null) {
                    output += "&" + entry.Key + "=" + entry.Value;
                } else {
                    output += "&" + entry.Key + "=" + valueString.Replace(' ', '+');
                }
            }

            return output.Substring(1);
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
