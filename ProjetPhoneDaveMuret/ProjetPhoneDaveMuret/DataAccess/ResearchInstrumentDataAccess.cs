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
    class ResearchInstrumentDataAccess
    {
        public ResearchInstrumentDataAccess()
        {

        }

        public async Task<List<Categorie>> getAsyncListCategories()
        {
            Uri url = new Uri("http://webapiphone.azurewebsites.net/api/categories/RamenerNomCategorie");

            HttpClient client = new HttpClient();
            var json = await client.GetStringAsync(url);
            List<String> nomCategories = JsonConvert.DeserializeObject<List<String>>(json);

            List<Categorie> listCategories = new List<Categorie>();

            foreach (var nomcat in nomCategories)
            {
                listCategories.Add(new Categorie(nomcat));
            }

            return listCategories;
        }
    }
}
