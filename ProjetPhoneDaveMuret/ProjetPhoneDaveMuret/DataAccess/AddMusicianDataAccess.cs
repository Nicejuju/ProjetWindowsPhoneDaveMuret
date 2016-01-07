using Newtonsoft.Json;
using ProjetPhoneDaveMuret.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace ProjetPhoneDaveMuret.DataAccess
{
    class AddMusicianDataAccess
    {
        public AddMusicianDataAccess()
        {

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


        public async Task setAsyncPhotoToBD()
        {
            String urlPhoto = "http://t8.ulule.me/vox/528/comment-hacker-photo-profil-facebook-1.jpeg";

            var url = new Uri("http://webapiphone.azurewebsites.net/api/photos/RechercheIdMaxPhoto");

            HttpClient client = new HttpClient();
            var json = await client.GetStringAsync(url);
            List<int> idMaxPhoto = JsonConvert.DeserializeObject<List<int>>(json);

            idPhotoToAdd = idMaxPhoto[0] + 1;

            Photo photoToAdd = new Photo(idPhotoToAdd, urlPhoto);
            var urlString = new Uri("http://webapiphone.azurewebsites.net/api/photos/InsererPhoto");
            client = new HttpClient();
            await client.PostAsJsonAsync<Photo>(urlString, photoToAdd);
        }

        public async Task setAnsycMusicianToBD(String nomInstrSansEspaces,String addName, String addFirstName, String addBiography)
        {
            // Id Instrument joué par le musicien
            var url = new Uri("http://webapiphone.azurewebsites.net/api/instruments/RetournerIdInstrument/?nomInstrument=" + nomInstrSansEspaces);
            HttpClient client = new HttpClient();
            var json = await client.GetStringAsync(url);
            List<int> idInstrumentList = JsonConvert.DeserializeObject<List<int>>(json);

            int idInstrumentOfMusician = idInstrumentList[0];

            // Id du musicien à ajouter
            url = new Uri("http://webapiphone.azurewebsites.net/api/musiciens/RechercheIdMaxMusicien");
            client = new HttpClient();
            json = await client.GetStringAsync(url);
            List<int> idMusicianList = JsonConvert.DeserializeObject<List<int>>(json);

            idMusicianToAdd = idMusicianList[0] + 1;

            // Date du musicien
            String dateToAdd = "2000-01-01";

            // Création du Musicien
            Musicien musicianToAdd = new Musicien(idMusicianToAdd, idPhotoToAdd, addName, addFirstName, addBiography, idInstrumentOfMusician, dateToAdd);

            // Insertion en BD
            var urlStringMus = new Uri("http://webapiphone.azurewebsites.net/api/musiciens/InsererMusicien");
            client = new HttpClient();
            await client.PostAsJsonAsync<Musicien>(urlStringMus, musicianToAdd);
        }

        public async Task setAsyncTitlesToBD(ObservableCollection<TitreConnu> listTitle)
        {
            foreach (var titre in listTitle)
            {
                TitreConnu newTitre = new TitreConnu(idMusicianToAdd, titre.TitreConnu1);

                var urlStringTitle = new Uri("http://webapiphone.azurewebsites.net/api/titreconnus/InsererTitre");
                HttpClient client = new HttpClient();
                await client.PostAsJsonAsync<TitreConnu>(urlStringTitle, newTitre);
            }
        }

        public async Task setAsyncConcertToBD(ObservableCollection<Concert> listConcert)
        {
            foreach (var concert in listConcert)
            {
                Concert newConcert = new Concert(idMusicianToAdd, concert.ConcertAvenir1);

                var urlStringConcert = new Uri("http://webapiphone.azurewebsites.net/api/concertavenirs/InsererConcert");
                HttpClient client = new HttpClient();
                await client.PostAsJsonAsync<Concert>(urlStringConcert,newConcert);
            }
        }

        public async Task<List<Instrument>> getAsyncNomInstruments()
        {
            var url = new Uri("http://webapiphone.azurewebsites.net/api/instruments/RetournerNomInstrument");

            HttpClient client = new HttpClient();
            var json = await client.GetStringAsync(url);
            List<String> nomInstrList = JsonConvert.DeserializeObject<List<String>>(json);

            List<Instrument> listInstruments = new List<Instrument>();

            foreach (var nomInstr in nomInstrList)
            {
                listInstruments.Add(new Instrument(nomInstr));
            }

            return listInstruments;
        }
    }
}
