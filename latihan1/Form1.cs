using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace latihan1
{
    public partial class Form1 : Form
    {
        latihan_1Entities1 entities = new latihan_1Entities1();
        public Form1()
        {
            InitializeComponent();
        }

        void validasi()
        {
            if(txtEmail.Text == "" || txtPass.Text == "")
            {
                MessageBox.Show("Email dan Password tidak boleh kosong!", "Validasi Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } else
            {
                login();
            } 
        }

        void login()
        {
            var user = entities.users.FirstOrDefault(u => u.email == txtEmail.Text && u.password == txtPass.Text);

            if(user != null)
            {
                new Form2().Show();
                this.Hide();
            } else
            {
                MessageBox.Show("Email atau password tidak ditemukan");
            }
        }


        private void btnLogin_Click(object sender, EventArgs e)
        {
            validasi();
        }

        private void btnToRegister_Click(object sender, EventArgs e)
        {
            new Register().Show();
            this.Hide();
        }
    }
}
