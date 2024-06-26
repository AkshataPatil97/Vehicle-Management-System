namespace WindowsFormsApplication1
{
    partial class Admin_hp
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
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.customerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.employeeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manufacturerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.partDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.billingDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.billDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.orderDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.analyticsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.reportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.customerReportsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.employeeReportsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manufacturerRepotsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.orderReportsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.partReportsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.serviceReportsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.billingReportsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutUsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logOutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Constantia", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(419, 296);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(350, 39);
            this.label1.TabIndex = 14;
            this.label1.Text = "Vehicle Repair System";
            this.label1.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.LightCoral;
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.Left;
            this.menuStrip1.Font = new System.Drawing.Font("Modern No. 20", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.customerToolStripMenuItem,
            this.employeeToolStripMenuItem,
            this.manufacturerToolStripMenuItem,
            this.partDetailsToolStripMenuItem,
            this.billingDetailsToolStripMenuItem,
            this.analyticsToolStripMenuItem1,
            this.reportToolStripMenuItem,
            this.aboutUsToolStripMenuItem,
            this.logOutToolStripMenuItem});
            this.menuStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Table;
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(212, 612);
            this.menuStrip1.TabIndex = 12;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // customerToolStripMenuItem
            // 
            this.customerToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.customerToolStripMenuItem.Name = "customerToolStripMenuItem";
            this.customerToolStripMenuItem.Size = new System.Drawing.Size(170, 25);
            this.customerToolStripMenuItem.Text = "Customer Details";
            this.customerToolStripMenuItem.Click += new System.EventHandler(this.customerToolStripMenuItem_Click);
            // 
            // employeeToolStripMenuItem
            // 
            this.employeeToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.employeeToolStripMenuItem.Name = "employeeToolStripMenuItem";
            this.employeeToolStripMenuItem.Size = new System.Drawing.Size(175, 25);
            this.employeeToolStripMenuItem.Text = "Employee Details";
            this.employeeToolStripMenuItem.Click += new System.EventHandler(this.employeeToolStripMenuItem_Click);
            // 
            // manufacturerToolStripMenuItem
            // 
            this.manufacturerToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.manufacturerToolStripMenuItem.Name = "manufacturerToolStripMenuItem";
            this.manufacturerToolStripMenuItem.Size = new System.Drawing.Size(210, 25);
            this.manufacturerToolStripMenuItem.Text = "Manufacturer Details";
            this.manufacturerToolStripMenuItem.Click += new System.EventHandler(this.manufacturerToolStripMenuItem_Click);
            // 
            // partDetailsToolStripMenuItem
            // 
            this.partDetailsToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.partDetailsToolStripMenuItem.Name = "partDetailsToolStripMenuItem";
            this.partDetailsToolStripMenuItem.Size = new System.Drawing.Size(129, 25);
            this.partDetailsToolStripMenuItem.Text = "Part Details";
            this.partDetailsToolStripMenuItem.Click += new System.EventHandler(this.partDetailsToolStripMenuItem_Click);
            // 
            // billingDetailsToolStripMenuItem
            // 
            this.billingDetailsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.billDetailsToolStripMenuItem,
            this.orderDetailsToolStripMenuItem});
            this.billingDetailsToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.billingDetailsToolStripMenuItem.Name = "billingDetailsToolStripMenuItem";
            this.billingDetailsToolStripMenuItem.Size = new System.Drawing.Size(154, 25);
            this.billingDetailsToolStripMenuItem.Text = "Billing Details";
            this.billingDetailsToolStripMenuItem.Click += new System.EventHandler(this.billingDetailsToolStripMenuItem_Click);
            // 
            // billDetailsToolStripMenuItem
            // 
            this.billDetailsToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.billDetailsToolStripMenuItem.Name = "billDetailsToolStripMenuItem";
            this.billDetailsToolStripMenuItem.Size = new System.Drawing.Size(192, 26);
            this.billDetailsToolStripMenuItem.Text = "Bill details";
            this.billDetailsToolStripMenuItem.Click += new System.EventHandler(this.billDetailsToolStripMenuItem_Click);
            // 
            // orderDetailsToolStripMenuItem
            // 
            this.orderDetailsToolStripMenuItem.Name = "orderDetailsToolStripMenuItem";
            this.orderDetailsToolStripMenuItem.Size = new System.Drawing.Size(192, 26);
            this.orderDetailsToolStripMenuItem.Text = "Order details";
            this.orderDetailsToolStripMenuItem.Click += new System.EventHandler(this.orderDetailsToolStripMenuItem_Click);
            // 
            // analyticsToolStripMenuItem1
            // 
            this.analyticsToolStripMenuItem1.ForeColor = System.Drawing.Color.White;
            this.analyticsToolStripMenuItem1.Name = "analyticsToolStripMenuItem1";
            this.analyticsToolStripMenuItem1.Size = new System.Drawing.Size(105, 25);
            this.analyticsToolStripMenuItem1.Text = "Analytics";
            this.analyticsToolStripMenuItem1.Click += new System.EventHandler(this.analyticsToolStripMenuItem1_Click);
            // 
            // reportToolStripMenuItem
            // 
            this.reportToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.customerReportsToolStripMenuItem,
            this.employeeReportsToolStripMenuItem,
            this.manufacturerRepotsToolStripMenuItem,
            this.orderReportsToolStripMenuItem,
            this.partReportsToolStripMenuItem,
            this.serviceReportsToolStripMenuItem,
            this.billingReportsToolStripMenuItem});
            this.reportToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.reportToolStripMenuItem.Name = "reportToolStripMenuItem";
            this.reportToolStripMenuItem.Size = new System.Drawing.Size(80, 25);
            this.reportToolStripMenuItem.Text = "Report";
            this.reportToolStripMenuItem.Click += new System.EventHandler(this.reportToolStripMenuItem_Click);
            // 
            // customerReportsToolStripMenuItem
            // 
            this.customerReportsToolStripMenuItem.Name = "customerReportsToolStripMenuItem";
            this.customerReportsToolStripMenuItem.Size = new System.Drawing.Size(271, 26);
            this.customerReportsToolStripMenuItem.Text = "Customer Reports";
            this.customerReportsToolStripMenuItem.Click += new System.EventHandler(this.customerReportsToolStripMenuItem_Click);
            // 
            // employeeReportsToolStripMenuItem
            // 
            this.employeeReportsToolStripMenuItem.Name = "employeeReportsToolStripMenuItem";
            this.employeeReportsToolStripMenuItem.Size = new System.Drawing.Size(271, 26);
            this.employeeReportsToolStripMenuItem.Text = "Employee Reports";
            this.employeeReportsToolStripMenuItem.Click += new System.EventHandler(this.employeeReportsToolStripMenuItem_Click);
            // 
            // manufacturerRepotsToolStripMenuItem
            // 
            this.manufacturerRepotsToolStripMenuItem.Name = "manufacturerRepotsToolStripMenuItem";
            this.manufacturerRepotsToolStripMenuItem.Size = new System.Drawing.Size(271, 26);
            this.manufacturerRepotsToolStripMenuItem.Text = "Manufacturer Reports";
            this.manufacturerRepotsToolStripMenuItem.Click += new System.EventHandler(this.manufacturerRepotsToolStripMenuItem_Click);
            // 
            // orderReportsToolStripMenuItem
            // 
            this.orderReportsToolStripMenuItem.Name = "orderReportsToolStripMenuItem";
            this.orderReportsToolStripMenuItem.Size = new System.Drawing.Size(271, 26);
            this.orderReportsToolStripMenuItem.Text = "Order Reports";
            this.orderReportsToolStripMenuItem.Click += new System.EventHandler(this.orderReportsToolStripMenuItem_Click);
            // 
            // partReportsToolStripMenuItem
            // 
            this.partReportsToolStripMenuItem.Name = "partReportsToolStripMenuItem";
            this.partReportsToolStripMenuItem.Size = new System.Drawing.Size(271, 26);
            this.partReportsToolStripMenuItem.Text = "Part Reports";
            this.partReportsToolStripMenuItem.Click += new System.EventHandler(this.partReportsToolStripMenuItem_Click);
            // 
            // serviceReportsToolStripMenuItem
            // 
            this.serviceReportsToolStripMenuItem.Name = "serviceReportsToolStripMenuItem";
            this.serviceReportsToolStripMenuItem.Size = new System.Drawing.Size(271, 26);
            this.serviceReportsToolStripMenuItem.Text = "Service Reports";
            this.serviceReportsToolStripMenuItem.Click += new System.EventHandler(this.serviceReportsToolStripMenuItem_Click);
            // 
            // billingReportsToolStripMenuItem
            // 
            this.billingReportsToolStripMenuItem.Name = "billingReportsToolStripMenuItem";
            this.billingReportsToolStripMenuItem.Size = new System.Drawing.Size(271, 26);
            this.billingReportsToolStripMenuItem.Text = "Billing Reports";
            this.billingReportsToolStripMenuItem.Click += new System.EventHandler(this.billingReportsToolStripMenuItem_Click);
            // 
            // aboutUsToolStripMenuItem
            // 
            this.aboutUsToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.aboutUsToolStripMenuItem.Name = "aboutUsToolStripMenuItem";
            this.aboutUsToolStripMenuItem.Size = new System.Drawing.Size(102, 25);
            this.aboutUsToolStripMenuItem.Text = "About Us";
            this.aboutUsToolStripMenuItem.Click += new System.EventHandler(this.aboutUsToolStripMenuItem_Click);
            // 
            // logOutToolStripMenuItem
            // 
            this.logOutToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.logOutToolStripMenuItem.Name = "logOutToolStripMenuItem";
            this.logOutToolStripMenuItem.Size = new System.Drawing.Size(92, 25);
            this.logOutToolStripMenuItem.Text = "Log Out";
            this.logOutToolStripMenuItem.Click += new System.EventHandler(this.logOutToolStripMenuItem_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::WindowsFormsApplication1.Properties.Resources.admin21;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(206, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(839, 612);
            this.pictureBox1.TabIndex = 13;
            this.pictureBox1.TabStop = false;
            // 
            // Admin_hp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1039, 612);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Admin_hp";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Admin_hp";
            this.Load += new System.EventHandler(this.Admin_hp_Load_1);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStripMenuItem customerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem employeeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manufacturerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem partDetailsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem billingDetailsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem billDetailsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem orderDetailsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem analyticsToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem reportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem customerReportsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem employeeReportsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manufacturerRepotsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem orderReportsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem partReportsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem serviceReportsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem billingReportsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutUsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logOutToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;



    }
}