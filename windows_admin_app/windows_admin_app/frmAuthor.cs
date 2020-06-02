using System;
using System.Windows.Forms;
using System.Collections.Generic;

namespace windows_admin_app
{
    public partial class frmAuthor : Form
    {
        private clsAuthor _Author;
        private DateTime _DefaultDate;
        //private clsBookList _BookList;

        private static Dictionary<string, frmAuthor> _AuthorFormList =
            new Dictionary<string, frmAuthor>();


        public frmAuthor()
        {
            InitializeComponent();
            _DefaultDate = DateTime.Today;
            MessageBox.Show(_DefaultDate.ToString("dd MMMM yyyy hh:mm:ss tt"));
        }

        public static void Run(string prAuthorName)
        {
            frmAuthor lcAuthorForm;

            if (string.IsNullOrEmpty(prAuthorName) ||
            !_AuthorFormList.TryGetValue(prAuthorName, out lcAuthorForm))
            {
                lcAuthorForm = new frmAuthor();
                if (string.IsNullOrEmpty(prAuthorName))
                    lcAuthorForm.SetDetails(new clsAuthor());
                else
                {
                    _AuthorFormList.Add(prAuthorName, lcAuthorForm);
                    lcAuthorForm.refreshFormFromDB(prAuthorName);
                }
            }
            else
            {
                lcAuthorForm.Show();
                lcAuthorForm.Activate();
            }
        }

        private async void refreshFormFromDB(string prAuthorName)
        {
            SetDetails(await ServiceClient.GetAuthorAsync(prAuthorName));
        }

        private void updateTitle(string prGalleryName)
        {
            if (!string.IsNullOrEmpty(prGalleryName))
            {
                Text = "Artist Details - " + prGalleryName;
            }
        }

        private void UpdateDisplay()
        {
            //lbxBooks.DataSource = null;

            //if (_Author.BookList != null)
            //{
            //    lbxBooks.DataSource = _Author.BookList;
            //}
        }

        public void UpdateForm()
        {
            txtName.Text = _Author.Name;
            txtEmail.Text = _Author.Email;
            dateJoinDate.Value = _Author.JoinDate;
            //_WorksList = _Artist.WorksList;

            //frmMain.Instance.GalleryNameChanged += new frmMain.Notify(updateTitle);
            //updateTitle(_Artist.ArtistList.GalleryName);
        }

        public void SetDetails(clsAuthor prAuthor)
        {
            

            _Author = prAuthor;
            txtName.Enabled = string.IsNullOrEmpty(_Author.Name);
            //dateJoinDate.Enabled = CurrentDate;
            UpdateForm();
            UpdateDisplay();
           //frmMain.Instance.GalleryNameChanged += new frmMain.Notify(updateTitle);
            //updateTitle(_Artist.ArtistList.GalleryName);
            Show();
        }

        private void pushData()
        {
            _Author.Name = txtName.Text;
            _Author.Email = txtEmail.Text;
            _Author.JoinDate = dateJoinDate.Value;
            //_WorksList.SortOrder = _SortOrder; // no longer required, updated with each rbByDate_CheckedChanged
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

        //private void lstWorks_DoubleClick(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        frmWork.DispatchWorkForm(lstWorks.SelectedValue as clsAllWork);
        //        UpdateDisplay();
        //        frmMain.Instance.UpdateDisplay();
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //}

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

        private Boolean isValid()
        {
            //if (txtName.Enabled && txtName.Text != "")
            //    if (_Artist.IsDuplicate(txtName.Text))
            //    {
            //        MessageBox.Show("Artist with that name already exists!", "Error adding artist");
            //        return false;
            //    }
            //    else
            //        return true;
            //else
            return true;
        }

        private void rbByDate_CheckedChanged(object sender, EventArgs e)
        {
            //_WorksList.SortOrder = Convert.ToByte(rbByDate.Checked);
            UpdateDisplay();
        }

    }
}
