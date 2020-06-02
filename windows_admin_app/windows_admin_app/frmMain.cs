﻿using System;
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

        private void frmMain_Load(object sender, EventArgs e)
        {
            UpdateDisplay();
        }

        //public delegate void Notify(string prGalleryName);

        //public event Notify GalleryNameChanged;

        //private void updateTitle(string prGalleryName)
        //{
        //    if (!string.IsNullOrEmpty(prGalleryName))
        //        Text = "Gallery (v3 C) - " + prGalleryName;
        //}

        public async void UpdateDisplay()
        {
            try
            {
                lbxAuthor.DataSource = null;
                lbxAuthor.DataSource = await ServiceClient.GetAuthorNamesAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                frmAuthor.Run(null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

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
                    MessageBox.Show(ex.Message, "This should never occur");
                }
        }



        private void btnDeleteOrder_Click(object sender, EventArgs e)
        {
            UpdateDisplay();
        }



        private async void btnDelete_Click(object sender, EventArgs e)
        {
            //string lcKey;
            //lcKey = Convert.ToString(lstArtists.SelectedItem);

            //if (lcKey != null && MessageBox.Show("Deleting an artist can not be undone", "Are you sure",
            //    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            //    try
            //    {
            //        MessageBox.Show(await ServiceClient.DeleteArtist(lcKey));
            //        lstArtists.ClearSelected();
            //        UpdateDisplay();
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show(ex.Message, "Error deleting artist");
            //    }
        }


        //private void btnGalName_Click(object sender, EventArgs e)
        //{
        //_ArtistList.GalleryName = new InputBox("Enter Gallery Name:").Answer;
        //GalleryNameChanged(_ArtistList.GalleryName);
        //}


        private void btnQuit_Click(object sender, EventArgs e)
        {
            Close();
        }

    }
}