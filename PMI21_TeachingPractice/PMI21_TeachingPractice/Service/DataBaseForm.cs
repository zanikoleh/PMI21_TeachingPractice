//-----------------------------------------------------------------------
// <copyright file="DataBaseForm.cs" company="PMI21_TeachingPractice">
//     Copyright PMI21_TeachingPractice. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace PMI21_TeachingPractice.Service
{
    using PMI21_TeachingPractice;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;

    /// <summary>
    /// Windows Form for input id and password
    /// </summary>
    public partial class DataBaseForm : Form
    {
        /// <summary>
        /// Initialize Component
        /// </summary>
        public DataBaseForm()
        {
            InitializeComponent();
        }

        private void DataBaseForm_Load(object sender, EventArgs e)
        {
            Menu.Visible = false;
        }

        private void HideStartIcon()
        {
            Text.Visible = false;
            IDinput.Visible = false;
            PASSWORDinput.Visible = false;
            OK.Visible = false;
            ID.Visible = false;
            PASSWORD.Visible = false;
            Menu.Visible = true;
        }

        /// <summary>
        /// Agree
        /// </summary>
        private void OK_Click_1(object sender, EventArgs e)
        {
            User s = PMI21_TeachingPractice.UserControls.Identify(IDinput.Text, PASSWORDinput.Text);
            if (s != null)
            {
                DataBase db = DataBase.Instance;
                db.LoadRoles();
                //int id = db.GetUserIdByLogin(IDinput.Text);
                //Role rol = db.GetRoleById(id);
                List<Role> roles = new List<Role>();
                //Text.Text = s.RolesId.Capacity;
                foreach (var i in s.RolesId)
                {
                    roles.Add(db.GetRoleById(i));
                }
                //foreach (Role i in roles)
                //{
                //    Text.Text += i.Name;
                //}
                if (roles != null)
                {
                    foreach (Role i in roles)
                    {
                        if (i.Name == "Admin")
                        {
                            HideStartIcon();
                            AdminMenu.Visible = true;
                        }
                        if (i.Name == "Client")
                        {
                            HideStartIcon();
                            ClientMenu.Visible = true;
                        }
                        if (i.Name == "TradeAgent")
                        {
                            HideStartIcon();
                            TradeAgentMenu.Visible = true;
                        }
                    }
                }

            }
        }

        private void ExiteMenu_Click(object sender, EventArgs e)
        {
                Environment.Exit(0);
        }

    }
}
