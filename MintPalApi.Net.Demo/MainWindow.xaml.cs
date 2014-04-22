using System;

namespace MintPalAPI.Demo
{
    public sealed partial class MainWindow : IDisposable
    {
        private MintPalClient MintPalClient { get; set; }

        public MainWindow()
        {
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

        public void Dispose()
        {
            Dispose(true);
        }

        private void Dispose(bool disposing)
        {
            if (disposing) {
                if (MintPalClient != null) {
                    MintPalClient.Dispose();
                    MintPalClient = null;
                }
            }
        }
    }
}
