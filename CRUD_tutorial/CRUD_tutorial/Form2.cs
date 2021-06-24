using CRUD_tutorial.Order;
using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Windows.Forms;

namespace CRUD_tutorial
{
    public partial class Form2 : Form
    {
        private Model1 Model1;
        public Form2()
        {
            InitializeComponent();
            Model1 = new Model1();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == String.Empty || textBox2.Text == String.Empty || textBox3.Text == String.Empty) 
            {
                MessageBox.Show("Текстовые поля не заполнены !");
                return;
            };
            using (var model = new Model1())
            {
                Orders orders = new Orders()
                {
                    NameProduct = textBox1.Text,
                    Price = Convert.ToDecimal(textBox2.Text),
                    Quantity = Convert.ToInt32(textBox3.Text),
                    CustomerID = Convert.ToInt32(textBox4.Text)
                };
                model.Orders.Add(orders);
                model.SaveChanges();
            }

            textBox1.Text = String.Empty;
            textBox2.Text = String.Empty;
            textBox3.Text = String.Empty;
            textBox4.Text = String.Empty;
            this.Close();

        }
        private void Form2_Load(object sender, EventArgs e)
        {
            Model1.Orders.Load();
            dataGridView1.DataSource = Model1.Orders.Local.ToBindingList();
            label6.Text = null;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentRow == null) return;

            Orders orders = (Orders)dataGridView1.CurrentRow.DataBoundItem;

            if (orders == null) return;
            label6.Text = Convert.ToString(orders.OrderID);
            textBox1.Text = Convert.ToString(orders.NameProduct);
            textBox2.Text = Convert.ToString( orders.Price);
            textBox3.Text = Convert.ToString( orders.Quantity);
            textBox4.Text = Convert.ToString( orders.CustomerID);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (label6.Text == String.Empty) return;

            var id = Convert.ToInt32(label6.Text);
            var Orders = Model1.Orders.Find(id);

            if (Orders == null) return;
            Orders.NameProduct = textBox1.Text;
            Orders.Price = Convert.ToDecimal(textBox2.Text);
            Orders.Quantity = Convert.ToInt32(textBox3.Text);
            Orders.CustomerID = Convert.ToInt32(textBox4.Text);


            Model1.Entry(Orders).State = EntityState.Modified;
            Model1.Orders.AddOrUpdate(Orders);

            Model1.SaveChanges();

            dataGridView1.Refresh();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (label6.Text == String.Empty) return;

            var id = Convert.ToInt32(label6.Text);
            var orders = Model1.Orders.Find(id);

            Model1.Entry(orders).State = EntityState.Deleted;
            Model1.Orders.Remove(orders);

            Model1.SaveChanges();

            dataGridView1.Refresh();
        }
    }
}
