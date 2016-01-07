using GalaSoft.MvvmLight;
using Newtonsoft.Json;
using ProjetPhoneDaveMuret.DataAccess;
using ProjetPhoneDaveMuret.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ProjetPhoneDaveMuret.ViewModel
{
    class ListInstrByCategoryViewModel : ViewModelBase
    {
        private List<Instrument> listInstruments = new List<Instrument>();

        private ListInstrByCategoryDataAccess listInstrByCatDA;

        public ListInstrByCategoryViewModel()
        {
            listInstrByCatDA = new ListInstrByCategoryDataAccess();
        }
        
        public async Task getAsyncInstrumentParCategories()
        {
            await listInstrByCatDA.getAsyncIdCategorie(NomCategorie);

            ListInstruments = await listInstrByCatDA.getAsyncListInstruments();          
        }

        public List<Instrument> ListInstruments
        {
            get {return listInstruments;}              
            set { listInstruments = value; }
        }

        private int intCategorie;

        public int IntCategorie
        {
            get { return intCategorie; }
            set { intCategorie = value; }
        }

        private String nomCategorie;

        public String NomCategorie
        {
            get { return nomCategorie; }
            set { nomCategorie = value; }
        }


    }
}
