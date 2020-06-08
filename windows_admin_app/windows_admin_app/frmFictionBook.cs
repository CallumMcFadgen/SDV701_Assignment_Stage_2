using System;

namespace windows_admin_app
{
    public sealed partial class frmFictionBook : windows_admin_app.frmBook
    {
        private static readonly frmFictionBook Instance = new frmFictionBook();

        private frmFictionBook()
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
            txtISBN.Text = _Book.Isbn.ToString();
            txtTitle.Text = _Book.Title.ToString();
            txtAuthor.Text = _Book.AuthorName.ToString();
            txtDesc.Text = _Book.Desc.ToString();
            txtPrice.Text = _Book.Price.ToString();
            txtQuantity.Text = _Book.Quantity.ToString();
            dateEditDate.Value = _Book.EditDate;
            txtGenre.Text = _Book.Genre.ToString();
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
            _Book.EditDate = dateEditDate.Value;
            _Book.Genre = txtGenre.Text;
        }
    }
}
