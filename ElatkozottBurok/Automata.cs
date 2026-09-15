using System;
using System.Collections.Generic;
using System.Linq;

namespace ElatkozottBurok
{
    public class Automata
    {
        public int KeszpenzKassza { get; private set; }

        public List<Nassolnivalo> Keszlet { get; } = new List<Nassolnivalo>();

        public bool Elakadva { get; set; }

        public void Feltolt(List<Nassolnivalo> ujElemek)
        {
            Keszlet.AddRange(ujElemek);
        }

        public Nassolnivalo? Vasarlas(string termekNev, Fejleszto vasarlo)
        {
            if (Elakadva)
            {
                vasarlo.StresszSzint += 15;
                Console.WriteLine("Az automata elakadt, nem ad ki terméket.");
                return null;
            }

            Nassolnivalo? termek = Keszlet.FirstOrDefault(elem => elem.Nev == termekNev);
            if (termek == null)
            {
                Console.WriteLine("A termék kifogyott.");
                return null;
            }

            if (vasarlo.Penz < termek.Ar)
            {
                Console.WriteLine("A vásárlónak nincs elég pénze.");
                return null;
            }

            vasarlo.Penz -= termek.Ar;

            if (Random.Shared.Next(1, 101) < 15)
            {
                Elakadva = true;
                vasarlo.StresszSzint += 30;
                Console.WriteLine("Az automata vásárlás közben elakadt.");
                return null;
            }

            KeszpenzKassza += termek.Ar;
            Keszlet.Remove(termek);
            return termek;
        }

        public void JavitasRugassal()
        {
            if (!Elakadva)
            {
                return;
            }

            if (Random.Shared.Next(0, 2) == 0)
            {
                Elakadva = false;
                Console.WriteLine("Az automata újra működik.");
            }
            else
            {
                Console.WriteLine("Riasztó! Az automata továbbra is elakadt.");
            }
        }
    }
}