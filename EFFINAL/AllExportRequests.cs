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
    public partial class AllExportRequests : Form
    {
        EF Ent=new EF();
        public AllExportRequests()
        {
            InitializeComponent();
        }

        private void AllExportRequests_Load(object sender, EventArgs e)
        {
            foreach (var item in Ent.Requests)
            {
                if (item.Req_Type == "Export")
                {
                    listBox1.Items.Add(item.Req_No);
                    listBox4.Items.Add(item.Prod_Code);
                    listBox5.Items.Add(item.Prod_Quantity);
                    listBox6.Items.Add(item.Req_Date);
                    foreach (Warehouse warehouse in Ent.Warehouses)
                    {
                        if (warehouse.Warehouse_Id == item.Warehouse_Id)
                        {
                            listBox2.Items.Add(warehouse.Ware_Name);
                        }
                    }
                    foreach (Supplier supplier in Ent.Suppliers)
                    {
                        if (supplier.Supplier_Id == item.Supplier_Id)
                        {
                            listBox3.Items.Add(supplier.Supplier_Name);
                        }
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
