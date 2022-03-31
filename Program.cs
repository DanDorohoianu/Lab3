using System;
using System.Configuration;
using LibrarieClase;
using StocareDate;

namespace ProiectPIU
{
    class Program
    {
        static void Main(string[] args)
        {
            string numeFisier = ConfigurationManager.AppSettings["NumeFisier"];
            FisierElevi adminElevi = new FisierElevi(numeFisier);
            Elev elevNou = new Elev();
            int nrElevi = 0;
            // acest apel ajuta la obtinerea numarului de elevi inca de la inceputul executiei
            // astfel incat o eventuala adaugare sa atribuie un IdElev corect noului elev
            adminElevi.GetElevi(out nrElevi);
            string optiune;
            do
            {
                Console.WriteLine("C. Citire elev de la tastatura");
                Console.WriteLine("S. Salvare elev in fisier");
                Console.WriteLine("A. Afisare elevi din fisier");
                Console.WriteLine("X. Inchidere program");
                Console.WriteLine("Alegeti o optiune");
                optiune = Console.ReadLine();
                switch (optiune.ToUpper())
                {
                    case "C":
                        elevNou = CitireEleviTastatura();
                        break;
                    case "A":
                        Elev[] elevi = adminElevi.GetElevi(out nrElevi);
                        AfisareElevi(elevi, nrElevi);
                        break;
                    case "S":
                        int idElevi = nrElevi + 1;
                        elevNou.SetIdElev(idElevi);
                        //adaugare elev in fisier
                        adminElevi.AddElev(elevNou);
                        nrElevi = nrElevi + 1;
                        break;
                    case "X":
                        return;
                    default:
                        Console.WriteLine("Optiune inexistenta");
                        break;
                }
            } while (optiune.ToUpper() != "X");

            Console.ReadKey();

        }
        
        public static void AfisareElev(Elev elev)
        {
            string infoElev = string.Format("Elevul cu id-ul #{0} are numele: {1} {2} este in clasa {3} la profilul {4}",
                   elev.GetIdElev(),
                   elev.GetNume() ?? " NECUNOSCUT ",
                   elev.GetPrenume() ?? " NECUNOSCUT ",
                   elev.GetClasa() ?? "NECUNOSCUT",
                   elev.GetProfil() ?? "NECUNOSCUT");

            Console.WriteLine(infoElev);
        }

        public static void AfisareElevi(Elev[] elevi, int nrElevi)
        {
            Console.WriteLine("Elevii sunt:");
            for (int contor = 0; contor < nrElevi; contor++)
            {
                AfisareElev(elevi[contor]);
            }
        }
        public static Elev CitireEleviTastatura()
        {
            Console.WriteLine("Introduceti numele");
            string nume = Console.ReadLine();

            Console.WriteLine("Introduceti prenumele");
            string prenume = Console.ReadLine();

            Console.WriteLine("Introduceti clasa");
            string clasa = Console.ReadLine();

            Console.WriteLine("Introduceti profilul");
            string profil = Console.ReadLine();

            Elev elev = new Elev(0, nume, prenume, clasa, profil);

            return elev;
        }
    }
}
