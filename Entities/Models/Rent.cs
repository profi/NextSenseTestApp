using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.Models
{
    public class Rent
    {
        [Key]
        public int Id { get; set; }
        public DateTime DateRented { get; set; }
        public DateTime DateReturned { get; set; }
        public int  UserId { get; set; }
        public int BookId { get; set; }
        public virtual User User  { get; set; }
        public virtual Book Book { get; set; }
        
    }
}
