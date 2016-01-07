using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetPhoneDaveMuret.Model
{
    class Categorie
    {
        private int idCategorie;       

        public int IdCategorie
        {
            get { return idCategorie; }
            set { idCategorie = value; }
        }

        private String nom;

        public String Nom
        {
            get { return nom; }
            set { nom = value; }
        }

        public Categorie (int id,String n)
        {
            idCategorie = id;
            nom = n;
        }

        //Pour ne ramener que le nom de la bd 
        public Categorie(String n)
        {
            nom = n;
        }
           
    }
}
