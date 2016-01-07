using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ProjetPhoneDaveMuret.Model
{
    class Photo
    {
        private int idPhoto;

        public int IdPhoto
        {
            get { return idPhoto; }
            set { idPhoto = value; }
        }

        private String url;        

        public Photo(string url)
        {
            this.url = url;
        }

        public String Url
        {
            get { return url; }
            set { url = value; }
        }

        public Photo(int id, String url)            
        {
            this.idPhoto = id;
            this.url = url;
        }  
    }
}
