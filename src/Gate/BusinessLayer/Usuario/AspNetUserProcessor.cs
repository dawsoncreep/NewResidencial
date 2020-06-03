using DataLayer;
using SecureGateTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class AspNetUserProcessor
    {
        AspNetUserRepository AspNetUserRepository;

        public AspNetUserProcessor()
        {
            AspNetUserRepository = new AspNetUserRepository();
        }
        public AspNetUser GetLocalUser()
        {
            return AspNetUserRepository.GetUser();
        }
    }
}
