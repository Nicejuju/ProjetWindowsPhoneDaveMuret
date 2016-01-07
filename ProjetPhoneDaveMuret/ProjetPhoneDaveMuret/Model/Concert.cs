using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetPhoneDaveMuret.Model
{
    class Concert
    {
        private Musicien musicienConcert;

        public Musicien MusicienConcert
        {
            get { return musicienConcert; }
            set { musicienConcert = value; }
        }

        private String concertAvenir1;

        public String ConcertAvenir1
        {
            get { return concertAvenir1; }
            set { concertAvenir1 = value; }
        }

        private int idMusicien;

        public int IdMusicien
        {
            get { return idMusicien; }
            set { idMusicien = value; }
        }


        public Concert (String concertAVenir)
        {
            this.concertAvenir1 = concertAVenir;
        }

        public Concert(int id, String concertAVenir)
        {
            this.idMusicien = id;
            this.concertAvenir1 = concertAVenir;
        }
    }
}
