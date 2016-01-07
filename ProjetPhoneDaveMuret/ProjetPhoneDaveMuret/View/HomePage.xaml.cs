using ProjetPhoneDaveMuret.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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


namespace ProjetPhoneDaveMuret
{
    public sealed partial class HomePage : Page
    {
        Boolean isAdmin;

        private HomeViewModel homeViewModel;

        public HomePage()
        {
            this.InitializeComponent();           
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            homeViewModel = new HomeViewModel();
            researchInstrumentBtn.DataContext = homeViewModel;
            isAdmin = (Boolean)e.Parameter;
            addMusicianBtn.IsEnabled = isAdmin;
            deleteMusicianBtn.IsEnabled = isAdmin;
        }

        private void addMusician_Tapped (object sender, TappedRoutedEventArgs e)
        {
            Frame.Navigate(typeof(AddMusicianPage),isAdmin);
        }

        private void deleteMusician_Tapped (object sender, TappedRoutedEventArgs e)
        {
            Frame.Navigate(typeof(DeleteMusicianPage),isAdmin);
        }

        private void researchMusician_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Frame.Navigate(typeof(ResearchMusicianPage), isAdmin);
        }

        private void researchInstrument_Tapped (object sender, TappedRoutedEventArgs e)
        {
            Frame.Navigate(typeof(ResearchInstrumentPage), isAdmin);
        }
    }
}
