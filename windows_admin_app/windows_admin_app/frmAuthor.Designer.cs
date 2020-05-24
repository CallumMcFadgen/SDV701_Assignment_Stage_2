namespace windows_admin_app
{
    partial class frmAuthor
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
            this.gbxBookSort = new System.Windows.Forms.GroupBox();
            this.rbtnBookName = new System.Windows.Forms.RadioButton();
            this.rbtnBookPrice = new System.Windows.Forms.RadioButton();
            this.lbxBooks = new System.Windows.Forms.ListBox();
            this.btnDeleteBook = new System.Windows.Forms.Button();
            this.btnAddBook = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblAuthorTotal = new System.Windows.Forms.Label();
            this.lblAuthorTotalHeading = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblBooks = new System.Windows.Forms.Label();
            this.gbxBookSort.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbxBookSort
            // 
            this.gbxBookSort.BackColor = System.Drawing.SystemColors.Control;
            this.gbxBookSort.Controls.Add(this.rbtnBookName);
            this.gbxBookSort.Controls.Add(this.rbtnBookPrice);
            this.gbxBookSort.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbxBookSort.Location = new System.Drawing.Point(212, 152);
            this.gbxBookSort.Name = "gbxBookSort";
            this.gbxBookSort.Size = new System.Drawing.Size(241, 43);
            this.gbxBookSort.TabIndex = 11;
            this.gbxBookSort.TabStop = false;
            this.gbxBookSort.Text = "Sort by";
            // 
            // rbtnBookName
            // 
            this.rbtnBookName.AutoSize = true;
            this.rbtnBookName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnBookName.Location = new System.Drawing.Point(85, 17);
            this.rbtnBookName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rbtnBookName.Name = "rbtnBookName";
            this.rbtnBookName.Size = new System.Drawing.Size(66, 21);
            this.rbtnBookName.TabIndex = 5;
            this.rbtnBookName.TabStop = true;
            this.rbtnBookName.Text = "Name";
            this.rbtnBookName.UseVisualStyleBackColor = true;
            // 
            // rbtnBookPrice
            // 
            this.rbtnBookPrice.AutoSize = true;
            this.rbtnBookPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnBookPrice.Location = new System.Drawing.Point(167, 18);
            this.rbtnBookPrice.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rbtnBookPrice.Name = "rbtnBookPrice";
            this.rbtnBookPrice.Size = new System.Drawing.Size(61, 21);
            this.rbtnBookPrice.TabIndex = 4;
            this.rbtnBookPrice.TabStop = true;
            this.rbtnBookPrice.Text = "Price";
            this.rbtnBookPrice.UseVisualStyleBackColor = true;
            // 
            // lbxBooks
            // 
            this.lbxBooks.FormattingEnabled = true;
            this.lbxBooks.ItemHeight = 16;
            this.lbxBooks.Location = new System.Drawing.Point(27, 205);
            this.lbxBooks.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lbxBooks.Name = "lbxBooks";
            this.lbxBooks.Size = new System.Drawing.Size(426, 212);
            this.lbxBooks.TabIndex = 10;
            // 
            // btnDeleteBook
            // 
            this.btnDeleteBook.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteBook.Location = new System.Drawing.Point(184, 513);
            this.btnDeleteBook.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnDeleteBook.Name = "btnDeleteBook";
            this.btnDeleteBook.Size = new System.Drawing.Size(107, 49);
            this.btnDeleteBook.TabIndex = 12;
            this.btnDeleteBook.Text = "Delete";
            this.btnDeleteBook.UseVisualStyleBackColor = true;
            // 
            // btnAddBook
            // 
            this.btnAddBook.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddBook.Location = new System.Drawing.Point(62, 513);
            this.btnAddBook.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAddBook.Name = "btnAddBook";
            this.btnAddBook.Size = new System.Drawing.Size(107, 49);
            this.btnAddBook.TabIndex = 13;
            this.btnAddBook.Text = "Add";
            this.btnAddBook.UseVisualStyleBackColor = true;
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(305, 513);
            this.btnClose.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(107, 49);
            this.btnClose.TabIndex = 14;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // lblAuthorTotal
            // 
            this.lblAuthorTotal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblAuthorTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAuthorTotal.Location = new System.Drawing.Point(169, 428);
            this.lblAuthorTotal.Name = "lblAuthorTotal";
            this.lblAuthorTotal.Size = new System.Drawing.Size(243, 25);
            this.lblAuthorTotal.TabIndex = 16;
            // 
            // lblAuthorTotalHeading
            // 
            this.lblAuthorTotalHeading.AutoSize = true;
            this.lblAuthorTotalHeading.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAuthorTotalHeading.Location = new System.Drawing.Point(58, 428);
            this.lblAuthorTotalHeading.Name = "lblAuthorTotalHeading";
            this.lblAuthorTotalHeading.Size = new System.Drawing.Size(105, 24);
            this.lblAuthorTotalHeading.TabIndex = 15;
            this.lblAuthorTotalHeading.Text = "Total Value";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(23, 30);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(61, 24);
            this.lblName.TabIndex = 17;
            this.lblName.Text = "Name";
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmail.Location = new System.Drawing.Point(23, 76);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(57, 24);
            this.lblEmail.TabIndex = 18;
            this.lblEmail.Text = "Email";
            // 
            // txtName
            // 
            this.txtName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtName.Location = new System.Drawing.Point(90, 30);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(363, 24);
            this.txtName.TabIndex = 19;
            // 
            // txtEmail
            // 
            this.txtEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmail.Location = new System.Drawing.Point(90, 76);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(363, 24);
            this.txtEmail.TabIndex = 20;
            // 
            // lblBooks
            // 
            this.lblBooks.AutoSize = true;
            this.lblBooks.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBooks.Location = new System.Drawing.Point(44, 154);
            this.lblBooks.Name = "lblBooks";
            this.lblBooks.Size = new System.Drawing.Size(99, 36);
            this.lblBooks.TabIndex = 21;
            this.lblBooks.Text = "Books";
            // 
            // AuthorWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(490, 582);
            this.Controls.Add(this.lblBooks);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.lblAuthorTotal);
            this.Controls.Add(this.lblAuthorTotalHeading);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnAddBook);
            this.Controls.Add(this.btnDeleteBook);
            this.Controls.Add(this.gbxBookSort);
            this.Controls.Add(this.lbxBooks);
            this.Name = "AuthorWindow";
            this.Text = "Author Details";
            this.gbxBookSort.ResumeLayout(false);
            this.gbxBookSort.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbxBookSort;
        private System.Windows.Forms.RadioButton rbtnBookName;
        private System.Windows.Forms.RadioButton rbtnBookPrice;
        private System.Windows.Forms.ListBox lbxBooks;
        private System.Windows.Forms.Button btnDeleteBook;
        private System.Windows.Forms.Button btnAddBook;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblAuthorTotal;
        private System.Windows.Forms.Label lblAuthorTotalHeading;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblBooks;
    }
}