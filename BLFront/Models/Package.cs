using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Package
    {
        public int Id { get; set; }

       
        public string name { get; set; }

       
        public double price { get; set; }

        public virtual ICollection<Booking> Bookings { get; set; }
    }
}
