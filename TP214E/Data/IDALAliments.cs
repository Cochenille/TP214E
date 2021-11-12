using MongoDB.Bson;
using MongoDB.Driver;

namespace TP214E.Data
{
    interface IDALAliments
    {
        void AjouterAliment(Aliment aliment);
        IMongoCollection<Aliment> Aliments();
        void ModifierAliment(Aliment aliment, ObjectId idAliment);
        void RetirerAliment(Aliment aliment);
    }
}