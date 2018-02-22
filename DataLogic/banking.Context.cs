﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Objects;
using System.Data.Objects.DataClasses;
using System.Linq;

public partial class BankingEntities : DbContext
{
    public BankingEntities()
        : base("name=BankingEntities")
    {
    }

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        throw new UnintentionalCodeFirstException();
    }

    public DbSet<login_mst> login_mst { get; set; }
    public DbSet<registration_mst> registration_mst { get; set; }
    public DbSet<sequrity_mst> sequrity_mst { get; set; }

    public virtual int registration_sp(string fname, string lname, Nullable<int> ac_no, string address, string b_name, Nullable<System.DateTime> dob)
    {
        var fnameParameter = fname != null ?
            new ObjectParameter("fname", fname) :
            new ObjectParameter("fname", typeof(string));

        var lnameParameter = lname != null ?
            new ObjectParameter("lname", lname) :
            new ObjectParameter("lname", typeof(string));

        var ac_noParameter = ac_no.HasValue ?
            new ObjectParameter("ac_no", ac_no) :
            new ObjectParameter("ac_no", typeof(int));

        var addressParameter = address != null ?
            new ObjectParameter("address", address) :
            new ObjectParameter("address", typeof(string));

        var b_nameParameter = b_name != null ?
            new ObjectParameter("b_name", b_name) :
            new ObjectParameter("b_name", typeof(string));

        var dobParameter = dob.HasValue ?
            new ObjectParameter("dob", dob) :
            new ObjectParameter("dob", typeof(System.DateTime));

        return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("registration_sp", fnameParameter, lnameParameter, ac_noParameter, addressParameter, b_nameParameter, dobParameter);
    }
}