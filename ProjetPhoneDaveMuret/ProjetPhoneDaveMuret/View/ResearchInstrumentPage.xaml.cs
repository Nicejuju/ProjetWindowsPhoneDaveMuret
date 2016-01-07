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
    public sealed partial class ResearchInstrumentPage : Page
    {
        Boolean isAdmin;

        private ResearchInstrumentViewModel researchInstrViewModel;

        public ResearchInstrumentPage()
        {
            this.InitializeComponent();
            researchInstrViewModel = new ResearchInstrumentViewModel();
            ListCategories.DataContext = researchInstrViewModel;           
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            isAdmin = (Boolean)e.Parameter;
            addMusicianBtn.IsEnabled = isAdmin;
            deleteMusicianBtn.IsEnabled = isAdmin;
            await researchInstrViewModel.getAsyncNomCategories();
            ListCategories.ItemsSource = researchInstrViewModel.ListCategories;
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

        private void CategoryBtn_Click(object sender, ItemClickEventArgs e)
        {
            var categorie = (Categorie)((ItemClickEventArgs)e).ClickedItem;
            ParameterToPass param = new ParameterToPass(isAdmin,categorie);                      
            Frame.Navigate(typeof(ListInstrByCategoryPage), param);
        }
    }
}
