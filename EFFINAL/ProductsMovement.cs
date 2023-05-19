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
    public partial class ProductsMovement : Form
    {
        EF Ent=new EF();
        public ProductsMovement()
        {
            InitializeComponent();
        }

        private void ProductsMovement_Load(object sender, EventArgs e)
        {
            foreach (Warehouse warehouse in Ent.Warehouses)
            {
                checkedListBox1.Items.Add(warehouse.Warehouse_Id);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (listBox1.Items.Count > 0)
            {
                listBox1.Items.Clear();
                listBox2.Items.Clear();
                listBox3.Items.Clear();
                listBox4.Items.Clear();
                listBox5.Items.Clear();
                listBox6.Items.Clear();
                listBox7.Items.Clear();

            }
            foreach (var check in checkedListBox1.CheckedItems)
            {
                int val = int.Parse(check.ToString());
                var transferid = (from s in Ent.Transfer_Products where s.Source_Warehouse == val select s);
                foreach (var item in transferid)
                {
                    if(item.Transfer_Date>=dateTimePicker1.Value && item.Transfer_Date <= dateTimePicker2.Value)
                    {
                        listBox1.Items.Add(item.Transfer_Id);
                        listBox2.Items.Add(item.Transfer_Date);
                        Warehouse warehouse = Ent.Warehouses.Find(item.Source_Warehouse);
                        listBox3.Items.Add(warehouse.Ware_Name);
                        Warehouse w2 = Ent.Warehouses.Find(item.Destination_Warehouse);
                        listBox4.Items.Add(w2.Ware_Name);
                        Product product = Ent.Products.Find(item.Prod_Code);
                        listBox5.Items.Add(item.Prod_Code);
                        listBox6.Items.Add(product.Name);
                        listBox7.Items.Add(item.Prod_Quantity);
                    }
                    

                }
            }
            
            
            
            
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.Show();
            this.Hide();
        }
    }
}
