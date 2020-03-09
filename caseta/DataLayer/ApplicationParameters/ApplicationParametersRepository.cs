using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class ApplicationParametersRepository
    {
        public ApplicationParametersRepository()
        {

        }

        public string GetParameterByKey(string key)
        {
            string parameters;
            using (var context = new SecureGateEntities())
            {
                parameters = context.ApplicationParameters.First(x => x.Key == key).Value;                
            }
            return parameters;
        }

        public void increasePictureID()
        {
            int pid;
            using (var context = new SecureGateEntities())
            {
                ApplicationParameters parameter = context.ApplicationParameters.Single(x => x.Key == "PictureID");
                pid = Convert.ToInt32(parameter.Value);
                pid++;
                parameter.Value = pid.ToString();
                context.SaveChanges();
            }
        }
    }
}

