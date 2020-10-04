using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Models
{
    public class Book
    {
        public int Id { get; set; }
        public int IDBM { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int Stock { get; set; }
        public ICollection<Rent> Rents { get; set; }
    }
}
