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
    public partial class ImportForm : Form
    {
        EF Ent=new EF();
        public ImportForm()
        {
            InitializeComponent();
        }

        private void ImportForm_Load(object sender, EventArgs e)
        {
            foreach(Warehouse warehouse in Ent.Warehouses)
            {
                comboBox1.Items.Add(warehouse.Warehouse_Id);
            }
            foreach(Supplier supplier in Ent.Suppliers)
            {
                comboBox2.Items.Add(supplier.Supplier_Id);
            }
            foreach (Product product in Ent.Products)
            {
                comboBox3.Items.Add(product.Prod_Code);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" )
            {
                int req = int.Parse(textBox1.Text);
                int ware=int.Parse(comboBox1.Text);
                int sup=int.Parse(comboBox2.Text);
                int prod=int.Parse(comboBox3.Text);
                Request request = Ent.Requests.Find(prod,ware,sup,req);
                if (request == null)
                {
                    request=new Request();
                    request.Prod_Code = prod;
                    request.Warehouse_Id = ware;
                    request.Supplier_Id = sup;
                    request.Req_No = req;
                    request.Prod_Quantity=int.Parse(textBox2.Text);
                    request.Req_Date = dateTimePicker3.Value;
                    request.Production_Date = dateTimePicker1.Value;
                    request.Validity_Period = dateTimePicker2.Value;
                    request.Req_Type = "Import";
                    Ent.Requests.Add(request);
                    Product_Warehouse product_Warehouse = Ent.Product_Warehouse.Find(prod, ware);
                    if (product_Warehouse == null)
                    {
                        //insert new record with the new product in this warehouse
                        product_Warehouse=new Product_Warehouse();
                        product_Warehouse.Prod_Code= prod;
                        product_Warehouse.Warehouse_Id= ware;
                        product_Warehouse.Available_Quantity= int.Parse(textBox2.Text);
                        Ent.Product_Warehouse.Add(product_Warehouse);

                    }
                    else
                    {
                        //the product already exists
                        product_Warehouse.Available_Quantity += int.Parse(textBox2.Text);
                    }
                    Ent.SaveChanges();
                    textBox1.Text = textBox2.Text = comboBox1.Text = comboBox2.Text =comboBox3.Text= string.Empty;
                    MessageBox.Show("NEW IMPORT REQUEST ADDED SUCCESSFULLY ;)");
                }
                else
                {
                    MessageBox.Show("A Request With No " + req + "Already Exists Please Make Sure U Entered Available Data ;(");
                }
            }
            else
            {
                MessageBox.Show("EMPTY DATA FILL THE TEXTBOXS FIRST");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "")
            {
                int req = int.Parse(textBox1.Text);
                int ware = int.Parse(comboBox1.Text);
                int sup = int.Parse(comboBox2.Text);
                int prod = int.Parse(comboBox3.Text);
                Request request = Ent.Requests.Find(prod, ware, sup, req);
                if (request != null)
                {
                    int quant = request.Prod_Quantity;
                    int newQuant = int.Parse(textBox2.Text);
                    int difference=newQuant- quant;
                    request.Prod_Quantity = int.Parse(textBox2.Text);
                    request.Req_Date = dateTimePicker3.Value;
                    request.Production_Date = dateTimePicker1.Value;
                    request.Validity_Period = dateTimePicker2.Value;
                    
                    Product_Warehouse product_Warehouse = Ent.Product_Warehouse.Find(prod, ware);
                    if (product_Warehouse == null)
                    {
                        //insert new record with the new product in this warehouse
                        product_Warehouse = new Product_Warehouse();
                        product_Warehouse.Prod_Code = prod;
                        product_Warehouse.Warehouse_Id = ware;
                        product_Warehouse.Available_Quantity = int.Parse(textBox2.Text);
                        Ent.Product_Warehouse.Add(product_Warehouse);

                    }
                    else
                    {
                        //the product already exists
                        product_Warehouse.Available_Quantity += difference;
                    }
                    Ent.SaveChanges();
                    textBox1.Text = textBox2.Text = comboBox1.Text = comboBox2.Text = comboBox3.Text = string.Empty;
                    MessageBox.Show("THE IMPORT REQUEST UPDATED SUCCESSFULLY ;)");
                }
                else
                {
                    MessageBox.Show("THERE IS NO REQUEST WITH SUCH NO. ;(");
                }
            }
            else
            {
                MessageBox.Show("EMPTY DATA FILL THE TEXTBOXS FIRST");
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AllImportsRequests allImports = new AllImportsRequests();
            allImports.Show();
            this.Hide();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.Show();
            this.Hide();
        }
    }
}
