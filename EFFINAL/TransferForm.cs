using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace EFFINAL
{
    public partial class TransferForm : Form
    {
        EF Ent =new EF(); 
        public TransferForm()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.Show();
            this.Hide();
        }

        private void TransferForm_Load(object sender, EventArgs e)
        {
            foreach (Warehouse warehouse in Ent.Warehouses)
            {
                comboBox2.Items.Add(warehouse.Warehouse_Id);
                comboBox3.Items.Add(warehouse.Warehouse_Id);
            }
            foreach (Supplier supplier in Ent.Suppliers)
            {
                comboBox4.Items.Add(supplier.Supplier_Id);
            }
            foreach (Product product in Ent.Products)
            {
                comboBox1.Items.Add(product.Prod_Code);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text != "" && comboBox2.Text != ""&&comboBox3.Text!=""&&textBox2.Text!="")
            {
                int ti=int.Parse(textBox2.Text);
                int fromware = int.Parse(comboBox2.Text);
                int toware=int.Parse(comboBox3.Text);
                int prod = int.Parse(comboBox1.Text);
                Transfer_Products tp = Ent.Transfer_Products.Find(prod, fromware,toware,ti);
                Product_Warehouse product_Warehouse = Ent.Product_Warehouse.Find(prod, toware);
                Product_Warehouse pw = Ent.Product_Warehouse.Find(prod, fromware);
                if (pw.Available_Quantity >= int.Parse(textBox1.Text))
                {


                    if (tp == null)
                    {
                        tp = new Transfer_Products();
                        tp.Transfer_Id = ti;
                        tp.Prod_Code = prod;
                        tp.Source_Warehouse = fromware;
                        tp.Destination_Warehouse = toware;
                        tp.Supplier_Id = int.Parse(comboBox4.Text);
                        tp.Prod_Quantity = int.Parse(textBox1.Text);
                        tp.Production_Date = dateTimePicker1.Value;
                        tp.Validity_Period = dateTimePicker2.Value;
                        tp.Transfer_Date = dateTimePicker3.Value;
                        Ent.Transfer_Products.Add(tp);

                        if (product_Warehouse == null)
                        {
                            //insert new record with the new product in this warehouse
                            product_Warehouse = new Product_Warehouse();
                            product_Warehouse.Prod_Code = prod;
                            product_Warehouse.Warehouse_Id = toware;
                            product_Warehouse.Available_Quantity = int.Parse(textBox1.Text);
                            Ent.Product_Warehouse.Add(product_Warehouse);

                        }
                        else
                        {
                            //the product already exists
                            product_Warehouse.Available_Quantity += int.Parse(textBox1.Text);
                        }
                        pw.Available_Quantity -= int.Parse(textBox1.Text);
                        Ent.SaveChanges();
                        textBox1.Text = textBox2.Text = comboBox1.Text = comboBox2.Text = comboBox3.Text = comboBox4.Text = string.Empty;
                        MessageBox.Show("THE PRODUCTS TRANSFERRED SUCCESSFULLY ;)");
                    }
                    else
                    {
                        MessageBox.Show("Transfer Operation With Id" + ti + "Already Exists ;(");
                    }
                }
                else
                {
                    MessageBox.Show("NOT ENOUGH QUANTITY IN THE WAREHOUSE");
                }
            }
            else
            {
                MessageBox.Show("EMPTY DATA FILL THE TEXTBOXS FIRST");
            }
        }
    }
}
