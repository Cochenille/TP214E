using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson;

namespace TP214E.Data
{
    public class Commandes
    {
        public ObjectId id { get; set; }
        public List<Plat> Plats { get; set; }
        public DateTime date { get; set; }

        public float SousTotal
        {
            get
            {
                float sommeDesPrix = 0;
                Plats.ForEach(plat => sommeDesPrix+=plat.Prix);
                return sommeDesPrix;
            }
        }

        public float Taxe
        {
            get { return SousTotal*(float)0.15; }
        }

        public float Total
        {
            get { return SousTotal+Taxe; }
        }
    }
}
