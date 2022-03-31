using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarieClase
{
    public class Elev // Clasa Elev contine date despre participantii la quiz: nume, clasa, profil,
    {
        private const int ID = 0;
        private const int NUME = 1;
        private const int PRENUME = 2;
        private const int CLASA = 3;
        private const int PROFIL = 4;
        private const char SEPARATOR_PRINCIPAL_FISIER = ';';

        int idElev;
        string nume;
        string prenume;
        string clasa;
        string profil;
        private string linieFisier;

        public Elev()   //Constructor implicit
        {
            nume=prenume=clasa=profil=string.Empty;
        }
        public Elev(int idElev, string nume, string prenume, string clasa, string profil)  //Construcor explicit
        {
            this.idElev = idElev;
            this.nume = nume;
            this.prenume = prenume;
            this.clasa = clasa;
            this.profil = profil;
        }

        public Elev(string linieFisier)
        {
            var dateFisier = linieFisier.Split(SEPARATOR_PRINCIPAL_FISIER);

            //ordinea de preluare a campurilor este data de ordinea in care au fost scrise in fisier prin apelul implicit al metodei ConversieLaSir_PentruFisier()
            idElev = Convert.ToInt32(dateFisier[ID]);
            nume = dateFisier[NUME];
            prenume = dateFisier[PRENUME];
            clasa = dateFisier[CLASA];
            profil = dateFisier[PROFIL];
        }

        public string ConversieLaSir_PentruFisier()
        {
            string obiectElevPentruFisier = string.Format("{1}{0}{2}{0}{3}{0}{4}{0}{5}{0}",
                SEPARATOR_PRINCIPAL_FISIER,
                idElev.ToString(),
                (nume ?? " NECUNOSCUT "),
                (prenume ?? " NECUNOSCUT "),
                (clasa ?? " NECUNOSCUT "),
                (profil ?? " NECUNOSCUT "));
            return obiectElevPentruFisier;
        }
        public int GetIdElev()
        {
            return idElev;
        }
        public string GetNume()
        {
            return nume;
        }
        public string GetPrenume()
        {
            return prenume;
        }
        public string GetClasa()
        {
            return clasa;
        }
        public string GetProfil()
        {
            return profil;
        }
        public void SetIdElev(int idElev)
        {
            this.idElev = idElev;
        }
    }
}

