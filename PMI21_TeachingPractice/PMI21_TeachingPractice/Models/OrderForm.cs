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
                this.dataBase.SetConnections("..\\..\\data\\Path.xml");
            }
            catch (ArgumentException p)
            {
                MessageBox.Show(p.Message);
                System.Windows.Forms.Application.Exit();
            }

            dataBase.LoadProducts();
            this.ProductListInitialize();
        }

        private void ProductListInitialize()
        {
            foreach (Products i in this.dataBase.Products)
            {
                this.ProductsList.Items.Add(i.PropProduct.Name + "\t-\t" + i.PropProduct.Price + " $");
            }
        }

        private void AddToCartButton_Click(object sender, EventArgs e)
        {
            if (this.ProductsList.SelectedItems.Count == 0)
            {
                MessageBox.Show("No selected products!");
                return;
            }
            foreach (int i in this.ProductsList.SelectedIndices)
            {
                Products tempProd = new Products(this.dataBase.Products[i]);
                string[] rowElement = { Convert.ToString(tempProd.PropProduct.Name), Convert.ToString(tempProd.PropProduct.Id), Convert.ToString(tempProd.PropProduct.Price),"1", Convert.ToString(tempProd.PropProduct.Price) };
                this.Cart.Rows.Add(rowElement);
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

        private string LeaveOnlyNumbers(string a)
        {
            string toReturn = null;
            if (a != null)
            {
                foreach (char i in a)
                {
                    if ((int)i >= 48 && (int)i <= 57)
                    {
                        toReturn += i;
                    }
                }
            }

            return toReturn;
        }

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
            for (int i = 0; i < this.Cart.Rows.Count;i++)
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
                MessageBox.Show("Operation successfil!");
        }

        private void ClearCartButton_Click(object sender, EventArgs e)
        {
            this.Cart.Rows.Clear();
            this.SubmitButton.Enabled = false;
            this.ClearCartButton.Enabled = false;
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.Cart.Rows.Clear();

            System.Windows.Forms.Application.Exit();
        }
    }
}
