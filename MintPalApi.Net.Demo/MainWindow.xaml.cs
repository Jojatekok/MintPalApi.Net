using System.Reflection;

namespace Jojatekok.MintPalAPI.Demo
{
    public sealed partial class MainWindow
    {
        private MintPalClient MintPalClient { get; set; }

        public MainWindow()
        {
            // Set icon from the assembly
            Icon = System.Drawing.Icon.ExtractAssociatedIcon(Assembly.GetExecutingAssembly().Location).ToImageSource();
            
            InitializeComponent();

            MintPalClient = new MintPalClient(ApiKeys.PublicKey, ApiKeys.PrivateKey);
            LoadMarketSummaryAsync();
        }

        private async void LoadMarketSummaryAsync()
        {
            var markets = await MintPalClient.Markets.GetSummaryAsync();
            DataGrid1.Items.Clear();

            foreach (var market in markets) {
                DataGrid1.Items.Add(market);
            }

            DataGrid1.Items.Refresh();
        }
    }
}
