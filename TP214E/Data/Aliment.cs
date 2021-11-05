﻿using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace TP214E.Data
{
    public class Aliment
    {
        // Pour tester
        public Aliment()
        {

        }

        public ObjectId Id { get; set; }
        public string Nom { get; set; }
        public int Quantite { get; set; }
        public string Unite { get; set; }
        public DateTime ExpireLe { get; set; }
    }
}
