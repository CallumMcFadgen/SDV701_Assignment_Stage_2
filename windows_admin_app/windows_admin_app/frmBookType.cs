using System;
using System.Windows.Forms;

namespace windows_admin_app
{
    public partial class frmBookType : Form
    {
        private string _Answer;

        public frmBookType()
        {
            InitializeComponent();
            setComboBox();
            ShowDialog();
        }

        // CONFIGURE THE COMBOBOX
        private void setComboBox()
        {
            cmbBookSelect.Items.Add("non-fiction");
            cmbBookSelect.Items.Add("fiction");
            cmbBookSelect.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbBookSelect.SelectedItem = "non-fiction";
            cmbBookSelect.Focus();
        }

        // VALIDATION CHECK THEN PASS RESULT
        private void btnOK_Click(object sender, EventArgs e)
        {
            if (isValid())
            {
                _Answer = cmbBookSelect.SelectedItem.ToString();
                DialogResult = DialogResult.OK;
            }
        }

        // CLOSE FORM
        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        // GET ANSWER VALUE
        public string Answer
        {
            get { return _Answer; }
        }

        // CHECKS FOR AN EMPTY OR NULL SELECTION
        private bool isValid()
        {
            if (string.IsNullOrEmpty(cmbBookSelect.Text))
            {
                MessageBox.Show("Please select a book type");
                return false;
            }

                return true;
        }
    }
}
