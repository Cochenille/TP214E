using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace TP214E.Data
{
    public class DALCommandes: DAL
    {
        private IMongoCollection<Commande> commandes;
        private IMongoCollection<Plat> plats;
        private const string NOM_COLLECTION_COMMANDES = "Commandes";
        private const string NOM_COLLECTION_PLATS = "Plats";

        public IMongoCollection<Commande> Commandes()
        {
            try
            {
                IMongoDatabase db = mongoDBClient.GetDatabase(NOM_BD);
                commandes = db.GetCollection<Commande>(NOM_COLLECTION_COMMANDES);
            }
            catch (Exception ex)
            {
                MessageBox.Show(MESSAGE_ERR_CONNEXION_MONGODB + ex.Message, ERREUR, MessageBoxButton.OK, MessageBoxImage.Error);
            }
            return commandes;
        }


        public async void AjouterCommande(Commande commande)
        {
            await commandes.InsertOneAsync(commande);
        }

        public IMongoCollection<Plat> Plats()
        {
            try
            {
                IMongoDatabase db = mongoDBClient.GetDatabase(NOM_BD);
                plats = db.GetCollection<Plat>(NOM_COLLECTION_PLATS);
            }
            catch (Exception ex)
            {
                MessageBox.Show(MESSAGE_ERR_CONNEXION_MONGODB + ex.Message, ERREUR, MessageBoxButton.OK, MessageBoxImage.Error);
            }
            return plats;
        }
    }
}
