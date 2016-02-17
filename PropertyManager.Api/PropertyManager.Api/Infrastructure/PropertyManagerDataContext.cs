﻿using Microsoft.AspNet.Identity.EntityFramework;
using PropertyManager.Api.Domain;
using System.Data.Entity;

namespace PropertyManager.Api.Infrastructure
{
    public class PropertyManagerDataContext : IdentityDbContext<PropertyManagerUser>
    {
        public PropertyManagerDataContext() : base("PropertyManager")
        {
        }

        //SQL Tables
        public IDbSet<Address> Addresses { get; set; }

        public IDbSet<Lease> Leases { get; set; }
        public IDbSet<Property> Properties { get; set; }
        public IDbSet<Tenant> Tenants { get; set; }
        public IDbSet<WorkOrder> WorkOrders { get; set; }

        //Model Relationships
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Address
            modelBuilder.Entity<Address>().HasMany(a => a.Properties).WithRequired(p => p.Address).HasForeignKey(p => p.AddressId);
            modelBuilder.Entity<Address>().HasMany(a => a.Tenants).WithRequired(t => t.PriorAddress).HasForeignKey(t => t.AddressId).WillCascadeOnDelete(false);

            //Property
            modelBuilder.Entity<Property>().HasMany(p => p.WorkOrders).WithRequired(wo => wo.Property).HasForeignKey(wo => wo.PropertyId);
            modelBuilder.Entity<Property>().HasMany(p => p.Leases).WithRequired(l => l.Property).HasForeignKey(l => l.PropertyId);

            //Tenant
            modelBuilder.Entity<Tenant>().HasMany(t => t.WorkOrders).WithRequired(wo => wo.Tenant).HasForeignKey(wo => wo.TenantId);
            modelBuilder.Entity<Tenant>().HasMany(t => t.Leases).WithRequired(l => l.Tenant).HasForeignKey(l => l.TenantId);

            //User
            modelBuilder.Entity<PropertyManagerUser>().HasMany(u => u.Properties).WithRequired(p => p.User).HasForeignKey(p => p.UserId);
            modelBuilder.Entity<PropertyManagerUser>().HasMany(u => u.Tenants).WithRequired(t => t.User).HasForeignKey(t => t.UserId).WillCascadeOnDelete(false);

            base.OnModelCreating(modelBuilder);
        }
    }
}