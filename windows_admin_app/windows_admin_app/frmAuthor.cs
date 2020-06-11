using System;
using System.Windows.Forms;
using System.Collections.Generic;

namespace windows_admin_app
{
    public partial class frmAuthor : Form
    {

        #region VARIABLES

        private clsAuthor _Author;

        private static Dictionary<string, frmAuthor> _AuthorFormList = new Dictionary<string, frmAuthor>();

        #endregion

        #region CONSTRUCTOR

        public frmAuthor()
        {
            InitializeComponent();
        }

        #endregion

        #region RUN METHOD

        public static void Run(string prAuthorName)
        {
            frmAuthor lcAuthorForm;

            if (string.IsNullOrEmpty(prAuthorName) ||
            !_AuthorFormList.TryGetValue(prAuthorName, out lcAuthorForm))
            {
                lcAuthorForm = new frmAuthor();
                if (string.IsNullOrEmpty(prAuthorName))
                {
                    lcAuthorForm.SetDetails(new clsAuthor());
                }
                else
                {
                    _AuthorFormList.Add(prAuthorName, lcAuthorForm);
                    lcAuthorForm.refreshFormFromDB(prAuthorName);
                    lcAuthorForm.DisableTextFields();
                }
            }
            else
            {
                lcAuthorForm.Show();
                lcAuthorForm.Activate();
            }
        }

        #endregion

        #region METHODS
        private void DisableTextFields()
        {
            dateJoinDate.Enabled = false;
            txtName.Enabled = false;
        }

        private async void refreshFormFromDB(string prAuthorName)
        {
            SetDetails(await ServiceClient.GetAuthorAsync(prAuthorName));
        }

        private void UpdateDisplay()
        {
            lbxBooks.DataSource = null;

            if (_Author.BookList != null)
            {
                lbxBooks.DataSource = _Author.BookList;
            }
        }

        public void UpdateForm()
        {
            txtName.Text = _Author.Name;
            txtEmail.Text = _Author.Email;
            dateJoinDate.Value = _Author.JoinDate.ToUniversalTime();
        }

        public void SetDetails(clsAuthor prAuthor)
        {
            _Author = prAuthor;
            txtName.Enabled = string.IsNullOrEmpty(_Author.Name);
            UpdateForm();
            UpdateDisplay();
            Show();
        }

        private void pushData()
        {
            _Author.Name = txtName.Text;
            _Author.Email = txtEmail.Text;
            _Author.JoinDate = dateJoinDate.Value;
        } 
        #endregion

        #region UI METHODS
        private async void btnAdd_Click(object sender, EventArgs e)
        {
            string lcReply = new frmBookType().Answer;

            try
            {
                if (!string.IsNullOrEmpty(lcReply))
                {
                    clsBook lcBook = clsBook.NewBook(lcReply);
                    if (lcBook != null)
                    {
                        if (txtName.Enabled)
                        {
                            pushData();
                            await ServiceClient.InsertAuthorAsync(_Author);
                            txtName.Enabled = false;
                        }

                        lcBook.AuthorName = _Author.Name;
                        frmBook.DispatchBookForm(lcBook);

                        if (!string.IsNullOrEmpty(lcBook.Isbn))
                        {
                            refreshFormFromDB(_Author.Name);
                            frmMain.Instance.UpdateDisplay();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void lbxBooks_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                frmBook.DispatchBookForm(lbxBooks.SelectedItem as clsBook);
                UpdateDisplay();
                frmMain.Instance.UpdateDisplay();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            int lcIndex = lbxBooks.SelectedIndex;

            if (lcIndex >= 0 && MessageBox.Show("Are you sure?", "Deleting Book", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                MessageBox.Show(await ServiceClient.DeleteBookAsync(lbxBooks.SelectedItem as clsBook));
                refreshFormFromDB(_Author.Name);
                frmMain.Instance.UpdateDisplay();
            }
        }

        private async void btnClose_Click(object sender, EventArgs e)
        {
            if (isNameValid() == true && isEmailValid() == true)
                try
                {
                    pushData();
                    if (txtName.Enabled)
                    {
                        MessageBox.Show(await ServiceClient.InsertAuthorAsync(_Author));
                        frmMain.Instance.UpdateDisplay();
                        txtName.Enabled = false;
                        dateJoinDate.Enabled = false;
                    }
                    else
                        MessageBox.Show(await ServiceClient.UpdateAuthorAsync(_Author));
                    Hide();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
        } 

        #endregion

        #region INPUT VALIDATION

        private bool isNameValid()
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Please enter an author name");
                return false;
            }

            return true;
        } 

        private bool isEmailValid()
        {
            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MessageBox.Show("Please enter an email address");
                return false;
            }
            
                return true;
        }

        #endregion

    }
}
