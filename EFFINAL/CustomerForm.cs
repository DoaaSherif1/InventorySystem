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
    public partial class ClientForm : Form
    {
        EF Ent=new EF();
        public ClientForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text!=""&& textBox6.Text!="" && textBox7.Text!="")
            {
                int id = int.Parse(textBox1.Text);
                Client client = Ent.Clients.Find(id);
                if (client == null)
                {
                    client = new Client();
                    client.Client_Id= id;
                    client.Client_Name = textBox2.Text;
                    client.Telephone=int.Parse(textBox3.Text);
                    client.Mobile=int.Parse(textBox4.Text);
                    client.Fax = textBox5.Text;
                    client.Mail = textBox6.Text;
                    client.Website= textBox7.Text;
                    Ent.Clients.Add(client);
                    Ent.SaveChanges();
                    
                    textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text =textBox5.Text=textBox6.Text=textBox7.Text= string.Empty;
                    MessageBox.Show("NEW CLIENT ADDED SUCCESSFULLy ;)");
                }
                else
                {
                    MessageBox.Show("A Client With ID " + id + "Already Exists Please Make Sure U Entered Available Data ;(");
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
            Client client= Ent.Clients.Find(id);
            if (client != null)
            {
                if (textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "" && textBox6.Text != "" && textBox7.Text != "")
                {
                    client.Client_Name = textBox2.Text;
                    client.Telephone = int.Parse(textBox3.Text);
                    client.Mobile = int.Parse(textBox4.Text);
                    client.Fax = textBox5.Text;
                    client.Mail = textBox6.Text;
                    client.Website = textBox7.Text;
                    Ent.SaveChanges();
                    textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = textBox5.Text = textBox6.Text = textBox7.Text = string.Empty;
                    MessageBox.Show("CLIENT DATA UPDATEDED SUCCESSFULLY ;)");
                }
                else
                {
                    MessageBox.Show("EMPTY DATA PLEASE FILL THE TEXTBOXS FIRST");
                }
            }
            else
            {
                MessageBox.Show("THERE IS NO CLIENT WITH SUCH ID ;(");
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AllClients clients=new AllClients();
            clients.Show();
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
