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
    class ListMusicianByInstrViewModel
    {
        private List<Musicien> listMusiciens = new List<Musicien>();

        private ListMusicianByInstrDataAccess listMusicianByInstrDA;
        
        public ListMusicianByInstrViewModel()
        {
            listMusicianByInstrDA = new ListMusicianByInstrDataAccess();
        }               

        public async Task getAsyncNomMusician()
        {
            String nomSansEspaces = setNomInstrumentSansEspaces(NomInstrument);

            await listMusicianByInstrDA.getAsyncIdInstrument(nomSansEspaces);

            ListMusiciens = await listMusicianByInstrDA.getAsyncListMusician();             
        }

        public List<Musicien> ListMusiciens
        {
            get { return listMusiciens; }
            set { listMusiciens = value; }
        }

        private String nomInstrument;

        public String NomInstrument
        {
            get { return nomInstrument; }
            set { nomInstrument = value; }
        }

        private int idInstrument;

        public int IdInstrument
        {
            get { return idInstrument; }
            set { idInstrument = value; }
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
