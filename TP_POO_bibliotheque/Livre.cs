using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace TP_POO_bibliotheque
{
    public class Livre
    {
        public int ISBN { get; set; }
        public string titre { get; set; }
        public string auteur { get; set; }
        public string date { get; set; }
        public bool emprunte { get; set; } = false;//false si disponible true si déjà empruntée

        public Livre(int unISBN, string untitre, string unauteur, string unedate)
        {
            ISBN = unISBN;
            titre = untitre;
            auteur = unauteur;
            date = unedate;
        }
    }
}
