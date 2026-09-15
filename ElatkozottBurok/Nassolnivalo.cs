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
            this.KoffeinLoket = koffeinLoket;
            this.StresszOldas = stresszOldas;
            this.Ar = ar;
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
            get => koffeinLoket;
            set { if (koffeinLoket < 0) { 
                koffeinLoket = 0; 
                } else if (koffeinLoket > 50) { 
                    koffeinLoket = 50; 
                } else { koffeinLoket = value; } }
        }

        public int StresszOldas
        {
            get => stresszOldas;
            set { if (stresszOldas < 0) { 
                stresszOldas = 0; 
                } else if (stresszOldas > 30) { 
                    stresszOldas = 30; 
                } else { stresszOldas = value; } }
        }

        public int Ar
        {
            get => ar;
            set { if (ar < 0) { 
                ar = 100; 
                } else { ar = value; } }
        }
    }
}