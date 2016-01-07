using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetPhoneDaveMuret.Model
{
    class Administrateur
    {
        private int idAdmin;

        public int IdAdmin
        {
            get { return idAdmin; }
            set { idAdmin = value; }
        }

        private String nom;

        public String Nom
        {
            get { return nom; }
            set { nom = value; }
        }

        private String prenom;

        public String Prenom
        {
            get { return prenom; }
            set { prenom = value; }
        }

        private String nomUtilisateur;

        public String NomUtilisateur
        {
            get { return nomUtilisateur; }
            set { nomUtilisateur = value; }
        }

        private String motDePasse;

        public String MotDePasse
        {
            get { return motDePasse; }
            set { motDePasse = value; }
        }
    }
}
