﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SMS_Sender
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class messsageEntities : DbContext
    {
        public messsageEntities()
            : base("name=messsageEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Mem_Details> Mem_Details { get; set; }
        public virtual DbSet<Mem_Info> Mem_Info { get; set; }
        public virtual DbSet<Mem_Title> Mem_Title { get; set; }
        public virtual DbSet<Msg> Msgs { get; set; }
    }
}
