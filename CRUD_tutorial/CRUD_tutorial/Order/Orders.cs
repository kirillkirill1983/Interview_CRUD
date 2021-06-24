using CRUD_tutorial.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_tutorial.Order
{
    public class Orders
    {
        public int OrderID { get; set; }
        public string NameProduct { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        
        public int CustomerID { get; set; }
        public Customers  Customers { get; set; }
    }
}

// название товара
// цена
// количество
// стоимость