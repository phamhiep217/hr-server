﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace QLNV_SER.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class HumanResourceEntities : DbContext
    {
        public HumanResourceEntities()
            : base("name=HumanResourceEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<RoleSub> RoleSubs { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Emp> Emps { get; set; }
        public virtual DbSet<Allowance> Allowances { get; set; }
        public virtual DbSet<AllowanceSub> AllowanceSubs { get; set; }
        public virtual DbSet<AnnualLeaf> AnnualLeaves { get; set; }
        public virtual DbSet<Area> Areas { get; set; }
        public virtual DbSet<Attach> Attachs { get; set; }
        public virtual DbSet<CalSheet> CalSheets { get; set; }
        public virtual DbSet<Comp> Comps { get; set; }
        public virtual DbSet<Contract> Contracts { get; set; }
        public virtual DbSet<Degree> Degrees { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<District> Districts { get; set; }
        public virtual DbSet<Ethnic> Ethnics { get; set; }
        public virtual DbSet<Nation> Nations { get; set; }
        public virtual DbSet<Position> Positions { get; set; }
        public virtual DbSet<Province> Provinces { get; set; }
        public virtual DbSet<Salary> Salarys { get; set; }
        public virtual DbSet<Setting> Settings { get; set; }
        public virtual DbSet<TimeSheet> TimeSheets { get; set; }
        public virtual DbSet<Ward> Wards { get; set; }
    }
}