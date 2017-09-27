using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using EwingInventory;

namespace StockManagement
{
    public partial class Form1 : Form
    {
        static string myConnection = "Server=localhost;Database=inventory;Uid=root;Pwd=;";
        MySqlConnection con = new MySqlConnection(myConnection);
        MySqlCommand cmd;
        DataTable dt = new DataTable();
        MySqlDataAdapter adapter;
        Homepage home = new Homepage();
        public Form1()
        {
            InitializeComponent();
              //view Inventory grid
            InventorydataGridView.ColumnCount = 6;
            InventorydataGridView.Columns[0].Name = "itemCode";
            InventorydataGridView.Columns[1].Name = "Location";
            InventorydataGridView.Columns[2].Name = "sellingPrice";
            InventorydataGridView.Columns[3].Name = "MRP";
            InventorydataGridView.Columns[4].Name = "Discription";
            InventorydataGridView.Columns[5].Name = "quantity";


            InventorydataGridView.Columns[0].Width = 115;
            InventorydataGridView.Columns[1].Width = 115;
            InventorydataGridView.Columns[2].Width = 115;
            InventorydataGridView.Columns[3].Width = 115;
            InventorydataGridView.Columns[4].Width = 115;
            InventorydataGridView.Columns[5].Width = 115;
            //dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnMode.Fill;

            InventorydataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            InventorydataGridView.MultiSelect = false;
            InventorydataGridView.Rows.Clear();

            string sql = "select itemCode,Location,sellingPrice,MRP,Discription,quantity from item,stock where item.itemCode=stock.itemCodes ";
            cmd = new MySqlCommand(sql, con);

            try
            {
                con.Open();
                adapter = new MySqlDataAdapter(sql, con);
                adapter.Fill(dt);

                foreach (DataRow row in dt.Rows)
                {
                    populate05(row[0].ToString(), row[1].ToString(), row[2].ToString(), row[3].ToString(), row[4].ToString(), row[5].ToString());
                }

                con.Close();
                dt.Rows.Clear();
            }
            catch (Exception exception)
            { MessageBox.Show(exception.Message); }
            
            
            //load ReOrderLevelGrid
            DataTable dtx = new DataTable();
            cmd = con.CreateCommand();
            cmd.CommandText = "Select itemCode from item";
            try
            {
                con.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                reordercbox.Items.Clear();
                while (reader.Read())
                {
                    reordercbox.Items.Add(reader["itemCode"]);

                }
                con.Close();
            }
            catch (Exception e)
            { MessageBox.Show(e.Message); }

            //Load table
            reordergrid.ColumnCount = 2;
            reordergrid.Columns[0].Name = "itemCode";
            reordergrid.Columns[1].Name = "ReOrder_Level";
            
            reordergrid.Columns[0].Width = 180;
            reordergrid.Columns[1].Width = 180;


            //
            reordergrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            reordergrid.MultiSelect = false;
            reordergrid.Rows.Clear();

            string mmsql = "select * from reorderlevel";
            cmd = new MySqlCommand(mmsql, con);

            try
            {
                con.Open();
                adapter = new MySqlDataAdapter(mmsql, con);
                adapter.Fill(dtx);

                foreach (DataRow row in dtx.Rows)
                {
                    populate03(row[0].ToString(), row[1].ToString());
                }

                con.Close();
                dtx.Rows.Clear();
            }
            catch (Exception exception)
            { MessageBox.Show(exception.Message); }

            //load stock adjustment tab
            cmd = con.CreateCommand();
            cmd.CommandText = "Select itemCode from item";
            try
            {
                con.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                sacbox.Items.Clear();
                while (reader.Read())
                {
                    sacbox.Items.Add(reader["itemCode"]);

                }
                con.Close();
            }
            catch (Exception e)
            { MessageBox.Show(e.Message); }


            //

            cmd.CommandText = "Select location from location";
            try
            {
                con.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                saclocation.Items.Clear();
                while (reader.Read())
                {
                    saclocation.Items.Add(reader["location"]);

                }
                con.Close();
            }
            catch (Exception e)
            { MessageBox.Show(e.Message); }
            //load location to combo box1 
            cmd = con.CreateCommand();
            cmd.CommandText = "Select location from location";
            try
            {
                con.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                comboBox1.Items.Clear();
                while (reader.Read())
                {
                    comboBox1.Items.Add(reader["location"]);

                }
                con.Close();
            }
            catch (Exception e)
            { MessageBox.Show(e.Message); }
        }

