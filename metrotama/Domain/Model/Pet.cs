﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace metrotama.Domain.Model
{
    class Pet
    {
        [PrimaryKey, AutoIncrement]
        public int PetId { get; set; }
        public int UserId { get; set; }
        public int PetStageId { get; set; }
        public int FavoriteGameObjectId { get; set; }
        public int DislikeGameObjectId { get; set; }
        public string Name { get; set; }
        public int Health { get; set; }
        public int Hygene { get; set; }
        public int Hunger { get; set; }
        public int Energy { get; set; }
        public int Discipline { get; set; }
        public int Mood { get; set; }
        public int Gender { get; set; }
        public int Age { get; set; }
        public DateTime LastUpdated { get; set; }
    }
}
