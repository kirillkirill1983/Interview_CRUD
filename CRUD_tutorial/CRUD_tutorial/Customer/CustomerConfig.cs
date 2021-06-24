using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_tutorial.Customer
{
    public class CustomerConfig: EntityTypeConfiguration<Customers>
    {
        public CustomerConfig()
        {
            HasKey(p => p.CustomerID);
            Property(p => p.DateTime).HasColumnName("Date");
            Property(p => p.Numbers).HasColumnName("Nambers").IsRequired();
            Property(p => p.Name).HasColumnName("Name").IsRequired();
        }
    }
}
