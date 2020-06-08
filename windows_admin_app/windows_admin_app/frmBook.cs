using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace windows_admin_app
{
    public partial class frmBook : Form
    {
        protected clsBook _Book;

        public delegate void LoadWorkFormDelegate(clsBook prBook);

        // NEEDS TO BE REBUILT FOR THE COMBO BOX
        public static Dictionary<string, Delegate> _BookForm = new System.Collections.Generic.Dictionary<string, Delegate>
        {
            {"non-fiction", new LoadWorkFormDelegate(frmNonFictionBook.Run)},
            {"fiction", new LoadWorkFormDelegate(frmFictionBook.Run)}
        };

        public frmBook()
        {
            InitializeComponent();
        }

        public static void DispatchBookForm(clsBook prBook)
        {
            _BookForm[prBook.Type].DynamicInvoke(prBook);
        }

        public void SetDetails(clsBook prBook)
        {
            _Book = prBook;
            updateForm();
            ShowDialog();
        }

        private async void btnOK_Click(object sender, EventArgs e)
        {
            if (isValid())
            {
                pushData();
                if (txtISBN.Enabled)
                    MessageBox.Show(await ServiceClient.InsertBookAsync(_Book));
                else
                    MessageBox.Show(await ServiceClient.UpdateBookAsync(_Book));
                Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        protected virtual bool isValid()
        {
            if (string.IsNullOrWhiteSpace(txtISBN.Text) && string.IsNullOrWhiteSpace(txtAuthor.Text))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        protected virtual void updateForm()
        {
            txtISBN.Enabled = string.IsNullOrEmpty(_Book.Isbn);
            txtTitle.Text = _Book.Title.ToString();
            txtAuthor.Text = _Book.AuthorName.ToString();
            txtDesc.Text = _Book.Desc.ToString();
            txtPrice.Text = _Book.Price.ToString();
            txtQuantity.Text = _Book.Quantity.ToString();
            dateEditDate.Value = _Book.EditDate;

            if (txtISBN.Enabled == false)
            {
                dateEditDate.Enabled = false;
                txtAuthor.Enabled = false;
                dateEditDate.Value = DateTime.Now;
            }
        }

        protected virtual void pushData()
        {
            _Book.Isbn = txtISBN.Text;
            _Book.Title = txtTitle.Text;
            _Book.AuthorName = txtAuthor.Text;
            _Book.Desc = txtDesc.Text;
            _Book.Price = decimal.Parse(txtPrice.Text);
            _Book.Quantity = int.Parse(txtQuantity.Text);
            _Book.EditDate = dateEditDate.Value;
        }
    }
}
