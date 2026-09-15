using System;

namespace ElatkozottBurok
{
    public class Fejleszto
    {
        private string nev;
        public enum Munkakor { Junior, Senior, DevOpsVarazslo };
        private Munkakor munkakor;
        private int penz;
        private int koffeinszint;
        private int stresszSzint;
        private bool kiegve;
        private string kedvencSnack;

        public Fejleszto(string nev, Munkakor munkakor, int penz, string kedvencSnack, int koffeinszint, int stresszSzint)
        {
            this.Nev = nev;
            this.Munkakork = munkakor;
            this.Penz = penz;
            this.kedvencSnack = kedvencSnack;
            this.Koffeinszint = koffeinszint;
            this.StresszSzint = stresszSzint;
            this.kiegve = false;
        }

        public string Nev
        {
            get => nev;
            set => nev = value;
        }

        public Munkakor Munkakork
        {
            get => munkakor;
            set => munkakor = value;
        }

        public int Penz
        {
            get => penz;
            set
            {
                if (penz < 0)
                {
                    penz = 0;
                }
                else
                {
                    penz = value;
                }
            }
        }

        public int Koffeinszint
        {
            get => koffeinszint;
            set
            {
                if (koffeinszint < 0)
                {
                    koffeinszint = 0;
                }
                else if (koffeinszint > 100)
                {
                    koffeinszint = 100;
                    kiegve = true;
                }
                else
                {
                    koffeinszint = value;
                }
            }
        }

        public int StresszSzint
        {
            get => stresszSzint;
            set
            {
                if (stresszSzint < 0)
                {
                    stresszSzint = 0;
                }
                else if (stresszSzint > 100)
                {
                    stresszSzint = 100;
                    kiegve = true;
                }
                else
                {
                    stresszSzint = value;
                }
            }
        }
    }
}