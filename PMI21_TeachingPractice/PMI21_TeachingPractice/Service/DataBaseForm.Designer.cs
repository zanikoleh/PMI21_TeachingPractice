namespace PMI21_TeachingPractice.Service
{
    partial class DataBaseForm
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
            this.OK = new System.Windows.Forms.Button();
            this.Text = new System.Windows.Forms.Label();
            this.ID = new System.Windows.Forms.Label();
            this.IDinput = new System.Windows.Forms.TextBox();
            this.PASSWORD = new System.Windows.Forms.Label();
            this.PASSWORDinput = new System.Windows.Forms.TextBox();
            this.AgentMenu = new System.Windows.Forms.ComboBox();
            this.NameOfRole = new System.Windows.Forms.Label();
            this.ClientMenu = new System.Windows.Forms.ComboBox();
            this.TradeAgentMenu = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // OK
            // 
            this.OK.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.OK.Location = new System.Drawing.Point(113, 235);
            this.OK.Name = "OK";
            this.OK.Size = new System.Drawing.Size(75, 23);
            this.OK.TabIndex = 0;
            this.OK.Text = "Connect";
            this.OK.UseVisualStyleBackColor = true;
            this.OK.Click += new System.EventHandler(this.OK_Click);
            // 
            // Text
            // 
            this.Text.AutoSize = true;
            this.Text.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Text.Location = new System.Drawing.Point(64, 46);
            this.Text.Name = "Text";
            this.Text.Size = new System.Drawing.Size(213, 24);
            this.Text.TabIndex = 1;
            this.Text.Text = "Data Base connection";
            // 
            // ID
            // 
            this.ID.AutoSize = true;
            this.ID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ID.Location = new System.Drawing.Point(27, 92);
            this.ID.Name = "ID";
            this.ID.Size = new System.Drawing.Size(21, 16);
            this.ID.TabIndex = 2;
            this.ID.Text = "Id";
            // 
            // IDinput
            // 
            this.IDinput.Location = new System.Drawing.Point(101, 88);
            this.IDinput.Name = "IDinput";
            this.IDinput.Size = new System.Drawing.Size(100, 20);
            this.IDinput.TabIndex = 3;
            this.IDinput.Text = "login3";
            // 
            // PASSWORD
            // 
            this.PASSWORD.AutoSize = true;
            this.PASSWORD.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PASSWORD.Location = new System.Drawing.Point(9, 157);
            this.PASSWORD.Name = "PASSWORD";
            this.PASSWORD.Size = new System.Drawing.Size(76, 16);
            this.PASSWORD.TabIndex = 4;
            this.PASSWORD.Text = "Password";
            // 
            // PASSWORDinput
            // 
            this.PASSWORDinput.Location = new System.Drawing.Point(101, 153);
            this.PASSWORDinput.Name = "PASSWORDinput";
            this.PASSWORDinput.PasswordChar = '*';
            this.PASSWORDinput.Size = new System.Drawing.Size(100, 20);
            this.PASSWORDinput.TabIndex = 5;
            this.PASSWORDinput.Text = "pas3";
            // 
            // AgentMenu
            // 
            this.AgentMenu.BackColor = System.Drawing.Color.White;
            this.AgentMenu.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AgentMenu.FormattingEnabled = true;
            this.AgentMenu.Items.AddRange(new object[] {
            "Add New User",
            "Delete User",
            "Show All Users"});
            this.AgentMenu.Location = new System.Drawing.Point(12, 7);
            this.AgentMenu.Name = "AgentMenu";
            this.AgentMenu.Size = new System.Drawing.Size(154, 24);
            this.AgentMenu.TabIndex = 6;
            this.AgentMenu.Visible = false;
            // 
            // NameOfRole
            // 
            this.NameOfRole.AutoSize = true;
            this.NameOfRole.BackColor = System.Drawing.Color.White;
            this.NameOfRole.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.NameOfRole.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.NameOfRole.Location = new System.Drawing.Point(172, 7);
            this.NameOfRole.Name = "NameOfRole";
            this.NameOfRole.Size = new System.Drawing.Size(2, 22);
            this.NameOfRole.TabIndex = 7;
            // 
            // ClientMenu
            // 
            this.ClientMenu.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ClientMenu.FormattingEnabled = true;
            this.ClientMenu.Items.AddRange(new object[] {
            "Show Products",
            "Perform Order"});
            this.ClientMenu.Location = new System.Drawing.Point(12, 7);
            this.ClientMenu.Name = "ClientMenu";
            this.ClientMenu.Size = new System.Drawing.Size(154, 24);
            this.ClientMenu.TabIndex = 9;
            // 
            // TradeAgentMenu
            // 
            this.TradeAgentMenu.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TradeAgentMenu.FormattingEnabled = true;
            this.TradeAgentMenu.Items.AddRange(new object[] {
            "Add New Product",
            "Get History Of Products",
            "Modify"});
            this.TradeAgentMenu.Location = new System.Drawing.Point(12, 7);
            this.TradeAgentMenu.Name = "TradeAgentMenu";
            this.TradeAgentMenu.Size = new System.Drawing.Size(154, 24);
            this.TradeAgentMenu.TabIndex = 10;
            // 
            // DataBaseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.ClientSize = new System.Drawing.Size(326, 302);
            this.Controls.Add(this.ClientMenu);
            this.Controls.Add(this.NameOfRole);
            this.Controls.Add(this.AgentMenu);
            this.Controls.Add(this.PASSWORDinput);
            this.Controls.Add(this.PASSWORD);
            this.Controls.Add(this.IDinput);
            this.Controls.Add(this.ID);
            this.Controls.Add(this.Text);
            this.Controls.Add(this.OK);
            this.Controls.Add(this.TradeAgentMenu);
            this.Name = "DataBaseForm";
            this.Load += new System.EventHandler(this.DataBaseForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button OK;
        private System.Windows.Forms.Label Text;
        private System.Windows.Forms.Label ID;
        private System.Windows.Forms.TextBox IDinput;
        private System.Windows.Forms.Label PASSWORD;
        private System.Windows.Forms.TextBox PASSWORDinput;
        private System.Windows.Forms.ComboBox AgentMenu;
        private System.Windows.Forms.Label NameOfRole;
        private System.Windows.Forms.ComboBox ClientMenu;
        private System.Windows.Forms.ComboBox TradeAgentMenu;
    }
}