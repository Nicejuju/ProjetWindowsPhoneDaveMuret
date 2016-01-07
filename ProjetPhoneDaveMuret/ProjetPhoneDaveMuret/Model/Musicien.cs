using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetPhoneDaveMuret.Model
{
    class Musicien
    {
        private int idMusicien;

        public int IdMusicien
        {
            get { return idMusicien; }
            set { idMusicien = value; }
        }

        private int idPhoto;

        public int IdPhoto
        {
            get { return idPhoto; }
            set { idPhoto = value; }
        }

        private string nom;

        public string Nom
        {
            get { return nom; }
            set {nom = value; }
        }

        private string prenom;

        public string Prenom
        {
            get { return prenom; }
            set { prenom = value; }
        }

        private string dateNaissance;

        public string DateNaissance
        {
            get { return dateNaissance; }
            set { dateNaissance = value; }
        }

        private string biographie;

        public string Biographie
        {
            get { return biographie; }
            set { biographie = value; }
        }

        private int idInstrument;

        public int IdInstrument
        {
            get { return idInstrument; }
            set { idInstrument = value; }
        }

        public Musicien (int id, string nom, string prenom)
        {
            this.idMusicien = id;
            this.nom = nom;
            this.prenom = prenom;
        }

        public Musicien(int id,int photoMusicien, string nom, string prenom,string bio,int instr,string dateNais)
        {
            this.idMusicien = id;
            this.idPhoto = photoMusicien;
            this.nom = nom;
            this.prenom = prenom;            
            this.biographie = bio;
            this.idInstrument = instr;
            this.dateNaissance = dateNais;
        }


        public Musicien(string nom)
        {
            this.nom = nom;
        }

        public Musicien()
        {

        }       
    }
}
