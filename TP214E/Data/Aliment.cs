using MongoDB.Bson;
using System;

namespace TP214E.Data
{
    public class Aliment : IAliment
    {
        public Aliment()
        {

        }

        public ObjectId _id { get; set; }
        public string Nom { get; set; }
        public int Quantite { get; set; }
        public string Unite { get; set; }
        public DateTime ExpireLe { get; set; }
    }
}