        public void refresh() {

            comboBox1.Items.Add("Add New Location");
            //view Inventory grid
            InventorydataGridView.ColumnCount = 6;
            InventorydataGridView.Columns[0].Name = "itemCode";
            InventorydataGridView.Columns[1].Name = "Location";
            InventorydataGridView.Columns[2].Name = "sellingPrice";
            InventorydataGridView.Columns[3].Name = "MRP";
            InventorydataGridView.Columns[4].Name = "Discription";
            InventorydataGridView.Columns[5].Name = "quantity";

            //dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnMode.Fill;

            InventorydataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            InventorydataGridView.MultiSelect = false;
            InventorydataGridView.Rows.Clear();

            string sql = "select itemCode,Location,sellingPrice,MRP,Discription,quantity from item,stock where item.itemCode=stock.itemCodes ";
            cmd = new MySqlCommand(sql, con);

            try
            {
                con.Open();
                adapter = new MySqlDataAdapter(sql, con);
                adapter.Fill(dt);

                foreach (DataRow row in dt.Rows)
                {
                    populate05(row[0].ToString(), row[1].ToString(), row[2].ToString(), row[3].ToString(), row[4].ToString(), row[5].ToString());
                }

                con.Close();
                dt.Rows.Clear();
            }
            catch (Exception exception)
            { MessageBox.Show(exception.Message); }


            //load ReOrderLevelGrid
            DataTable dtx = new DataTable();
            cmd = con.CreateCommand();
            cmd.CommandText = "Select itemCode from item";
            try
            {
                con.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                reordercbox.Items.Clear();
                while (reader.Read())
                {
                    reordercbox.Items.Add(reader["itemCode"]);

                }
                con.Close();
            }
            catch (Exception e)
            { MessageBox.Show(e.Message); }

            //Load table
            reordergrid.ColumnCount = 2;
            reordergrid.Columns[0].Name = "itemCode";
            reordergrid.Columns[1].Name = "ReOrder_Level";


            //
            reordergrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            reordergrid.MultiSelect = false;
            reordergrid.Rows.Clear();

            string mmsql = "select * from reorderlevel";
            cmd = new MySqlCommand(mmsql, con);

            try
            {
                con.Open();
                adapter = new MySqlDataAdapter(mmsql, con);
                adapter.Fill(dtx);

                foreach (DataRow row in dtx.Rows)
                {
                    populate03(row[0].ToString(), row[1].ToString());
                }

                con.Close();
                dtx.Rows.Clear();
            }
            catch (Exception exception)
            { MessageBox.Show(exception.Message); }

            //load stock adjustment tab
            cmd = con.CreateCommand();
            cmd.CommandText = "Select itemCode from item";
            try
            {
                con.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                sacbox.Items.Clear();
                while (reader.Read())
                {
                    sacbox.Items.Add(reader["itemCode"]);

                }
                con.Close();
            }
            catch (Exception e)
            { MessageBox.Show(e.Message); }


            //

            cmd.CommandText = "Select location from location";
            try
            {
                con.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                saclocation.Items.Clear();
                while (reader.Read())
                {
                    saclocation.Items.Add(reader["location"]);

                }
                con.Close();
            }
            catch (Exception e)
            { MessageBox.Show(e.Message); }
            //load location to combo box1 
            cmd = con.CreateCommand();
            cmd.CommandText = "Select location from location";
            try
            {
                con.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                comboBox1.Items.Clear();
                while (reader.Read())
                {
                    comboBox1.Items.Add(reader["location"]);

                }
                con.Close();
            }
            catch (Exception e)
            { MessageBox.Show(e.Message); }
        
        
        }
        private void populate03(string itemCode, string ReOrder_Level)
        {

            reordergrid.Rows.Add(itemCode, ReOrder_Level);
        }
        private void Items_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //empty the textBoxes
            ItemCode.Text = "";
            comboBox1.SelectedItem = "";
            SellingPrice.Text = "";
            MRP.Text = "";
            Description.Text = "";
            //add to item table 
            string sql = "INSERT INTO `item` (`itemCode`,`Location`,`sellingPrice`,`MRP`,`Discription`) VALUES ('" + ItemCode.Text + "','" + comboBox1.SelectedItem + "','" + SellingPrice.Text + "','" + MRP.Text + "','" + Description.Text + "')";
            cmd = new MySqlCommand(sql, con);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();

                MessageBox.Show("Successfully Item Added");

                con.Close();

            }
            catch (Exception except)
            { 
            con.Close();
            }


            int x = 0;
            //add to reorder table
            sql = "INSERT INTO `reorderlevel` (`itemCode`,`reOrderPoint`) VALUES ('" + ItemCode.Text + "','" + x + "')";
            cmd = new MySqlCommand(sql, con);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();


