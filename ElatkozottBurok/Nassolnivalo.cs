using System;

namespace ElatkozottBurok
{
    public class Nassolnivalo
    {
        private string nev;
        private int koffeinLoket;
        private int stresszOldas;
        private int ar;

        public Nassolnivalo(string nev, int koffeinLoket, int stresszOldas, int ar)
        {
            this.Nev = nev;
            this.koffeinLoket = koffeinLoket;
            this.stresszOldas = stresszOldas;
            this.ar = ar;
        }

        public string Nev
        {
            get => nev;
            set { if (nev== "" || nev == null)
                {
                    nev = "ismeretlen nassolnivalo";
                } else { nev = value; }}
        }

        public int KoffeinLoket
        {
            get { return koffeinLoket; }
            set { koffeinLoket = value; }
        }

        public int StresszOldas
        {
            get { return stresszOldas; }
            set { stresszOldas = value; }
        }

        public int Ar
        {
            get { return ar; }
            set { ar = value; }
        }
    }
}