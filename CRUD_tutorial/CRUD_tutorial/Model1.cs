using CRUD_tutorial.Customer;
using CRUD_tutorial.Order;
using System;
using System.Data.Entity;
using System.Linq;

namespace CRUD_tutorial
{
    public class Model1 : DbContext
    {
       
        public Model1()
            : base("name=Model1")
        {
        }
        public virtual DbSet<Customers> Customers{ get; set; }
        public virtual DbSet<Orders> Orders { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add(new CustomerConfig());
            modelBuilder.Configurations.Add(new OrderConfig());
            
        }
    }

   
}