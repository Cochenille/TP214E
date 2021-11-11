﻿using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace TP214E.Data
{
    public class Commande
    {
        public Commande()
        {
        }

        public ObjectId _id { get; set; }
        public List<string> PlatsCommandes { get; set; }
        public string TypePaiement { get; set; }

    }
}
