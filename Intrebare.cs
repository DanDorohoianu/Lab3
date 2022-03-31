using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarieClase
{
    public class Intrebare // Clasa Intrebare va contine numarul intrebarii, textul intrebarii, poze, daca sunt necesare
    {
        static int nrIntrebare=1; //La test se vor da 9 intrebari(+1p din oficiu), iar in total vor exista ~20 intrebari
        int idIntrebare;
        string textIntrebare;

        public Intrebare(int nrIntrebare, string TextIntrebare) //Constructor explicit
        {
            idIntrebare = nrIntrebare++;
            textIntrebare = TextIntrebare;
        }
        public int GetidIntrebare() //Get pentru nrIntrebare
        {
            return idIntrebare;
        }
    }
}