using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace EFFINAL
{
    public partial class ProductForm : Form
    {
        EF Ent=new EF();
        public ProductForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" )
            {
                int code = int.Parse(textBox1.Text);
                Product product=Ent.Products.Find(code);
                MeasurementUnit unit = new MeasurementUnit();
                if (product == null)
                {
                    product = new Product();
                    product.Prod_Code = code;
                    product.Name = textBox2.Text;
                    product.Entry_Date = dateTimePicker3.Value;
                    unit.Prod_Code= code;
                    unit.Measurement_Unit = textBox3.Text;
                    Ent.Products.Add(product);
                    Ent.MeasurementUnits.Add(unit);
                    Ent.SaveChanges();
                    comboBox1.Items.Add(product.Prod_Code);
                    textBox1.Text = textBox2.Text = textBox3.Text = string.Empty;
                    MessageBox.Show("NEW PRODUCT IS ADDED SUCCESSFULLY ;)");
                }
                else
                {
                    MessageBox.Show("A Product With Code " + code + "Already Exists Please Make Sure U Entered Available Data ;(");
                }
            }
            else
            {
                MessageBox.Show("EMPTY DATA FILL THE TEXTBOXS FIRST");
            }
        }

        private void ProductForm_Load(object sender, EventArgs e)
        {
            foreach (Product product in Ent.Products)
            {
                comboBox1.Items.Add(product.Prod_Code);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int code = int.Parse(textBox1.Text);
            Product product = Ent.Products.Find(code);
            if (product != null)
            {
                if (textBox2.Text != "" && textBox3.Text != "")
                {
                    product.Name = textBox2.Text;
                    product.Entry_Date = dateTimePicker3.Value;
                    Ent.SaveChanges();
                    textBox1.Text = textBox2.Text = textBox3.Text = string.Empty;
                    MessageBox.Show("PRODUCT UPDATED SUCCESSFULLY ;)");
                }
                else
                {
                    MessageBox.Show("EMPTY DATA PLEASE FILL THE TEXTBOXES FIRST");
                }
            }
            else
            {
                MessageBox.Show("THERE IS NO PRODUCT WITH SUCH CODE ;(");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (listBox1.Items.Count > 0)
            {
                listBox1.Items.Clear();
                listBox2.Items.Clear();
                listBox3.Items.Clear();
                listBox4.Items.Clear();
                listBox5.Items.Clear();
                textBox5.Text = textBox6.Text = string.Empty;
            }
            int code = int.Parse(comboBox1.Text);
            Product product = Ent.Products.Find(code);

           

            if (product != null)
            {
                textBox5.Text = product.Prod_Code.ToString();
                textBox6.Text = product.Name;
                var result = Ent.Product_Warehouse
                    .Join(Ent.Requests,
                          pw => new { pw.Prod_Code, pw.Warehouse_Id},
                          r => new { r.Prod_Code, r.Warehouse_Id },
                          (pw, r) => new { Product_Warehouse = pw, Request = r })
                    .Join(Ent.Products,
                          pr => pr.Product_Warehouse.Prod_Code,
                          p => p.Prod_Code,
                          (pr, p) => new { pr.Request.Req_Date, pr.Request.Validity_Period,pr.Request.Production_Date, p.Prod_Code,pr.Product_Warehouse.Available_Quantity,pr.Product_Warehouse.Warehouse_Id })
                    .Where(p => p.Prod_Code == code &&p.Req_Date<=dateTimePicker2.Value&&p.Req_Date>=dateTimePicker1.Value)
                    .Distinct()
                    .ToList();
                foreach (var item in result)
                {
                    listBox3.Items.Add(item.Req_Date);
                    DateTime current= DateTime.Now;
                    TimeSpan timeSpan = (TimeSpan)(current - item.Req_Date);
                    TimeSpan rem = (TimeSpan)(item.Validity_Period - item.Production_Date);
                    int remaining = rem.Days;
                    int diff = timeSpan.Days;
                    listBox5.Items.Add(remaining);
                    listBox2.Items.Add(item.Available_Quantity);
                    Warehouse warehouse = Ent.Warehouses.Find(item.Warehouse_Id);
                    listBox4.Items.Add(warehouse.Ware_Name);


                }
                
                foreach (var m in product.MeasurementUnits)
                {
                    listBox1.Items.Add(m.Measurement_Unit);
                }


            }
        }

        

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            TransferForm form = new TransferForm();
            form.Show();
            this.Hide();
        }
    }
}
