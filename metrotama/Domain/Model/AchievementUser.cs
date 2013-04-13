using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace metrotama.Domain.Model
{
    class AchievementUser
    {
        [PrimaryKey, AutoIncrement]
        public int AchievementUserId { get; set; }
        public int UserId { get; set; }
        public int AchievementId { get; set; }
    }
}
