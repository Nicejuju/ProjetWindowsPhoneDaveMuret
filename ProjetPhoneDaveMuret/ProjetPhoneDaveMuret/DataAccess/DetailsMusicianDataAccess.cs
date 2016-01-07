using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ProjetPhoneDaveMuret.DataAccess
{
    class DetailsMusicianDataAccess
    {
        public DetailsMusicianDataAccess()
        {

        }

        private int idMusicien;

        public int IdMusicien
        {
            get { return idMusicien; }
            set { idMusicien = value; }
        }

        public async Task getAsyncIdMusician( String nomMusicienSansEspaces)
        {
            var url = new Uri("http://webapiphone.azurewebsites.net/api/musiciens/RechercheridParNom/?nomPrenom=" + nomMusicienSansEspaces);

            HttpClient client = new HttpClient();
            var json = await client.GetStringAsync(url);
            List<int> idMusList = JsonConvert.DeserializeObject<List<int>>(json);

            idMusicien = idMusList[0];
        }

        public async Task<String> getAsyncBiography()
        {
            Uri url = new Uri("http://webapiphone.azurewebsites.net/api/musiciens/RechercheBiographie/?idMusicien=" + idMusicien);

            HttpClient client = new HttpClient();
            var json = await client.GetStringAsync(url);
            List<String> BiographieListeString = JsonConvert.DeserializeObject<List<String>>(json);

            return BiographieListeString[0];
        }

        public async Task<String> getAsyncChaineTitres()
        {

            Uri url = new Uri("http://webapiphone.azurewebsites.net/api/titreconnus/RechercherNomTitre/?idMusicien=" + idMusicien);

            HttpClient client = new HttpClient();
            var json = await client.GetStringAsync(url);
            List<String> TitresConnusListString = JsonConvert.DeserializeObject<List<String>>(json);

            var loader = new Windows.ApplicationModel.Resources.ResourceLoader();

            String chaineTitres = loader.GetString("ChaineTitreDebut") + "\n";

            foreach (var titre in TitresConnusListString)
            {
                chaineTitres += titre + "\n";
            }

            return chaineTitres;
        }
        
        public async Task<String> getAsyncChaineConcerts()
        {
            
            Uri url = new Uri("http://webapiphone.azurewebsites.net/api/concertavenirs/RechercherNomConcert/?idMusicien=" + idMusicien);

            HttpClient client = new HttpClient();
            var json = await client.GetStringAsync(url);
            List<String> ConcertsListString = JsonConvert.DeserializeObject<List<String>>(json);

            var loader = new Windows.ApplicationModel.Resources.ResourceLoader();

            String chaineConcerts = loader.GetString("ChaineConcertDebut") + "\n";

            foreach (var concert in ConcertsListString)
            {
                chaineConcerts += concert + "\n";
            }

            return chaineConcerts;
        }

        public async Task<String> getAsyncUrl ()
        {                     
            Uri url = new Uri("http://webapiphone.azurewebsites.net/api/photos/RechercherPhotoMusicien/?idMusicien=" + idMusicien);

            HttpClient client = new HttpClient();
            var json = await client.GetStringAsync(url);
            List<String> PhotoMusicienListString = JsonConvert.DeserializeObject<List<String>>(json);

            return PhotoMusicienListString[0];
        }


    }
}
