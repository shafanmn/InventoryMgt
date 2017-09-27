using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using EwingInventory;

namespace StockManagement
{
    public partial class Form2 : Form
    {
        static string myConnection = "Server=localhost;Database=inventory;Uid=root;Pwd=;";
        MySqlConnection myconn = new MySqlConnection(myConnection);
        MySqlCommand cmd;
        MySqlDataAdapter adapter;

        DataTable dt = new DataTable();

        Homepage home = new Homepage();
        public Form2()
        {
            InitializeComponent();
            

         

        //data grid updates
        updatesitems.ColumnCount = 5;
        updatesitems.Columns[0].Name = "itemCode";
        updatesitems.Columns[1].Name = "Location";
        updatesitems.Columns[2].Name = "sellingPrice";
        updatesitems.Columns[3].Name = "MRP";
        updatesitems.Columns[4].Name = "Discription";

        //
        updatesitems.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        updatesitems.MultiSelect = false;
        updatesitems.Rows.Clear();

        string sql = "select itemCode,Location,sellingPrice,MRP,Discription from item";
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
            //load values for delete combo

        cmd = myconn.CreateCommand();
        cmd.CommandText = "Select itemCode,Discription from item";
        try
        {
            myconn.Open();
            MySqlDataReader reader = cmd.ExecuteReader();
            comboBox1.Items.Clear();
            //
            DataTable dt = new DataTable();
            while (reader.Read())
            {
                comboBox1.Items.Add(reader["itemCode"]);
                //comboBox1.Items.Add(reader["itemCode"].ToString() + reader["Discription"].ToString());

            }
            myconn.Close();
        }
        catch (Exception e)
        { MessageBox.Show(e.Message); }


            //data grid for view
        isearchgrid.ColumnCount = 5;
        isearchgrid.Columns[0].Name = "itemCode";
        isearchgrid.Columns[1].Name = "Location";
        isearchgrid.Columns[2].Name = "sellingPrice";
        isearchgrid.Columns[3].Name = "MRP";
        isearchgrid.Columns[4].Name = "Discription";


        isearchgrid.Columns[0].Width = 149;
        isearchgrid.Columns[1].Width = 149;
        isearchgrid.Columns[2].Width = 149;
        isearchgrid.Columns[3].Width = 149;
        isearchgrid.Columns[4].Width = 149;

        isearchgrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        isearchgrid.MultiSelect = false;
        isearchgrid.Rows.Clear();

        string msql = "select itemCode,Location,sellingPrice,MRP,Discription from item  ";
        cmd = new MySqlCommand(msql, myconn);
        try
        {
            myconn.Open();
            adapter = new MySqlDataAdapter(msql, myconn);
            adapter.Fill(dt);

            foreach (DataRow row in dt.Rows)
            {
                populate02(row[0].ToString(), row[1].ToString(), row[2].ToString(), row[3].ToString(), row[4].ToString());
            }

            myconn.Close();
            dt.Rows.Clear();
        }
        catch (Exception exception)
        {
            MessageBox.Show(exception.Message);
        }


        }
        private void populate(string itemcode, string Location, string sellingPrice, string MRP, string Discription)
        {

            updatesitems.Rows.Add(itemcode, Location, sellingPrice, MRP, Discription);
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }
        private void populate02(string itemcode, string Location, string sellingPrice, string MRP, string Discription)
        {

            isearchgrid.Rows.Add(itemcode, Location, sellingPrice, MRP, Discription);
        }
        private void button9_Click(object sender, EventArgs e)
        {
            //update
            string sql = "update item set Location='" + Location.Text + "',sellingPrice='" + SellingPr.Text + "',MRP='" + MRP.Text + "',Discription='" + Discription.Text + "' where itemCode='" + iCode.Text + "'";
            cmd = new MySqlCommand(sql, myconn);

            try
            {
                myconn.Open();
                adapter = new MySqlDataAdapter(cmd);
                adapter.UpdateCommand = myconn.CreateCommand();
                adapter.UpdateCommand.CommandText = sql;

                if (adapter.UpdateCommand.ExecuteNonQuery() > 0)

                { MessageBox.Show("Successfully Updated !"); }
                myconn.Close();
            }
            catch (Exception ex)
            {
                myconn.Close();
                MessageBox.Show("Please Input correct data to correct fields");
            }

            //empty the textBoxes
            iCode.Text = "";
            Location.Text = "";
            Discription.Text = "";
            SellingPr.Text = "";
            MRP.Text = "";

            //reload the tabel
            updatesitems.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            updatesitems.MultiSelect = false;
            updatesitems.Rows.Clear();

            string msql = "select itemCode,Location,sellingPrice,MRP,Discription from item";
            cmd = new MySqlCommand(msql, myconn);

            try
            {
                myconn.Open();
                adapter = new MySqlDataAdapter(msql, myconn);
                adapter.Fill(dt);

                foreach (DataRow row in dt.Rows)
                {
                    populate(row[0].ToString(), row[1].ToString(), row[2].ToString(), row[3].ToString(), row[4].ToString());
                }

                myconn.Close();
                dt.Rows.Clear();
            }
            catch (Exception exception)
            { MessageBox.Show(exception.Message);

           
            }

            refresh01();

        }

