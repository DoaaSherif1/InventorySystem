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
    public partial class Reports : Form
    {
        public Reports()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ProductsMovement productsMovement = new ProductsMovement();
            productsMovement.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ProductPeriodReport report = new ProductPeriodReport();
            report.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            RemainingTimeReport remainingTimeReport = new RemainingTimeReport();
            remainingTimeReport.Show();
            this.Hide();
        }
    }
}
