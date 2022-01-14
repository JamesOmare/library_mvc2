using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Library_Project1._1.Models
{
    public class Library
    {
        public int id { get; set; }
        public string author { get; set; }
        public string book_name { get; set; }
        public string genre { get; set;  }
        public DateTime publish_date { get; set;  }
        public string isbn { get; set; }
    }
}