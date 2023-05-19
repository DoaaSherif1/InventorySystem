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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            WarehouseForm warehouse=new WarehouseForm();
            warehouse.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ProductForm product=new ProductForm();
            product.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ClientForm client=new ClientForm();
            client.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SupplierForm supplier=new SupplierForm();
            supplier.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Requests requests=new Requests();
            requests.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Reports reports=new Reports();
            reports.Show();
            this.Hide();
        }
    }
}
