using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace metrotama.Domain.Model
{
    class User
    {
        [PrimaryKey, AutoIncrement]
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string NickName { get; set; }
        public int PetPoints { get; set; }

    }
}
