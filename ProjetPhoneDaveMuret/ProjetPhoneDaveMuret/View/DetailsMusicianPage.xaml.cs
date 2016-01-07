using ProjetPhoneDaveMuret.Model;
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
    public sealed partial class DetailsMusicianPage : Page
    {

        ParameterToPass parameter;
        Boolean isAdmin;

        DetailsMusicianViewModel detailsMusicienVM;

        public DetailsMusicianPage()
        {
            this.InitializeComponent();
            detailsMusicienVM = new DetailsMusicianViewModel();
        }

        protected override async  void OnNavigatedTo(NavigationEventArgs e)
        {
            parameter = (ParameterToPass)e.Parameter;
            isAdmin = parameter.IsAdmin;
            addMusicianBtn.IsEnabled = isAdmin;
            deleteMusicianBtn.IsEnabled = isAdmin;
            detailsMusicienVM.NomMusicien = parameter.Musicien.Nom;
            await detailsMusicienVM.getAsyncDetailMusicien();
            detailsMusicianPanel.DataContext = detailsMusicienVM;
        }

        private void addMusician_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Frame.Navigate(typeof(AddMusicianPage), isAdmin);
        }

        private void deleteMusician_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Frame.Navigate(typeof(DeleteMusicianPage), isAdmin);
        }

        private void researchInstrument_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Frame.Navigate(typeof(ResearchInstrumentPage), isAdmin);
        }
    }
}
