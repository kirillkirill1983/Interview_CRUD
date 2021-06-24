using CRUD_tutorial.Customer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRUD_tutorial
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
            //при первом запуске раскоментировать для создания БД и потом сново закиментировать 
            //Database.SetInitializer(new DropModel());
          
        }
        public static IEnumerable<object> GetResulr()
        {
            Model1 model1 = new Model1();
            var result = (from order in model1.Orders
                          join Customer in model1.Customers on order.CustomerID equals Customer.CustomerID
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


        private void button1_Click(object sender, EventArgs e)
        {
            Form2 newForm2 = new Form2();
            newForm2.Show();
            

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            dataGridView1.DataSource = GetResulr();
            dataGridView1.Refresh();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form3 newForm3 = new Form3();
            newForm3.Show();
            

        }

        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = GetResulr();
            dataGridView1.Refresh(); 
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form3 newForm3 = new Form3();
            newForm3.Show();

        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form2 newForm2 = new Form2();
            newForm2.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form3 newForm3 = new Form3();
            newForm3.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Form2 newForm2 = new Form2();
            newForm2.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form4 newForm4 = new Form4();
            newForm4.Show();
        }
    }
}
