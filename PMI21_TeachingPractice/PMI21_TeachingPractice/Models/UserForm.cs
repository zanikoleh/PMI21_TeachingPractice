//-----------------------------------------------------------------------
// <copyright file="UserForm.cs" company="MyCompane">
//      Copyright PMI21.Team3 All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace PMI21_TeachingPractice
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;

    /// <summary>
    /// describes form for adding user and user list
    /// </summary>
    public partial class UserForm : Form
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserForm"/> class.
        /// </summary>
        public UserForm()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// loads form
        /// </summary>
        /// <param name="sender">sender of event</param>
        /// <param name="e">event data</param>
        private void UserForm_Load(object sender, EventArgs e)
        {
            this.usersList.Hide();
            this.back.Hide();
        }
    }
}
