using ProjetPhoneDaveMuret.Model;
using ProjetPhoneDaveMuret.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;


namespace ProjetPhoneDaveMuret
{
    

    public sealed partial class AddMusicianPage : Page
    {
        Boolean isAdmin;

        AddMusicianViewModel addMusicienVM;

        public AddMusicianPage()
        {
            this.InitializeComponent();
            addMusicienVM = new AddMusicianViewModel();
            AddMusicianPanel.DataContext = addMusicienVM;           
            addMusicienVM.ReadyToAddMusician += addMusicienVM_readyToAddMusician;           
            AddListBox.ItemsSource = addMusicienVM.ListTitle;
            AddConcertBox.ItemsSource = addMusicienVM.ListConcert;            
        }

        private async void addMusicienVM_readyToAddMusician(object sender, EventArgs e)
        {            
             await addMusicienVM.setAsyncPhotoToBD();

             await addMusicienVM.setAnsycMusicianToBD();

             await addMusicienVM.setAsyncTitlesToBD();

             await addMusicienVM.setAsyncConcertToBD();

             MessageDialog msgDialog = new MessageDialog("musicien " + addMusicienVM.AddName + " " + addMusicienVM.AddFirstName + " " + "ajouté", "Ajout OK");
             msgDialog.ShowAsync();      
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            isAdmin = (Boolean)e.Parameter;            
            deleteMusicianBtn.IsEnabled = isAdmin;            
            await addMusicienVM.getAsyncNomInstruments();
            AddInstrComboBox.ItemsSource = addMusicienVM.ListInstruments;
            AddInstrComboBox.SelectedIndex = 0;
        }

        private void deleteMusician_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Frame.Navigate(typeof(DeleteMusicianPage), isAdmin);
        }

        private void researchMusician_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Frame.Navigate(typeof(ResearchMusicianPage), isAdmin);
        }

        private void researchInstrument_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Frame.Navigate(typeof(ResearchInstrumentPage), isAdmin);
        }

        private void AddTitleToList_Click(object sender, RoutedEventArgs e)
        {
            addMusicienVM.AddTitleToList();                      
        }

        private void AddConcertToList_Click(object sender, RoutedEventArgs e)
        {
            addMusicienVM.AddConcertToList();           
        }
    }
}
