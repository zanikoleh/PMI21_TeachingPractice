namespace PMI21_TeachingPractice
{
    partial class FormOrder
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonOrders = new System.Windows.Forms.Button();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.textBoxOrders = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // buttonOrders
            // 
            this.buttonOrders.Location = new System.Drawing.Point(27, 53);
            this.buttonOrders.Name = "buttonOrders";
            this.buttonOrders.Size = new System.Drawing.Size(101, 33);
            this.buttonOrders.TabIndex = 1;
            this.buttonOrders.Text = "List of your orders";
            this.buttonOrders.UseVisualStyleBackColor = true;
            this.buttonOrders.Click += new System.EventHandler(this.buttonOrders_Click);
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(134, 53);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(101, 33);
            this.buttonAdd.TabIndex = 2;
            this.buttonAdd.Text = "Add new order";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // textBoxOrders
            // 
            this.textBoxOrders.Location = new System.Drawing.Point(27, 106);
            this.textBoxOrders.Multiline = true;
            this.textBoxOrders.Name = "textBoxOrders";
            this.textBoxOrders.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxOrders.Size = new System.Drawing.Size(208, 112);
            this.textBoxOrders.TabIndex = 3;
            // 
            // FormOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.textBoxOrders);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.buttonOrders);
            this.Name = "FormOrder";
            this.Text = "Order";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonOrders;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.TextBox textBoxOrders;
    }
}

