using System;
using System.Windows.Forms;
using System.Collections.Generic;

namespace windows_admin_app
{
    public partial class frmAuthor : Form
    {
        private clsAuthor _Author;
        private static Dictionary<string, frmAuthor> _AuthorFormList = new Dictionary<string, frmAuthor>();

        public frmAuthor()
        {
            InitializeComponent();
        }

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

       private void DisableTextFields()
        {
            dateJoinDate.Enabled = false;
            txtName.Enabled = false;
        }

        private async void refreshFormFromDB(string prAuthorName)
        {
           SetDetails(await ServiceClient.GetAuthorAsync(prAuthorName));       //bombs out
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
            //dateJoinDate.Value = _Author.JoinDate;
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

        //private async void btnAdd_Click(object sender, EventArgs e)
        //{
        //    string lcReply = new InputBox(clsAllWork.FACTORY_PROMPT).Answer;

        //    try
        //    {
        //        if (!string.IsNullOrEmpty(lcReply)) // not cancelled?
        //        {
        //            clsAllWork lcWork = clsAllWork.NewWork(lcReply[0]);
        //            if (lcWork != null) // valid artwork created?
        //            {
        //                if (txtName.Enabled) // new artist not saved?
        //                {
        //                    pushData();
        //                    await ServiceClient.InsertArtistAsync(_Artist);
        //                    txtName.Enabled = false;
        //                }

        //                lcWork.ArtistName = _Artist.Name;
        //                frmWork.DispatchWorkForm(lcWork);

        //                if (!string.IsNullOrEmpty(lcWork.Name)) // not cancelled?
        //                {
        //                    refreshFormFromDB(_Artist.Name);
        //                    frmMain.Instance.UpdateDisplay();
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //}

        private void lbxBooks_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                frmBook.DispatchBookForm(lbxBooks.SelectedValue as clsBook);
                UpdateDisplay();
                frmMain.Instance.UpdateDisplay();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //private async void btnDelete_Click(object sender, EventArgs e)
        //{
        //    int lcIndex = lstWorks.SelectedIndex;

        //    if (lcIndex >= 0 && MessageBox.Show("Are you sure?", "Deleting work", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
        //    {
        //        MessageBox.Show(await ServiceClient.DeleteArtworkAsync(lstWorks.SelectedItem as clsAllWork));
        //        refreshFormFromDB(_Artist.Name);
        //        frmMain.Instance.UpdateDisplay();
        //    }
        //}

        private async void btnClose_Click(object sender, EventArgs e)
        {
            if (isValid() == true)
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

        private bool isValid()
        {
            if (string.IsNullOrWhiteSpace(txtName.Text) && string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void rbByDate_CheckedChanged(object sender, EventArgs e)
        {
            //_WorksList.SortOrder = Convert.ToByte(rbByDate.Checked);
            UpdateDisplay();
        }

    }
}
