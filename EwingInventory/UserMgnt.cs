﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.IO;

namespace EwingInventory
{
    public partial class frm_users : Form
    {
        static Homepage home = new Homepage();
        MySqlConnection conn = new MySqlConnection(home.connString);
        public string currentUser = String.Empty;
        public string currentUseraccess = String.Empty;
        public string currentUID = "";
        public string imagepath = null;
        public string selectedUser = "";

        public frm_users()
        {
            InitializeComponent();
        }
        
        public void clearFields()
        {
            lbl_id.Text = "--";
            txt_fName.Text = "";
            txt_lName.Text = "";
            txt_nic.Text = "";
            txt_addr1.Text = "";
            txt_addr2.Text = "";
            txt_email.Text = "";
            txt_mob.Text = "";
            lbl_age.Text = "--";
            txt_user.Text = "";
            txt_pass.Text = "";

            dateBirth.Value = dateBirth.MaxDate;
            dateJoined.Value = dateJoined.MaxDate;

            cmb_access.Text ="";
            cmb_desig.Text = "";
            comboBox3.Text = "";
        }

        public void disableFields()
        {
            //Manage Fields
            txt_fName.Enabled = false;
            txt_lName.Enabled = false;
            txt_nic.Enabled = false;
            txt_addr1.Enabled = false;
            txt_addr2.Enabled = false;
            txt_email.Enabled = false;
            txt_mob.Enabled = false;
            txt_user.Enabled = false;
            txt_pass.Enabled = false;

            dateBirth.Enabled = false;
            dateJoined.Enabled = false;
            comboBox3.Enabled = false;
            cmb_access.Enabled = false;
            cmb_desig.Enabled = false;
            btn_save.Enabled = false;

            //Hide Invalid Lables
            lbl_validBasic.Visible = false;
            lbl_validContact.Visible = false;
            lbl_validDes.Visible = false;
            lbl_validEmail.Visible = false;
            lbl_validLog.Visible = false;
            
            //Request Fields
            lbl_leaveOn.Visible = false;
            lbl_nOdays.Visible = false;
            lbl_amount.Visible = false;
            reqDate.Visible = false;
            reqDays.Visible = false;
            reqAmt.Visible = false;
            button4.Visible = false;
        }

        public void enableFields()
        {
            txt_fName.Enabled = true;
            txt_lName.Enabled = true;
            txt_nic.Enabled = true;
            txt_addr1.Enabled = true;
            txt_addr2.Enabled = true;
            txt_email.Enabled = true;
            txt_mob.Enabled = true;
            txt_user.Enabled = true;
            txt_pass.Enabled = true;

            dateBirth.Enabled = true;
            dateJoined.Enabled = true;
            comboBox3.Enabled = true;
            cmb_access.Enabled = true;
            cmb_desig.Enabled = true;
            btn_save.Enabled = true;
        }

        public bool isFilled()
        {
            if (txt_fName.Text == "" || txt_lName.Text == "" || txt_nic.Text == "" || comboBox3.Text == "")
            {
                lbl_validBasic.Text = "*Please fill basic details";
                lbl_validBasic.Visible = true;
                return false;
            }
            else if (txt_user.Text == "" || txt_pass.Text == "" || cmb_access.Text == "")
            {
                lbl_validBasic.Visible = false;
                lbl_validLog.Text = "*Please fill login details";
                lbl_validLog.Visible = true;
                return false;
            }else if(cmb_desig.Text == "")
            {
                lbl_validBasic.Visible = false;
                lbl_validLog.Visible = false;
                lbl_desig.Text = "*Please select designation";
                return false;
            }
            else if (txt_addr1.Text == "" || txt_mob.Text == "" || txt_email.Text == "")
            {
                lbl_validBasic.Visible = false;
                lbl_validLog.Visible = false;
                lbl_validDes.Visible = false;
                lbl_validContact.Text = "*Please fill contact details";
                lbl_validContact.Visible = true;
                return false;
            }
            else
            {
                lbl_validBasic.Visible = false;
                lbl_validContact.Visible = false;
                lbl_validDes.Visible = false;
                lbl_validLog.Visible = false;
                return true;
            }
        }

