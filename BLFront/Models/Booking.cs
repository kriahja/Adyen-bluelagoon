using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Booking
    {
        public int Id { get; set; }

        
        public int adult { get; set; }

        
        public int child { get; set; }

        
        public DateTime date { get; set; }

        
        public int time { get; set; }

        
        //  public int packId { get; set; }
        public virtual Package Package { get; set; }


        
        public string first { get; set; }

        
        public string last { get; set; }

        
        public string email { get; set; }

        
        public string mobil { get; set; }

        
        public double price { get; set; }

        
        public virtual ICollection<Extra> Extras { get; set; }

    }
}
