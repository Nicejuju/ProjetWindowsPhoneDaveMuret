using GalaSoft.MvvmLight;
using Newtonsoft.Json;
using ProjetPhoneDaveMuret.DataAccess;
using ProjetPhoneDaveMuret.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ProjetPhoneDaveMuret.ViewModel
{
    class ResearchInstrumentViewModel : ViewModelBase
    {
        private List<Categorie> listCategories = new List<Categorie>();

        private ResearchInstrumentDataAccess researchInstrDA;

        public ResearchInstrumentViewModel ()
        {
            researchInstrDA = new ResearchInstrumentDataAccess();
        }

        public async Task getAsyncNomCategories()
        {
            ListCategories = await researchInstrDA.getAsyncListCategories();           
        }

        public List<Categorie> ListCategories
        {
            get { return listCategories; }
            set { listCategories = value; }
        }

    }
}
