namespace StockManagement
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Tabs = new System.Windows.Forms.TabControl();
            this.Items = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.Uitems = new System.Windows.Forms.Button();
            this.MRP = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.NewLocation = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.SellingPrice = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.ItemCode = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.Description = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label21 = new System.Windows.Forms.Label();
            this.reason = new System.Windows.Forms.TextBox();
            this.ViewsAdjust = new System.Windows.Forms.Button();
            this.label20 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.Adjust = new System.Windows.Forms.Button();
            this.label17 = new System.Windows.Forms.Label();
            this.Nquantity = new System.Windows.Forms.TextBox();
            this.sacbox = new System.Windows.Forms.ComboBox();
            this.saclocation = new System.Windows.Forms.ComboBox();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.reordergrid = new System.Windows.Forms.DataGridView();
            this.set = new System.Windows.Forms.Button();
            this.reoderpoint = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.reordercbox = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.InventorydataGridView = new System.Windows.Forms.DataGridView();
            this.vsearchtext = new System.Windows.Forms.TextBox();
            this.vSearch = new System.Windows.Forms.Button();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.Tabs.SuspendLayout();
            this.Items.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.reordergrid)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.InventorydataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // Tabs
            // 
            this.Tabs.Controls.Add(this.Items);
            this.Tabs.Controls.Add(this.tabPage2);
            this.Tabs.Controls.Add(this.tabPage1);
            this.Tabs.Controls.Add(this.tabPage3);
            this.Tabs.Controls.Add(this.tabPage4);
            this.Tabs.Location = new System.Drawing.Point(2, 1);
            this.Tabs.Name = "Tabs";
            this.Tabs.SelectedIndex = 0;
            this.Tabs.Size = new System.Drawing.Size(971, 497);
            this.Tabs.TabIndex = 0;
            // 
            // Items
            // 
            this.Items.Controls.Add(this.label2);
            this.Items.Controls.Add(this.Uitems);
            this.Items.Controls.Add(this.MRP);
            this.Items.Controls.Add(this.label3);
            this.Items.Controls.Add(this.panel1);
            this.Items.Controls.Add(this.label8);
            this.Items.Controls.Add(this.SellingPrice);
            this.Items.Controls.Add(this.comboBox1);
            this.Items.Controls.Add(this.ItemCode);
            this.Items.Controls.Add(this.label5);
            this.Items.Controls.Add(this.label4);
            this.Items.Controls.Add(this.label1);
            this.Items.Controls.Add(this.label22);
            this.Items.Controls.Add(this.button2);
            this.Items.Controls.Add(this.Description);
            this.Items.Location = new System.Drawing.Point(4, 22);
            this.Items.Name = "Items";
            this.Items.Padding = new System.Windows.Forms.Padding(3);
            this.Items.Size = new System.Drawing.Size(963, 471);
            this.Items.TabIndex = 0;
            this.Items.Text = "Items";
            this.Items.UseVisualStyleBackColor = true;
            this.Items.Click += new System.EventHandler(this.Items_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Cambria", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label2.Location = new System.Drawing.Point(9, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(263, 23);
            this.label2.TabIndex = 60;
            this.label2.Text = "Add New Items to Inventory";
            // 
            // Uitems
            // 
            this.Uitems.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.Uitems.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Uitems.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.Uitems.Location = new System.Drawing.Point(636, 31);
            this.Uitems.Name = "Uitems";
            this.Uitems.Size = new System.Drawing.Size(254, 48);
            this.Uitems.TabIndex = 59;
            this.Uitems.Text = "View/Update/Delete Items";
            this.Uitems.UseVisualStyleBackColor = false;
            this.Uitems.Click += new System.EventHandler(this.Uitems_Click);
            // 
            // MRP
            // 
            this.MRP.Location = new System.Drawing.Point(197, 187);
            this.MRP.Name = "MRP";
            this.MRP.Size = new System.Drawing.Size(172, 20);
            this.MRP.TabIndex = 58;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label3.Location = new System.Drawing.Point(61, 186);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 19);
            this.label3.TabIndex = 57;
            this.label3.Text = "MRP";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.NewLocation);
            this.panel1.Location = new System.Drawing.Point(636, 177);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(194, 170);
            this.panel1.TabIndex = 56;
            this.panel1.Visible = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Cambria", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label7.Location = new System.Drawing.Point(40, 18);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(120, 22);
            this.label7.TabIndex = 6;
            this.label7.Text = "New Location";
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.button3.Font = new System.Drawing.Font("Calibri", 12F);
            this.button3.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.button3.Location = new System.Drawing.Point(23, 99);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(105, 49);
            this.button3.TabIndex = 7;
            this.button3.Text = "Enter";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // NewLocation
            // 
            this.NewLocation.Location = new System.Drawing.Point(23, 58);
            this.NewLocation.Name = "NewLocation";
            this.NewLocation.Size = new System.Drawing.Size(159, 20);
            this.NewLocation.TabIndex = 8;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Cambria", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label8.Location = new System.Drawing.Point(19, -23);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(263, 23);
            this.label8.TabIndex = 51;
            this.label8.Text = "Add New Items to Inventory";
            // 
            // SellingPrice
            // 
            this.SellingPrice.Location = new System.Drawing.Point(197, 147);
            this.SellingPrice.Name = "SellingPrice";
            this.SellingPrice.Size = new System.Drawing.Size(172, 20);
            this.SellingPrice.TabIndex = 50;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(197, 111);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(172, 21);
            this.comboBox1.TabIndex = 49;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // ItemCode
            // 
            this.ItemCode.Location = new System.Drawing.Point(197, 71);
            this.ItemCode.Name = "ItemCode";
            this.ItemCode.Size = new System.Drawing.Size(172, 20);
            this.ItemCode.TabIndex = 48;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label5.Location = new System.Drawing.Point(61, 147);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 19);
            this.label5.TabIndex = 47;
            this.label5.Text = "Selling Price";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label4.Location = new System.Drawing.Point(61, 109);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 19);
            this.label4.TabIndex = 46;
            this.label4.Text = "Location";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label1.Location = new System.Drawing.Point(61, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 19);
            this.label1.TabIndex = 45;
            this.label1.Text = "Item Code";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label22.Location = new System.Drawing.Point(61, 234);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(83, 19);
            this.label22.TabIndex = 54;
            this.label22.Text = "Description";
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.button2.Font = new System.Drawing.Font("Calibri", 12F);
            this.button2.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.button2.Location = new System.Drawing.Point(259, 284);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(105, 46);
            this.button2.TabIndex = 44;
            this.button2.Text = "Add";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Description
            // 
            this.Description.Location = new System.Drawing.Point(197, 233);
            this.Description.Name = "Description";
            this.Description.Size = new System.Drawing.Size(172, 20);
            this.Description.TabIndex = 55;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label21);
            this.tabPage2.Controls.Add(this.reason);
            this.tabPage2.Controls.Add(this.ViewsAdjust);
            this.tabPage2.Controls.Add(this.label20);
            this.tabPage2.Controls.Add(this.label19);
            this.tabPage2.Controls.Add(this.label18);
            this.tabPage2.Controls.Add(this.Adjust);
            this.tabPage2.Controls.Add(this.label17);
            this.tabPage2.Controls.Add(this.Nquantity);
            this.tabPage2.Controls.Add(this.sacbox);
            this.tabPage2.Controls.Add(this.saclocation);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(963, 471);
            this.tabPage2.TabIndex = 0;
            this.tabPage2.Text = "Stock Adjustment";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Calibri", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(149, 56);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(158, 24);
            this.label21.TabIndex = 24;
            this.label21.Text = "Stock Adjustment";
            this.label21.Click += new System.EventHandler(this.label21_Click);
            // 
            // reason
            // 
            this.reason.Location = new System.Drawing.Point(431, 307);
            this.reason.Name = "reason";
            this.reason.Size = new System.Drawing.Size(148, 20);
            this.reason.TabIndex = 23;
            // 
            // ViewsAdjust
            // 
            this.ViewsAdjust.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ViewsAdjust.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ViewsAdjust.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.ViewsAdjust.Location = new System.Drawing.Point(681, 56);
            this.ViewsAdjust.Name = "ViewsAdjust";
            this.ViewsAdjust.Size = new System.Drawing.Size(199, 38);
            this.ViewsAdjust.TabIndex = 21;
            this.ViewsAdjust.Text = "View Stock Adjustments";
            this.ViewsAdjust.UseVisualStyleBackColor = false;
            this.ViewsAdjust.Click += new System.EventHandler(this.ViewsAdjust_Click);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(277, 310);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(57, 19);
            this.label20.TabIndex = 22;
            this.label20.Text = "Reason";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(277, 195);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(73, 19);
            this.label19.TabIndex = 14;
            this.label19.Text = "Item code";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(277, 232);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(64, 19);
            this.label18.TabIndex = 15;
            this.label18.Text = "Location";
            // 
            // Adjust
            // 
            this.Adjust.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.Adjust.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Adjust.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.Adjust.Location = new System.Drawing.Point(504, 356);
            this.Adjust.Name = "Adjust";
            this.Adjust.Size = new System.Drawing.Size(75, 65);
            this.Adjust.TabIndex = 20;
            this.Adjust.Text = "Adjust";
            this.Adjust.UseVisualStyleBackColor = false;
            this.Adjust.Click += new System.EventHandler(this.Adjust_Click);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(277, 271);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(98, 19);
            this.label17.TabIndex = 16;
            this.label17.Text = "New Quantity";
            // 
            // Nquantity
            // 
            this.Nquantity.Location = new System.Drawing.Point(431, 268);
            this.Nquantity.Name = "Nquantity";
            this.Nquantity.Size = new System.Drawing.Size(149, 20);
            this.Nquantity.TabIndex = 19;
            // 
            // sacbox
            // 
            this.sacbox.FormattingEnabled = true;
            this.sacbox.Location = new System.Drawing.Point(431, 192);
            this.sacbox.Name = "sacbox";
            this.sacbox.Size = new System.Drawing.Size(149, 21);
            this.sacbox.TabIndex = 17;
            // 
            // saclocation
            // 
            this.saclocation.FormattingEnabled = true;
            this.saclocation.Location = new System.Drawing.Point(431, 229);
            this.saclocation.Name = "saclocation";
            this.saclocation.Size = new System.Drawing.Size(149, 21);
            this.saclocation.TabIndex = 18;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.reordergrid);
            this.tabPage1.Controls.Add(this.set);
            this.tabPage1.Controls.Add(this.reoderpoint);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.label9);
            this.tabPage1.Controls.Add(this.reordercbox);
            this.tabPage1.Controls.Add(this.label10);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(963, 471);
            this.tabPage1.TabIndex = 1;
            this.tabPage1.Text = "Set Re-Order Level";
            this.tabPage1.UseVisualStyleBackColor = true;
            this.tabPage1.Click += new System.EventHandler(this.tabPage1_Click);
            // 
            // reordergrid
            // 
            this.reordergrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.reordergrid.Location = new System.Drawing.Point(405, 55);
            this.reordergrid.Name = "reordergrid";
            this.reordergrid.Size = new System.Drawing.Size(401, 290);
            this.reordergrid.TabIndex = 18;
            this.reordergrid.MouseClick += new System.Windows.Forms.MouseEventHandler(this.reordergrid_MouseClick);
            // 
            // set
            // 
            this.set.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.set.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.set.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.set.Location = new System.Drawing.Point(223, 214);
            this.set.Name = "set";
            this.set.Size = new System.Drawing.Size(89, 30);
            this.set.TabIndex = 17;
            this.set.Text = "Set";
            this.set.UseVisualStyleBackColor = false;
            this.set.Click += new System.EventHandler(this.set_Click);
            // 
            // reoderpoint
            // 
            this.reoderpoint.Location = new System.Drawing.Point(213, 149);
            this.reoderpoint.Name = "reoderpoint";
            this.reoderpoint.Size = new System.Drawing.Size(121, 20);
            this.reoderpoint.TabIndex = 16;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(71, 148);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(100, 19);
            this.label6.TabIndex = 15;
            this.label6.Text = "ReOrder Point";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(70, 23);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(169, 26);
            this.label9.TabIndex = 14;
            this.label9.Text = "Set ReOrder Level";
            // 
            // reordercbox
            // 
            this.reordercbox.FormattingEnabled = true;
            this.reordercbox.Location = new System.Drawing.Point(213, 100);
            this.reordercbox.Name = "reordercbox";
            this.reordercbox.Size = new System.Drawing.Size(121, 21);
            this.reordercbox.TabIndex = 13;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(71, 99);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(73, 19);
            this.label10.TabIndex = 12;
            this.label10.Text = "Item code";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.InventorydataGridView);
            this.tabPage3.Controls.Add(this.vsearchtext);
            this.tabPage3.Controls.Add(this.vSearch);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(963, 471);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "View Inventory";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // InventorydataGridView
            // 
            this.InventorydataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.InventorydataGridView.Location = new System.Drawing.Point(86, 75);
            this.InventorydataGridView.Name = "InventorydataGridView";
            this.InventorydataGridView.Size = new System.Drawing.Size(724, 362);
            this.InventorydataGridView.TabIndex = 5;
            // 
            // vsearchtext
            // 
            this.vsearchtext.Location = new System.Drawing.Point(585, 29);
            this.vsearchtext.Name = "vsearchtext";
            this.vsearchtext.Size = new System.Drawing.Size(212, 20);
            this.vsearchtext.TabIndex = 4;
            // 
            // vSearch
            // 
            this.vSearch.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.vSearch.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.vSearch.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.vSearch.Location = new System.Drawing.Point(813, 6);
            this.vSearch.Name = "vSearch";
            this.vSearch.Size = new System.Drawing.Size(75, 62);
            this.vSearch.TabIndex = 3;
            this.vSearch.Text = "Search";
            this.vSearch.UseVisualStyleBackColor = false;
            this.vSearch.Click += new System.EventHandler(this.vSearch_Click);
            // 
            // tabPage4
            // 
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(963, 471);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Reports";
            this.tabPage4.UseVisualStyleBackColor = true;
            this.tabPage4.Click += new System.EventHandler(this.tabPage4_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(968, 472);
            this.Controls.Add(this.Tabs);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Tabs.ResumeLayout(false);
            this.Items.ResumeLayout(false);
            this.Items.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.reordergrid)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.InventorydataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl Tabs;
        private System.Windows.Forms.TabPage Items;
        private System.Windows.Forms.Button Uitems;
        private System.Windows.Forms.TextBox MRP;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox NewLocation;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox SellingPrice;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TextBox ItemCode;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox Description;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox reason;
        private System.Windows.Forms.Button ViewsAdjust;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Button Adjust;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox Nquantity;
        private System.Windows.Forms.ComboBox sacbox;
        private System.Windows.Forms.ComboBox saclocation;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView reordergrid;
        private System.Windows.Forms.Button set;
        private System.Windows.Forms.TextBox reoderpoint;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox reordercbox;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.DataGridView InventorydataGridView;
        private System.Windows.Forms.TextBox vsearchtext;
        private System.Windows.Forms.Button vSearch;
    }
}

