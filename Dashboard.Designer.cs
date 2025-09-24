namespace LoginForm
{
    partial class Dashboard
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.but_search = new Guna.UI2.WinForms.Guna2TileButton();
            this.teb_name = new Guna.UI2.WinForms.Guna2TextBox();
            this.guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel2 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.txb_phone = new Guna.UI2.WinForms.Guna2TextBox();
            this.but_delete = new Guna.UI2.WinForms.Guna2TileButton();
            this.but_clear = new Guna.UI2.WinForms.Guna2TileButton();
            this.guna2HtmlLabel3 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.txb_lastName = new Guna.UI2.WinForms.Guna2TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(576, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(1469, 909);
            this.dataGridView1.TabIndex = 0;
            // 
            // but_search
            // 
            this.but_search.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.but_search.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.but_search.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.but_search.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.but_search.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.but_search.ForeColor = System.Drawing.Color.White;
            this.but_search.Location = new System.Drawing.Point(29, 266);
            this.but_search.Name = "but_search";
            this.but_search.Size = new System.Drawing.Size(145, 61);
            this.but_search.TabIndex = 1;
            this.but_search.Text = "Search";
            this.but_search.Click += new System.EventHandler(this.but_search_Click);
            // 
            // teb_name
            // 
            this.teb_name.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.teb_name.DefaultText = "";
            this.teb_name.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.teb_name.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.teb_name.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.teb_name.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.teb_name.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.teb_name.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.teb_name.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.teb_name.Location = new System.Drawing.Point(255, 27);
            this.teb_name.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.teb_name.Name = "teb_name";
            this.teb_name.PlaceholderText = "";
            this.teb_name.SelectedText = "";
            this.teb_name.Size = new System.Drawing.Size(286, 60);
            this.teb_name.TabIndex = 2;
            // 
            // guna2HtmlLabel1
            // 
            this.guna2HtmlLabel1.AutoSize = false;
            this.guna2HtmlLabel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel1.Location = new System.Drawing.Point(23, 44);
            this.guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            this.guna2HtmlLabel1.Size = new System.Drawing.Size(152, 27);
            this.guna2HtmlLabel1.TabIndex = 3;
            this.guna2HtmlLabel1.Text = "Frist Name";
            // 
            // guna2HtmlLabel2
            // 
            this.guna2HtmlLabel2.AutoSize = false;
            this.guna2HtmlLabel2.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel2.Location = new System.Drawing.Point(29, 182);
            this.guna2HtmlLabel2.Name = "guna2HtmlLabel2";
            this.guna2HtmlLabel2.Size = new System.Drawing.Size(197, 31);
            this.guna2HtmlLabel2.TabIndex = 5;
            this.guna2HtmlLabel2.Text = "Phone Number";
            this.guna2HtmlLabel2.Click += new System.EventHandler(this.guna2HtmlLabel2_Click);
            // 
            // txb_phone
            // 
            this.txb_phone.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txb_phone.DefaultText = "";
            this.txb_phone.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txb_phone.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txb_phone.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txb_phone.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txb_phone.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txb_phone.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txb_phone.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txb_phone.Location = new System.Drawing.Point(255, 167);
            this.txb_phone.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txb_phone.Name = "txb_phone";
            this.txb_phone.PlaceholderText = "";
            this.txb_phone.SelectedText = "";
            this.txb_phone.Size = new System.Drawing.Size(286, 60);
            this.txb_phone.TabIndex = 4;
            // 
            // but_delete
            // 
            this.but_delete.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.but_delete.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.but_delete.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.but_delete.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.but_delete.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.but_delete.ForeColor = System.Drawing.Color.White;
            this.but_delete.Location = new System.Drawing.Point(415, 266);
            this.but_delete.Name = "but_delete";
            this.but_delete.Size = new System.Drawing.Size(141, 61);
            this.but_delete.TabIndex = 6;
            this.but_delete.Text = "Close";
            this.but_delete.Click += new System.EventHandler(this.but_delete_Click);
            // 
            // but_clear
            // 
            this.but_clear.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.but_clear.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.but_clear.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.but_clear.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.but_clear.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.but_clear.ForeColor = System.Drawing.Color.White;
            this.but_clear.Location = new System.Drawing.Point(225, 266);
            this.but_clear.Name = "but_clear";
            this.but_clear.Size = new System.Drawing.Size(141, 61);
            this.but_clear.TabIndex = 7;
            this.but_clear.Text = "Clear";
            this.but_clear.Click += new System.EventHandler(this.but_clear_Click);
            // 
            // guna2HtmlLabel3
            // 
            this.guna2HtmlLabel3.AutoSize = false;
            this.guna2HtmlLabel3.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel3.Location = new System.Drawing.Point(29, 114);
            this.guna2HtmlLabel3.Name = "guna2HtmlLabel3";
            this.guna2HtmlLabel3.Size = new System.Drawing.Size(146, 31);
            this.guna2HtmlLabel3.TabIndex = 9;
            this.guna2HtmlLabel3.Text = "Last Name";
            // 
            // txb_lastName
            // 
            this.txb_lastName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txb_lastName.DefaultText = "";
            this.txb_lastName.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txb_lastName.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txb_lastName.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txb_lastName.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txb_lastName.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txb_lastName.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txb_lastName.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txb_lastName.Location = new System.Drawing.Point(255, 97);
            this.txb_lastName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txb_lastName.Name = "txb_lastName";
            this.txb_lastName.PlaceholderText = "";
            this.txb_lastName.SelectedText = "";
            this.txb_lastName.Size = new System.Drawing.Size(286, 60);
            this.txb_lastName.TabIndex = 8;
            // 
            // Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2176, 1139);
            this.Controls.Add(this.guna2HtmlLabel3);
            this.Controls.Add(this.txb_lastName);
            this.Controls.Add(this.but_clear);
            this.Controls.Add(this.but_delete);
            this.Controls.Add(this.guna2HtmlLabel2);
            this.Controls.Add(this.txb_phone);
            this.Controls.Add(this.guna2HtmlLabel1);
            this.Controls.Add(this.teb_name);
            this.Controls.Add(this.but_search);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Dashboard";
            this.Text = "Dashboard";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Dashboard_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private Guna.UI2.WinForms.Guna2TileButton but_search;
        private Guna.UI2.WinForms.Guna2TextBox teb_name;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel2;
        private Guna.UI2.WinForms.Guna2TextBox txb_phone;
        private Guna.UI2.WinForms.Guna2TileButton but_delete;
        private Guna.UI2.WinForms.Guna2TileButton but_clear;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel3;
        private Guna.UI2.WinForms.Guna2TextBox txb_lastName;
    }
}