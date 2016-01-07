using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetPhoneDaveMuret.Model
{
    class TitreConnu
    {
        private Musicien musicienTitreConnu;

        public Musicien MusicienTitreConnu
        {
            get { return musicienTitreConnu; }
            set { musicienTitreConnu = value; }
        }

        private String titreConnu1;
   
        public String TitreConnu1
        {
            get { return titreConnu1; }
            set { titreConnu1 = value; }
        }

        private int idMusicien;

        public int IdMusicien
        {
            get { return idMusicien; }
            set { idMusicien = value; }
        }


        public TitreConnu (String titre)
        {
            this.titreConnu1 = titre;
        }

        public TitreConnu(int id, String nomTitre)
        {
            this.idMusicien = id;
            this.titreConnu1 = nomTitre;
        }
    }
}
