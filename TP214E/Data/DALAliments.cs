using System;
using System.Windows;
using MongoDB.Bson;
using MongoDB.Driver;

namespace TP214E.Data
{
    public class DALAliments : DAL, IDALAliments
    {
        private IMongoCollection<Aliment> aliments;
        private const string NOM_COLLECTION_ALIMENTS = "Aliments";

        public IMongoCollection<Aliment> Aliments()
        {
            try
            {
                IMongoDatabase db = mongoDBClient.GetDatabase(NOM_BD);
                aliments = db.GetCollection<Aliment>(NOM_COLLECTION_ALIMENTS);
            }
            catch (Exception ex)
            {
                MessageBox.Show(MESSAGE_ERR_CONNEXION_MONGODB + ex.Message, ERREUR, MessageBoxButton.OK, MessageBoxImage.Error);
            }
            return aliments;
        }

        public async void AjouterAliment(Aliment aliment)
        {
            await aliments.InsertOneAsync(aliment);
        }

        public void RetirerAliment(Aliment aliment)
        {
            var filtre = Builders<Aliment>.Filter.Eq("_id", aliment._id);
            aliments.DeleteOne(filtre);
        }

        public void ModifierAliment(Aliment aliment, ObjectId idAliment)
        {
            var filtre = Builders<Aliment>.Filter.Eq("_id", idAliment);
            var update = Builders<Aliment>.Update
                .Set("Nom", aliment.Nom)
                .Set("Quantite", aliment.Quantite)
                .Set("ExpireLe", aliment.ExpireLe)
                .Set("Unite", aliment.Unite);
            aliments.UpdateOne(filtre, update);
        }
    }
}
