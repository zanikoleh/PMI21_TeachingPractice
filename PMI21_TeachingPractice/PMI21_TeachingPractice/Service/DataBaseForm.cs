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

        /// <summary>
        /// Method to enter to the system
        /// </summary>fsdsdf
        
        private void ChangeWindow() {
            IDinput.Visible = false;
            PASSWORDinput.Visible = false;
            OK.Visible =true;
            ID.Visible = false;
            PASSWORD.Visible = false;
            Text.Visible = false;
            Menu.Visible = true;
            
        }

        /// <summary>
        /// Agree
        /// </summary>
        private void button1_Click(object sender, EventArgs e)
        {
            if (Menu.Visible == true)
            {
                switch (Menu.Text)
                {
                    case "Admin":
                        //TODO
                        break;
                    case "Client":
                        //TODO
                        break;
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
                    ChangeWindow();
                }
                else
                {
                    MessageBox.Show("Incorrect ID\\password");
                }
            }
        }
    }
}
