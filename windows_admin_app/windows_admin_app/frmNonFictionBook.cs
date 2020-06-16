using System;
using System.Windows.Forms;

namespace windows_admin_app
{
    public sealed partial class frmNonFictionBook : windows_admin_app.frmBook
    {
        private static readonly frmNonFictionBook Instance = new frmNonFictionBook();

        private frmNonFictionBook()
        {
            InitializeComponent();
        }

        public static void Run(clsBook prBook)
        {
            Instance.SetDetails(prBook);
        }

        protected override void updateForm()
        {
            base.updateForm();
            txtISBN.Text = _Book.Isbn;
            txtTitle.Text = _Book.Title;
            txtAuthor.Text = _Book.AuthorName;
            txtDesc.Text = _Book.Desc;
            txtPrice.Text = _Book.Price.ToString();
            txtQuantity.Text = _Book.Quantity.ToString();
            txtCategory.Text = _Book.Category;
        }

        protected override void pushData()
        {
            base.pushData();
            _Book.Isbn = txtISBN.Text;
            _Book.Title = txtTitle.Text;
            _Book.AuthorName = txtAuthor.Text;
            _Book.Desc = txtDesc.Text;
            _Book.Price = decimal.Parse(txtPrice.Text);
            _Book.Quantity = int.Parse(txtQuantity.Text);
            _Book.EditDate = DateTime.Now;
            _Book.Category = txtCategory.Text;
        }

        private bool isCategoryValid()
        {
            if (string.IsNullOrWhiteSpace(txtCategory.Text))
            {
                MessageBox.Show("Please enter a genre");
                return false;
            }

            return true;
        }

        // CHECK FOR FIELD CHANGES
        protected override bool isChanged()
        {
            if (base.isChanged() || txtCategory.Text != _Book.Category)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

    }
}
