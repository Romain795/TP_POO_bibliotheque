using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_POO_bibliotheque
{
    public class Emprunt
    {
        private static int compteurId = 0;
        public int idemprunt {  get; set; }
        public Livre livre { get; set; }
        public utilisateur utilisateur { get; set; }

        public Emprunt(Livre unlivre, utilisateur unuser)
        {
            idemprunt = ++compteurId;
            livre = unlivre;
            utilisateur = unuser;
        }
    }
}
