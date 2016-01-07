using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Newtonsoft.Json;
using ProjetPhoneDaveMuret.DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net.Http;
using System.Threading.Tasks;

namespace ProjetPhoneDaveMuret.ViewModel
{


    class ConnectionViewModel : ViewModelBase, INotifyPropertyChanged
    {
        public event EventHandler verifyConnection;

        private ConnectionDataAccess connectionDataAccess;

        private List<String> response;

        public List<String> Response
        {
            get { return response; }
            set { response = value; }
        }


        public ConnectionViewModel()
        {
            Verify = new RelayCommand(ClickConnection, validateTextBox);
            connectionDataAccess = new ConnectionDataAccess();
        }

        public void OnVerifyConnection()
        {
            if (verifyConnection != null)
            {
                verifyConnection(this, new EventArgs());
            }
        }

        private string userName;

        public string UserName
        {
            get { return userName; }
            set
            {
                userName = value;                
                Verify.RaiseCanExecuteChanged();
            }
        }

        private String password;

        public String Password
        {
            get { return password; }
            set
            {
                password = value;
                Verify.RaiseCanExecuteChanged();
            }
        }

        public RelayCommand Verify { get; set; }

        public Boolean validateTextBox()
        {
            if (UserName == null || Password == null)
                return false;
            else
                return true;
        }

        private void ClickConnection()
        {
            OnVerifyConnection();
        }

        public async Task<List<String>> getAsyncUserInfos (String userName, String pwd)
        {
            return await connectionDataAccess.getAsyncUserInfos(userName, pwd);           
        }

    }
}