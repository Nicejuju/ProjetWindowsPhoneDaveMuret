using ProjetPhoneDaveMuret.Model;
using ProjetPhoneDaveMuret.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Media.Playback;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Navigation;


namespace ProjetPhoneDaveMuret
{
    

    public sealed partial class InstrumentDetails : Page
    {
        Boolean isAdmin;
        ParameterToPass parameter;
        DetailsInstrumentViewModel detailsInstrumentVM;

        public InstrumentDetails()
        {
            this.InitializeComponent();
            detailsInstrumentVM = new DetailsInstrumentViewModel();                     
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            parameter = (ParameterToPass)e.Parameter;            
            isAdmin = parameter.IsAdmin;
            addMusicianBtn.IsEnabled = isAdmin;
            deleteMusicianBtn.IsEnabled = isAdmin;
            detailsInstrumentVM.NomInstrument = parameter.Instrument.Nom;
            await detailsInstrumentVM.getAsyncDetailInstrument();
            DetailsInstrumentPanel.DataContext = detailsInstrumentVM;                      
        }

        private void addMusician_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Frame.Navigate(typeof(AddMusicianPage), isAdmin);
        }

        private void deleteMusician_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Frame.Navigate(typeof(DeleteMusicianPage), isAdmin);
        }

        private void researchMusician_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Frame.Navigate(typeof(ResearchMusicianPage), isAdmin);
        }

        private void ListenBtn_Tapped(object sender, TappedRoutedEventArgs e)
        {
                               
        }
    }   
}
