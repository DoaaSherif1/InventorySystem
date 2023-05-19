using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EFFINAL
{
    public partial class WarehouseForm : Form
    {
        EF Ent = new EF();
        public WarehouseForm()
        {
            InitializeComponent();
        }

        private void WarehouseForm_Load(object sender, EventArgs e)
        {
            foreach (Warehouse warehouse in Ent.Warehouses)
            {
                comboBox1.Items.Add(warehouse.Warehouse_Id);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "")
            {
                int id = int.Parse(textBox1.Text);
                Warehouse warehouse = Ent.Warehouses.Find(id);
                if (warehouse == null)
                {
                    warehouse = new Warehouse();
                    warehouse.Warehouse_Id = id;
                    warehouse.Ware_Name = textBox2.Text;
                    warehouse.Address = textBox3.Text;
                    warehouse.Manager = textBox4.Text;
                    Ent.Warehouses.Add(warehouse);
                    Ent.SaveChanges();
                    comboBox1.Items.Add(warehouse.Warehouse_Id);
                    textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = string.Empty;
                    MessageBox.Show("NEW WAREHOUSE ADDED SUCCESSFULLY ;)");
                }
                else
                {
                    MessageBox.Show("A Warehouse With ID " + id + "Already Exists Please Make Sure U Entered Available Data ;(");
                }
            }
            else
            {
                MessageBox.Show("EMPTY DATA FILL THE TEXTBOXS FIRST");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int id = int.Parse(textBox1.Text);
            Warehouse warehouse = Ent.Warehouses.Find(id);
            if (warehouse != null)
            {
                if (textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "")
                {
                    warehouse.Ware_Name = textBox2.Text;
                    warehouse.Address = textBox3.Text;
                    warehouse.Manager = textBox4.Text;
                    Ent.SaveChanges();
                    textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = string.Empty;
                    MessageBox.Show("WAREHOUSE UPDATEDED SUCCESSFULLY ;)");
                }
                else
                {
                    MessageBox.Show("EMPTY DATA PLEASE FILL THE TEXTBOXS FIRST");
                }
            }
            else
            {
                MessageBox.Show("THERE IS NO WAREHOUSE WITH SUCH ID ;(");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (listBox1.Items.Count > 0)
            {
                listBox1.Items.Clear();
                listBox2.Items.Clear();
                listBox5.Items.Clear();
                listBox6.Items.Clear();
                textBox5.Text = textBox6.Text = textBox7.Text = textBox8.Text = string.Empty;
            }
            int id = int.Parse(comboBox1.Text);
            Warehouse warehouse = Ent.Warehouses.Find(id);

            if (warehouse != null)
            {
                textBox5.Text=warehouse.Warehouse_Id.ToString();
                textBox6.Text=warehouse.Ware_Name;
                textBox7.Text= warehouse.Address;
                textBox8.Text= warehouse.Manager;
                foreach (var item in warehouse.Product_Warehouse)
                {
                    if (item.Warehouse_Id == id)
                    {
                        Product product = Ent.Products.Find(item.Prod_Code);

                        if (product != null && product.Entry_Date >= dateTimePicker1.Value && product.Entry_Date <= dateTimePicker2.Value)
                        {
                            listBox5.Items.Add(product.Name);
                            listBox6.Items.Add(item.Available_Quantity);
                            listBox1.Items.Add(item.Prod_Code);
                            listBox2.Items.Add(product.Entry_Date);
                        }


                    }
                }

            }
        }

      
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.Show();
            this.Hide();
        }
    }
}
