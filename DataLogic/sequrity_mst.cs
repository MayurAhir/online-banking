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
    
    public partial class sequrity_mst
    {
        public int sec_id { get; set; }
        public Nullable<int> login_id { get; set; }
        public string q1 { get; set; }
        public string ans1 { get; set; }
        public string q2 { get; set; }
        public string ans2 { get; set; }
        public string q3 { get; set; }
        public string ans3 { get; set; }
    
        public virtual login_mst login_mst { get; set; }
    }
}
