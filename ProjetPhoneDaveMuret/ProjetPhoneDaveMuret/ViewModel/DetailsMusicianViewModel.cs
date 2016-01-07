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
    class DetailsMusicianViewModel
    {
        //private Musicien musicianDetails;

        //public Musicien MusicianDetails
        //{
        //    get { return musicianDetails; }
        //    set { musicianDetails = value; }
        //}

        private DetailsMusicianDataAccess detailsMusicianDA;

        public DetailsMusicianViewModel()
        {
            detailsMusicianDA = new DetailsMusicianDataAccess();
        }

        public async Task getAsyncDetailMusicien()
        {
            String nomMusicienSansEspaces = setNomMusicienSansEspaces(NomMusicien);

            await detailsMusicianDA.getAsyncIdMusician(nomMusicienSansEspaces);

            Biographie = await detailsMusicianDA.getAsyncBiography();

            ChaineTitres = await detailsMusicianDA.getAsyncChaineTitres();

            ChaineConcerts = await detailsMusicianDA.getAsyncChaineConcerts();

            Url = await detailsMusicianDA.getAsyncUrl();
        }

        public String setNomMusicienSansEspaces(String nom)
        {
            //Il faut remplacer les espaces du nom par un caractère (ici _) pour pouvoir l'envoyer dans l'url
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

        private int idMusicien;

        public int IdMusicien
        {
            get { return idMusicien; }
            set { idMusicien = value; }
        }

        private String nomMusicien;

        public String NomMusicien
        {
            get { return nomMusicien; }
            set { nomMusicien = value; }
        }
        private String biographie;

        public String Biographie
        {
            get { return biographie; }
            set { biographie = value; }
        }
        
        private String chaineTitres;

        public String ChaineTitres
        {
            get { return chaineTitres; }
            set { chaineTitres = value; }
        }

        private String chaineConcerts;

        public String ChaineConcerts
        {
            get { return chaineConcerts; }
            set { chaineConcerts = value; }
        }

        private String url;

        public String Url
        {
            get { return url; }
            set { url = value; }
        }
    }
}
