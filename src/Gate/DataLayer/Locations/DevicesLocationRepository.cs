using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class DevicesLocationRepository
    {
        public string IpLocationSystem { get; set; }
        public DevicesLocationRepository()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            IpLocationSystem = host.AddressList.Single(w => w.AddressFamily.ToString() == "InterNetwork").ToString();
        }

        public string GetIpLocationSystem()
        {
            return IpLocationSystem;
        }
    }
}
