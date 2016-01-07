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
     public sealed partial class DeleteMusicianPage : Page
    {
        Boolean isAdmin;

        DeleteMusicianViewModel deleteMusicianVM;

        public DeleteMusicianPage()
        {
            deleteMusicianVM = new DeleteMusicianViewModel();
            this.InitializeComponent();
            ListMusician.DataContext = deleteMusicianVM;            
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            isAdmin = (Boolean)e.Parameter;
            addMusicianBtn.IsEnabled = isAdmin;
            await deleteMusicianVM.getAsyncListMusician();
            ListMusician.ItemsSource = deleteMusicianVM.ListMusiciens;
        }

        private void addMusician_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Frame.Navigate(typeof(AddMusicianPage), isAdmin);
        }

        private void researchMusician_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Frame.Navigate(typeof(ResearchMusicianPage), isAdmin);
        }

        private void researchInstrument_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Frame.Navigate(typeof(ResearchInstrumentPage), isAdmin);
        }

        public async void MusicianBtn_Click(object sender, ItemClickEventArgs e)
        {
            Musicien musicianClicked = (Musicien)((ItemClickEventArgs)e).ClickedItem;
            deleteMusicianVM.DeletedMusician = musicianClicked;
            await deleteMusicianVM.deleteMusician();

            Frame.Navigate(typeof(DeleteMusicianPage), isAdmin);            
        }
    }
}
