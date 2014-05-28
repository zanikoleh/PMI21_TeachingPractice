using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PMI21_TeachingPractice;

namespace PMI21_TeachingPractice
{
    public partial class OrderForm : Form
    {
        private DataBase dataBase;
        private double totalPrice = 0.0;

        public OrderForm()
        {
            InitializeComponent();
            dataBase = DataBase.GetInstance();
            try
            {
                this.dataBase = DataBase.GetInstance();
            }
            catch (ArgumentException p)
            {
                MessageBox.Show(p.Message);
                System.Windows.Forms.Application.Exit();
            }

            dataBase.LoadProducts();
            this.ProductListInitialize();
        }

        /// <summary>
        /// This method loads the list of products from the database
        /// </summary>
        private void ProductListInitialize()
        {
            foreach (Products i in this.dataBase.Products)
            {
                this.ProductsList.Items.Add("(id)" + i.PropProduct.Id + " (name)" + i.PropProduct.Name + "\t-\t (price)" + i.PropProduct.Price + " $");
            }
        }

        /// <summary>
        /// This method adds the items into the cart if the button is clicked
        /// </summary>
        private void AddToCartButton_Click(object sender, EventArgs e)
        {
            if (this.ProductsList.SelectedItems.Count == 0)
            {
                MessageBox.Show("No selected products!");
                return;
            }
            foreach (string i in this.ProductsList.SelectedItems)
            {
                Products tempProd = new Products(dataBase.GetProductById(this.IdOfSelectedProduct(i)));
                for (int k = 0; k < this.Cart.Rows.Count; k++)
                {
                    if (Convert.ToString(this.Cart[1, k].Value) == Convert.ToString(tempProd.PropProduct.Id))
                    {
                        string temp = Convert.ToString(this.Cart[3, k].Value);
                        int num = Convert.ToInt32(temp);

                        if (num + 1 > 1000)
                        {
                            MessageBox.Show("Amount should be less than 1000!");
                            break;
                        }
                        else
                        {
                            num += 1;
                            this.Cart[3, k].Value = Convert.ToString(num);

                            string temp1 = (string)this.Cart[3, k].Value;
                            string temp2 = (string)this.Cart[2, k].Value;
                            double temp3 = Convert.ToDouble(temp1) * Convert.ToDouble(temp2);
                            this.Cart[4, k].Value = Convert.ToString(temp3);
                            this.TotalPrice();
                            this.TotalPriceLabel.Text = "Total price: " + Convert.ToString(this.totalPrice);
                            return;
                        }
                    }
                }
                string[] rowElement = { Convert.ToString(tempProd.PropProduct.Name), Convert.ToString(tempProd.PropProduct.Id), Convert.ToString(tempProd.PropProduct.Price), "1", Convert.ToString(tempProd.PropProduct.Price) };
                this.Cart.Rows.Add(rowElement);
                this.TotalPrice();
                this.TotalPriceLabel.Text = "Total price: " + Convert.ToString(this.totalPrice);
            }
            this.ProductsList.SelectedItems.Clear();
            if (!this.SubmitButton.Enabled)
            {
                this.SubmitButton.Enabled = true;
            }
            if (!this.ClearCartButton.Enabled)
            {
                this.ClearCartButton.Enabled = true;
            }
        }

