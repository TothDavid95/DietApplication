﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Application.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class DietDBEntities : DbContext
    {
        public DietDBEntities()
            : base("name=DietDBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Allergy> Allergy { get; set; }
        public virtual DbSet<Diary> Diary { get; set; }
        public virtual DbSet<Food> Food { get; set; }
        public virtual DbSet<TimeOfMeal> TimeOfMeal { get; set; }
        public virtual DbSet<User> User { get; set; }
    }
}
