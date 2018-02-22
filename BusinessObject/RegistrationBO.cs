using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
  public class RegistrationBO
    {
       private string f_name;
        private string l_name;
        private DateTime dob;
        private int ac_no;
        private string add;
        private string br_name;
        public string fname
        {
            get
            {
                return f_name;
            }
            set
            {
                f_name = value;
            }
        }
        public string lname
        {
            get
            {
                return l_name;
            }
            set
            {
                l_name = value;
            }
        }
        public DateTime _dob
        {
            get
            {
                return dob;
            }
            set
            {
                dob = value;
            }
        }
        public int _ac_no
        {
            get
            {
                return ac_no;
            }
            set
            {
                ac_no = value;
            }
        }
        public string _add
        {
            get
            {
                return add;
            }
            set
            {
                add = value;
            }
        }
        public string _brname
        {
            get
            {
                return br_name;
            }
            set
            {
                br_name = value;
            }
        }


    }
}
