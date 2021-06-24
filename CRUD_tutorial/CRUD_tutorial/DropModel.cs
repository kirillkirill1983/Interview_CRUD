using CRUD_tutorial.Customer;
using CRUD_tutorial.Order;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_tutorial
{
    public class DropModel:DropCreateDatabaseAlways<Model1>
    {
        protected override void Seed(Model1 context)
        {
            base.Seed(context);
            context.Customers.Add(new Customers
            {
                CustomerID = 1,
                DateTime = DateTime.Now,
                Name = "Kirill",
                Numbers = 12,
            });
           
            context.Orders.Add(new Orders
            {
                OrderID = 1,
                NameProduct = "Cola",
                Price = 10,
                Quantity = 1,
                
                CustomerID = 1
            }); ;
        }
    }
}
