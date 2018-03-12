using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PRSWebAppBackEndProject.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() : base()  
        {
        }

        public DbSet<Users> Users { get; set; }
        public DbSet<Vendors> Vendors { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<PurchaseRequests> PurchaseRequests { get; set; }
        public DbSet<PurchaseRequestLineItems> PurchaseRequestLineItems { get; set; }
        
    }
}