using System;
using System.Collections.Generic;
using System.Linq;

namespace ElatkozottBurok
{
    public class Iroda
    {
        public List<Fejleszto> Fejlesztok { get; } = new List<Fejleszto>();

        public Automata AutomataGep { get; } = new Automata();

        public void MunkanapSzimulacio(int orakSzama)
        {
            for (int ora = 0; ora < orakSzama; ora++)
            {
                foreach (Fejleszto fejleszto in Fejlesztok)
                {
                    fejleszto.Dolgozik();

                    if (fejleszto.Koffeinszint < 20 || fejleszto.StresszSzint > 70)
                    {
                        VasarlasEsFogyasztas(fejleszto);
                    }
                }

                KiirOraVegeAllapot(ora + 1);
            }
        }

        public void NapiJelentes()
        {
            Console.WriteLine("\n--- Napi jelentés ---");
            Console.WriteLine("Legfeszültebb fejlesztők:");

            foreach (Fejleszto fejleszto in Fejlesztok
                         .OrderByDescending(fejleszto => fejleszto.StresszSzint)
                         .Take(3))
            {
                Console.WriteLine($"{fejleszto.Nev}: stressz {fejleszto.StresszSzint}, " +
                                  $"koffein {fejleszto.Koffeinszint}, kiégett: {fejleszto.Kiegve}");
            }

            int kiegtekSzama = Fejlesztok.Count(fejleszto => fejleszto.Kiegve);
            Console.WriteLine($"Kiégett vagy túladagolta magát: {kiegtekSzama} fő");
            Console.WriteLine($"Automata napi bevétele: {AutomataGep.KeszpenzKassza} Ft");
            Console.WriteLine($"Maradék készlet: {AutomataGep.Keszlet.Count} termék");
        }

        private void VasarlasEsFogyasztas(Fejleszto fejleszto)
        {
            if (AutomataGep.Elakadva)
            {
                AutomataGep.JavitasRugassal();
                if (AutomataGep.Elakadva)
                {
                    return;
                }
            }

            Nassolnivalo? termek = AutomataGep.Keszlet
                .FirstOrDefault(elem => elem.Nev == fejleszto.KedvencSnack);

            termek ??= AutomataGep.Keszlet
                .OrderBy(elem => elem.Ar)
                .FirstOrDefault();

            if (termek != null)
            {
                Nassolnivalo? megvasaroltTermek = AutomataGep.Vasarlas(termek.Nev, fejleszto);
                if (megvasaroltTermek != null)
                {
                    fejleszto.Fogyaszt(megvasaroltTermek);
                }
            }
        }

        private void KiirOraVegeAllapot(int ora)
        {
            Console.WriteLine($"\n--- {ora}. óra vége ---");
            foreach (Fejleszto fejleszto in Fejlesztok)
            {
                ConsoleColor elozoSzin = Console.ForegroundColor;
                Console.ForegroundColor = fejleszto.Kiegve ? ConsoleColor.Red : ConsoleColor.Green;
                Console.WriteLine($"{fejleszto.Nev}: koffein {fejleszto.Koffeinszint}, " +
                                  $"stressz {fejleszto.StresszSzint}, kiégett: {fejleszto.Kiegve}");
                Console.ForegroundColor = elozoSzin;
            }
        }
    }
}