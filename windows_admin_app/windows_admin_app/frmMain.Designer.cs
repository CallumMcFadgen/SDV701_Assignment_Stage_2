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
            this.rbtnAuthorDate = new System.Windows.Forms.RadioButton();
            this.rbtnAuthorName = new System.Windows.Forms.RadioButton();
            this.lblAuthorHeading = new System.Windows.Forms.Label();
            this.lblOrdersHeading = new System.Windows.Forms.Label();
            this.btnDeleteOrder = new System.Windows.Forms.Button();
            this.lblOrderTotalHeading = new System.Windows.Forms.Label();
            this.lblOrderTotal = new System.Windows.Forms.Label();
            this.gbxAuthorSort = new System.Windows.Forms.GroupBox();
            this.gbxOrderSort = new System.Windows.Forms.GroupBox();
            this.rbtnOrderDate = new System.Windows.Forms.RadioButton();
            this.rbtnOrderName = new System.Windows.Forms.RadioButton();
            this.btnQuit = new System.Windows.Forms.Button();
            this.gbxAuthorSort.SuspendLayout();
            this.gbxOrderSort.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbxAuthor
            // 
            this.lbxAuthor.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbxAuthor.FormattingEnabled = true;
            this.lbxAuthor.ItemHeight = 18;
            this.lbxAuthor.Location = new System.Drawing.Point(35, 60);
            this.lbxAuthor.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lbxAuthor.Name = "lbxAuthor";
            this.lbxAuthor.Size = new System.Drawing.Size(265, 472);
            this.lbxAuthor.TabIndex = 0;
            this.lbxAuthor.DoubleClick += new System.EventHandler(this.lbxAuthor_DoubleClick);
            // 
            // lbxOrders
            // 
            this.lbxOrders.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbxOrders.FormattingEnabled = true;
            this.lbxOrders.ItemHeight = 18;
            this.lbxOrders.Location = new System.Drawing.Point(469, 60);
            this.lbxOrders.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lbxOrders.Name = "lbxOrders";
            this.lbxOrders.Size = new System.Drawing.Size(532, 436);
            this.lbxOrders.TabIndex = 1;
            // 
            // rbtnAuthorDate
            // 
            this.rbtnAuthorDate.AutoSize = true;
            this.rbtnAuthorDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnAuthorDate.Location = new System.Drawing.Point(19, 75);
            this.rbtnAuthorDate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
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
            this.rbtnAuthorName.Location = new System.Drawing.Point(19, 48);
            this.rbtnAuthorName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rbtnAuthorName.Name = "rbtnAuthorName";
            this.rbtnAuthorName.Size = new System.Drawing.Size(66, 21);
            this.rbtnAuthorName.TabIndex = 4;
            this.rbtnAuthorName.TabStop = true;
            this.rbtnAuthorName.Text = "Name";
            this.rbtnAuthorName.UseVisualStyleBackColor = true;
            // 
            // lblAuthorHeading
            // 
            this.lblAuthorHeading.AutoSize = true;
            this.lblAuthorHeading.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAuthorHeading.Location = new System.Drawing.Point(107, 11);
            this.lblAuthorHeading.Name = "lblAuthorHeading";
            this.lblAuthorHeading.Size = new System.Drawing.Size(120, 36);
            this.lblAuthorHeading.TabIndex = 3;
            this.lblAuthorHeading.Text = "Authors";
            // 
            // lblOrdersHeading
            // 
            this.lblOrdersHeading.AutoSize = true;
            this.lblOrdersHeading.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrdersHeading.Location = new System.Drawing.Point(695, 11);
            this.lblOrdersHeading.Name = "lblOrdersHeading";
            this.lblOrdersHeading.Size = new System.Drawing.Size(105, 36);
            this.lblOrdersHeading.TabIndex = 5;
            this.lblOrdersHeading.Text = "Orders";
            // 
            // btnDeleteOrder
            // 
            this.btnDeleteOrder.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteOrder.Location = new System.Drawing.Point(1025, 202);
            this.btnDeleteOrder.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnDeleteOrder.Name = "btnDeleteOrder";
            this.btnDeleteOrder.Size = new System.Drawing.Size(107, 49);
            this.btnDeleteOrder.TabIndex = 6;
            this.btnDeleteOrder.Text = "Delete";
            this.btnDeleteOrder.UseVisualStyleBackColor = true;
            this.btnDeleteOrder.Click += new System.EventHandler(this.btnDeleteOrder_Click);
            // 
            // lblOrderTotalHeading
            // 
            this.lblOrderTotalHeading.AutoSize = true;
            this.lblOrderTotalHeading.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrderTotalHeading.Location = new System.Drawing.Point(524, 510);
            this.lblOrderTotalHeading.Name = "lblOrderTotalHeading";
            this.lblOrderTotalHeading.Size = new System.Drawing.Size(159, 24);
            this.lblOrderTotalHeading.TabIndex = 7;
            this.lblOrderTotalHeading.Text = "Total Order Value";
            // 
            // lblOrderTotal
            // 
            this.lblOrderTotal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblOrderTotal.Font = new System.Drawing.Font("Consolas", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrderTotal.Location = new System.Drawing.Point(701, 509);
            this.lblOrderTotal.Name = "lblOrderTotal";
            this.lblOrderTotal.Size = new System.Drawing.Size(261, 25);
            this.lblOrderTotal.TabIndex = 8;
            // 
            // gbxAuthorSort
            // 
            this.gbxAuthorSort.BackColor = System.Drawing.SystemColors.Control;
            this.gbxAuthorSort.Controls.Add(this.rbtnAuthorDate);
            this.gbxAuthorSort.Controls.Add(this.rbtnAuthorName);
            this.gbxAuthorSort.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbxAuthorSort.Location = new System.Drawing.Point(320, 50);
            this.gbxAuthorSort.Name = "gbxAuthorSort";
            this.gbxAuthorSort.Size = new System.Drawing.Size(106, 123);
            this.gbxAuthorSort.TabIndex = 9;
            this.gbxAuthorSort.TabStop = false;
            this.gbxAuthorSort.Text = "Sort by";
            // 
            // gbxOrderSort
            // 
            this.gbxOrderSort.BackColor = System.Drawing.SystemColors.Control;
            this.gbxOrderSort.Controls.Add(this.rbtnOrderDate);
            this.gbxOrderSort.Controls.Add(this.rbtnOrderName);
            this.gbxOrderSort.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbxOrderSort.Location = new System.Drawing.Point(1025, 50);
            this.gbxOrderSort.Name = "gbxOrderSort";
            this.gbxOrderSort.Size = new System.Drawing.Size(106, 123);
            this.gbxOrderSort.TabIndex = 10;
            this.gbxOrderSort.TabStop = false;
            this.gbxOrderSort.Text = "Sort by";
            // 
            // rbtnOrderDate
            // 
            this.rbtnOrderDate.AutoSize = true;
            this.rbtnOrderDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnOrderDate.Location = new System.Drawing.Point(19, 75);
            this.rbtnOrderDate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rbtnOrderDate.Name = "rbtnOrderDate";
            this.rbtnOrderDate.Size = new System.Drawing.Size(59, 21);
            this.rbtnOrderDate.TabIndex = 5;
            this.rbtnOrderDate.TabStop = true;
            this.rbtnOrderDate.Text = "Date";
            this.rbtnOrderDate.UseVisualStyleBackColor = true;
            // 
            // rbtnOrderName
            // 
            this.rbtnOrderName.AutoSize = true;
            this.rbtnOrderName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnOrderName.Location = new System.Drawing.Point(19, 48);
            this.rbtnOrderName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rbtnOrderName.Name = "rbtnOrderName";
            this.rbtnOrderName.Size = new System.Drawing.Size(66, 21);
            this.rbtnOrderName.TabIndex = 4;
            this.rbtnOrderName.TabStop = true;
            this.rbtnOrderName.Text = "Name";
            this.rbtnOrderName.UseVisualStyleBackColor = true;
            // 
            // btnQuit
            // 
            this.btnQuit.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQuit.Location = new System.Drawing.Point(1024, 495);
            this.btnQuit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Size = new System.Drawing.Size(107, 49);
            this.btnQuit.TabIndex = 11;
            this.btnQuit.Text = "Quit";
            this.btnQuit.UseVisualStyleBackColor = true;
            this.btnQuit.Click += new System.EventHandler(this.btnQuit_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1165, 575);
            this.Controls.Add(this.btnQuit);
            this.Controls.Add(this.gbxOrderSort);
            this.Controls.Add(this.gbxAuthorSort);
            this.Controls.Add(this.lblOrderTotal);
            this.Controls.Add(this.lblOrderTotalHeading);
            this.Controls.Add(this.btnDeleteOrder);
            this.Controls.Add(this.lblOrdersHeading);
            this.Controls.Add(this.lblAuthorHeading);
            this.Controls.Add(this.lbxOrders);
            this.Controls.Add(this.lbxAuthor);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frmMain";
            this.Text = "The Writers Collective";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.gbxAuthorSort.ResumeLayout(false);
            this.gbxAuthorSort.PerformLayout();
            this.gbxOrderSort.ResumeLayout(false);
            this.gbxOrderSort.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbxAuthor;
        private System.Windows.Forms.ListBox lbxOrders;
        private System.Windows.Forms.Label lblAuthorHeading;
        private System.Windows.Forms.RadioButton rbtnAuthorDate;
        private System.Windows.Forms.RadioButton rbtnAuthorName;
        private System.Windows.Forms.Label lblOrdersHeading;
        private System.Windows.Forms.Button btnDeleteOrder;
        private System.Windows.Forms.Label lblOrderTotalHeading;
        private System.Windows.Forms.Label lblOrderTotal;
        private System.Windows.Forms.GroupBox gbxAuthorSort;
        private System.Windows.Forms.GroupBox gbxOrderSort;
        private System.Windows.Forms.RadioButton rbtnOrderDate;
        private System.Windows.Forms.RadioButton rbtnOrderName;
        private System.Windows.Forms.Button btnQuit;
    }
}

