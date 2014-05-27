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

        private void buttonOrders_Click(object sender, EventArgs e)
        {
            DataBase temp = DataBase.GetInstance();
            temp.SetConnections("...\\PMI21_TeachingPractice\\data\\Path.xml");
            temp.Load();
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

        /*private void buttonAdd_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
            System.Windows.Forms.Application.Run(new OrderForm());
            
        }*/

        private void FormOrder_Load(object sender, EventArgs e)
        {

        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
