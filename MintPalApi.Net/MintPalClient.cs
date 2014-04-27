namespace MintPalAPI
{
    public sealed class MintPalClient
    {
        private ApiWebClient _apiWebClient;

        public Authenticator Authenticator { get; private set; }

        public Market.Markets Markets { get; private set; }
        public Trading.Trading Trading { get; private set; }
        public Wallet.Wallet Wallet { get; private set; }

        public MintPalClient(string publicApiKey, string privateApiKey)
        {
            _apiWebClient = new ApiWebClient(Helper.ApiUrlBase);

            Authenticator = new Authenticator(_apiWebClient, publicApiKey, privateApiKey);

            Markets = new Market.Markets(_apiWebClient);
            Trading = new Trading.Trading(_apiWebClient);
            Wallet = new Wallet.Wallet(_apiWebClient);
        }

        public MintPalClient() : this(null, null)
        {

        }
    }
}
