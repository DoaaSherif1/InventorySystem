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
    public partial class Requests : Form
    {
        public Requests()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ExportForm exportForm = new ExportForm();
            exportForm.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ImportForm import=new ImportForm();
            import.Show();
            this.Hide();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.Show();
            this.Hide();
        }
    }
}
