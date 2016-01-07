using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Newtonsoft.Json;
using ProjetPhoneDaveMuret.DataAccess;
using ProjetPhoneDaveMuret.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Windows.UI.Popups;
using Windows.UI.Xaml.Controls;

namespace ProjetPhoneDaveMuret.ViewModel
{

    class AddMusicianViewModel : ViewModelBase, INotifyPropertyChanged
    {
        public event EventHandler ReadyToAddMusician;
        public RelayCommand CheckData { get; set; }

        public AddMusicianViewModel()
        {
            CheckData = new RelayCommand(AddMusician,validateData);
            CheckTitle = new RelayCommand(AddTitleRelay, validateTitle);
            CheckConcert = new RelayCommand(AddConcertRelay, validateConcert);
            addMusicianDA = new AddMusicianDataAccess();
            addBirthdate = new DatePicker();
        }

        private AddMusicianDataAccess addMusicianDA;

        public void AddMusician()
        {
            if (ReadyToAddMusician != null)
                ReadyToAddMusician(this, new EventArgs());
        }



        public Boolean validateData()
        {
            if (AddName == null || AddFirstName == null || AddBiography == null || ListTitle.Count == 0)
                return false;
            else
                return true;
        }

        private string addName;

        public string AddName
        {
            get { return addName; }
            set
            {
                var nameToTest = value;
                Match match = Regex.Match(nameToTest, "([A-Za-z]+)");

                if(match.Success)
                    addName = value;  
                else
                    addName = null;
                
                CheckData.RaiseCanExecuteChanged();
            }
        }

        private string addFirstName;

        public string AddFirstName
        {
            get { return addFirstName; }
            set
            {
                var firstNameToTest = value;
                Match match = Regex.Match(firstNameToTest, "([A-Za-z]+)");

                if (match.Success)
                    addFirstName = value;
                else
                    addFirstName = null;

                CheckData.RaiseCanExecuteChanged();
            }
        }

        private DatePicker addBirthdate;

        public DatePicker AddBirthdate
        {
            get { return addBirthdate; }
            set { addBirthdate = value; }
        }

        private List<Instrument> listInstruments = new List<Instrument>();       

        public List<Instrument> ListInstruments
        {
            get { return listInstruments; }
            set { listInstruments = value; }
        }

        private String nomInstrument;

        public String  NomInstrument
        {
            get { return nomInstrument; }
            set { nomInstrument = value; }
        }


        public async Task getAsyncNomInstruments()
        {           

            ListInstruments =  await addMusicianDA.getAsyncNomInstruments();
        }

        private Instrument instrSelected;

        public Instrument InstrSelected
        {
            get { return instrSelected; }
            set { instrSelected = value; }
        }      
        
        private string addBiography;
        
        public string AddBiography
        {
            get { return addBiography; }
            set { 
                addBiography = value;
                CheckData.RaiseCanExecuteChanged();
            }
        }

        private String addTitle;

        public event EventHandler ReadyToAddTitle;
        public RelayCommand CheckTitle { get; set; }


        public Boolean validateTitle()
        {
            if (AddTitle == null)
                return false;
            else
                return true;
        }

        public void AddTitleRelay()
        {
            if (ReadyToAddTitle != null)
                ReadyToAddTitle(this, new EventArgs());
        }

        public String AddTitle
        {
            get { return addTitle; }
            set {
                var titleToTest = value;
                if (titleToTest != null && !titleToTest.Equals(""))
                    addTitle = value;
                else
                    addTitle = null;

                    CheckTitle.RaiseCanExecuteChanged();
            }
        }      

        private ObservableCollection<TitreConnu> listTitle = new ObservableCollection<TitreConnu> ();

        public ObservableCollection<TitreConnu> ListTitle
        {
            get { return listTitle; }
            set { listTitle = value;            
            }
        }

        public void AddTitleToList ()
        {
            TitreConnu titleToAdd = new TitreConnu(addTitle);
            listTitle.Add(titleToAdd);
            CheckData.RaiseCanExecuteChanged();
        }

        private String addConcert;

        public event EventHandler ReadyToAddConcert;
        public RelayCommand CheckConcert { get; set; }

        public Boolean validateConcert()
        {
            if (AddConcert == null)
                return false;
            else
                return true;
        }

        public void AddConcertRelay()
        {
            if (ReadyToAddConcert != null)
                ReadyToAddConcert(this, new EventArgs());
        }

        public String AddConcert
        {
            get { return addConcert; }
            set { addConcert = value;
                CheckConcert.RaiseCanExecuteChanged();
            }
        }

        private ObservableCollection<Concert> listConcert = new ObservableCollection<Concert>();

        public ObservableCollection<Concert> ListConcert
        {
            get { return listConcert; }
            set { listConcert = value; }
        }

        public void AddConcertToList ()
        {
            Concert concertToAdd = new Concert(addConcert);
            listConcert.Add(concertToAdd);
        }

        private int idPhotoToAdd;

        public int IdPhotoToAdd
        {
            get { return idPhotoToAdd; }
            set { idPhotoToAdd = value; }
        }

        private int idMusicianToAdd;

        public int IdMusicianToAdd
        {
            get { return idMusicianToAdd; }
            set { idMusicianToAdd = value; }
        }

        public async Task setAsyncPhotoToBD ()
        {           
            await addMusicianDA.setAsyncPhotoToBD();
        }

        public async Task setAnsycMusicianToBD()
        {
            String nomInstrumentSansEspaces = setNomInstrumentSansEspaces(instrSelected.Nom);
            await addMusicianDA.setAnsycMusicianToBD(nomInstrumentSansEspaces, addName, addFirstName, addBiography);
        }

        public async Task setAsyncTitlesToBD()
        {
            await addMusicianDA.setAsyncTitlesToBD(listTitle);
        }

        public async Task setAsyncConcertToBD()
        {
           await addMusicianDA.setAsyncConcertToBD(listConcert);
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
