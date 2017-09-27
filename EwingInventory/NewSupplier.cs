using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Text.RegularExpressions;
using EwingInventory;


namespace Supplier
{
    public partial class sup : Form
    {
        static string myConnection = "Server=localhost;Database=inventory;Uid=root;Pwd=;";
        
        MySqlConnection con = new MySqlConnection(myConnection);
        MySqlCommand cmd;
        MySqlDataAdapter adapter;
        DataTable dt = new DataTable();
        DataTable dt1 = new DataTable();
        public sup()
        {


            {   //if the user chooses card credit or cash in purchase order
                InitializeComponent();
                payM.Items.Add("Card");
                payM.Items.Add("Cheque");
                payM.Items.Add("Cash");

                //loading payment History

                paymentHis.ColumnCount = 6; //
                paymentHis.Columns[0].Name = "Name";
                paymentHis.Columns[1].Name = "Total";
                paymentHis.Columns[2].Name = "Payment Amount";
                paymentHis.Columns[3].Name = "Payment Method";
                paymentHis.Columns[4].Name = "Balance";
                paymentHis.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                paymentHis.MultiSelect = false;
                paymentHis.Rows.Clear();
                string sql = "select * from orders";
                cmd = new MySqlCommand(sql, con);

                try
                {
                    con.Open();
                    adapter = new MySqlDataAdapter(sql, con);
                    adapter.Fill(dt);

                    foreach (DataRow row in dt.Rows)
                    {
                        populate1(row[0].ToString(), row[1].ToString(), row[2].ToString(), row[3].ToString(), row[4].ToString());
                    }

                    con.Close();
                    dt.Rows.Clear();
                }
                catch (Exception exception)
                { MessageBox.Show(exception.Message); }

                //Load the update inventory table once the page is opned

                uptable.ColumnCount = 2;
                uptable.Columns[0].Name = "ItemCode";
                uptable.Columns[1].Name = "Quantity";



                uptable.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                uptable.MultiSelect = false;
                uptable.Rows.Clear();
                 string osql = "select itemCodes,quantity from stock";
                cmd = new MySqlCommand(osql, con);

                try
                {
                    con.Open();
                    adapter = new MySqlDataAdapter(osql, con);
                    adapter.Fill(dt1);

                    foreach (DataRow row in dt1.Rows)
                    {
                        populate2(row[0].ToString(), row[1].ToString());
                    }

                    con.Close();
                    dt1.Rows.Clear();
                }
                catch (Exception exception)
                { MessageBox.Show(exception.Message); }

                //load the item code to combo box in updating inventory
                cmd = con.CreateCommand();
                cmd.CommandText = "Select itemCodes from stock";
                try
                {
                    con.Open();
                    MySqlDataReader reader = cmd.ExecuteReader();
                    comboBox1.Items.Clear();
                    while (reader.Read())
                    {
                        comboBox1.Items.Add(reader[("itemCodes")]);

                    }
                    con.Close();
                }
                catch (Exception e)
                { MessageBox.Show(e.Message); }

                //load the item code to combo box in purchase order
                /////////////////////////////////////////////////////////////////////

                cmd = con.CreateCommand();
                cmd.CommandText = "Select itemCodes from stock";
                try
                {
                    con.Open();
                    MySqlDataReader reader = cmd.ExecuteReader();
                    ItemCode.Items.Clear();
                    while (reader.Read())
                    {
                        ItemCode.Items.Add(reader[("itemCodes")]);

                    }
                    con.Close();
                }
                catch (Exception e)
                { MessageBox.Show(e.Message); }




                //load the supplier name to combo box in purchase order 
                cmd = con.CreateCommand();
                cmd.CommandText = "Select Name from supplier";
                try
                {
                    con.Open();
                    MySqlDataReader reader = cmd.ExecuteReader();
                    textBox1.Items.Clear();
                    while (reader.Read())
                    {
                        textBox1.Items.Add(reader[("Name")]);

                    }
                    con.Close();
                }
                catch (Exception e)
                { MessageBox.Show(e.Message); }




            }


            








        }



     
        private void populate1(string Name, string Total, string Payment_Amount, string Payment_Method, string Balance)
        {
            paymentHis.Rows.Add(Name, Total, Payment_Amount, Payment_Method, Balance);
        }

        




        private void button2_Click(object sender, EventArgs e) // pop out of update sup in sup manipulation
        {
            updateSupplier us = new updateSupplier();
            us.Show();
            us.TopLevel = true;
            us.Owner = this;
        }

        private void button3_Click(object sender, EventArgs e) //pop out of delete sup in sup manipulation
        {
            Delete d = new Delete();
            d.Show();
            d.TopLevel = true;
            d.Owner = this;
        }

        private void button10_Click(object sender, EventArgs e) //pop out of view sup list in sup manipulation
        {
            viewsup vs = new viewsup();
            vs.Show();
            vs.TopLevel = true;
            vs.Owner = this;
        }
        string wordcount = "";
        private void button1_Click(object sender, EventArgs e)

