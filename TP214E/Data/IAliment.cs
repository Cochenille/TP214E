using MongoDB.Bson;
using System;

namespace TP214E.Data
{
    public interface IAliment
    {
        ObjectId _id { get; set; }
        DateTime ExpireLe { get; set; }
        string Nom { get; set; }
        int Quantite { get; set; }
        string Unite { get; set; }
    }
}