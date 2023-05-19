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
    public partial class AllClients : Form
    {
        EF Ent=new EF();
        public AllClients()
        {
            InitializeComponent();
        }

        private void AllClients_Load(object sender, EventArgs e)
        {
            foreach(var item in Ent.Clients)
            {
                listBox1.Items.Add(item.Client_Id);
                listBox2.Items.Add(item.Client_Name);
                listBox3.Items.Add(item.Telephone);
                listBox4.Items.Add(item.Website);
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = ((ListBox)sender).SelectedIndex;
            if (index != -1)
            {

                listBox1.SelectedIndex = index;
                listBox2.SelectedIndex = index;
                listBox3.SelectedIndex = index;
                listBox4.SelectedIndex = index;

            }
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = ((ListBox)sender).SelectedIndex;
            if (index != -1)
            {

                listBox1.SelectedIndex = index;
                listBox2.SelectedIndex = index;
                listBox3.SelectedIndex = index;
                listBox4.SelectedIndex = index;

            }
        }

        private void listBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = ((ListBox)sender).SelectedIndex;
            if (index != -1)
            {

                listBox1.SelectedIndex = index;
                listBox2.SelectedIndex = index;
                listBox3.SelectedIndex = index;
                listBox4.SelectedIndex = index;

            }
        }

        private void listBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = ((ListBox)sender).SelectedIndex;
            if (index != -1)
            {

                listBox1.SelectedIndex = index;
                listBox2.SelectedIndex = index;
                listBox3.SelectedIndex = index;
                listBox4.SelectedIndex = index;

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
