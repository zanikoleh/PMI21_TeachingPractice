namespace PMI21_TeachingPractice
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using PMI21_TeachingPractice;

    public partial class FormOrder : Form
    {
        /// <summary>
        /// identificator of user
        /// </summary>
        public int ident;

        public FormOrder()
        {
            InitializeComponent();
        }

        

        private void FormOrder_Load(object sender, EventArgs e)
        {

        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void backToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void listOfOrdersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataBase temp = DataBase.Instance;
            temp.Load();
            this.textBoxOrders.Text = string.Empty;
            if (temp.Orders[0].ID != -1)
            {
                Order orders = temp.GetOrderById(this.ident);
                foreach (KeyValuePair<int, int> elem in orders.List)
                {
                    textBoxOrders.Text += "Name: " + temp.GetNameById(elem.Key) + "Count: " + elem.Value + "Price: " + temp.GetPriceById(elem.Key) * elem.Value + "\r\n";
                }
            }
            else
            {
                this.textBoxOrders.Text = "No order`s";
            }
        }
    }
}
