using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace TP214E.Data
{
    public class Plat
    {
        public Plat()
        {

        }

        public ObjectId _id { get; set; }
        public string Nom { get; set; }
        public List<Aliment> Recette { get; set; }
        public double Prix { get; set; }
    }
}
