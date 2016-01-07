using GalaSoft.MvvmLight;
using ProjetPhoneDaveMuret.Model;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Windows.Foundation;
using Windows.UI.Popups;
using System.Net.Http;
using Newtonsoft.Json;
using ProjetPhoneDaveMuret.DataAccess;

namespace ProjetPhoneDaveMuret.ViewModel
{
    class DeleteMusicianViewModel : ViewModelBase
    {
        private List<Musicien> listMusiciens = new List<Musicien>();

        private DeleteMusicianDataAccess deleteMusicianDA;

        public DeleteMusicianViewModel()
        {
            deleteMusicianDA = new DeleteMusicianDataAccess();
        }

        public List<Musicien> ListMusiciens
        {
            get { return listMusiciens; }
            set { listMusiciens = value; }
        }

        private Musicien deletedMusician;

        public Musicien DeletedMusician
        {
            get { return deletedMusician; }
            set { deletedMusician = value; }
        }

        private Boolean deletedMusicianChoice;

        public Boolean DeletedMusicianChoice
        {
            get { return deletedMusicianChoice; }
            set { deletedMusicianChoice = value; }
        }

        public async Task getAsyncListMusician()
        {
            ListMusiciens = await deleteMusicianDA.getAsyncListMusician();
        }

        public async Task deleteMusician ()
        {
            var loader = new Windows.ApplicationModel.Resources.ResourceLoader ();
            var message = loader.GetString("messageDeleteDialog") + " " + deletedMusician.Nom + " ? ";
            var title = loader.GetString("DeleteMusicianTitleDialog");

            MessageDialog msgDialog = new MessageDialog(message,title);
         
            UICommand okBtn = new UICommand(loader.GetString("YesMessage"));
            okBtn.Invoked = YesBtnClick;
            msgDialog.Commands.Add(okBtn);
          
            UICommand cancelBtn = new UICommand(loader.GetString("NoMessage"));
            cancelBtn.Invoked = NoBtnClick;
            msgDialog.Commands.Add(cancelBtn);
                        
            await msgDialog.ShowAsync();
            
            if(deletedMusicianChoice)
            {
                String nomMusicienSansEspaces = setNomInstrumentSansEspaces(deletedMusician.Nom);
                await deleteMusicianDA.deleteMusicianToBD(nomMusicienSansEspaces);    
            }                         
        }

        private void NoBtnClick(IUICommand command)
        {
            deletedMusicianChoice = false;
        }

        public  void  YesBtnClick(IUICommand command)
        {
            deletedMusicianChoice = true;                 
        }

        public String setNomInstrumentSansEspaces(String nom)
        {
            String nomCopie = "";

            for (int i = 0; i < nom.Length; i++)
            {
                if (nom.ElementAt(i) == ' ')
                {
                    nomCopie += '_';
                }
                else
                {
                    nomCopie += nom.ElementAt(i);
                }
            }

            return nomCopie;
        }
    }
}
