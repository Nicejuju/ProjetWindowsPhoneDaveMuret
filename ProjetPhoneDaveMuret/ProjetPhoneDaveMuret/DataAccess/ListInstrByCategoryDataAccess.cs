using Newtonsoft.Json;
using ProjetPhoneDaveMuret.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ProjetPhoneDaveMuret.DataAccess
{
    class ListInstrByCategoryDataAccess
    {
        public ListInstrByCategoryDataAccess()
        {

        }

        private int intCategorie;

        public int IntCategorie
        {
            get { return intCategorie; }
            set { intCategorie = value; }
        }

        private int idInstrument;

        public int IdInstrument
        {
            get { return idInstrument; }
            set { idInstrument = value; }
        }


        public async Task getAsyncIdCategorie(String nomCat)
        {
            Uri url = new Uri("http://webapiphone.azurewebsites.net/api/categories/RechercherIdCategorie/?nomCategorie=" + nomCat);

            HttpClient client = new HttpClient();
            var json = await client.GetStringAsync(url);
            List<int> idCatList = JsonConvert.DeserializeObject<List<int>>(json);

            intCategorie = idCatList[0];
        }

        public async Task<List<Instrument>> getAsyncListInstruments()
        {
            Uri url = new Uri("http://webapiphone.azurewebsites.net/api/instruments/RechercherInstrumentParCategorie/?idCategorie=" + intCategorie);

            HttpClient client = new HttpClient();
            var json = await client.GetStringAsync(url);
            List<String> nomInstrumentListeString = JsonConvert.DeserializeObject<List<String>>(json);

            List<Instrument> listInstruments = new List<Instrument>();

            foreach (var nomInstrument in nomInstrumentListeString)
            {
                listInstruments.Add(new Instrument(nomInstrument));
            }

            return listInstruments;
        }        
    }
}
