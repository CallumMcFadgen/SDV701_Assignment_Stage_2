using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace windows_admin_app
{
    public partial class frmBook : Form
    {

        #region VARIABLES

        protected clsBook _Book;

        public delegate void LoadWorkFormDelegate(clsBook prBook);

        public static Dictionary<string, Delegate> _BookForm = new System.Collections.Generic.Dictionary<string, Delegate>
        {
            {"non-fiction", new LoadWorkFormDelegate(frmNonFictionBook.Run)},
            {"fiction", new LoadWorkFormDelegate(frmFictionBook.Run)}
        };

        #endregion

        #region CONSTRUCTOR

        public frmBook()
        {
            InitializeComponent();
        }

        #endregion

        #region METHODS

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

        // SET VALUES IN THE UI FROM DTO
        protected virtual void updateForm()
        {
            txtISBN.Enabled = string.IsNullOrEmpty(_Book.Isbn);
            txtTitle.Text = _Book.Title;
            txtAuthor.Text = _Book.AuthorName;
            txtDesc.Text = _Book.Desc;
            txtPrice.Text = _Book.Price.ToString();
            txtQuantity.Text = _Book.Quantity.ToString();

            if (txtISBN.Enabled == false)
            {
                dateEditDate.Enabled = false;
                txtAuthor.Enabled = false;
                dateEditDate.Value = _Book.EditDate.ToUniversalTime();
            }
            else
            {
                dateEditDate.Value = DateTime.Now.ToUniversalTime();
            }
        }

        // PUSH UI DATA TO DTO
        protected virtual void pushData()
        {
            _Book.Isbn = txtISBN.Text;
            _Book.Title = txtTitle.Text;
            _Book.AuthorName = txtAuthor.Text;
            _Book.Desc = txtDesc.Text;
            _Book.Price = decimal.Parse(txtPrice.Text);
            _Book.Quantity = int.Parse(txtQuantity.Text);
            _Book.EditDate = DateTime.Now;
        }

        #endregion

        #region UI METHODS

        // CHECK FOR CHANGE AND VALIDATION THEN UPDATE OR INSERT
        protected async void btnOK_Click(object sender, EventArgs e)
        {
            if (isChanged() == true)
            {
                if (isISBNValid() == true && isAuthorValid() == true && isTitleValid() == true && isPriceValid() == true && isQuantityValid() == true)
                {
                    pushData();
                    if (txtISBN.Enabled)
                        MessageBox.Show(await ServiceClient.InsertBookAsync(_Book));
                    else
                        MessageBox.Show(await ServiceClient.UpdateBookAsync(_Book));
                    Close();
                }
            }
            else
            {
                Close();
            }
        }

        // CLOSE FORM WITH NO CHANGES
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        } 

        #endregion

        #region INPUT VALIDATION

        // CHECK IF ISBN IS NULL OR EMPTY
        protected virtual bool isISBNValid()
        {
            if (string.IsNullOrWhiteSpace(txtISBN.Text))
            {
                MessageBox.Show("Please enter an ISBN number");
                return false;
            }

            return true;
        }

        // CHECK IF AUTHOR NAME IS NULL OR EMPTY
        protected virtual bool isAuthorValid()
        {
            if (string.IsNullOrWhiteSpace(txtAuthor.Text))
            {
                MessageBox.Show("Please enter an author name");
                return false;
            }

            return true;
        }

        // CHECK IF THE BOOK TITLE IS NULL OR EMPTY
        protected virtual bool isTitleValid()
        {
            if (string.IsNullOrWhiteSpace(txtTitle.Text))
            {
                MessageBox.Show("Please enter a book title");
                return false;
            }

            return true;
        }

        // CHECK IF PRICE IS NULL OR EMPTY OR A LETTER
        protected virtual bool isPriceValid()
        {
            if (string.IsNullOrWhiteSpace(txtPrice.Text))
            {
                MessageBox.Show("Please enter a book price");
                return false;
            }

            if (txtPrice.Text.Any(x => char.IsLetter(x)))
            {
                MessageBox.Show("Book price is not a valid number");
                return false;
            }

            return true;
        }

        // CHECK IF QUANTITY IS NULL OR EMPTY OR A LETTER
        protected virtual bool isQuantityValid()
        {
            if (string.IsNullOrWhiteSpace(txtQuantity.Text))
            {
                MessageBox.Show("Please enter a book quantity");
                return false;
            }

            if (txtQuantity.Text.Any(x => char.IsLetter(x)))
            {
                MessageBox.Show("Book quantity is not a valid number");
                return false;
            }

            return true;
        }

        // CHECK FOR FIELD CHANGES
        protected virtual bool isChanged()
        {
            if (txtTitle.Text != _Book.Title || txtDesc.Text != _Book.Desc || txtPrice.Text != _Book.Price.ToString() || txtQuantity.Text != _Book.Price.ToString())
            {
                return true;
            }

            return false;
        }

        #endregion

    }
}
