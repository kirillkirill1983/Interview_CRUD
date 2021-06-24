using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_tutorial.Order
{
    public class OrderConfig : EntityTypeConfiguration<Orders>
    {
        public OrderConfig()
        {
            HasKey(p => p.OrderID);
            Property(p => p.NameProduct).HasMaxLength(50);
            Property(p => p.Price).HasColumnName("Price");
            
        }
    }
}
