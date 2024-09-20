using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_POO_bibliotheque;

//rajouter la sécurité sur le code (on ne peut pas supprimer un utilisateur qui à une réservation, et autres sécurité)
partial class Program
{
    static void Main()
    {
        bool continuer = true;

        Bibliotheque mabibliotheque = new Bibliotheque();
        while (continuer)
        {
        //Console.Clear(); //à remettre après les tests
        

        Console.WriteLine("Bienvenue à la bibliothèque");
        Console.WriteLine("Entrer le numéro de l'action que vous voulez effectuer :");
        Console.WriteLine("\ta - Ajouter un livre");
        Console.WriteLine("\ts - Supprimer un livre");
        Console.WriteLine("\tm - Voir la liste des livres disponible");
        Console.WriteLine("\tu - Ajouter un utilisateur");
        Console.WriteLine("\td - Supprimer un utilisateur");
        Console.WriteLine("\tl - Voir la liste des utilisateurs");
        Console.WriteLine("\te - Emprunter un livre");
        Console.WriteLine("\tr - Rendre un livre");
        Console.WriteLine("\tf - Voir la liste des livres empruntés");
        Console.Write("Votre choix ? : ");

        switch (Console.ReadLine())
        {
            case "a":
                Console.WriteLine("Pouvez vous entrez l'ISBN de ce livre :");
                int ISBN = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Pouvez vous entrez le titre de ce livre :");
                string titre = Convert.ToString(Console.ReadLine());
                Console.WriteLine("Pouvez vous entrez l'auteur de ce livre :");
                string auteur = Convert.ToString(Console.ReadLine());
                Console.WriteLine("Pouvez vous entrez la date de sortie de ce livre sous le format JJ/MM/AAAA :");
                string date = Convert.ToString(Console.ReadLine());
                //on ajoute ensuite avec le livre avec la méthode ajouter livre de la classe bibliotheque
                mabibliotheque.ajouterlivre(ISBN, titre, auteur, date);
                break;
            case "s":
                Console.WriteLine("Entrer le numéro ISBN du livre :");
                int ISBNdel = Convert.ToInt32(Console.ReadLine());
                //on supprime le livre grâce à la méthode supprimer livre de la classe bibliothèque grâce à son ID
                mabibliotheque.supprimerlivre(ISBNdel);
                break;
            case "m":
                Console.WriteLine("Voici la liste des livres disponible :");
                //On va faire une boucle qui récupère les livres de la méthode listeslivredispo  et affiche les ISBN, titre et auteur de chaque livre
                foreach(var unlivre in mabibliotheque.listelivresdispo())
                {
                    Console.WriteLine($"-{unlivre.ISBN + unlivre.auteur+ unlivre.titre + unlivre.date}");
                }//modifier ce format pour que la liste de livre soit plus visible
                break;
            case "u":
                Console.WriteLine("Pouvez vous entrez le nom de l'utilisateur :");
                string nom = Convert.ToString(Console.ReadLine());
                Console.WriteLine("Pouvez vous entrez le prénom de l'utilisateur :");
                string prenom = Convert.ToString(Console.ReadLine());
                Console.WriteLine("Choisissez le type d'utilisateur :");
                Console.WriteLine("1 - Utilisateur Basique");
                Console.WriteLine("2 - Utilisateur Premium");
                string choix = Convert.ToString(Console.ReadLine());
                bool premium = false;
                    if (choix == "1")
                    {
                        premium= false;
                    }
                    else if (choix == "2")
                    {
                        premium = true;
                    }
                    else
                    {
                        Console.WriteLine("Choix non valide. Veuillez entrer 1 ou 2.");
                    }
                    mabibliotheque.ajouterutilisateur(nom, prenom, premium);
                break;
            case "d":
                Console.WriteLine("Entrer le numéro ID de l'utilisateur :");
                int iduser = Convert.ToInt32(Console.ReadLine());
                mabibliotheque.deletutilisateur(iduser);
                break;
            case "l":
                Console.WriteLine("Voici la liste des utilisateurs :");
                foreach (var unuser in mabibliotheque.Listdesusers())
                {
                    Console.WriteLine($"-{unuser.idutilisateur + unuser.Nom + unuser.prenom + unuser.typeutilisateur}");
                }
                break;
            case "e":
                Console.WriteLine("Pouvez vous entrez l'ID de l'utilisateur :");
                int IDuseremprunt = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Pouvez vous entrez l'ISBN du livre' :");
                int ISBNemprunt = Convert.ToInt32(Console.ReadLine());
                mabibliotheque.ajouteremprunt(ISBNemprunt, IDuseremprunt);
                break;
            case "r":
                Console.WriteLine("Entrer le numéro de l'emprunt :");
                int idemprunt = Convert.ToInt32(Console.ReadLine());
                mabibliotheque.deletemprunt(idemprunt);
                break;
            case "f":
                Console.WriteLine("Voici la liste des livres empruntés :");
                foreach (var unemprunt in mabibliotheque.Listemprunt())
                {
                    Console.WriteLine($"-{unemprunt.idemprunt}{unemprunt.livre.ISBN+ unemprunt.livre.titre+unemprunt.utilisateur.Nom}");
                }
                break;
        }
        }
    }
}