        /// <summary>
        /// This method checks if the amount of purchased items is more than zero and less than one thousand; counts the current price; 
        /// is performed when the edition of the current cell was finished
        /// </summary>
        private void Cart_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 3)
            {
                string temp = (string)this.Cart.CurrentCell.Value;

                temp = this.LeaveOnlyNumbers(temp);
                if (temp == null)
                {
                    this.Cart.CurrentCell.Value = "1";
                }
                else if (Convert.ToDouble(temp) < 0)
                {
                    this.Cart.CurrentCell.Value = "1";
                }
                else if (Convert.ToDouble(temp) > 1000)
                {
                    MessageBox.Show("Amount shoult be less than 1000!");
                    this.Cart.CurrentCell.Value = "1";
                }
                else
                {
                    this.Cart.CurrentCell.Value = temp;
                }

                string temp1 = (string)this.Cart.CurrentCell.Value;
                string temp2 = (string)this.Cart[e.ColumnIndex - 1, e.RowIndex].Value;
                double temp3 = Convert.ToDouble(temp1) * Convert.ToDouble(temp2);
                this.Cart[e.ColumnIndex + 1, e.RowIndex].Value = Convert.ToString(temp3);
                this.TotalPrice();
                this.TotalPriceLabel.Text = "Total price: " + Convert.ToString(this.totalPrice);
            }
        }

        /// <summary>
        /// This method finds the id of selected product and converts it to string
        /// </summary>
        /// <param name="selected">the selected product</param>
        /// <returns>the id of selected product converted to string</returns>
        private int IdOfSelectedProduct(string selected)
        {
            string toConvert = selected.Substring(selected.IndexOf(')') + 1, selected.IndexOf(' ') - selected.IndexOf(')'));
            return Convert.ToInt32(toConvert);
        }

        /// <summary>
        /// This method deletes the letters if the user types them in the "amount" row
        /// </summary>
        /// <param name="line">the line typed by the user</param>
        /// <returns>only numbers</returns>
        private string LeaveOnlyNumbers(string line)
        {
            string toReturn = null;
            if (line != null)
            {
                foreach (char i in line)
                {
                    if ((int)i >= 48 && (int)i <= 57)
                    {
                        toReturn += i;
                    }
                }
            }

            return toReturn;
        }

        /// <summary>
        /// Defines the total sum of the purchase
        /// </summary>
        private void TotalPrice()
        {
            this.totalPrice = 0.0;
            if (this.Cart.Columns[4] != null)
            {
                for (int i = 0; i < this.Cart.Rows.Count; i++)
                {
                    string temp = (string)this.Cart[4, i].Value;
                    this.totalPrice += Convert.ToDouble(temp);
                }
            }
        }

        /// <summary>
        /// This method defines the events that are performed when the user deletes the row
        /// </summary>
        private void Cart_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            string temp = (string)e.Row.Cells[4].Value;
            this.totalPrice -= Convert.ToDouble(temp);
            this.TotalPriceLabel.Text = "Total price: " + Convert.ToString(this.totalPrice);
            if (this.Cart.Rows.Count == 0)
            {
                this.SubmitButton.Enabled = false;
                this.ClearCartButton.Enabled = false;
            }
        }

        /// <summary>
        /// This method provides edition of the "amount" column after the first click
        /// </summary>
        private void Cart_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 3)
            {
                this.Cart.BeginEdit(true);
            }
        }

        private void Cart_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 3)
            {
                this.Cart.Cursor = Cursors.IBeam;
            }
        }

        private void Cart_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            this.Cart.Cursor = Cursors.Default;
        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            Order order = new Order();
            //order.ID = FormOrder.ident;
            for (int i = 0; i < this.Cart.Rows.Count; i++)
            {
                string id = (string)this.Cart[1, i].Value;
                string amount = (string)this.Cart[3, i].Value;
                order.AddProduct(Convert.ToInt32(id), Convert.ToInt32(amount));
                this.dataBase.Add(order);
            }
            this.dataBase.CommitOrders();
            this.Cart.Rows.Clear();
            this.SubmitButton.Enabled = false;
            this.ClearCartButton.Enabled = false;
            MessageBox.Show("Operation successfull!");
        }

        private void ClearCartButton_Click(object sender, EventArgs e)
        {
            this.totalPrice = 0.0;
            this.TotalPriceLabel.Text = "Total price: " + Convert.ToString(this.totalPrice);
            this.Cart.Rows.Clear();
            this.SubmitButton.Enabled = false;
            this.ClearCartButton.Enabled = false;
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.Cart.Rows.Clear();
            this.Close();
        }
    }
}