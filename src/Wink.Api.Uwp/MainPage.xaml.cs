using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace Wink.Api.Uwp
{
    public partial class MainPage : Page
    {
        private WinkClient Client { get; set; }

        public MainPage()
        {
            this.InitializeComponent();

            WinkClient.SetLogging((message) => Debug.WriteLine(message));
            WinkClient.CLIENT_ID = Credentials.CLIENT_ID;
            WinkClient.CLIENT_SECRET = Credentials.CLIENT_SECRET;
            WinkClient.REDIRECT_URL = Credentials.REDIRECT_URL;
        }

        private async void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            CancellationToken ct = new CancellationToken();
            await this.AuthenticateAsync(ct);
            await this.RefreshAsync(ct);
        }

        private async void btnRefreshToken_Click(object sender, RoutedEventArgs e)
        {
            CancellationToken ct = new CancellationToken();
            if (this.Client?.UserAuthentication != null)
            {
                spToken.DataContext = JsonConvert.SerializeObject(await this.Client.RefreshTokenAsync(ct));
                await this.RefreshAsync(ct);
            }
            else
                await this.AuthenticateAsync(ct);
        }

        private async void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            if (this.Client != null)
            {
                CancellationToken ct = new CancellationToken();
                spToken.DataContext = this.Client = null;
                await this.RefreshAsync(ct);
            }
        }

        private async void btnRefreshData_Click(object sender, RoutedEventArgs e)
        {
            CancellationToken ct = new CancellationToken();
            if (this.Client == null)
                await this.AuthenticateAsync(ct);
            await this.RefreshAsync(ct);
        }

        private async Task AuthenticateAsync(CancellationToken ct)
        {
            this.Client = new WinkClient();
            spToken.DataContext = await this.Client.AuthenticateAsync(new AuthProvider(), ct);
        }

        private async Task RefreshAsync(CancellationToken ct)
        {
            if (this.Client?.UserAuthentication == null)
            {
                piDataRange.DataContext = null;
                piEGV.DataContext = null;
                piDevices.DataContext = null;
                piEvents.DataContext = null;
                piCalibrations.DataContext = null;
                piStatistics.DataContext = null;
                return;
            }

            try
            {
                piDataRange.DataContext = null;
                piDataRange.DataContext = JsonConvert.SerializeObject(await this.Client.GetDevices(ct));
            }
            catch (Exception ex)
            {
                piDataRange.DataContext = ex.ToString();
            }
        }
    }
}
