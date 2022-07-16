using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Models
{
    public class Customer
    {
        public int ID { get; set; }
        public int userID { get; set; }
        public string title { get; set; }
        public bool complete { get; set; }

    }
}
