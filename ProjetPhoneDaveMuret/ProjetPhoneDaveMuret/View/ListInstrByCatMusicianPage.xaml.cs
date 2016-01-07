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
    public sealed partial class ListInstrByCatMusicianPage : Page
    {

        ParameterToPass parameter;
        Boolean isAdmin;
        ListInstrByCategoryViewModel listInstrByCatVM;


        public ListInstrByCatMusicianPage()
        {
            this.InitializeComponent();
            listInstrByCatVM = new ListInstrByCategoryViewModel();
            ListInstruments.DataContext = listInstrByCatVM;

        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            parameter = (ParameterToPass)e.Parameter;            
            listInstrByCatVM.NomCategorie = parameter.Categorie.Nom;
            await listInstrByCatVM.getAsyncInstrumentParCategories();
            ListInstruments.ItemsSource = listInstrByCatVM.ListInstruments;
            isAdmin = parameter.IsAdmin;
            addMusicianBtn.IsEnabled = isAdmin;
            deleteMusicianBtn.IsEnabled = isAdmin;           
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

        private void InstrumentBtn_Click(object sender, ItemClickEventArgs e)
        {
            Instrument instrClicked = (Instrument)((ItemClickEventArgs)e).ClickedItem;
            var parameter = new ParameterToPass(isAdmin, instrClicked);
            Frame.Navigate(typeof(ListMusicianByInstrPage), parameter);
        }
    }
}
