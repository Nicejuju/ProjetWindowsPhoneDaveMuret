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
    class DeleteMusicianDataAccess
    {
        public DeleteMusicianDataAccess()
        {

        }

        public async Task<List<Musicien>> getAsyncListMusician()
        {
            var url = new Uri("http://webapiphone.azurewebsites.net/api/musiciens/RetournerNomsMusiciens");
            HttpClient client = new HttpClient();
            var json = await client.GetStringAsync(url);
            List<String> NomPrenomMusicianList = JsonConvert.DeserializeObject<List<String>>(json);

            List<Musicien> listMusiciens = new List<Musicien>();

            foreach (var nomPrenomMus in NomPrenomMusicianList)
            {
                listMusiciens.Add(new Musicien(nomPrenomMus));
            }

            return listMusiciens;
        }

        public async Task deleteMusicianToBD (String nomSansEspaces)
        {
            var url = new Uri("http://webapiphone.azurewebsites.net/api/musiciens/RechercheridParNom/?nomPrenom=" + nomSansEspaces);
            HttpClient client = new HttpClient();
            var json = await client.GetStringAsync(url);
            List<int> idMusicianList = JsonConvert.DeserializeObject<List<int>>(json);

            int idMusicianToDelete = idMusicianList[0];

            // Supprimer Concerts du musicien
            url = new Uri("http://webapiphone.azurewebsites.net/api/concertavenirs/SupprimerConcertsMusiciens/?idMusicien=" + idMusicianToDelete);
            client = new HttpClient();
            HttpResponseMessage response = await client.DeleteAsync(url);                      

            // Supprimer Titres du musicien
            url = new Uri("http://webapiphone.azurewebsites.net/api/titreconnus/SupprimerTitresMusiciens/?idMusicien=" + idMusicianToDelete);
            client = new HttpClient();
            response = await client.DeleteAsync(url);

            // Récupérer ID photo à supprimer
            url = new Uri("http://webapiphone.azurewebsites.net/api/musiciens/RetournerPhotoMusiciens/?idMusicien=" + idMusicianToDelete);
            client = new HttpClient();
            json = await client.GetStringAsync(url);
            List<int> idPhotoList = JsonConvert.DeserializeObject<List<int>>(json);

            int idPhotoToDelete = idPhotoList[0];

            //Supprimer Musicien
            url = new Uri("http://webapiphone.azurewebsites.net/api/musiciens/SupprimerMusicien/?id=" + idMusicianToDelete);
            client = new HttpClient();
            response = await client.DeleteAsync(url);

            // Supprimer Photo
            url = new Uri("http://webapiphone.azurewebsites.net/api/photos/SupprimerPhoto/?id=" + idPhotoToDelete);
            client = new HttpClient();
            response = await client.DeleteAsync(url);

        }
    }
}
