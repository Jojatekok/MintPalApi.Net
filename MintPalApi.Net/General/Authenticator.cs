using System;
using System.Security.Cryptography;
using System.Text;

namespace MintPalAPI
{
    public class Authenticator
    {
        private ApiWebClient ApiWebClient { get; set; }

        public string PublicKey { get; set; }
        public string PrivateKey { get; set; }

        private static bool IsTimeDifferenceSet { get; set; }
        private static double TimeDifference { get; set; }

        internal Authenticator(ApiWebClient apiWebClient, string publicKey, string privateKey) : this(apiWebClient)
        {
            apiWebClient.Authenticator = this;
            PublicKey = publicKey;
            PrivateKey = privateKey;
        }

        internal Authenticator(ApiWebClient apiWebClient)
        {
            ApiWebClient = apiWebClient;
            if (!IsTimeDifferenceSet) SyncTime();
        }

        private async void SyncTime()
        {
            IsTimeDifferenceSet = true;

            var serverTime = await ApiWebClient.GetDataAsync<double>(null, false, "timestamp");
            var clientTime = Helper.DateTimeToUnixTimeStamp(DateTime.UtcNow);

            TimeDifference = serverTime - clientTime + Helper.AuthRequestsExtraTimeSeconds;
        }

        internal string GetUrl(string mainUrl)
        {
            var output = "/?key=" + PublicKey +
                         "&time=" + (int)(Helper.DateTimeToUnixTimeStamp(DateTime.UtcNow) + TimeDifference);

            return output + "&hash=" + GetHash(mainUrl + output);
        }

        private string GetHash(string input)
        {
            var encoder = Encoding.ASCII;

            using (var hmac = new HMACSHA256(encoder.GetBytes(PrivateKey))) {
                return BitConverter.ToString(hmac.ComputeHash(encoder.GetBytes(input))).Replace("-", "").ToLower(Helper.InvariantCulture);
            }
        }
    }
}
