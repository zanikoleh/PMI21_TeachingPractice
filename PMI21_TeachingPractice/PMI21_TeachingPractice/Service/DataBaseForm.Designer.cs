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
            this.Menu = new System.Windows.Forms.ComboBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // OK
            // 
            this.OK.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.OK.Location = new System.Drawing.Point(111, 236);
            this.OK.Name = "OK";
            this.OK.Size = new System.Drawing.Size(75, 23);
            this.OK.TabIndex = 0;
            this.OK.Text = "Connect";
            this.OK.UseVisualStyleBackColor = true;
            this.OK.Click += new System.EventHandler(this.button1_Click);
            // 
            // Text
            // 
            this.Text.AutoSize = true;
            this.Text.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Text.Location = new System.Drawing.Point(67, 34);
            this.Text.Name = "Text";
            this.Text.Size = new System.Drawing.Size(174, 18);
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
            this.IDinput.Text = "login1";
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
            this.PASSWORDinput.Text = "password1";
            // 
            // Menu
            // 
            this.Menu.BackColor = System.Drawing.Color.White;
            this.Menu.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Menu.FormattingEnabled = true;
            this.Menu.Items.AddRange(new object[] {
            "Admin",
            "Client",
            "TradeAgent"});
            this.Menu.Location = new System.Drawing.Point(12, 10);
            this.Menu.Name = "Menu";
            this.Menu.Size = new System.Drawing.Size(100, 24);
            this.Menu.TabIndex = 6;
            this.Menu.Visible = false;
            // 
            // DataBaseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(293, 302);
            this.Controls.Add(this.Menu);
            this.Controls.Add(this.PASSWORDinput);
            this.Controls.Add(this.PASSWORD);
            this.Controls.Add(this.IDinput);
            this.Controls.Add(this.ID);
            this.Controls.Add(this.Text);
            this.Controls.Add(this.OK);
            this.Name = "DataBaseForm";
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
        private System.Windows.Forms.ComboBox Menu;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}