        {
            //nic validation
            //string str = Snic.Text;
            //if ((str.Count(char.IsDigit) == 9) && (str.EndsWith("V", StringComparison.OrdinalIgnoreCase)))
            //{
                //email validation
                if (!Regex.IsMatch(email.Text, @"^[a-z,A-Z]{1,10}((-|.)\w+)*@\w+.\w{3}$"))


                {
                    MessageBox.Show("Please enter a valid email address");
                    email.Text = "";
                }
                else
                {
                    //inserting values to the database
                    string sql = "INSERT INTO `supplier` (`Name`,`Nic`,`Phone`,`fax`,`email`) VALUES ('" + supName.Text + "','" + Snic.Text + "','" + sphone.Text + "','" + fax.Text + "','" + email.Text + "')";
                    cmd = new MySqlCommand(sql, con);
                    try
                    {
                        con.Open();
                        cmd.ExecuteNonQuery();

                        MessageBox.Show(" New Supplier Added Successfully");

                        con.Close();

                    }
                    catch (Exception except)
                    {
                        MessageBox.Show(except.ToString());
                            
                           MessageBox.Show("Input correct data to All fields"); con.Close(); }

                    // clear text as soon as it is finsh submitting
                    supName.Text = "";
                    Snic.Text = "";
                    sphone.Text = "";
                    fax.Text = "";
                    email.Text = "";
                }
            
            //else
            //{
              //  MessageBox.Show("Invalid NIC");
            //}
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            //get the total
            int total = 0;
            string tot = "";
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (dataGridView1.Rows[i].Cells["Quantity"].Value == null && dataGridView1.Rows[i].Cells["ItemCode"].Value == null)
                {
                }
                else
                {
                    string quan = dataGridView1.Rows[i].Cells["Quantity"].Value.ToString();
                    int q = Int32.Parse(quan);
                    string upr = dataGridView1.Rows[i].Cells["UnitPrice"].Value.ToString();
                    int up = Int32.Parse(upr);
                    total = total + (q * up);
                }
            }
            tot = total + tot;
            this.tot.Text = tot;

            //get the balance

            int balance = total - Int32.Parse(pamount.Text);



            MySqlCommand cmd;
            //insert data to order table
            string sql = "INSERT INTO `orders` (`sname`,`total`,`pamount`,`pmethod`,`balance`) VALUES ('" + textBox1.Text + "','" + tot + "','" + pamount.Text + "','" + payM.Text + "','" + balance + "')";
            cmd = new MySqlCommand(sql, con);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

            }
            catch (Exception except)
            { MessageBox.Show(except.Message); }

            //get the order no

            string query = " Select ono from orders where sname like'" + textBox1.Text + "' and total like'" + total + "' and pamount like'" + pamount.Text + "' and pamount like'" + pamount.Text + "' and balance like'" + balance + "'";
            string ono = "";
            con.Open();
            cmd = new MySqlCommand(query, con);
            ono = cmd.ExecuteScalar().ToString();


            con.Close();
            int orderno = System.Convert.ToInt32(ono);

            //sending values to database from data grid
            for (int i = 0; i < dataGridView1.Rows.Count; i++)

