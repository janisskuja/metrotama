using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace metrotama.Domain.Model
{
    class Highscore
    {
        [PrimaryKey, AutoIncrement]
        public int HighscoreId { get; set; }
        public int UserId { get; set; }
        public int GameObjectId { get; set; }
        public int Score { get; set; }
    }
}
