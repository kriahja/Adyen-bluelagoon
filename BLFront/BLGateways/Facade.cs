using BLGateways.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLGateways
{
    public class Facade
    {
        public BookingGatewayService GetBookingGateway()
        {
            return new BookingGatewayService();
        }

        public ExtraGatewayService GetExtraGateway()
        {
            return new ExtraGatewayService();
        }

        public PackageGatewayService GetPackageGateway()
        {
            return new PackageGatewayService();
        }
    }
}
