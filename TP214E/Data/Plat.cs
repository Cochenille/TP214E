using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson;

namespace TP214E.Data
{
    public class Plat
    {
        public ObjectId Id { get; set; }
        public string Nom { get; set; }
        public List<Aliment> Aliments { get; set; }
        public float Prix { get; set; }

    }
}
