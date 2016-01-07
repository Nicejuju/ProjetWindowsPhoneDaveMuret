using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetPhoneDaveMuret.Model
{
    class ParameterToPass
    {
        private Boolean isAdmin;

        public Boolean IsAdmin
        {
            get { return isAdmin; }
            set { isAdmin = value; }
        }

        private Categorie categorie;

        public Categorie Categorie
        {
            get { return categorie; }
            set { categorie = value; }
        }

        private Instrument instrument;

        public Instrument Instrument
        {
            get { return instrument; }
            set { instrument = value; }
        }

        private Musicien musicien;

        public Musicien Musicien
        {
            get { return musicien; }
            set { musicien = value; }
        }

        public ParameterToPass (Boolean admin, Categorie cat)
        {
            this.isAdmin = admin;
            this.categorie = cat;
        }

        public ParameterToPass (Boolean admin, Instrument instr)
        {
            this.isAdmin = admin;            
            this.instrument = instr;
        }

        public ParameterToPass (Boolean admin,Musicien musicien)
        {
            this.isAdmin = admin;
            this.musicien = musicien;
        }
    }
}
