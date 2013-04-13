using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace metrotama.Domain.Model
{
    class PetStage
    {
        [PrimaryKey, AutoIncrement]
        public int PetStageId { get; set; }
        public int AgeFrom { get; set; }
        public int AgeTo { get; set; }
        public int HealthInterval { get; set; }
        public int HealthCoeff { get; set; }
        public int HungerInterval {get; set; }
        public int HungerCoeff { get; set; }
        public int HygeneInterval { get; set; }
        public int HygeneCoeff { get; set; }
        public int DisciplineInterval { get; set; }
        public int DisciplineCoeff { get; set; }
        public int MoodInterval { get; set; }
        public int MoodCoeff { get; set; }
        public int EnergyInterval { get; set; }
        public int EnergyCoeff { get; set; }
    }
}
