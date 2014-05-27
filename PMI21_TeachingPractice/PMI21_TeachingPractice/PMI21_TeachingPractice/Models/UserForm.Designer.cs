//-----------------------------------------------------------------------
// <copyright file="UserForm.Designer.cs" company="MyCompane">
//      Copyright PMI21.Team3 All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace PMI21_TeachingPractice
{
    /// <summary>
    /// describes form for addition users and list of them
    /// </summary>
    public partial class UserForm
    {
        /// <summary>
        /// login of user
        /// </summary>
        private System.Windows.Forms.TextBox login;

        /// <summary>
        /// password of user
        /// </summary>
        private System.Windows.Forms.TextBox password;

        /// <summary>
        /// informational label
        /// </summary>
        private System.Windows.Forms.Label label1;

        /// <summary>
        /// informational label
        /// </summary>
        private System.Windows.Forms.Label label2;

        /// <summary>
        /// creates new user
        /// </summary>
        private System.Windows.Forms.Button newUser;

        /// <summary>
        /// makes visible password
        /// </summary>
        private System.Windows.Forms.Button visible;

        /// <summary>
        /// shows list of users
        /// </summary>
        private System.Windows.Forms.Button showUsers;

        /// <summary>
        /// turns back
        /// </summary>
        private System.Windows.Forms.Button back;

        /// <summary>
        /// list of users
        /// </summary>
        private System.Windows.Forms.TextBox usersList;

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
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
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
            this.login = new System.Windows.Forms.TextBox();
            this.password = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.newUser = new System.Windows.Forms.Button();
            this.visible = new System.Windows.Forms.Button();
            this.showUsers = new System.Windows.Forms.Button();
            this.back = new System.Windows.Forms.Button();
            this.usersList = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // login
            // 
            this.login.Location = new System.Drawing.Point(120, 98);
            this.login.Name = "login";
            this.login.Size = new System.Drawing.Size(129, 22);
            this.login.TabIndex = 0;
            // 
            // password
            // 
            this.password.Location = new System.Drawing.Point(120, 162);
            this.password.Name = "password";
            this.password.Size = new System.Drawing.Size(129, 22);
            this.password.TabIndex = 1;
            this.password.UseSystemPasswordChar = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(162, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Login";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(149, 133);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Password";
            // 
            // newUser
            // 
            this.newUser.Location = new System.Drawing.Point(143, 217);
            this.newUser.Name = "newUser";
            this.newUser.Size = new System.Drawing.Size(75, 23);
            this.newUser.TabIndex = 4;
            this.newUser.Text = "New user";
            this.newUser.UseVisualStyleBackColor = true;
            this.newUser.Click += new System.EventHandler(this.NewUser_Click);
            // 
            // visible
            // 
            this.visible.Location = new System.Drawing.Point(256, 160);
            this.visible.Name = "visible";
            this.visible.Size = new System.Drawing.Size(72, 23);
            this.visible.TabIndex = 7;
            this.visible.Text = "visible";
            this.visible.UseVisualStyleBackColor = true;
            this.visible.MouseCaptureChanged += new System.EventHandler(this.Visible_Up);
            this.visible.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Visible_Down);
            // 
            // showUsers
            // 
            this.showUsers.Location = new System.Drawing.Point(129, 288);
            this.showUsers.Name = "showUsers";
            this.showUsers.Size = new System.Drawing.Size(106, 23);
            this.showUsers.TabIndex = 8;
            this.showUsers.Text = "Show users";
            this.showUsers.UseVisualStyleBackColor = true;
            this.showUsers.Click += new System.EventHandler(this.ShowUsers_Click);
            // 
            // back
            // 
            this.back.Location = new System.Drawing.Point(143, 288);
            this.back.Name = "back";
            this.back.Size = new System.Drawing.Size(75, 23);
            this.back.TabIndex = 9;
            this.back.Text = "back";
            this.back.UseVisualStyleBackColor = true;
            this.back.Click += new System.EventHandler(this.Back_Click);
            // 
            // usersList
            // 
            this.usersList.AcceptsTab = true;
            this.usersList.Location = new System.Drawing.Point(83, 35);
            this.usersList.Multiline = true;
            this.usersList.Name = "usersList";
            this.usersList.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.usersList.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.usersList.Size = new System.Drawing.Size(206, 232);
            this.usersList.TabIndex = 10;
            this.usersList.WordWrap = false;
            // 
            // UserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(393, 358);
            this.Controls.Add(this.usersList);
            this.Controls.Add(this.back);
            this.Controls.Add(this.showUsers);
            this.Controls.Add(this.visible);
            this.Controls.Add(this.newUser);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.password);
            this.Controls.Add(this.login);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "UserForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.UserForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion
    }
}
