using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLDal.DomainModel
{
    public class Payment
    {
        public Amount amount { get; set; }
        public string reference { get; set; }
        public string merchantAccount { get; set; }

        public string sdkVersion { get; set; }

        public string shopperReference { get; set; }

        public string channel { get; set; }

        public bool html { get; set; }

        public string origin { get; set; }

        public string returnUrl { get; set; }

        public string countryCode { get; set; }

        public string shopperLocale { get; set; }
    }
}
