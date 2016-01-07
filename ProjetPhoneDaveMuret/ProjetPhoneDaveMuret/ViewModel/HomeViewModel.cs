using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Xaml;

namespace ProjetPhoneDaveMuret.ViewModel
{
    class HomeViewModel : ViewModelBase
    {
        private ICommand _goToResearchInstrPageCommand;

        public ICommand GoToSecondPageCommand
        {
            get
            {
                if (_goToResearchInstrPageCommand == null)
                    _goToResearchInstrPageCommand = new RelayCommand(() => GoToResearchInstrPage());
                return _goToResearchInstrPageCommand;
            }
        }
        private void GoToResearchInstrPage()
        {
           // (Application.Current.RootVisual as PhoneApplicationFrame).Navigate(typeof(ResearchInstrumentPage)," ");
        }
    }
}
