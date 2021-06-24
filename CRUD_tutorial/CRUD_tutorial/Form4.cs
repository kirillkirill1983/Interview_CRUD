using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRUD_tutorial
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime dateTime = Convert.ToDateTime(textBox1.Text);
                dataGridView1.DataSource = GetResulr(dateTime);
                label2.Text = textBox1.Text;
            }
            catch (Exception)
            {

                MessageBox.Show("Ошибка ввода ");
            }
            
        }
        public static IEnumerable<object> GetResulr(DateTime dateTime)
        {
            //DateTime dt = new DateTime(yyyy,mm,dd);
            DateTime dateTime1 = dateTime.Date;
            Model1 model1 = new Model1();
            var result = (from order in model1.Orders
                          join Customer in model1.Customers on order.CustomerID equals Customer.CustomerID
                          where(Customer.DateTime>=dateTime )
                          select new
                          {
                              Customer = Customer.CustomerID,
                              CustomerName = Customer.Name,
                              Orders = order.OrderID,
                              NameProducts = order.NameProduct,
                              Quantity = order.Quantity,
                              totalprice = order.Price * order.Quantity,
                              Price = order.Price,

                          }).ToList();

            return result;
        }
    }
}
