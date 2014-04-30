using System.Reflection;

namespace MintPalAPI.Demo
{
    public sealed partial class MainWindow
    {
        private MintPalClient MintPalClient { get; set; }

        public MainWindow()
        {
            // Set icon from the assembly
            Icon = System.Drawing.Icon.ExtractAssociatedIcon(Assembly.GetExecutingAssembly().Location).ToImageSource();
            
            InitializeComponent();

            MintPalClient = new MintPalClient();
            LoadMarketSummary();
        }

        private async void LoadMarketSummary()
        {
            DataGrid1.Items.Clear();

            var markets = await MintPalClient.Markets.GetSummaryAsync();
            foreach (var market in markets) {
                DataGrid1.Items.Add(market);
            }

            DataGrid1.Items.Refresh();
        }
    }
}
