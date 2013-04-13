using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace metrotama.Domain.Model
{
    class GraveYard
    {
        [PrimaryKey, AutoIncrement]
        public int GraveYardId { get; set; }
        public int PetId { get; set; }
        public DateTime TimeDied { get; set; }
        public string LastThought { get; set; }
    }
}
