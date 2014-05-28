﻿//-----------------------------------------------------------------------
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
            NameOfRole.Visible = false;
            AgentMenu.Visible = false;
            ClientMenu.Visible = false;
            TradeAgentMenu.Visible = false;
        }

        /// <summary>
        /// Method to enter to the system
        /// </summary>fsdsdf
        
        private void chooseAdmin() {
            IDinput.Visible = false;
            PASSWORDinput.Visible = false;
            //OK.Visible = false;
            ID.Visible = false;
            PASSWORD.Visible = false;
            Text.Visible = false;
            NameOfRole.Visible = true;
            NameOfRole.Text = "Agent";
            AgentMenu.Visible = true;
        }

        private void chooseClient()
        {
            IDinput.Visible = false;
            PASSWORDinput.Visible = false;
            //OK.Visible = false;
            ID.Visible = false;
            PASSWORD.Visible = false;
            Text.Visible = false;
            NameOfRole.Visible = true;
            NameOfRole.Text = "Client";
            ClientMenu.Visible = true;
        }

        private void chooseTradeAgent()
        {
            IDinput.Visible = false;
            PASSWORDinput.Visible = false;
            OK.Visible = false;
            ID.Visible = false;
            PASSWORD.Visible = false;
            Text.Visible = false;
            NameOfRole.Visible = true;
            NameOfRole.Text = "Trade Agent";
            TradeAgentMenu.Visible = true;
        }

        /// <summary>
        /// Agree
        /// </summary>
        private void OK_Click(object sender, EventArgs e)
        {
            if (ClientMenu.Visible == true)
            {
                switch (ClientMenu.Text)
                {
                    case "Perform Order":
                        OrderForm form1 = new OrderForm();
                        form1.ShowDialog();
                        break;
                    case "Show Products":
                        {
                            FormOrder form = new FormOrder();
                            DataBase db = DataBase.GetInstance();
                            form.ident = db.GetUserIdByLogin(this.IDinput.Text);
                            form.ShowDialog();
                            break;
                        }
                    case "TradeAgent":
                        //TODO
                        break;
                }
            }
            else
            {

                User s = PMI21_TeachingPractice.UserControls.Identify(IDinput.Text, PASSWORDinput.Text);
                if (s != null)
                {
                    DataBase db = DataBase.Instance;
                    db.LoadRoles();
                    int id = db.GetUserIdByLogin(IDinput.Text);
                    Role rol = db.GetRoleById(id);
                    switch (rol.Name)
                    {
                        case "Admin":
                            {
                                chooseAdmin();
                                break;
                            }
                        case "Client":
                            {
                                chooseClient();
                                break;
                            }
                        case "TradeAgent":
                            {
                                chooseTradeAgent();
                                break;
                            }
                    }
                    // ChangeWindow();
                }
            }
        }
    }
}
