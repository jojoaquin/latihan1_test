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
    public partial class Form2 : Form
    {
        latihan_1Entities1 entities = new latihan_1Entities1();
        public Form2()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        void validasi()
        {
            if(int.TryParse(txtPhone.Text, out int result))
            {
                MessageBox.Show("Berhasil");
            } else
            {
                MessageBox.Show("Phone tidak boleh ada huruf");
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            validasi();
        }

        void addButtonDeleteEdit()
        {
            var btnEdit = new DataGridViewButtonColumn();
            btnEdit.UseColumnTextForButtonValue = true;
            btnEdit.Text = "Edit";
            dataGridView1.Columns.Add(btnEdit);

            var btnDelete = new DataGridViewButtonColumn();
            btnDelete.UseColumnTextForButtonValue = true;
            btnDelete.Text = "Delete";
            dataGridView1.Columns.Add(btnDelete);
        }

        void addComboBox()
        {
            // comboBox1.Items.Clear();
            comboBox1.Items.Add("email");
            comboBox1.Items.Add("username");
        }

       

        private void Form2_Load(object sender, EventArgs e)
        {
            var users = entities.users.Select(u => u);
            txtEmail.Enabled = false;

            dataGridView1.DataSource = users.ToList();

            addButtonDeleteEdit();
            addComboBox();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if(comboBox1.Text == "email")
            {
                var result = entities.users.Where(u => u.email.Contains(txtSearch.Text));

                dataGridView1.DataSource = result.ToList();
            } else if(comboBox1.Text == "username")
            {
                var result = entities.users.Where(u => u.username.Contains(txtSearch.Text));

                dataGridView1.DataSource = result.ToList();
            }
            
        }
    }
}
