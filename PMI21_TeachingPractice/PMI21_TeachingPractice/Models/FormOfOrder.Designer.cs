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
            this.textBoxOrders = new System.Windows.Forms.TextBox();
            this.buttonBack = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonOrders
            // 
            this.buttonOrders.Location = new System.Drawing.Point(27, 67);
            this.buttonOrders.Name = "buttonOrders";
            this.buttonOrders.Size = new System.Drawing.Size(101, 33);
            this.buttonOrders.TabIndex = 1;
            this.buttonOrders.Text = "Show list";
            this.buttonOrders.UseVisualStyleBackColor = true;
            this.buttonOrders.Click += new System.EventHandler(this.buttonOrders_Click);
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
            // buttonBack
            // 
            this.buttonBack.Location = new System.Drawing.Point(134, 67);
            this.buttonBack.Name = "buttonBack";
            this.buttonBack.Size = new System.Drawing.Size(101, 33);
            this.buttonBack.TabIndex = 4;
            this.buttonBack.Text = "Back";
            this.buttonBack.UseVisualStyleBackColor = true;
            this.buttonBack.Click += new System.EventHandler(this.buttonBack_Click);
            // 
            // FormOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.buttonBack);
            this.Controls.Add(this.textBoxOrders);
            this.Controls.Add(this.buttonOrders);
            this.Name = "FormOrder";
            this.Text = "Order";
            this.Load += new System.EventHandler(this.FormOrder_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonOrders;
        private System.Windows.Forms.TextBox textBoxOrders;
        private System.Windows.Forms.Button buttonBack;
    }
}