        public bool isExist(string con)
        {
            string q = "SELECT * FROM staff WHERE uName='"+con+"';";
            bool o = false;
            MySqlCommand cmd = new MySqlCommand(q, conn);
            
            try
            {
                conn.Open();
                if (cmd.ExecuteNonQuery() > 0)
                {
                    conn.Close();
                    o = true;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                conn.Close();
            }

            return o;
        }

        bool isValidNIC(string nic)
        {
            bool r = true;
            if (nic != "")
            {
                if (nic.Length == 2)
                {
                    int year = Convert.ToInt32(nic);
                    if (year < 62 && year != 19)
                        r = false;
                }
                else if (nic.Length == 4)
                {
                    int year = Convert.ToInt32(nic);
                    if (year < 1962)
                        r = false;
                }
                else if (nic.Length == 10)
                {
                    if (!System.Text.RegularExpressions.Regex.IsMatch(nic, "^[0-9]{9}[xXvV]$") && !System.Text.RegularExpressions.Regex.IsMatch(nic, "^[0-9]{10}$"))
                        r = false;
                }
                else if (nic.Length == 12)
                {
                    if (!System.Text.RegularExpressions.Regex.IsMatch(nic, "^[0-9]{12}$"))
                        r = false;
                }
            }
            return r;
        }

        public void userDetails()
        {
            MySqlConnection conn = new MySqlConnection(home.connString);

            try
            {
                conn.Open();
                MySqlDataReader dr = null;
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM staff s, designation d WHERE s.desig = d.id AND s.uName = '"+this.currentUser+"';", conn);

                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    string[] dob = dr["dob"].ToString().Split(' ');
                    string[] db = dob[0].ToString().Split('-');

                    fullName.Text = dr["fName"].ToString()+" "+ dr["lName"].ToString();
                    designation.Text = dr["name"].ToString();
                    username.Text = dr["uName"].ToString();
                    leaves.Text = dr["leaves"].ToString();
                    txt_password.Text = dr["pass"].ToString();
                    pic_user.ImageLocation = dr["image"].ToString();

                    age.Text = (DateTime.Now.Year - Convert.ToInt32(db[0])).ToString();

                }
                conn.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void attDetails()
        {
            MySqlConnection conn = new MySqlConnection(home.connString);
            string[] date = DateTime.Now.Date.ToString().Split(' ');

            try
            {
                conn.Open();
                MySqlDataReader dr = null;
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM staff s, attendance a WHERE a.sId=s.sId AND a.date=CURDATE() AND s.sId='"+this.currentUID+"';", conn);

                dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    lblTi.Text = dr["inTime"].ToString().Substring(0,5);

                    if (dr["offTime"].ToString() == "")
                    {
                        lblTo.Text = "--";
                        btn_inOut.Text = "Out";
                        btn_inOut.Enabled = true;
                    }
                    else
                    {
                        lblTo.Text = dr["offTime"].ToString().Substring(0, 5);
                        btn_inOut.Enabled = false;
                        btn_inOut.Text = "Checked";
                    }
                }else
                {
                    lblTi.Text = "--";
                    lblTo.Text = "--";
                    btn_inOut.Text = "In";
                    btn_inOut.Enabled = true;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void frm_users_Load(object sender, EventArgs e)
        {
            if (this.currentUseraccess == "0")
            {
                //Administrator
                tab_user.TabPages.Remove(tabPage2); //MyAccount
                tab_user.TabPages.Remove(tabPage3); //Requests
                home.LoadToDatagridview(dgvStaff, "SELECT sId 'ID',fName 'NAME' FROM staff WHERE sId > 0");
                dgvStaff.Columns[0].Width = 20;
                home.fillCombo(cmb_desig, "SELECT name FROM designation WHERE id > 0;", "name");
            }
            else if(this.currentUseraccess == "2")
            {
                //User mode staff
                tab_user.TabPages.Remove(tabPage1);
                tab_user.TabPages.Remove(tabPage3);
                home.LoadToDatagridview(dgvRequest, "SELECT date, type, amount, status FROM requests WHERE sId=" + this.currentUID + ";");
                userDetails();
                attDetails();
            }
            else
            {
                //Admin mode staff
                home.LoadToDatagridview(dgvStaff, "SELECT sId 'ID',fName 'NAME' FROM staff WHERE sId > 0");
                home.fillCombo(cmb_desig, "SELECT name FROM designation WHERE id > 0;", "name");
                dgvStaff.Columns[0].Width = 20;
                home.LoadToDatagridview(dgvRequest, "SELECT date, type, amount, status FROM requests WHERE sId=" + this.currentUID + ";");
                home.LoadToDatagridview(dgvReqMg, "SELECT * FROM requests");
                userDetails();
                attDetails();
            }

            string w = Screen.FromControl(home).WorkingArea.Width.ToString();
            this.Location = new Point((Convert.ToInt32(w)-this.Width)/2,120);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            btn_clear.Enabled = true;
            disableFields();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!lbl_id.Text.Equals(""))
            {
                var opt = MessageBox.Show("Are you sure you want to close?\nAny modifications to the user will not be saved", "Confirm Clsoe", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                if (opt == DialogResult.OK)
                    this.Close();
            }
            else
                this.Close();
            
        }
        
        //Search Staff
        private void txt_serach_TextChanged(object sender, EventArgs e)
        {
            string filter = txt_serach.Text;
            home.LoadToDatagridview(dgvStaff, "SELECT sId,fName FROM staff WHERE fName like '%" + filter + "%'");
            dgvStaff.Columns[0].Width = 20;
        }

       
        
        private void dgvStaff_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btn_save.Text = "Edit";
            btn_save.Enabled = true;
            this.selectedUser = dgvStaff.SelectedCells[1].Value.ToString();
            string id = dgvStaff.SelectedCells[0].Value.ToString();
            
            MySqlConnection conn = new MySqlConnection(home.connString);

            try
            {
                conn.Open();
                MySqlDataReader dr = null;
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM staff WHERE sId =" + id + ";", conn);

                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    string[] a = dr["dob"].ToString().Split(' ');
                    string[] b = dr["joined"].ToString().Split(' ');

                    string[] dob = a[0].Split('-');
                    string[] dj = a[0].Split('-');

                    lbl_id.Text = dr["sId"].ToString();
                    lbl_age.Text = (DateTime.Now.Year - Convert.ToInt32(dob[0])).ToString();
                    txt_fName.Text = dr["fName"].ToString();
                    txt_lName.Text = dr["lName"].ToString();
                    txt_nic.Text = dr["nic"].ToString();
                    txt_addr1.Text = dr["add1"].ToString();
                    txt_addr2.Text = dr["add2"].ToString();
                    txt_mob.Text = dr["mob"].ToString();
                    txt_email.Text = dr["email"].ToString();
                    dateBirth.Value = new DateTime(Convert.ToInt32(dob[0]), Convert.ToInt32(dob[1]), Convert.ToInt32(dob[2]));
                    dateJoined.Value = new DateTime(Convert.ToInt32(dj[0]), Convert.ToInt32(dj[1]), Convert.ToInt32(dj[2]));
                    txt_user.Text = dr["uName"].ToString();
                    txt_pass.Text = dr["pass"].ToString();
                    
                    cmb_access.SelectedItem = cmb_access.Items[Convert.ToInt32(dr["access"].ToString())];
                    cmb_desig.SelectedItem = cmb_desig.Items[Convert.ToInt32(dr["desig"].ToString())];
                    comboBox3.SelectedItem = comboBox3.Items[Convert.ToInt32(dr["religion"].ToString())];

                }
                conn.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            string id = dgvStaff.SelectedCells[0].Value.ToString();
            var opt = DialogResult.Cancel;
            string ms, q;
            
            
            btn_clear.Text = "Clear";
            btn_clear.Enabled = true;

            if (btn_save.Text == "Edit")
            {
                enableFields();
                dgvStaff.Enabled = false;
                btn_clear.Text = "Clear";
                btn_save.Text = "Save";
            }else
            {
                if (isFilled())
                {
                    if(this.selectedUser.ToString() != txt_user.Text && home.isExist("SELECT uName FROM staff WHERE uName='"+txt_user.Text+"';"))
                    {
                        MessageBox.Show("Username already exist!", "Error");
                        txt_user.Focus();
                        txt_user.SelectAll();
                    }
                    else
                    {
                        if(btn_save.Text == "Add")
                        {
                            ms = "Added ";
                            opt = MessageBox.Show("Do you want to add new staff details?", "Confirm",MessageBoxButtons.OKCancel);
                            q = "INSERT INTO staff(uName,pass,fName,lName,add1,add2,religion,mob,email,nic,access,joined,dob,desig)"+
                                "VALUES(@uName,@pass,@fName,@lName,@add1,@add2,@religion,@mob,@email,@nic,@access,@joined,@dob,@desig)";
                        }
                        else
                        {
                            ms = "Modified ";
                            opt = MessageBox.Show("Do you want to modify staff details?", "Confirm",MessageBoxButtons.OKCancel);
                            q = "UPDATE staff SET uName=@uName, pass=@pass, fName=@fName, lName=@lName, add1=@add1, add2=@add2,"+
                                "religion=@religion, mob=@mob, email=@email, nic=@nic, access=@access,joined=@joined, dob=@dob, desig=@desig WHERE sId="+id+";";
                        }

                        if(opt == DialogResult.OK)
                        {
                            MySqlCommand cmd = new MySqlCommand(q, conn);

                            string[] db = dateBirth.Value.ToShortDateString().Split('-');
                            string[] dj = dateJoined.Value.ToShortDateString().Split('-');

                            cmd.Parameters.Add("@uName", MySqlDbType.VarChar).Value = txt_user.Text;
                            cmd.Parameters.Add("@pass", MySqlDbType.VarChar).Value = txt_pass.Text;
                            cmd.Parameters.Add("@fName", MySqlDbType.VarChar).Value = txt_fName.Text;
                            cmd.Parameters.Add("@lName", MySqlDbType.VarChar).Value = txt_lName.Text;
                            cmd.Parameters.Add("@add1", MySqlDbType.VarChar).Value = txt_addr1.Text;
                            cmd.Parameters.Add("@add2", MySqlDbType.VarChar).Value = txt_addr2.Text;
                            cmd.Parameters.Add("@religion", MySqlDbType.Int32).Value = comboBox3.SelectedIndex;
                            cmd.Parameters.Add("@mob", MySqlDbType.VarChar).Value = txt_mob.Text;
                            cmd.Parameters.Add("@email", MySqlDbType.VarChar).Value = txt_email.Text;
                            cmd.Parameters.Add("@nic", MySqlDbType.VarChar).Value = txt_nic.Text;
                            cmd.Parameters.Add("@access", MySqlDbType.Int32).Value = cmb_access.SelectedIndex;
                            cmd.Parameters.Add("@joined", MySqlDbType.Date).Value = new DateTime(Convert.ToInt32(dj[0]),Convert.ToInt32(dj[1]),Convert.ToInt32(dj[2]));
                            cmd.Parameters.Add("@dob", MySqlDbType.Date).Value = new DateTime(Convert.ToInt32(db[0]), Convert.ToInt32(db[1]), Convert.ToInt32(db[2])); ;
                            cmd.Parameters.Add("@desig", MySqlDbType.Int32).Value = cmb_desig.SelectedIndex+1;

                            try
                            {
                                conn.Open();
                                if(cmd.ExecuteNonQuery() > 0)
                                {
                                    MessageBox.Show("Staff details " + ms + " Successfully");
                                    btn_save.Enabled = false;
                                    clearFields();
                                    disableFields();
                                    dgvStaff.Enabled = true;
                                    this.selectedUser = "";
                                    btn_clear.Text = "New";
                                }

                            }catch(Exception ex)
                            {
                                MessageBox.Show(ex.ToString());
                            }
                            finally
                            {
                                conn.Close();
                                home.LoadToDatagridview(dgvStaff, "SELECT sId 'ID',fName 'NAME' FROM staff WHERE sId > 0");
                            }
                        }

                    }//Check Existing User
                }//Check Filled
                    
            }//Udate or Add


        }

        private void frm_users_MouseClick(object sender, MouseEventArgs e)
        {
            this.Focus();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int select = comboBox1.SelectedIndex;

            if(select == 0)
            {
                lbl_leaveOn.Visible = true;
                lbl_leaveOn.Text = "From";
                lbl_nOdays.Visible = true;
                lbl_nOdays.Text = "Days";
                lbl_amount.Visible = false;
                reqDate.Visible = true;
                reqDays.Visible = true;
                reqAmt.Visible = false;
                button4.Visible = true;
            }
            else if(select == 1)
            {
                lbl_leaveOn.Visible = true;
                lbl_nOdays.Visible = false;
                lbl_amount.Visible = false;
                reqDate.Visible = true;
                reqDays.Visible = false;
                reqAmt.Visible = false;
                button4.Visible = true;
            }
            else if(select == 2)
            {
                lbl_leaveOn.Visible = true;
                lbl_nOdays.Visible = false;
                lbl_amount.Visible = true;
                reqDate.Visible = true;
                reqDays.Visible = false;
                reqAmt.Visible = true;
                button4.Visible = true;
            }
            else if(select == 3)
            {
                lbl_leaveOn.Visible = false;
                lbl_nOdays.Visible = false;
                lbl_amount.Visible = true;
                reqDate.Visible = false;
                reqDays.Visible = false;
                reqAmt.Visible = true;
                button4.Visible = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image Files(*.jpg; *.jpeg; *.png; *.bmp)|*.jpg; *.jpeg; *.png; *.bmp";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                pic_user.Image = new Bitmap(ofd.FileName);
                string path = ofd.FileName;

                MySqlCommand cmd = new MySqlCommand("UPDATE staff SET image=@path WHERE sId='"+this.currentUID+"';",conn);
                cmd.Parameters.Add("@path", MySqlDbType.VarChar).Value = path;

                try
                {
                    conn.Open();
                    if(cmd.ExecuteNonQuery() == 1)
                    {
                        MessageBox.Show("Image Updated Successfully!");
                        userDetails();
                    }
                }catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            if (btn_clear.Text == "New")
            {
                btn_clear.Text = "Clear";
                dgvStaff.Enabled = false;
                btn_save.Text = "Add";
            }
            clearFields();
            enableFields();
        }

        private void txt_nic_TextChanged(object sender, EventArgs e)
        {
            if (!isValidNIC(txt_nic.Text))
            {
                txt_nic.Text = txt_nic.Text.Remove(txt_nic.Text.Length - 1);
                txt_nic.SelectionStart = txt_nic.Text.Length;
                MessageBox.Show("Invalid N.I.C Number!");
            }else
            {
                if(txt_nic.Text.Length == 2)
                {
                    int y = Convert.ToInt32(txt_nic.Text);
                    if (y > 62)
                        txt_nic.MaxLength = 10;
                    else
                        txt_nic.MaxLength = 12;
                }
            }
            
        }//end

        private void txt_mob_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(txt_mob.Text, "[^0-9]"))
            {
                MessageBox.Show("Invalid Mobie");
                txt_mob.Text = txt_mob.Text.Remove(txt_mob.Text.Length - 1);
                txt_mob.SelectionStart = txt_mob.Text.Length;
            }
        }

        private void txt_email_TextChanged(object sender, EventArgs e)
        {
            if (!home.isValidEmail(txt_email.Text))
            {
                lbl_validEmail.Text = "*Invalid Email ID";
                lbl_validEmail.Visible = true;
            }
            else
                lbl_validEmail.Visible = false;

        }

        private void btn_inOut_Click(object sender, EventArgs e)
        {
            string q,ms;
            try
            {
                if (btn_inOut.Text == "In")
                {
                    ms = "In";
                    q = "INSERT INTO attendance(date,sId,inTime) VALUES(CURDATE(),@sId,@inTime);";
                } else
                {
                    ms = "Out";
                    q = "UPDATE attendance SET offTime=@offTime, otHrs=@otHrs WHERE date=CURDATE() AND sId=@sId;";
                }

                MySqlCommand cmd = new MySqlCommand(q, conn);

                cmd.Parameters.Add("@sId", MySqlDbType.VarChar).Value = this.currentUID.ToString();

                if(btn_inOut.Text == "In")
                {
                    cmd.Parameters.Add("@inTime", MySqlDbType.VarChar).Value = DateTime.Now.ToShortTimeString();
                }
                else if(btn_inOut.Text == "Out")
                {
                    cmd.Parameters.Add("@offTime", MySqlDbType.VarChar).Value = DateTime.Now.ToShortTimeString();
                    cmd.Parameters.Add("@otHrs", MySqlDbType.VarChar).Value = "0";
                }

            
                conn.Open();
                
                if (cmd.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Checked " + ms + " Successfully");
                    attDetails();
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(txt_password.Text != "")
            {
                var rep = MessageBox.Show("Are you sure you want to change the password?", "Confirm",MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if(rep == DialogResult.OK)
                {
                    MySqlCommand cmd = new MySqlCommand("UPDATE staff SET pass=@pass WHERE sId='"+this.currentUID+"';",conn);
                    cmd.Parameters.Add("@pass", MySqlDbType.VarChar).Value = txt_password.Text;

                    try
                    {
                        conn.Open();
                        if(cmd.ExecuteNonQuery() == 1)
                        {
                            MessageBox.Show("Password updated successfully!");
                            userDetails();
                        }
                    }catch(Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    finally
                    {
                        conn.Close();
                    }
                }
            }
        }

        private void txt_password_TextChanged(object sender, EventArgs e)
        {
            if (txt_password.Text == "")
                button3.Enabled = false;
            else
                button3.Enabled = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string date = reqDate.Value.ToShortDateString();

            string q = "INSERT INTO requests VALUES(@sId,@date,@type,@amt,@st);";

            MySqlCommand cmd = new MySqlCommand(q, conn);
            cmd.Parameters.Add("@sId", MySqlDbType.Int32).Value = Convert.ToInt32(this.currentUID);
            cmd.Parameters.Add("@date",MySqlDbType.VarChar).Value = reqDate.Value.ToShortDateString();
            cmd.Parameters.Add("@type", MySqlDbType.Int32).Value = comboBox1.SelectedIndex;
            //cmd.Parameters.Add("@amt",MySqlDbType.Double).Value = ;
        }
    }
}
