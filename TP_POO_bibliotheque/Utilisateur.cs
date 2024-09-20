using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_POO_bibliotheque
{
    public class utilisateur
    {
        private static int compteurId = 0;

        public int idutilisateur { get; set; }
        public string Nom { get; set; }
        public string prenom { get; set; }
        public List<Livre> Livresempruntee { get; set; } = new List<Livre>();

        public utilisateur(string unnom, string unprenom) 
        {
            idutilisateur = ++compteurId;
            Nom = unnom;
            prenom= unprenom;
        }
    }

}
