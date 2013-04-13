using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace metrotama.Domain.Model
{
    class Achievement
    {
        [PrimaryKey, AutoIncrement]
        public int AchievementId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int HighScore { get; set; }
        public int AwardPoints { get; set; }
        public int Category {get; set;}
    }
}
