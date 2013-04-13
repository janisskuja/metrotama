using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace metrotama.Domain.Model
{
    class SayText
    {
        [PrimaryKey, AutoIncrement]
        public int SayTextId { get; set; }
        public int Parametter { get; set; }
        public int From { get; set; }
        public int To { get; set; }
        public string Text { get; set; }
    }
}
