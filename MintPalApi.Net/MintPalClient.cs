using MintPalAPI.MarketTools;
using MintPalAPI.TradingTools;
using MintPalAPI.WalletTools;

namespace MintPalAPI
{
    public sealed class MintPalClient
    {
        private ApiWebClient _apiWebClient;

        public Authenticator Authenticator { get; private set; }

        public Markets Markets { get; private set; }
        public Trading Trading { get; private set; }
        public Wallet Wallet { get; private set; }

        public MintPalClient(string publicApiKey, string privateApiKey)
        {
            _apiWebClient = new ApiWebClient(Helper.ApiUrlBase);

            Authenticator = new Authenticator(_apiWebClient, publicApiKey, privateApiKey);

            Markets = new Markets(_apiWebClient);
            Trading = new Trading(_apiWebClient);
            Wallet = new Wallet(_apiWebClient);
        }

        public MintPalClient() : this(null, null)
        {

        }
    }
}
