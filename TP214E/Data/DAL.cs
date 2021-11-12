using System;
using System.Windows;
using MongoDB.Bson;
using MongoDB.Driver;

namespace TP214E.Data
{
    public class DAL : IDAL
    {
        public MongoClient mongoDBClient;
        private const string CHAINE_CONNEXION_MONGODB = "mongodb://localhost:27017/TP2DB";
        protected const string MESSAGE_ERR_CONNEXION_MONGODB = "Impossible de se connecter à la base de données ";
        protected const string ERREUR = "Erreur";
        protected const string NOM_BD = "TP2DB";

        public DAL()
        {
            mongoDBClient = OuvrirConnexion();
        }

        private MongoClient OuvrirConnexion()
        {
            MongoClient dbClient = null;
            try
            {
                dbClient = new MongoClient(CHAINE_CONNEXION_MONGODB);
            }
            catch (Exception ex)
            {
                MessageBox.Show(MESSAGE_ERR_CONNEXION_MONGODB + ex.Message, ERREUR, MessageBoxButton.OK, MessageBoxImage.Error);
            }
            return dbClient;
        }
    }
}
