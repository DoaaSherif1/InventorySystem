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
    public partial class SupplierForm : Form
    {
        EF Ent = new EF();
        public SupplierForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "" && textBox6.Text != "" && textBox7.Text != "")
            {

                int id = int.Parse(textBox1.Text);
                Supplier supplier = Ent.Suppliers.Find(id);
                if (supplier == null)
                {
                    supplier = new Supplier();
                    supplier.Supplier_Id = id;
                    supplier.Supplier_Name = textBox2.Text;
                    supplier.Telephone = int.Parse(textBox3.Text);
                    supplier.Mobile = int.Parse(textBox4.Text);
                    supplier.Fax = textBox5.Text;
                    supplier.Mail = textBox6.Text;
                    supplier.Website = textBox7.Text;
                    Ent.Suppliers.Add(supplier);
                    Ent.SaveChanges();

                    textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = textBox5.Text = textBox6.Text = textBox7.Text = string.Empty;
                    MessageBox.Show("NEW SUPPLIER ADDED SUCCESSFULLY ;)");
                }
                else
                {
                    MessageBox.Show("A Supplier With ID " + id + "Already Exists Please Make Sure U Entered Available Data ;(");
                }
            }
            else
            {
                MessageBox.Show("EMPTY DATA FILL THE TEXTBOXS FIRST");
            }
        } 

        private void button2_Click(object sender, EventArgs e)
        {
            int id = int.Parse(textBox1.Text);
            Supplier supplier = Ent.Suppliers.Find(id);
            if (supplier != null)
            {
                if (textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "" && textBox6.Text != "" && textBox7.Text != "")
                {
                    supplier.Supplier_Name = textBox2.Text;
                    supplier.Telephone = int.Parse(textBox3.Text);
                    supplier.Mobile = int.Parse(textBox4.Text);
                    supplier.Fax = textBox5.Text;
                    supplier.Mail = textBox6.Text;
                    supplier.Website = textBox7.Text;
                    Ent.SaveChanges();
                    textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = textBox5.Text = textBox6.Text = textBox7.Text = string.Empty;
                    MessageBox.Show("SUPPLIER DATA UPDATEDED SUCCESSFULLY ;)");
                }
                else
                {
                    MessageBox.Show("EMPTY DATA PLEASE FILL THE TEXTBOXS FIRST");
                }
            }
            else
            {
                MessageBox.Show("THERE IS NO SUPPLIER WITH SUCH ID ;(");
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.Show();
            this.Hide();
        }
    }
}
