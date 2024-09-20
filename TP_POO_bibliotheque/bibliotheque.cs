using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace TP_POO_bibliotheque
{
    public class Bibliotheque
    {
        
        public List<Livre> Livres { get; set; } = new List<Livre>();
        public List<utilisateur> Utilisateurs { get; set; } = new List<utilisateur>();
        public List<Emprunt> Livresempruntee { get; set; } = new List<Emprunt>();

        public Bibliotheque()
        {
            Livre livre1 = new Livre(10002, "undeuxtrois", "Moi", "unedate");
            Livres.Add(livre1);
            utilisateur user1 = new utilisateur("voyard", "romain");
            Utilisateurs.Add(user1);
        }
        
        public void ajouterlivre(int numISBN, string nomlivre, string nomauteur, string datesortie)
        {
            foreach (var livre in Livres)
            {
                if (livre.ISBN == numISBN)
                {
                    //on ne fait rien, l'ISBN rentrer existe déjà, envoyer une notification ici aussi
                }
                else
                {
                    Livres.Add(new Livre(numISBN, nomlivre, nomauteur, datesortie));
                }
            }
        }
        public void supprimerlivre(int idlivre)
        {
            Livre Lelivre=null;
            foreach (var livre in Livres)
            {
                if(livre.ISBN==idlivre)
                {
                    Lelivre = livre;
                }
            }
            Livres.Remove(Lelivre);
        }
        public List<Livre> listelivresdispo()
        {
            List<Livre> listlivredispo = new List<Livre>();
            foreach (var livre in Livres)
            {
                if (livre.emprunte == false)
                {
                    listlivredispo.Add(livre);
                }
            }
            return listlivredispo;
        }
        public void ajouterutilisateur(string unnom, string unprenom,bool premium)
        {
            if (premium==true)
            {
                Utilisateurs.Add(new UtilisateurPremium(unnom, unprenom));
            }
            else
            {
                Utilisateurs.Add(new UtilisateurBasique(unnom, unprenom));
            }
            //Utilisateurs.Add(new utilisateur(unnom, unprenom));//inutile désormais
        }
        public void deletutilisateur(int id)
        {
            utilisateur unuser = null;
            foreach (var user in Utilisateurs)
            {
                if (user.idutilisateur == id)
                {
                    unuser = user;
                }
            }
            Utilisateurs.Remove(unuser);
        }
        public List<utilisateur> Listdesusers()
        {
            return Utilisateurs;
        }
        public void ajouteremprunt(int idlivre, int iduser)
        {
            Livre lelivre=null;
            utilisateur leuser=null;
            foreach (var unlivre in Livres)
            {
                if (unlivre.ISBN == idlivre)
                {
                    lelivre = unlivre;
                }
            }
            foreach (var unuser in Utilisateurs)
            {
                if (unuser.idutilisateur == iduser)
                {
                    leuser = unuser;
                }
            }

            bool maxemprunt = Maxemprunt(leuser);

            if(maxemprunt==true || lelivre.emprunte == true)
            {
                //on ne fait rien puisqu'il ne peut plus emprunter ou le livre est déjà emprunter, potentiellement envoyer un message d'erreur/notification
            }
            else
            {
                Livresempruntee.Add(new Emprunt(lelivre, leuser));
                lelivre.emprunte = true;
            }
            
        }
        public void deletemprunt(int idemprunt)
        {
            Emprunt unemprunt=null;
            foreach (var emprunt in Livresempruntee)
            {
                if (emprunt.idemprunt == idemprunt)
                {
                    unemprunt= emprunt;
                }
            }
            unemprunt.livre.emprunte = false;
            Livresempruntee.Remove(unemprunt);
        }
        public List<Emprunt> Listemprunt()
        {
            return Livresempruntee;
        }

        public int nbempruntuser(utilisateur unuser)
        {
            int i = 0;
            foreach(var unemprunt in Livresempruntee)
            {
                if(unemprunt.utilisateur==unuser)
                {
                    i=+1;
                }
            }
            return i;
        }
        //la méthode va elle même lancer la méthode précédente afin de connâitre le nombre de réservation de l'utilisateur
        public Boolean Maxemprunt(utilisateur unuser)
        {
            int nbempruntsuser = nbempruntuser(unuser);
            if (nbempruntsuser ==unuser.MaxNbEmprunt)//ici on récupère le nombre max de livre que peut empruntée un user en fonction de si il est membre basique ou premium
            {
                return true;
            }
            else
                return false;
        }
    }
}
