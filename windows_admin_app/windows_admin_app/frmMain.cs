using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace windows_admin_app
{
    public sealed partial class frmMain : Form
    {

        #region Singleton Pattern

        private static readonly frmMain _Instance = new frmMain();

        private frmMain()
        {
            InitializeComponent();
        }

        public static frmMain Instance
        {
            get { return frmMain._Instance; }
        }
        #endregion

        #region LOAD METHOD

        // UPDATE DISPLAY ON FORM LOAD
        private void frmMain_Load(object sender, EventArgs e)
        {
            UpdateDisplay();
        }

        #endregion

        // SET UI ELEMENTS TO VALUES
        public async void UpdateDisplay()
        {
            decimal lctotal = 0;

            try
            {
                List<string> lcauthors = new List<string>();
                lcauthors = await ServiceClient.GetAuthorNamesAsync();
                List<clsOrder> lcorders = new List<clsOrder>();
                lcorders = await ServiceClient.GetOrdersAsync();

                lbxAuthor.DataSource = null;
                lbxOrders.DataSource = null;
                lbxAuthor.DataSource = lcauthors;
                lbxOrders.DataSource = lcorders;

                for (var i = 0; i < lcorders.Count; i++)
                {
                   lctotal += (lcorders[i].Price * lcorders[i].Quantity);
                }

                lblOrderTotal.Text = ("$" + lctotal.ToString());

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        #region UI METHODS

        // OPEN THE SELECTED ARTISTS FORM
        private void lbxAuthor_DoubleClick(object sender, EventArgs e)
        {
            string lcKey;
            lcKey = Convert.ToString(lbxAuthor.SelectedItem);

            if (lcKey != null)
                try
                {
                    frmAuthor.Run(lbxAuthor.SelectedItem as string);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
        }

        // DELETE A SELECTED LISTBOX ITEM AND REFRESH DISPLAY
        private async void btnDelete_Click(object sender, EventArgs e)
        {
            int lcIndex = lbxOrders.SelectedIndex;

            try
            {
                if (lcIndex >= 0 && MessageBox.Show("Are you sure?", "Deleting Order", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    MessageBox.Show(await ServiceClient.DeleteOrderAsync(lbxOrders.SelectedItem as clsOrder));
                    lbxOrders.ClearSelected();
                    UpdateDisplay();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // CLOSE APPLICATION
        private void btnQuit_Click(object sender, EventArgs e)
        {
            Close();
        } 

        #endregion

    }
}
