using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace metrotama.Domain.Model
{
    class GameObject
    {
        [PrimaryKey, AutoIncrement]
        public int GameObjectId { get; set; }
        public string ObjectName { get; set; }
        public string Description { get; set; }
        public int HealthEffect { get; set; }
        public int HungerEffect { get; set; }
        public int HygeneEffect { get; set; }
        public int DisciplineEffect { get; set; }
        public int MoodEffect { get; set; }
        public int EnergyEffect { get; set; }
        public int Price { get; set; }
    }
}
