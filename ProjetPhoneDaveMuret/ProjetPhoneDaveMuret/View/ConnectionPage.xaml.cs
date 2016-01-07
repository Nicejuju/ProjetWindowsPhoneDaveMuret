using ProjetPhoneDaveMuret.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Newtonsoft.Json;

namespace ProjetPhoneDaveMuret
{
 
    public sealed partial class MainPage : Page
    {
        private ConnectionViewModel connectionViewModel;

        public MainPage()
        {
            this.InitializeComponent();
            connectionViewModel = new ConnectionViewModel();
            ConnectionPanel.DataContext = connectionViewModel;
            connectionViewModel.verifyConnection += ConnectionViewModel_verifyConnection;
        }
        
        private async void ConnectionViewModel_verifyConnection(object sender, EventArgs e)
        {
            Boolean isAdmin = false;                        

            List<String> response = await connectionViewModel.getAsyncUserInfos(connectionViewModel.UserName, connectionViewModel.Password);

            if (response[0].Equals("0"))
            {
                isAdmin = true;
                Frame.Navigate(typeof(HomePage),isAdmin);
            }
            else
            {
                if (connectionViewModel.UserName == "Guest" && connectionViewModel.Password == "visiteur")
                {
                    Frame.Navigate(typeof(HomePage), isAdmin);
                }
            }
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
        }
    }
}
