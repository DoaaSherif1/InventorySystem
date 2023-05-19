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
    public partial class ProductPeriodReport : Form
    {
        EF Ent = new EF();
        public ProductPeriodReport()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (listBox1.Items.Count > 0)
            {
                listBox1.Items.Clear();
                listBox2.Items.Clear();
                listBox3.Items.Clear();
                listBox4.Items.Clear();
                
            }
            string Input = textBox1.Text;
            if (int.TryParse(Input, out int days))
            {
                
                var Data = from r in Ent.Requests
                           join p in Ent.Products on r.Prod_Code equals p.Prod_Code
                           where  r.Req_Type == "Import"
                           select new
                           {
                               Product_Code = r.Prod_Code,
                               Product_Name = p.Name,
                               Warehouse = r.Warehouse.Ware_Name,
                               Request_Date = r.Req_Date
                           };
                //dataGridView1.DataSource = Data.ToList();
                foreach(var d in Data)
                {
                    DateTime current = DateTime.Now;
                    TimeSpan timeSpan = (TimeSpan)(current - d.Request_Date);
                    int dif=timeSpan.Days;
                    if (dif >= days)
                    {
                        listBox1.Items.Add(d.Product_Code);
                        listBox2.Items.Add(d.Product_Name);
                        listBox3.Items.Add(d.Warehouse);
                        listBox4.Items.Add(d.Request_Date);
                    }
                }
            }
            else
            {
                MessageBox.Show("Invalid input. Please enter a valid number of Days.");
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
