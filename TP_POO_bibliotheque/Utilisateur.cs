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

        public virtual int MaxNbEmprunt { get; }
        public virtual string typeutilisateur { get; }


        public utilisateur(string unnom, string unprenom) 
        {
            idutilisateur = ++compteurId;
            Nom = unnom;
            prenom= unprenom;
        }
    }
    public class UtilisateurBasique : utilisateur
    {
        public override int MaxNbEmprunt => 3;
        public override string typeutilisateur => "Basique";


        public UtilisateurBasique(string unNom, string unPrenom) : base(unNom, unPrenom)
        {
        }

    }

    public class UtilisateurPremium : utilisateur
    {
        public override int MaxNbEmprunt => 5;
        public override string typeutilisateur => "Premium";


        public UtilisateurPremium(string unNom, string unPrenom) : base(unNom, unPrenom)
        {
        }
    }

}
