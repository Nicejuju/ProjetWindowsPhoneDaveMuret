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
    class ListMusicianByInstrDataAccess
    {
        public ListMusicianByInstrDataAccess ()
        {

        }

        private int idInstrument;

        public int IdInstrument
        {
            get { return idInstrument; }
            set { idInstrument = value; }
        }

        public async Task getAsyncIdInstrument(String nomSansEspaces)
        {
            var url = new Uri("http://webapiphone.azurewebsites.net/api/instruments/RetournerIdInstrument/?nomInstrument=" + nomSansEspaces);

            HttpClient client = new HttpClient();
            var json = await client.GetStringAsync(url);
            List<int> idInstrList = JsonConvert.DeserializeObject<List<int>>(json);

            IdInstrument = idInstrList[0];
        }

        public async Task<List<Musicien>> getAsyncListMusician()
        {
            Uri url = new Uri("http://webapiphone.azurewebsites.net/api/musiciens/ListeMusicienParInstrument/?idInstrument=" + IdInstrument);

            HttpClient client = new HttpClient();
            var json = await client.GetStringAsync(url);
            List<String> nomMusicienListString = JsonConvert.DeserializeObject<List<String>>(json);

            List<Musicien> listMusiciens = new List<Musicien>();

            foreach (var nomMusicien in nomMusicienListString)
            {
                listMusiciens.Add(new Musicien(nomMusicien));
            }

            return listMusiciens;
        }

    }
}
