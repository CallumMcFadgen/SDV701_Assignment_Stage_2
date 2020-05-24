namespace windows_admin_app
{
    partial class MainWindow
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
            this.pnlAuthorSort = new System.Windows.Forms.Panel();
            this.rbtnAuthorDate = new System.Windows.Forms.RadioButton();
            this.rbtnAuthorName = new System.Windows.Forms.RadioButton();
            this.lblAuthorSortHeading = new System.Windows.Forms.Label();
            this.lblAuthorHeading = new System.Windows.Forms.Label();
            this.pnlOrderSort = new System.Windows.Forms.Panel();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.rbtnOrderName = new System.Windows.Forms.RadioButton();
            this.lblOrderSortHeading = new System.Windows.Forms.Label();
            this.lblOrdersHeading = new System.Windows.Forms.Label();
            this.btnDeleteOrder = new System.Windows.Forms.Button();
            this.lblOrderTotalHeading = new System.Windows.Forms.Label();
            this.lblOrderTotal = new System.Windows.Forms.Label();
            this.pnlAuthorSort.SuspendLayout();
            this.pnlOrderSort.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbxAuthor
            // 
            this.lbxAuthor.FormattingEnabled = true;
            this.lbxAuthor.ItemHeight = 16;
            this.lbxAuthor.Location = new System.Drawing.Point(35, 60);
            this.lbxAuthor.Name = "lbxAuthor";
            this.lbxAuthor.Size = new System.Drawing.Size(302, 484);
            this.lbxAuthor.TabIndex = 0;
            // 
            // lbxOrders
            // 
            this.lbxOrders.FormattingEnabled = true;
            this.lbxOrders.ItemHeight = 16;
            this.lbxOrders.Location = new System.Drawing.Point(486, 60);
            this.lbxOrders.Name = "lbxOrders";
            this.lbxOrders.Size = new System.Drawing.Size(558, 436);
            this.lbxOrders.TabIndex = 1;
            // 
            // pnlAuthorSort
            // 
            this.pnlAuthorSort.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlAuthorSort.Controls.Add(this.rbtnAuthorDate);
            this.pnlAuthorSort.Controls.Add(this.rbtnAuthorName);
            this.pnlAuthorSort.Controls.Add(this.lblAuthorSortHeading);
            this.pnlAuthorSort.Location = new System.Drawing.Point(352, 60);
            this.pnlAuthorSort.Name = "pnlAuthorSort";
            this.pnlAuthorSort.Size = new System.Drawing.Size(98, 123);
            this.pnlAuthorSort.TabIndex = 2;
            // 
            // rbtnAuthorDate
            // 
            this.rbtnAuthorDate.AutoSize = true;
            this.rbtnAuthorDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnAuthorDate.Location = new System.Drawing.Point(16, 76);
            this.rbtnAuthorDate.Name = "rbtnAuthorDate";
            this.rbtnAuthorDate.Size = new System.Drawing.Size(59, 21);
            this.rbtnAuthorDate.TabIndex = 5;
            this.rbtnAuthorDate.TabStop = true;
            this.rbtnAuthorDate.Text = "Date";
            this.rbtnAuthorDate.UseVisualStyleBackColor = true;
            // 
            // rbtnAuthorName
            // 
            this.rbtnAuthorName.AutoSize = true;
            this.rbtnAuthorName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnAuthorName.Location = new System.Drawing.Point(16, 49);
            this.rbtnAuthorName.Name = "rbtnAuthorName";
            this.rbtnAuthorName.Size = new System.Drawing.Size(66, 21);
            this.rbtnAuthorName.TabIndex = 4;
            this.rbtnAuthorName.TabStop = true;
            this.rbtnAuthorName.Text = "Name";
            this.rbtnAuthorName.UseVisualStyleBackColor = true;
            // 
            // lblAuthorSortHeading
            // 
            this.lblAuthorSortHeading.AutoSize = true;
            this.lblAuthorSortHeading.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAuthorSortHeading.Location = new System.Drawing.Point(12, 10);
            this.lblAuthorSortHeading.Name = "lblAuthorSortHeading";
            this.lblAuthorSortHeading.Size = new System.Drawing.Size(68, 24);
            this.lblAuthorSortHeading.TabIndex = 4;
            this.lblAuthorSortHeading.Text = "Sort by";
            // 
            // lblAuthorHeading
            // 
            this.lblAuthorHeading.AutoSize = true;
            this.lblAuthorHeading.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAuthorHeading.Location = new System.Drawing.Point(124, 12);
            this.lblAuthorHeading.Name = "lblAuthorHeading";
            this.lblAuthorHeading.Size = new System.Drawing.Size(120, 36);
            this.lblAuthorHeading.TabIndex = 3;
            this.lblAuthorHeading.Text = "Authors";
            // 
            // pnlOrderSort
            // 
            this.pnlOrderSort.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlOrderSort.Controls.Add(this.radioButton1);
            this.pnlOrderSort.Controls.Add(this.rbtnOrderName);
            this.pnlOrderSort.Controls.Add(this.lblOrderSortHeading);
            this.pnlOrderSort.Location = new System.Drawing.Point(1061, 60);
            this.pnlOrderSort.Name = "pnlOrderSort";
            this.pnlOrderSort.Size = new System.Drawing.Size(98, 123);
            this.pnlOrderSort.TabIndex = 4;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton1.Location = new System.Drawing.Point(16, 76);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(59, 21);
            this.radioButton1.TabIndex = 5;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Date";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // rbtnOrderName
            // 
            this.rbtnOrderName.AutoSize = true;
            this.rbtnOrderName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnOrderName.Location = new System.Drawing.Point(16, 49);
            this.rbtnOrderName.Name = "rbtnOrderName";
            this.rbtnOrderName.Size = new System.Drawing.Size(66, 21);
            this.rbtnOrderName.TabIndex = 4;
            this.rbtnOrderName.TabStop = true;
            this.rbtnOrderName.Text = "Name";
            this.rbtnOrderName.UseVisualStyleBackColor = true;
            // 
            // lblOrderSortHeading
            // 
            this.lblOrderSortHeading.AutoSize = true;
            this.lblOrderSortHeading.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrderSortHeading.Location = new System.Drawing.Point(12, 10);
            this.lblOrderSortHeading.Name = "lblOrderSortHeading";
            this.lblOrderSortHeading.Size = new System.Drawing.Size(68, 24);
            this.lblOrderSortHeading.TabIndex = 4;
            this.lblOrderSortHeading.Text = "Sort by";
            // 
            // lblOrdersHeading
            // 
            this.lblOrdersHeading.AutoSize = true;
            this.lblOrdersHeading.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrdersHeading.Location = new System.Drawing.Point(729, 12);
            this.lblOrdersHeading.Name = "lblOrdersHeading";
            this.lblOrdersHeading.Size = new System.Drawing.Size(105, 36);
            this.lblOrdersHeading.TabIndex = 5;
            this.lblOrdersHeading.Text = "Orders";
            // 
            // btnDeleteOrder
            // 
            this.btnDeleteOrder.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteOrder.Location = new System.Drawing.Point(1061, 202);
            this.btnDeleteOrder.Name = "btnDeleteOrder";
            this.btnDeleteOrder.Size = new System.Drawing.Size(98, 32);
            this.btnDeleteOrder.TabIndex = 6;
            this.btnDeleteOrder.Text = "Delete";
            this.btnDeleteOrder.UseVisualStyleBackColor = true;
            // 
            // lblOrderTotalHeading
            // 
            this.lblOrderTotalHeading.AutoSize = true;
            this.lblOrderTotalHeading.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrderTotalHeading.Location = new System.Drawing.Point(482, 520);
            this.lblOrderTotalHeading.Name = "lblOrderTotalHeading";
            this.lblOrderTotalHeading.Size = new System.Drawing.Size(159, 24);
            this.lblOrderTotalHeading.TabIndex = 7;
            this.lblOrderTotalHeading.Text = "Total Order Value";
            // 
            // lblOrderTotal
            // 
            this.lblOrderTotal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblOrderTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrderTotal.Location = new System.Drawing.Point(647, 520);
            this.lblOrderTotal.Name = "lblOrderTotal";
            this.lblOrderTotal.Size = new System.Drawing.Size(397, 24);
            this.lblOrderTotal.TabIndex = 8;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1199, 575);
            this.Controls.Add(this.lblOrderTotal);
            this.Controls.Add(this.lblOrderTotalHeading);
            this.Controls.Add(this.btnDeleteOrder);
            this.Controls.Add(this.lblOrdersHeading);
            this.Controls.Add(this.pnlOrderSort);
            this.Controls.Add(this.lblAuthorHeading);
            this.Controls.Add(this.pnlAuthorSort);
            this.Controls.Add(this.lbxOrders);
            this.Controls.Add(this.lbxAuthor);
            this.Name = "MainWindow";
            this.Text = "The Writers Collective";
            this.pnlAuthorSort.ResumeLayout(false);
            this.pnlAuthorSort.PerformLayout();
            this.pnlOrderSort.ResumeLayout(false);
            this.pnlOrderSort.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbxAuthor;
        private System.Windows.Forms.ListBox lbxOrders;
        private System.Windows.Forms.Panel pnlAuthorSort;
        private System.Windows.Forms.Label lblAuthorHeading;
        private System.Windows.Forms.Label lblAuthorSortHeading;
        private System.Windows.Forms.RadioButton rbtnAuthorDate;
        private System.Windows.Forms.RadioButton rbtnAuthorName;
        private System.Windows.Forms.Panel pnlOrderSort;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton rbtnOrderName;
        private System.Windows.Forms.Label lblOrderSortHeading;
        private System.Windows.Forms.Label lblOrdersHeading;
        private System.Windows.Forms.Button btnDeleteOrder;
        private System.Windows.Forms.Label lblOrderTotalHeading;
        private System.Windows.Forms.Label lblOrderTotal;
    }
}

