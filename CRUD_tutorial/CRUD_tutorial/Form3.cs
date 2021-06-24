using CRUD_tutorial.Customer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRUD_tutorial
{
    public partial class Form3 : Form
    {
        private Model1 Model1;
        public Form3()
        {
            InitializeComponent();
            Model1 = new Model1();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == String.Empty || textBox3.Text == String.Empty)
            {
                MessageBox.Show("Текстовые поля не заполнены !");
                return;
            };
            using (var model = new Model1())
            {
                Customers customers = new Customers
                {
                    Name = textBox1.Text,
                    Numbers = Convert.ToInt32(textBox3.Text),
                    DateTime = DateTime.Now 
                    
                };
                model.Customers.Add(customers);
                model.SaveChanges();
            }

            textBox1.Text = String.Empty;
            textBox3.Text = String.Empty;
            
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }
        private void Form3_Load(object sender, EventArgs e)
        {//dataGridView1.DataSource = GetResultCustomer();
            Model1.Customers.Load();
            dataGridView1.DataSource = Model1.Customers.Local.ToBindingList();
            label5.Text = null;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (label5.Text == String.Empty) return;

            var id = Convert.ToInt32(label5.Text);
            var Customer = Model1.Customers.Find(id);

            if (Customer == null) return;
            Customer.Name = textBox1.Text;
            Customer.Numbers = Convert.ToInt32(textBox3.Text);


            Model1.Entry(Customer).State = EntityState.Modified;
            Model1.Customers.AddOrUpdate(Customer);

            Model1.SaveChanges();

            dataGridView1.Refresh();
        }

       
        public static IEnumerable<object> GetResultCustomer()
        {
            Model1 model1 = new Model1();
            var result = (from Customer in model1.Customers
                           
                          select new
                          {
                              Customer = Customer.CustomerID,
                              CustomerName = Customer.Name,
                              Date=Customer.DateTime,
                              CaetomerNamber=Customer.Numbers
                          }).ToList();

            return result;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //dataGridView1.DataSource = Model1.Customers;
            if (dataGridView1.CurrentRow == null) return;

            Customers customer = (Customers)dataGridView1.CurrentRow.DataBoundItem ;

            if (customer == null) return;
            label5.Text = Convert.ToString(customer.CustomerID);
            textBox1.Text = customer.Name;
            textBox3.Text = Convert.ToString(customer.Numbers);

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (label5.Text == String.Empty) return;

            var id = Convert.ToInt32(label5.Text);
            var customer = Model1.Customers.Find(id);

            Model1.Entry(customer).State = EntityState.Deleted;
            Model1.Customers.Remove(customer);

            Model1.SaveChanges();

            dataGridView1.Refresh();
        }
    }
    
}
