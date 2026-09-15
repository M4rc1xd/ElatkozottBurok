using System;

namespace ElatkozottBurok
{
    public class Fejleszto
    {
        private string nev = string.Empty;
        private Munkakor munkakor;
        private int penz;
        private int koffeinszint;
        private int stresszSzint;
        private bool kiegve;
        private string kedvencSnack = string.Empty;

        public Fejleszto(string nev, Munkakor munkakor, int penz, string kedvencSnack, int koffeinszint, int stresszSzint)
        {
            this.Nev = nev;
            this.Munkakor = munkakor;
            this.Penz = penz;
            this.KedvencSnack = kedvencSnack;
            this.Koffeinszint = koffeinszint;
            this.StresszSzint = stresszSzint;
        }

        public string Nev
        {
            get => nev;
            set => nev = value;
        }

        public Munkakor Munkakor
        {
            get => munkakor;
            set => munkakor = value;
        }

        public string KedvencSnack
        {
            get => kedvencSnack;
            set => kedvencSnack = value;
        }

        public bool Kiegve => kiegve;

        public int Penz
        {
            get => penz;
            set
            {
                if (value < 0)
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
                if (value < 0)
                {
                    koffeinszint = 0;
                }
                else if (value >= 100)
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
                if (value < 0)
                {
                    stresszSzint = 0;
                }
                else if (value >= 100)
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

        public void Dolgozik()
        {
            if (Kiegve)
            {
                Console.WriteLine($"{Nev} kiégett, ezért már nem tud dolgozni.");
                return;
            }

            switch (Munkakor)
            {
                case Munkakor.Junior:
                    Koffeinszint -= 25;
                    StresszSzint += 20;
                    break;
                case Munkakor.Senior:
                    Koffeinszint -= 15;
                    StresszSzint += 10;
                    break;
                case Munkakor.DevOpsVarazslo:
                    Koffeinszint -= 10;
                    StresszSzint += 25;
                    break;
            }

            if (Koffeinszint < 15)
            {
                Console.WriteLine($"{Nev} agya lefagyott (BlueScreen), koffeinre van szüksége!");
            }
        }

        public void Fogyaszt(Nassolnivalo elem)
        {
            Koffeinszint += elem.KoffeinLoket;
            StresszSzint -= elem.StresszOldas * (elem.Nev == KedvencSnack ? 2 : 1);

            if (elem.Nev == KedvencSnack)
            {
                Koffeinszint += 5;
            }
        }
    }
}