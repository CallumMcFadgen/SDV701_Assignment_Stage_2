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

        private void setComboBox()
        {
            cmbBookSelect.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbBookSelect.Items.Add("non-fiction");
            cmbBookSelect.Items.Add("fiction");
            cmbBookSelect.SelectedItem = "fiction";
            cmbBookSelect.Focus();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (isValid())
            {
                _Answer = cmbBookSelect.SelectedItem.ToString();
                DialogResult = DialogResult.OK;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        public string Answer
        {
            get { return _Answer; }
        }

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
