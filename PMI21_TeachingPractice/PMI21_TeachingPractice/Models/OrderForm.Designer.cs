namespace PMI21_TeachingPractice
{
    partial class OrderForm
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
            this.ProductsList = new System.Windows.Forms.ListBox();
            this.AddToCartButton = new System.Windows.Forms.Button();
            this.Cart = new System.Windows.Forms.DataGridView();
            this.Product = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.currentPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PrListLabel = new System.Windows.Forms.Label();
            this.CartLabel = new System.Windows.Forms.Label();
            this.TotalPriceLabel = new System.Windows.Forms.Label();
            this.SubmitButton = new System.Windows.Forms.Button();
            this.ClearCartButton = new System.Windows.Forms.Button();
            this.CancelButtom = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Cart)).BeginInit();
            this.SuspendLayout();
            // 
            // ProductsList
            // 
            this.ProductsList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ProductsList.CausesValidation = false;
            this.ProductsList.ColumnWidth = 100;
            this.ProductsList.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ProductsList.Font = new System.Drawing.Font("Calibri", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ProductsList.FormattingEnabled = true;
            this.ProductsList.HorizontalScrollbar = true;
            this.ProductsList.ItemHeight = 23;
            this.ProductsList.Location = new System.Drawing.Point(14, 38);
            this.ProductsList.Margin = new System.Windows.Forms.Padding(5);
            this.ProductsList.Name = "ProductsList";
            this.ProductsList.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.ProductsList.Size = new System.Drawing.Size(886, 138);
            this.ProductsList.TabIndex = 0;
            // 
            // AddToCartButton
            // 
            this.AddToCartButton.Font = new System.Drawing.Font("Segoe Script", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AddToCartButton.Location = new System.Drawing.Point(768, 206);
            this.AddToCartButton.Name = "AddToCartButton";
            this.AddToCartButton.Size = new System.Drawing.Size(132, 28);
            this.AddToCartButton.TabIndex = 1;
            this.AddToCartButton.Text = "Add to cart";
            this.AddToCartButton.UseVisualStyleBackColor = true;
            this.AddToCartButton.Click += new System.EventHandler(this.AddToCartButton_Click);
            // 
            // Cart
            // 
            this.Cart.AllowUserToAddRows = false;
            this.Cart.AllowUserToResizeColumns = false;
            this.Cart.AllowUserToResizeRows = false;
            this.Cart.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.Cart.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.Cart.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Cart.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Cart.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Product,
            this.IdCol,
            this.Price,
            this.Amount,
            this.currentPrice});
            this.Cart.Location = new System.Drawing.Point(14, 257);
            this.Cart.Name = "Cart";
            this.Cart.Size = new System.Drawing.Size(886, 193);
            this.Cart.TabIndex = 2;
            this.Cart.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Cart_CellClick);
            this.Cart.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.Cart_CellEndEdit);
            this.Cart.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.Cart_CellMouseEnter);
            this.Cart.CellMouseLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.Cart_CellMouseLeave);
            this.Cart.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.Cart_UserDeletingRow);
            // 
            // Product
            // 
            this.Product.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Product.Frozen = true;
            this.Product.HeaderText = "Product";
            this.Product.Name = "Product";
            this.Product.ReadOnly = true;
            this.Product.Width = 169;
            // 
            // IdCol
            // 
            this.IdCol.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.IdCol.Frozen = true;
            this.IdCol.HeaderText = "Id";
            this.IdCol.Name = "IdCol";
            this.IdCol.ReadOnly = true;
            this.IdCol.Width = 169;
            // 
            // Price
            // 
            this.Price.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Price.Frozen = true;
            this.Price.HeaderText = "Unit price";
            this.Price.Name = "Price";
            this.Price.ReadOnly = true;
            this.Price.Width = 169;
            // 
            // Amount
            // 
            this.Amount.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Amount.Frozen = true;
            this.Amount.HeaderText = "Amount";
            this.Amount.Name = "Amount";
            this.Amount.Width = 169;
            // 
            // currentPrice
            // 
            this.currentPrice.HeaderText = "Current price";
            this.currentPrice.Name = "currentPrice";
            this.currentPrice.ReadOnly = true;
            // 
            // PrListLabel
            // 
            this.PrListLabel.AutoSize = true;
            this.PrListLabel.Font = new System.Drawing.Font("Segoe Script", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PrListLabel.Location = new System.Drawing.Point(8, 0);
            this.PrListLabel.Name = "PrListLabel";
            this.PrListLabel.Size = new System.Drawing.Size(191, 33);
            this.PrListLabel.TabIndex = 3;
            this.PrListLabel.Text = "Choose products:";
            // 
            // CartLabel
            // 
            this.CartLabel.AutoSize = true;
            this.CartLabel.Font = new System.Drawing.Font("Segoe Script", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CartLabel.Location = new System.Drawing.Point(8, 221);
            this.CartLabel.Name = "CartLabel";
            this.CartLabel.Size = new System.Drawing.Size(61, 33);
            this.CartLabel.TabIndex = 4;
            this.CartLabel.Text = "Cart";
            // 
            // TotalPriceLabel
            // 
            this.TotalPriceLabel.AutoSize = true;
            this.TotalPriceLabel.Font = new System.Drawing.Font("Segoe Script", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TotalPriceLabel.Location = new System.Drawing.Point(12, 466);
            this.TotalPriceLabel.Name = "TotalPriceLabel";
            this.TotalPriceLabel.Size = new System.Drawing.Size(178, 33);
            this.TotalPriceLabel.TabIndex = 5;
            this.TotalPriceLabel.Text = "Total price: 0.0";
            // 
            // SubmitButton
            // 
            this.SubmitButton.Enabled = false;
            this.SubmitButton.Location = new System.Drawing.Point(784, 456);
            this.SubmitButton.Name = "SubmitButton";
            this.SubmitButton.Size = new System.Drawing.Size(116, 35);
            this.SubmitButton.TabIndex = 6;
            this.SubmitButton.Text = "Submit order";
            this.SubmitButton.UseVisualStyleBackColor = true;
            this.SubmitButton.Click += new System.EventHandler(this.SubmitButton_Click);
            // 
            // ClearCartButton
            // 
            this.ClearCartButton.Enabled = false;
            this.ClearCartButton.Location = new System.Drawing.Point(660, 456);
            this.ClearCartButton.Name = "ClearCartButton";
            this.ClearCartButton.Size = new System.Drawing.Size(117, 35);
            this.ClearCartButton.TabIndex = 7;
            this.ClearCartButton.Text = "Clear cart";
            this.ClearCartButton.UseVisualStyleBackColor = true;
            this.ClearCartButton.Click += new System.EventHandler(this.ClearCartButton_Click);
            // 
            // CancelButtom
            // 
            this.CancelButtom.Location = new System.Drawing.Point(783, 497);
            this.CancelButtom.Name = "CancelButtom";
            this.CancelButtom.Size = new System.Drawing.Size(117, 35);
            this.CancelButtom.TabIndex = 8;
            this.CancelButtom.Text = "Cancel";
            this.CancelButtom.UseVisualStyleBackColor = true;
            // 
            // OrderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(914, 543);
            this.Controls.Add(this.CancelButtom);
            this.Controls.Add(this.ClearCartButton);
            this.Controls.Add(this.SubmitButton);
            this.Controls.Add(this.TotalPriceLabel);
            this.Controls.Add(this.CartLabel);
            this.Controls.Add(this.PrListLabel);
            this.Controls.Add(this.Cart);
            this.Controls.Add(this.AddToCartButton);
            this.Controls.Add(this.ProductsList);
            this.Name = "OrderForm";
            this.Text = "Order";
            ((System.ComponentModel.ISupportInitialize)(this.Cart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox ProductsList;
        private System.Windows.Forms.Button AddToCartButton;
        private System.Windows.Forms.DataGridView Cart;
        private System.Windows.Forms.Label PrListLabel;
        private System.Windows.Forms.Label CartLabel;
        private System.Windows.Forms.Label TotalPriceLabel;
        private System.Windows.Forms.DataGridViewTextBoxColumn Product;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn Price;
        private System.Windows.Forms.DataGridViewTextBoxColumn Amount;
        private System.Windows.Forms.DataGridViewTextBoxColumn currentPrice;
        private System.Windows.Forms.Button SubmitButton;
        private System.Windows.Forms.Button ClearCartButton;
        private System.Windows.Forms.Button CancelButtom;



    }
}

