using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Resto.Models
{
    public interface IDal : IDisposable
    {
        List<Resto> ObtientTousLesRestaurants();
        void CreerRestaurant(string nom, string telephone);
        void ModifierRestaurant(int id, string nom, string telephone);

        bool RestaurantExiste(string nomRestaurant);
        Utilisateur ObtenirUtilisateur(int id);
        Utilisateur ObtenirUtilisateur(string name);
        int AjouterUtilisateur(string nom, string motDePasse);
        Utilisateur Authentifier(string nom, string motDePasse);
        bool ADejaVote(int idSondage, string idstr);
        int CreerUnSondage();
        void AjouterVote(int idSondage, int v, int idUtilisateur);
        List<Resultats> ObtenirLesResultats(int idSondage);
    }
}