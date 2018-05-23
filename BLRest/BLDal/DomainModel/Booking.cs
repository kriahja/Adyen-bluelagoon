using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace BLDal.DomainModel
{
    [DataContract(IsReference = true)]
    [Table("Booking")]

    public class Booking
    {
        [Key]
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public int adult { get; set; }

        [DataMember]
        public int child { get; set; }

        [DataMember]
        public DateTime date { get; set; }

        [DataMember]
        public int time { get; set; }

        [DataMember]
      //  public int packId { get; set; }
        public virtual Package Package { get; set; }


        [DataMember]
        public string first { get; set; }

        [DataMember]
        public string last { get; set; }

        [DataMember]
        public string email { get; set; }

        [DataMember]
        public string mobil { get; set; }

        [DataMember]
        public double price { get; set; }

        [DataMember]
        public virtual ICollection<Extra> Extras { get; set; }

    }
}
