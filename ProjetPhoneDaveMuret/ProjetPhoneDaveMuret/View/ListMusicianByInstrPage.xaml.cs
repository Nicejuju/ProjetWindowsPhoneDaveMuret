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
    public sealed partial class ListMusicianByInstrPage : Page
    {
        ParameterToPass parameter;
        Boolean isAdmin;

        ListMusicianByInstrViewModel listMusicianByInstrVM;

        public ListMusicianByInstrPage()
        {
            this.InitializeComponent();
            listMusicianByInstrVM = new ListMusicianByInstrViewModel();
            ListMusicianByInstr.DataContext = listMusicianByInstrVM;
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            parameter = (ParameterToPass)e.Parameter;
            listMusicianByInstrVM.NomInstrument = parameter.Instrument.Nom;
            isAdmin = parameter.IsAdmin;
            addMusicianBtn.IsEnabled = isAdmin;
            deleteMusicianBtn.IsEnabled = isAdmin;
            await listMusicianByInstrVM.getAsyncNomMusician();
            ListMusicianByInstr.ItemsSource = listMusicianByInstrVM.ListMusiciens;
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

        private void MusicianBtn_Click(object sender, ItemClickEventArgs e)
        {
            Musicien musicienClicked = (Musicien)((ItemClickEventArgs)e).ClickedItem;
            var parameter = new ParameterToPass(isAdmin, musicienClicked);
            Frame.Navigate(typeof(DetailsMusicianPage), parameter);
        }
    }
}
