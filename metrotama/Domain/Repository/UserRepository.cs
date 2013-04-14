using metrotama.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace metrotama.Domain.Repository
{
    class UserRepository
    {
        public User GetUserByName(string userName)
        {
            User result = null;
            using (var db = new SQLite.SQLiteConnection(App.DBPath))
            {
                result = db.Table<User>().Where(u => u.UserName == userName).Single();
            }
            return result;
        }
    }
}