        private void updatesitems_MouseClick(object sender, MouseEventArgs e)
        {

            iCode.Text = updatesitems.SelectedRows[0].Cells[0].Value.ToString();
            Location.Text = updatesitems.SelectedRows[0].Cells[1].Value.ToString();
            SellingPr.Text = updatesitems.SelectedRows[0].Cells[2].Value.ToString();
            MRP.Text = updatesitems.SelectedRows[0].Cells[3].Value.ToString();
            Discription.Text = updatesitems.SelectedRows[0].Cells[4].Value.ToString();


            cmd = myconn.CreateCommand();
            cmd.CommandText = "Select location from location";
            try
            {
                myconn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                Location.Items.Clear();
                while (reader.Read())
                {
                    Location.Items.Add(reader["location"]);

                }
                myconn.Close();
            }
            catch (Exception exx)
            { MessageBox.Show(exx.Message); }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            string sql = "DELETE from item where itemCode='" + comboBox1.SelectedItem + "'";
            cmd = new MySqlCommand(sql, myconn);
            try
            {
                myconn.Open();
                adapter = new MySqlDataAdapter(cmd);
                adapter.DeleteCommand = myconn.CreateCommand();
                adapter.DeleteCommand.CommandText = sql;

                if (MessageBox.Show("Sure you want to delete ?", "DELETE", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                {
                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        MessageBox.Show("Successfully deleted!"); }

                }
                myconn.Close();
            }
            catch (Exception a)
            {
                MessageBox.Show("Connection Error!");
                MessageBox.Show(a.Message);
            }

            // delete from the stock

            sql = "DELETE from stock where itemCodes='" + comboBox1.SelectedItem + "'";
            cmd = new MySqlCommand(sql, myconn);
            try
            {
                myconn.Open();
                adapter = new MySqlDataAdapter(cmd);
                adapter.DeleteCommand = myconn.CreateCommand();
                adapter.DeleteCommand.CommandText = sql;
                cmd.ExecuteNonQuery();

                myconn.Close();
            }
            catch (Exception a)
            {
                MessageBox.Show("Connection Error!");
                MessageBox.Show(a.Message);
            }
            // delete from the reorder level

            sql = "DELETE from reorderlevel where itemCode='" + comboBox1.SelectedItem + "'";
            cmd = new MySqlCommand(sql, myconn);
            try
            {
                myconn.Open();
                adapter = new MySqlDataAdapter(cmd);
                adapter.DeleteCommand = myconn.CreateCommand();
                adapter.DeleteCommand.CommandText = sql;
                cmd.ExecuteNonQuery();

                myconn.Close();
            }
            catch (Exception a)
            {
                MessageBox.Show("Connection Error!");
                MessageBox.Show(a.Message);
            }

            //reload the combobox
            cmd = myconn.CreateCommand();
            cmd.CommandText = "Select itemCode,Discription from item";
            try
            {
                myconn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                comboBox1.Items.Clear();
                //
                DataTable dt = new DataTable();
                while (reader.Read())
                {
                    comboBox1.Items.Add(reader["itemCode"]);
                    //comboBox1.Items.Add(reader["itemCode"].ToString() + reader["Discription"].ToString());

                }
                myconn.Close();
            }
            catch (Exception xe)
            { MessageBox.Show(xe.Message); }

            refresh01();
        }

        private void iSearch_Click(object sender, EventArgs e)
        {
            isearchgrid.ColumnCount = 5;
            isearchgrid.Columns[0].Name = "itemCode";
            isearchgrid.Columns[1].Name = "Location";
            isearchgrid.Columns[2].Name = "sellingPrice";
            isearchgrid.Columns[3].Name = "MRP";
            isearchgrid.Columns[4].Name = "Discription";


            //dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnMode.Fill;

            isearchgrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            isearchgrid.MultiSelect = false;
            isearchgrid.Rows.Clear();

            string sql = "select itemCode,Location,sellingPrice,MRP,Discription from item where item.itemCode like '%" + itemSearch.Text + "%' OR item.Location like '%" + itemSearch.Text + "%' OR item.sellingPrice like '%" + itemSearch.Text + "%' OR item.MRP like '%" + itemSearch.Text + "%' OR item.Discription like '%" + itemSearch.Text + "%' ";
            cmd = new MySqlCommand(sql, myconn);

            try
            {
                myconn.Open();
                adapter = new MySqlDataAdapter(sql, myconn);
                adapter.Fill(dt);

                foreach (DataRow row in dt.Rows)
                {
                    populate02(row[0].ToString(), row[1].ToString(), row[2].ToString(), row[3].ToString(), row[4].ToString());
                }

                myconn.Close();
                dt.Rows.Clear();
            }
            catch (Exception exception)
            { MessageBox.Show(exception.Message); }
        }
        public void refresh01()
        {
            //data grid updates
            updatesitems.ColumnCount = 5;
            updatesitems.Columns[0].Name = "itemCode";
            updatesitems.Columns[1].Name = "Location";
            updatesitems.Columns[2].Name = "sellingPrice";
            updatesitems.Columns[3].Name = "MRP";
            updatesitems.Columns[4].Name = "Discription";

            //
            updatesitems.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            updatesitems.MultiSelect = false;
            updatesitems.Rows.Clear();

            string sql = "select itemCode,Location,sellingPrice,MRP,Discription from item";
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
            //load values for delete combo

            cmd = myconn.CreateCommand();
            cmd.CommandText = "Select itemCode,Discription from item";
            try
            {
                myconn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                comboBox1.Items.Clear();
                //
                DataTable dt = new DataTable();
                while (reader.Read())
                {
                    comboBox1.Items.Add(reader["itemCode"]);
                    //comboBox1.Items.Add(reader["itemCode"].ToString() + reader["Discription"].ToString());

                }
                myconn.Close();
            }
            catch (Exception e)
            { MessageBox.Show(e.Message); }


            //data grid for view
            isearchgrid.ColumnCount = 5;
            isearchgrid.Columns[0].Name = "itemCode";
            isearchgrid.Columns[1].Name = "Location";
            isearchgrid.Columns[2].Name = "sellingPrice";
            isearchgrid.Columns[3].Name = "MRP";
            isearchgrid.Columns[4].Name = "Discription";
            isearchgrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            isearchgrid.MultiSelect = false;
            isearchgrid.Rows.Clear();

            string msql = "select itemCode,Location,sellingPrice,MRP,Discription from item  ";
            cmd = new MySqlCommand(msql, myconn);
            try
            {
                myconn.Open();
                adapter = new MySqlDataAdapter(msql, myconn);
                adapter.Fill(dt);

                foreach (DataRow row in dt.Rows)
                {
                    populate02(row[0].ToString(), row[1].ToString(), row[2].ToString(), row[3].ToString(), row[4].ToString());
                }

                myconn.Close();
                dt.Rows.Clear();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            //string w = Screen.FromControl(home).WorkingArea.Width.ToString();
            //this.Location = new Point((Convert.ToInt32(w) - this.Width) / 2, 120);
            //FormBorderStyle = FormBorderStyle.FixedSingle;
        }
        
    }
}