            {
                //string sql = "insert into test values(" +dataGridView1.Rows[i].Cells["ItemCode"].Value+ "," + dataGridView1.Rows[i].Cells["Quantity"].Value + "," + dataGridView1.Rows[i].Cells["UnitPrice"].Value + "," + dataGridView1.Rows[i].Cells["SubTotal"].Value + "";
                sql = "INSERT INTO `oitems` (`ItemCode`,`Quantity`,`UnitPrice`,`ono`) VALUES ('" + dataGridView1.Rows[i].Cells["ItemCode"].Value + "','" + dataGridView1.Rows[i].Cells["Quantity"].Value + "','" + dataGridView1.Rows[i].Cells["UnitPrice"].Value + "','" + ono + "')";

                try
                {
                    con.Open();
                    using (MySqlCommand comm = new MySqlCommand(sql, con))
                    { comm.ExecuteNonQuery(); }
                    con.Close();
                }
                catch (Exception de)
                { MessageBox.Show(de.Message); }

            }
            MessageBox.Show("Order Successfull !");



        }

        private void button8_Click(object sender, EventArgs e)
        {
            supName.Text = "";
            tot.Text = "";
            pamount.Text = "";
            payM.Text = "";
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(comboBox1.Text) && string.IsNullOrWhiteSpace(addqty.Text))
            { MessageBox.Show("Input corect data to fields! "); }
            else
            {
                if (!addqty.Text.All(char.IsDigit)) { MessageBox.Show("Input Numeric Values for Qty"); }
                else
                {
                    //GET THE CURRENT STOCK QUANTITY FROM THE DATABASE
                    string query = " Select quantity from stock where itemCodes like'" + comboBox1.Text + "'";
                    string qty;
                    con.Open();
                    cmd = new MySqlCommand(query, con);
                    qty = cmd.ExecuteScalar().ToString();
                    con.Close();
                    int q = System.Convert.ToInt32(qty);
                    //GET THE ADDING QUANTITY

                    int a = System.Convert.ToInt32(addqty.Text);
                    int tot = q + a;
                    //update the new value

                    string sql = "update stock set quantity='" + tot + "' where itemCodes='" + comboBox1.Text + "' ";
                    cmd = new MySqlCommand(sql, con);

                    try
                    {
                        con.Open();
                        adapter = new MySqlDataAdapter(cmd);
                        adapter.UpdateCommand = con.CreateCommand();
                        adapter.UpdateCommand.CommandText = sql;

                        if (adapter.UpdateCommand.ExecuteNonQuery() > 0)
                        {
                            MessageBox.Show("Successfully Updated!");
                        }
                        con.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        con.Close();

                    }
                    ic.Text = "";
                    addqty.Text = "";
                    uptable.ColumnCount = 2;
                    uptable.Columns[0].Name = "ItemCode";
                    uptable.Columns[1].Name = "Quantity";



                    uptable.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    uptable.MultiSelect = false;
                    uptable.Rows.Clear();
                    sql = "select itemCodes,quantity from stock";
                    cmd = new MySqlCommand(sql, con);

                    try
                    {
                        con.Open();
                        adapter = new MySqlDataAdapter(sql, con);
                        adapter.Fill(dt1);

                        foreach (DataRow row in dt1.Rows)
                        {
                            populate2(row[0].ToString(), row[1].ToString());
                        }

                        con.Close();
                        dt1.Rows.Clear();
                    }
                    catch (Exception exception)
                    { MessageBox.Show(exception.Message); }
                }
            }
        }

        private void populate2(string ItemCode, string Quantity)
        {
            uptable.Rows.Add(ItemCode, Quantity);
        }


        private void tabPage5_Click(object sender, EventArgs e)
        {

        }

        private void tabPage6_Click(object sender, EventArgs e)
        {

        }

        private void paymentHis_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            {
                if (MessageBox.Show("Are You Sure To Exit?", "Exit", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    Application.Exit();
                }
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are You Sure To Exit?", "Exit", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                Application.Exit();
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are You Sure To Exit?", "Exit", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                Application.Exit();
            }
        }

        private void Close_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are You Sure To Exit?", "Exit", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                Application.Exit();
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are You Sure To Exit?", "Exit", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                Application.Exit();
            }
        }

        private void supName_TextChanged(object sender, EventArgs e)
        {

        }

        private void sup_Load(object sender, EventArgs e)
        {
            Homepage home = new Homepage();
            string w = (Screen.FromControl(home).WorkingArea.Width.ToString());
            this.Location = new Point((Convert.ToInt32(w) - this.Width) / 2, 120);
            FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void sphone_TextChanged(object sender, EventArgs e)
        {
            

        }

        private void sphone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) || char.IsPunctuation(e.KeyChar) || char.IsSymbol(e.KeyChar) || (sphone.Text.Length < 0 || sphone.Text.Length > 11))
             
            { e.Handled = true; }

        else
            { e.Handled = false; }
        }

        private void fax_TextChanged(object sender, EventArgs e)
        {

        }

        private void fax_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) || char.IsPunctuation(e.KeyChar) || char.IsSymbol(e.KeyChar) || (fax.Text.Length < 0 || fax.Text.Length > 11))
            { e.Handled = true; }

            else
            { e.Handled = false; }
        }

        private void supName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || char.IsPunctuation(e.KeyChar) || char.IsSymbol(e.KeyChar))
            { e.Handled = true; }

            else
            { e.Handled = false; }
        }

        private void email_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void pamount_TextChanged(object sender, EventArgs e)
        {

        }

        private void Snic_TextChanged(object sender, EventArgs e)
        {

        }

        private void tot_MouseClick(object sender, MouseEventArgs e)
        {
            
        }

        private void button9_Click_1(object sender, EventArgs e)
        {
            int total = 0;
            string tot = "";
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (dataGridView1.Rows[i].Cells["Quantity"].Value == null && dataGridView1.Rows[i].Cells["ItemCode"].Value == null)
                {
                }
                else
                {
                    string quan = dataGridView1.Rows[i].Cells["Quantity"].Value.ToString();
                    int q = Int32.Parse(quan);
                    string upr = dataGridView1.Rows[i].Cells["UnitPrice"].Value.ToString();
                    int up = Int32.Parse(upr);
                    total = total + (q * up);
                }
            }
            tot = total + tot;
            this.tot.Text = tot;
        }

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }

        private void Snic_KeyPress(object sender, KeyPressEventArgs e)
        {

        }
    }

    internal class Response
    {
        internal static void Write(string v)
        {
            throw new NotImplementedException();
        }
    }
}