                con.Close();

            }
            catch (Exception except)
            {
         
            con.Close();
            }
            //add to stock table

            sql = "INSERT INTO `stock` (`quantity`,`itemCodes`) VALUES ('" + x + "','" + ItemCode.Text + "')";
            cmd = new MySqlCommand(sql, con);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();


                con.Close();

            }
            catch (Exception except)
            {
                MessageBox.Show("Please Input correct data to correct fields"); //,"Errer", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                
                con.Close();
            }


            refresh();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("Add New Location");
            string w = Screen.FromControl(home).WorkingArea.Width.ToString();
            this.Location = new Point((Convert.ToInt32(w) - this.Width) / 2, 120);
            FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text.Equals("Add New Location"))
            {

                panel1.Visible = true;

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string sql = "INSERT INTO `location` (`location`) VALUES ('" + NewLocation.Text + "')";
            cmd = new MySqlCommand(sql, con);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();

                MessageBox.Show("Successfully Location Added");

                con.Close();

            }
            catch (Exception except)
            { MessageBox.Show(except.Message); }

            //reload the combo box

            cmd = con.CreateCommand();
            cmd.CommandText = "Select location from location";
            try
            {
                con.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                comboBox1.Items.Clear();
                while (reader.Read())
                {
                    comboBox1.Items.Add(reader["location"]);

                }
                con.Close();
            }
            catch (Exception eee)
            { MessageBox.Show(eee.Message); }
            refresh();
        }

        private void Uitems_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.TopLevel = true;
            f2.Show();
            f2.Owner = this;

        }
       
        private void Adjust_Click(object sender, EventArgs e)
        {




            if (string.IsNullOrWhiteSpace(sacbox.Text)&& string.IsNullOrWhiteSpace(Nquantity.Text) ) 

            {  MessageBox.Show("Input correct data to all fields"); }
            else
              if (!Nquantity.Text.All(char.IsDigit)) { MessageBox.Show("Input Numeric Values for New Qty Field"); }
            else
            {
               



                        cmd = con.CreateCommand();
                        cmd.CommandText = "Select itemCode from item";
                        try
                        {
                            con.Open();
                            MySqlDataReader reader = cmd.ExecuteReader();
                            sacbox.Items.Clear();
                            while (reader.Read())
                            {
                                sacbox.Items.Add(reader["itemCode"]);

                            }
                            con.Close();
                        }
                        catch (Exception exx)
                        {
                            con.Close();
                            MessageBox.Show("Please Input correct data to correct fields");
                        }


                        //

                        cmd.CommandText = "Select location from location";
                        try
                        {
                            con.Open();
                            MySqlDataReader reader = cmd.ExecuteReader();
                            saclocation.Items.Clear();
                            while (reader.Read())
                            {
                                saclocation.Items.Add(reader["location"]);

                            }
                            con.Close();
                        }
                        catch (Exception ecc)
                        { MessageBox.Show(ecc.Message); }
                        refresh();

                        //Insert data to stock adjustment table

                        //get the curent qty
                        string query = " Select quantity from stock where itemCodes like'" + sacbox.Text + "'";
                        string qty;
                        con.Open();
                        cmd = new MySqlCommand(query, con);
                        qty = cmd.ExecuteScalar().ToString();
                        con.Close();
                        int cq = System.Convert.ToInt32(qty);
                        //get the new qty
                        int nq = System.Convert.ToInt32(Nquantity.Text);
                        //get the qty lost
                        int lq = cq - nq;

                        //add to item table 
                        string sql = "INSERT INTO `stockadjustments` (`Date`,`itemCode`,`NewQuantity`,`PreviousQuantity`,`quantityLost`,reason,Location) VALUES (CURRENT_TIMESTAMP,'" + sacbox.Text + "','" + nq + "','" + cq + "','" + lq + "','" + reason.Text + "','" + saclocation.SelectedItem + "')";
                        cmd = new MySqlCommand(sql, con);
                        try
                        {
                            con.Open();
                            cmd.ExecuteNonQuery();

                            MessageBox.Show("Successfully Stock Adjust Added");

                            con.Close();

                        }
                        catch (Exception except)
                        {
                            MessageBox.Show(except.Message);
                            con.Close();
                        }

                        //update the stock table
                        sql = "update stock set quantity='" + nq + "' where itemCodes='" + sacbox.Text + "'";
                        cmd = new MySqlCommand(sql, con);

                        try
                        {
                            con.Open();
                            adapter = new MySqlDataAdapter(cmd);
                            adapter.UpdateCommand = con.CreateCommand();
                            adapter.UpdateCommand.CommandText = sql;

                            if (adapter.UpdateCommand.ExecuteNonQuery() > 0)

                            { MessageBox.Show("Successfully Updated !"); }
                            con.Close();
                        }
                        catch (Exception ex)
                        {
                            con.Close();
                            MessageBox.Show("Please Input correct data to correct fields");
                        }
                        //empty the textBoxes
                        sacbox.Text = "";
                        saclocation.Text = "";
                        Nquantity.Text = "";
                        reason.Text = "";
                 
                }
        }

        private void ViewsAdjust_Click(object sender, EventArgs e)
        {
            ViewStockAdjustment vsa = new ViewStockAdjustment();
            vsa.Show();
            vsa.TopLevel = true;
            vsa.Owner = this;
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void set_Click(object sender, EventArgs e)
        {
            DataTable dtx = new DataTable();
            string mmsql = "update reorderlevel set reOrderPoint='" + reoderpoint.Text + "' where itemCode ='" + reordercbox.Text + "'";
            cmd = new MySqlCommand(mmsql, con);

            try
            {
                con.Open();
                adapter = new MySqlDataAdapter(cmd);
                adapter.UpdateCommand = con.CreateCommand();
                adapter.UpdateCommand.CommandText = mmsql;

                if (adapter.UpdateCommand.ExecuteNonQuery() > 0)

                { MessageBox.Show("Successfully Updated !"); }
                con.Close();
            }
            catch (Exception ex)
            {
               
                MessageBox.Show("Please Input correct data to correct fields");
                con.Close();
            }
            //load table
            reordergrid.ColumnCount = 2;
            reordergrid.Columns[0].Name = "itemCode";
            reordergrid.Columns[1].Name = "ReOrder_Level";


            //
            reordergrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            reordergrid.MultiSelect = false;
            reordergrid.Rows.Clear();

            string msql = "select * from reorderlevel";
            cmd = new MySqlCommand(mmsql, con);

            try
            {
                con.Open();
                adapter = new MySqlDataAdapter(msql, con);
                adapter.Fill(dtx);

                foreach (DataRow row in dtx.Rows)
                {
                    populate03(row[0].ToString(), row[1].ToString());
                }

                con.Close();
                dtx.Rows.Clear();
            }
            catch (Exception exception)
            { MessageBox.Show(exception.Message); }

            refresh();
        }

        private void reordergrid_MouseClick(object sender, MouseEventArgs e)
        {
            reordercbox.Text = reordergrid.SelectedRows[0].Cells[0].Value.ToString();
            reoderpoint.Text = reordergrid.SelectedRows[0].Cells[1].Value.ToString();
        
        }

        private void vSearch_Click(object sender, EventArgs e)
        {
            InventorydataGridView.ColumnCount = 6;
            InventorydataGridView.Columns[0].Name = "itemCode";
            InventorydataGridView.Columns[1].Name = "Location";
            InventorydataGridView.Columns[2].Name = "sellingPrice";
            InventorydataGridView.Columns[3].Name = "MRP";
            InventorydataGridView.Columns[4].Name = "Discription";
            InventorydataGridView.Columns[5].Name = "quantity";

            //dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnMode.Fill;

            InventorydataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            InventorydataGridView.MultiSelect = false;
            InventorydataGridView.Rows.Clear();

            string sql = "select itemCode,Location,sellingPrice,MRP,Discription,quantity from item,stock where item.itemCode=stock.itemCodes  and (item.itemCode like '%" + vsearchtext.Text + "%' OR item.Location like '%" + vsearchtext.Text + "%' OR item.sellingPrice like '%" + vsearchtext.Text + "%' OR item.MRP like '%" + vsearchtext.Text + "%' OR item.Discription like '%" + vsearchtext.Text + "%' )";
            cmd = new MySqlCommand(sql, con);

            try
            {
                con.Open();
                adapter = new MySqlDataAdapter(sql, con);
                adapter.Fill(dt);

                foreach (DataRow row in dt.Rows)
                {
                    populate05(row[0].ToString(), row[1].ToString(), row[2].ToString(), row[3].ToString(), row[4].ToString(), row[5].ToString());
                }

                con.Close();
                dt.Rows.Clear();
            }
            catch (Exception exception)
            { MessageBox.Show(exception.Message); }
        }
        private void populate05(string itemcode, string Location, string sellingPrice, string MRP, string Discription, string quantity)
        {

            InventorydataGridView.Rows.Add(itemcode, Location, sellingPrice, MRP, Discription, quantity);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //get the curent qty
            string query = " Select quantity from stock where itemCodes like'" + sacbox.SelectedItem + "'";
            string qty;
            con.Open();
            cmd = new MySqlCommand(query, con);
            qty = cmd.ExecuteScalar().ToString();
            con.Close();
            MessageBox.Show(qty);
            int cq = System.Convert.ToInt32(qty);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void label21_Click(object sender, EventArgs e)
        {

        }

        private void tabPage4_Click(object sender, EventArgs e)
        {

        }
    }
}
