using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DataLogic;
using BusinessObject;


namespace BusinessLogic
{
   public class registrationBL
    {// from here u have to call method of data access layer
        public void insertregistration(RegistrationBO bo,Dictionary<string,string> d1)
        {
            Registrationdata obj = new Registrationdata();
            obj.insert(bo,d1);

        }
        public void checklogin(string unm,string pas)
        {


        }
    }
}
