//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataLogic
{
    using System;
    using System.Collections.Generic;
    
    public partial class registration_mst
    {
        public registration_mst()
        {
            this.login_mst = new HashSet<login_mst>();
        }
    
        public int reg_id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public Nullable<System.DateTime> birth_date { get; set; }
        public Nullable<int> ac_no { get; set; }
        public string address1 { get; set; }
        public string branch_name { get; set; }
    
        public virtual ICollection<login_mst> login_mst { get; set; }
    }
}
