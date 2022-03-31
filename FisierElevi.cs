using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using LibrarieClase;

namespace StocareDate
{
    public class FisierElevi //In clasa aceasta se vor stoca numele elevilor ce va fi introdus de la tastatura la inceputul quiz-ului,
                             //iar la final li se va stoca si scorul obtinut
    {
        private string numeFisier;
        private const int NR_MAX_ELEVI = 100;
        public FisierElevi(string numeFisier)
        {
            this.numeFisier = numeFisier;
            // se incearca deschiderea fisierului in modul OpenOrCreate
            // astfel incat sa fie creat daca nu exista
            Stream streamFisierText = File.Open(numeFisier, FileMode.OpenOrCreate);
            streamFisierText.Close();
        }

        public void AddElev(Elev elev)
        {
            // instructiunea 'using' va apela la final streamWriterFisierText.Close();
            // al doilea parametru setat la 'true' al constructorului StreamWriter indica
            // modul 'append' de deschidere al fisierului
            using (StreamWriter streamWriterFisierText = new StreamWriter(numeFisier, true))
            {
                streamWriterFisierText.WriteLine(elev.ConversieLaSir_PentruFisier());
            }
        }
        public Elev[] GetElevi(out int nrElevi)
        {
            Elev[] elevi = new Elev[NR_MAX_ELEVI];
            // instructiunea 'using' va apela streamReader.Close()
            using (StreamReader streamReader = new StreamReader(numeFisier))
            {
                string linieFisier;
                nrElevi = 0;

                // citeste cate o linie si creaza un obiect de tip Elev
                // pe baza datelor din linia citita
                while ((linieFisier = streamReader.ReadLine()) != null)
                {
                    elevi[nrElevi++] = new Elev(linieFisier);
                }
            }
            return elevi;
        }
    }
}
