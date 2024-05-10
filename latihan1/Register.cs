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
    public partial class Register : Form
    {

        latihan_1Entities1 entities = new latihan_1Entities1();
        public Register()
        {
            InitializeComponent();
        }

        private void btnBackToLogin_Click(object sender, EventArgs e)
        {
            new Form1().Show();
            this.Hide();
        }

        void register()
        {
            if(txtEmail.Text == "" || txtPass.Text == "" || txtUsername.Text == "")
            {
                MessageBox.Show("Data tidak boleh kosong");
            } else
            {
                var user = new user();
                user.email = txtEmail.Text;
                user.password = txtPass.Text;
                user.username = txtUsername.Text;
                entities.users.Add(user);
                entities.SaveChanges();

                MessageBox.Show("Selamat, anda sudah terdaftar!");

                txtEmail.Text = "";
                txtUsername.Text = "";
                txtPass.Text = "";
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            register();
        }
    }
}
