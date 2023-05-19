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
    public partial class RemainingTimeReport : Form
    {
        EF Ent=new EF();
        public RemainingTimeReport()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.Show();
            this.Hide();
        }

        private void RemainingTimeReport_Load(object sender, EventArgs e)
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

            }
            foreach (var check in checkedListBox1.CheckedItems)
            {
                int val = int.Parse(check.ToString());
                var result = Ent.Product_Warehouse
                    .Join(Ent.Requests,
                          pw => new { pw.Prod_Code, pw.Warehouse_Id },
                          r => new { r.Prod_Code, r.Warehouse_Id },
                          (pw, r) => new { Product_Warehouse = pw, Request = r })
                    .Join(Ent.Products,
                          pr => pr.Product_Warehouse.Prod_Code,
                          p => p.Prod_Code,
                          (pr, p) => new { pr.Request.Req_Date, pr.Request.Validity_Period, pr.Request.Production_Date, p.Prod_Code, pr.Product_Warehouse.Available_Quantity, pr.Product_Warehouse.Warehouse_Id,p.Name })
                    .Where(p =>p.Warehouse_Id==val)
                    .Distinct()
                    .ToList();
                foreach (var item in result)
                {
                    DateTime current = DateTime.Now;
                    TimeSpan timeSpan = (TimeSpan)(current - item.Req_Date);
                    TimeSpan rem = (TimeSpan)(item.Validity_Period - item.Production_Date);
                    int remaining = rem.Days;
                    int diff = timeSpan.Days;
                    if (remaining < 60) 
                    {
                        listBox1.Items.Add(item.Prod_Code);
                        listBox2.Items.Add(item.Name);
                        listBox3.Items.Add(item.Available_Quantity);
                        Warehouse warehouse = Ent.Warehouses.Find(item.Warehouse_Id);
                        listBox4.Items.Add(warehouse.Ware_Name);
                        listBox5.Items.Add(remaining);
                    }
                    
                }
            }
        }
    }
}
