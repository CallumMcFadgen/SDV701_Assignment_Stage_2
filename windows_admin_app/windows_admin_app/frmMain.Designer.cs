namespace windows_admin_app
{
    partial class frmMain
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
            this.lbxAuthor = new System.Windows.Forms.ListBox();
            this.lbxOrders = new System.Windows.Forms.ListBox();
            this.lblAuthorHeading = new System.Windows.Forms.Label();
            this.lblOrdersHeading = new System.Windows.Forms.Label();
            this.btnDeleteOrder = new System.Windows.Forms.Button();
            this.lblOrderTotalHeading = new System.Windows.Forms.Label();
            this.lblOrderTotal = new System.Windows.Forms.Label();
            this.btnQuit = new System.Windows.Forms.Button();
            this.lblOrderNumber = new System.Windows.Forms.Label();
            this.lblOrderName = new System.Windows.Forms.Label();
            this.lblOrderEmail = new System.Windows.Forms.Label();
            this.lblOrderPrice = new System.Windows.Forms.Label();
            this.lblOrderDate = new System.Windows.Forms.Label();
            this.lblOrderQuantity = new System.Windows.Forms.Label();
            this.lblOrderISBN = new System.Windows.Forms.Label();
            this.lblOrderTitle = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbxAuthor
            // 
            this.lbxAuthor.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbxAuthor.FormattingEnabled = true;
            this.lbxAuthor.ItemHeight = 18;
            this.lbxAuthor.Location = new System.Drawing.Point(42, 60);
            this.lbxAuthor.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lbxAuthor.Name = "lbxAuthor";
            this.lbxAuthor.Size = new System.Drawing.Size(230, 472);
            this.lbxAuthor.TabIndex = 0;
            this.lbxAuthor.DoubleClick += new System.EventHandler(this.lbxAuthor_DoubleClick);
            // 
            // lbxOrders
            // 
            this.lbxOrders.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbxOrders.FormattingEnabled = true;
            this.lbxOrders.ItemHeight = 18;
            this.lbxOrders.Location = new System.Drawing.Point(322, 82);
            this.lbxOrders.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lbxOrders.Name = "lbxOrders";
            this.lbxOrders.Size = new System.Drawing.Size(1121, 382);
            this.lbxOrders.TabIndex = 1;
            // 
            // lblAuthorHeading
            // 
            this.lblAuthorHeading.AutoSize = true;
            this.lblAuthorHeading.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAuthorHeading.Location = new System.Drawing.Point(92, 11);
            this.lblAuthorHeading.Name = "lblAuthorHeading";
            this.lblAuthorHeading.Size = new System.Drawing.Size(120, 36);
            this.lblAuthorHeading.TabIndex = 3;
            this.lblAuthorHeading.Text = "Authors";
            // 
            // lblOrdersHeading
            // 
            this.lblOrdersHeading.AutoSize = true;
            this.lblOrdersHeading.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrdersHeading.Location = new System.Drawing.Point(726, 11);
            this.lblOrdersHeading.Name = "lblOrdersHeading";
            this.lblOrdersHeading.Size = new System.Drawing.Size(105, 36);
            this.lblOrdersHeading.TabIndex = 5;
            this.lblOrdersHeading.Text = "Orders";
            // 
            // btnDeleteOrder
            // 
            this.btnDeleteOrder.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteOrder.Location = new System.Drawing.Point(1210, 489);
            this.btnDeleteOrder.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnDeleteOrder.Name = "btnDeleteOrder";
            this.btnDeleteOrder.Size = new System.Drawing.Size(107, 49);
            this.btnDeleteOrder.TabIndex = 6;
            this.btnDeleteOrder.Text = "Delete";
            this.btnDeleteOrder.UseVisualStyleBackColor = true;
            this.btnDeleteOrder.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // lblOrderTotalHeading
            // 
            this.lblOrderTotalHeading.AutoSize = true;
            this.lblOrderTotalHeading.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrderTotalHeading.Location = new System.Drawing.Point(322, 489);
            this.lblOrderTotalHeading.Name = "lblOrderTotalHeading";
            this.lblOrderTotalHeading.Size = new System.Drawing.Size(168, 24);
            this.lblOrderTotalHeading.TabIndex = 7;
            this.lblOrderTotalHeading.Text = "Total Orders Value";
            // 
            // lblOrderTotal
            // 
            this.lblOrderTotal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblOrderTotal.Font = new System.Drawing.Font("Consolas", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrderTotal.Location = new System.Drawing.Point(499, 489);
            this.lblOrderTotal.Name = "lblOrderTotal";
            this.lblOrderTotal.Size = new System.Drawing.Size(199, 25);
            this.lblOrderTotal.TabIndex = 8;
            // 
            // btnQuit
            // 
            this.btnQuit.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQuit.Location = new System.Drawing.Point(1336, 489);
            this.btnQuit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Size = new System.Drawing.Size(107, 49);
            this.btnQuit.TabIndex = 11;
            this.btnQuit.Text = "Quit";
            this.btnQuit.UseVisualStyleBackColor = true;
            this.btnQuit.Click += new System.EventHandler(this.btnQuit_Click);
            // 
            // lblOrderNumber
            // 
            this.lblOrderNumber.AutoSize = true;
            this.lblOrderNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrderNumber.Location = new System.Drawing.Point(328, 60);
            this.lblOrderNumber.Name = "lblOrderNumber";
            this.lblOrderNumber.Size = new System.Drawing.Size(34, 20);
            this.lblOrderNumber.TabIndex = 12;
            this.lblOrderNumber.Text = "Nu.";
            // 
            // lblOrderName
            // 
            this.lblOrderName.AutoSize = true;
            this.lblOrderName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrderName.Location = new System.Drawing.Point(440, 60);
            this.lblOrderName.Name = "lblOrderName";
            this.lblOrderName.Size = new System.Drawing.Size(53, 20);
            this.lblOrderName.TabIndex = 13;
            this.lblOrderName.Text = "Name";
            // 
            // lblOrderEmail
            // 
            this.lblOrderEmail.AutoSize = true;
            this.lblOrderEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrderEmail.Location = new System.Drawing.Point(675, 60);
            this.lblOrderEmail.Name = "lblOrderEmail";
            this.lblOrderEmail.Size = new System.Drawing.Size(51, 20);
            this.lblOrderEmail.TabIndex = 14;
            this.lblOrderEmail.Text = "Email";
            // 
            // lblOrderPrice
            // 
            this.lblOrderPrice.AutoSize = true;
            this.lblOrderPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrderPrice.Location = new System.Drawing.Point(1205, 60);
            this.lblOrderPrice.Name = "lblOrderPrice";
            this.lblOrderPrice.Size = new System.Drawing.Size(48, 20);
            this.lblOrderPrice.TabIndex = 15;
            this.lblOrderPrice.Text = "Price";
            // 
            // lblOrderDate
            // 
            this.lblOrderDate.AutoSize = true;
            this.lblOrderDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrderDate.Location = new System.Drawing.Point(924, 60);
            this.lblOrderDate.Name = "lblOrderDate";
            this.lblOrderDate.Size = new System.Drawing.Size(45, 20);
            this.lblOrderDate.TabIndex = 16;
            this.lblOrderDate.Text = "Date";
            // 
            // lblOrderQuantity
            // 
            this.lblOrderQuantity.AutoSize = true;
            this.lblOrderQuantity.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrderQuantity.Location = new System.Drawing.Point(1292, 60);
            this.lblOrderQuantity.Name = "lblOrderQuantity";
            this.lblOrderQuantity.Size = new System.Drawing.Size(35, 20);
            this.lblOrderQuantity.TabIndex = 17;
            this.lblOrderQuantity.Text = "Qty";
            // 
            // lblOrderISBN
            // 
            this.lblOrderISBN.AutoSize = true;
            this.lblOrderISBN.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrderISBN.Location = new System.Drawing.Point(1072, 60);
            this.lblOrderISBN.Name = "lblOrderISBN";
            this.lblOrderISBN.Size = new System.Drawing.Size(48, 20);
            this.lblOrderISBN.TabIndex = 18;
            this.lblOrderISBN.Text = "ISBN";
            // 
            // lblOrderTitle
            // 
            this.lblOrderTitle.AutoSize = true;
            this.lblOrderTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrderTitle.Location = new System.Drawing.Point(1365, 60);
            this.lblOrderTitle.Name = "lblOrderTitle";
            this.lblOrderTitle.Size = new System.Drawing.Size(46, 20);
            this.lblOrderTitle.TabIndex = 19;
            this.lblOrderTitle.Text = "Total";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1487, 562);
            this.Controls.Add(this.lblOrderTitle);
            this.Controls.Add(this.lblOrderISBN);
            this.Controls.Add(this.lblOrderQuantity);
            this.Controls.Add(this.lblOrderDate);
            this.Controls.Add(this.lblOrderPrice);
            this.Controls.Add(this.lblOrderEmail);
            this.Controls.Add(this.lblOrderName);
            this.Controls.Add(this.lblOrderNumber);
            this.Controls.Add(this.btnQuit);
            this.Controls.Add(this.lblOrderTotal);
            this.Controls.Add(this.lblOrderTotalHeading);
            this.Controls.Add(this.btnDeleteOrder);
            this.Controls.Add(this.lblOrdersHeading);
            this.Controls.Add(this.lblAuthorHeading);
            this.Controls.Add(this.lbxOrders);
            this.Controls.Add(this.lbxAuthor);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "The Writers Collective";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbxAuthor;
        private System.Windows.Forms.ListBox lbxOrders;
        private System.Windows.Forms.Label lblAuthorHeading;
        private System.Windows.Forms.Label lblOrdersHeading;
        private System.Windows.Forms.Button btnDeleteOrder;
        private System.Windows.Forms.Label lblOrderTotalHeading;
        private System.Windows.Forms.Label lblOrderTotal;
        private System.Windows.Forms.Button btnQuit;
        private System.Windows.Forms.Label lblOrderNumber;
        private System.Windows.Forms.Label lblOrderName;
        private System.Windows.Forms.Label lblOrderEmail;
        private System.Windows.Forms.Label lblOrderPrice;
        private System.Windows.Forms.Label lblOrderDate;
        private System.Windows.Forms.Label lblOrderQuantity;
        private System.Windows.Forms.Label lblOrderISBN;
        private System.Windows.Forms.Label lblOrderTitle;
    }
}

