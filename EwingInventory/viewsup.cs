using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
namespace Supplier
{
    public partial class viewsup : Form
    {
        static string myConnection = "Server=localhost;Database=inventory;Uid=root;Pwd=;";
        MySqlConnection myconn = new MySqlConnection(myConnection);
        MySqlCommand cmd;
        MySqlDataAdapter adapter;
        DataTable dt = new DataTable();
        public viewsup()
        {
            
            InitializeComponent();
            dataGridView1.ColumnCount = 5;
            dataGridView1.Columns[0].Name = "SupplierName";
            dataGridView1.Columns[1].Name = "Nic";
            dataGridView1.Columns[2].Name = "Phone";
            dataGridView1.Columns[3].Name = "Fax";
            dataGridView1.Columns[4].Name = "E-mail";
            
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
            dataGridView1.Rows.Clear();
             string sql = "select Name,Nic,Phone,fax,email from supplier  ";
            
            cmd = new MySqlCommand(sql, myconn);

            try
            {
                myconn.Open();
                adapter = new MySqlDataAdapter(sql, myconn);
                adapter.Fill(dt);

                foreach (DataRow row in dt.Rows)
                {
                    populate(row[0].ToString(), row[1].ToString(), row[2].ToString(), row[3].ToString(), row[4].ToString());
                }

                myconn.Close();
                dt.Rows.Clear();
            }
            catch (Exception exception)
            { MessageBox.Show(exception.Message); }
        }
        private void populate(string SupplierName, string Nic, string Phone, string Fax, string E_mail)
        {

            dataGridView1.Rows.Add(SupplierName, Nic, Phone, Fax, E_mail);
        }
        private void viewsup_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.ColumnCount = 5;
            dataGridView1.Columns[0].Name = "SupplierName";
            dataGridView1.Columns[1].Name = "Nic";
            dataGridView1.Columns[2].Name = "Phone";
            dataGridView1.Columns[3].Name = "Fax";
            dataGridView1.Columns[4].Name = "E-mail";

            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
            dataGridView1.Rows.Clear();


             string sql = "select Name,Nic,Phone,fax,email from supplier where Name like '%" + textBox1.Text + "%'  ";
            
            cmd = new MySqlCommand(sql, myconn);

            try
            {
                myconn.Open();
                adapter = new MySqlDataAdapter(sql, myconn);
                adapter.Fill(dt);

                foreach (DataRow row in dt.Rows)
                {
                    populate(row[0].ToString(), row[1].ToString(), row[2].ToString(), row[3].ToString(), row[4].ToString());
                }

                myconn.Close();
                dt.Rows.Clear();
            }
            catch (Exception exception)
            { MessageBox.Show(exception.Message); }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            {
                if (MessageBox.Show("Are You Sure To Exit?", "Exit", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    Application.Exit();
                }
            }
        }
    }
}
