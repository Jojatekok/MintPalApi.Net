using Jojatekok.MintPalAPI.MarketTools;
using Jojatekok.MintPalAPI.TradingTools;
using Jojatekok.MintPalAPI.WalletTools;

namespace Jojatekok.MintPalAPI
{
    public sealed class MintPalClient
    {
        /// <summary>Represents the authenticator object of the client.</summary>
        public IAuthenticator Authenticator { get; private set; }

        /// <summary>A class which contains market tools for the client.</summary>
        public IMarkets Markets { get; private set; }
        /// <summary>A class which contains trading tools for the client.</summary>
        public ITrading Trading { get; private set; }
        /// <summary>A class which contains wallet tools for the client.</summary>
        public IWallet Wallet { get; private set; }

        /// <summary>Creates a new instance of MintPal API .NET's client service.</summary>
        /// <param name="publicApiKey">Your public API key.</param>
        /// <param name="privateApiKey">Your private API key.</param>
        public MintPalClient(string publicApiKey, string privateApiKey)
        {
            var apiWebClient = new ApiWebClient(Helper.ApiUrlBase);

            Authenticator = new Authenticator(apiWebClient, publicApiKey, privateApiKey);

            Markets = new Markets(apiWebClient);
            Trading = new Trading(apiWebClient);
            Wallet = new Wallet(apiWebClient);
        }

        /// <summary>Creates a new, unauthorized instance of MintPal API .NET's client service.</summary>
        public MintPalClient() : this(null, null)
        {

        }
    }
}
