using CRUD_tutorial.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_tutorial.Customer
{
    public class Customers
    {
        public int CustomerID { get; set; }
        public DateTime DateTime { get; set; }
        public int Numbers { get; set; }
        public string Name { get; set; }
       
        public ICollection<Orders> Orders { get; set; }
    }
}


// Дата,
// Номер,
// ФИО Клиента,
// общая сумма заказа
// список позиций заказа