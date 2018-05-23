using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BLDal.DomainModel
{
    [DataContract(IsReference = true)]
    [Table("Extra")]
    public class Extra
    {
        [Key]
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string name { get; set; }

        [DataMember]
        public double price { get; set; }

        [DataMember]
        public virtual ICollection<Booking> Bookings { get; set; }

    }
}
