using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Resto.Models
{

    public class Dal : IDal
    {
        private BddContext bdd;

        public Dal()
        {
            bdd = new BddContext();

        }

        public bool ADejaVote(int v1, string v2)
        {
            int id;
            if (int.TryParse(v2, out id))
            {
                Sondage sondage = bdd.Sondages.First(s => s.Id == v1);
                if (sondage.Votes == null)
                    return false;
                return sondage.Votes.Any(v => v.Utilisateur != null && v.Utilisateur.Id == id);
            }
            return false;
        }

        public int AjouterUtilisateur(string nom, string motDePasse)
        {
            var encodeMdp = new Encodage().EncodeMD5(motDePasse);
            var user = bdd.Utilisateurs.Add(new Utilisateur
            {
                Prenom = nom,
                Password = encodeMdp

            });
            bdd.SaveChanges();
            if (user != null)
                return user.Id;
            else return 0;
        }

        public void AjouterVote(int idSondage, int idResto, int idUtilisateur)
        {
            Vote vote = new Vote
            {
                Resto = bdd.Restos.First(r => r.Id == idResto),
                Utilisateur = bdd.Utilisateurs.First(u => u.Id == idUtilisateur)
            };
            Sondage sondage = bdd.Sondages.First(s => s.Id == idSondage);
            if (sondage.Votes == null)
                sondage.Votes = new List<Vote>();
            sondage.Votes.Add(vote);
            bdd.SaveChanges();
        }

        public Utilisateur Authentifier(string v1, string v2)
        {
            var decode = new Encodage().EncodeMD5(v2);
            var user = bdd.Utilisateurs.FirstOrDefault(o => o.Prenom == v1 && o.Password == decode);
            return user;
        }

        public void CreerRestaurant(string nom, string telephone)
        {
            bdd.Restos.Add(new Resto { Nom = nom, Telephone = telephone });
            bdd.SaveChanges();
        }

        public int CreerUnSondage()
        {
            Sondage sondage = new Sondage { Date = DateTime.Now };
            bdd.Sondages.Add(sondage);
            bdd.SaveChanges();
            return sondage.Id;
        }

        public void Dispose()
        {
            bdd.Dispose();
        }

        public void ModifierRestaurant(int id, string nom, string telephone)
        {
            Resto resto = bdd.Restos.FirstOrDefault(o => o.Id == id);

            if(resto!=  null)
            {
                resto.Nom = nom;
                resto.Telephone = telephone;
                bdd.SaveChanges();
            }
        }

        public List<Resultats> ObtenirLesResultats(int idSondage)
        {
            List<Resto> restaurants = ObtientTousLesRestaurants();
            List<Resultats> resultats = new List<Resultats>();
            Sondage sondage = bdd.Sondages.First(s => s.Id == idSondage);
            foreach (IGrouping<int, Vote> grouping in sondage.Votes.GroupBy(v => v.Resto.Id))
            {
                int idRestaurant = grouping.Key;
                Resto resto = restaurants.First(r => r.Id == idRestaurant);
                int nombreDeVotes = grouping.Count();
                resultats.Add(new Resultats { Nom = resto.Nom, Telephone = resto.Telephone, NombreDeVotes = nombreDeVotes });
            }
            return resultats;
        }

        public Utilisateur ObtenirUtilisateur(string name)
        {
            
            int result = 0;
            Int32.TryParse(name, out result);
            if (result == 0)
                return null;
            return bdd.Utilisateurs.FirstOrDefault(o => o.Id == result);
        }

        public Utilisateur ObtenirUtilisateur(int id)
        {
            return bdd.Utilisateurs.FirstOrDefault(o => o.Id == id);
        }

        public List<Resto> ObtientTousLesRestaurants()
        {
            return bdd.Restos.ToList();
        }

        public bool RestaurantExiste(string nomRestaurant)
        {
            var isExist = bdd.Restos.FirstOrDefault(o => o.Nom == nomRestaurant);
            if (isExist != null)
                return true;
            return false;
        }

        
    }
}