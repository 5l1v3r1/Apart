﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.Skins;
using DevExpress.LookAndFeel;
using DevExpress.UserSkins;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraBars.Helpers;


namespace ApartYonetim
{
    public partial class frmAnaSayfa : RibbonForm
    {
        public frmAnaSayfa()
        {
            InitializeComponent();
            InitSkinGallery();
        }
        void InitSkinGallery()
        {
            SkinHelper.InitSkinGallery(rgbiSkins, true);
        }

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            
        }

        private void frmMusteriler_ItemClick(object sender, ItemClickEventArgs e)
        {
            
           /* tbl_GelirTuru gelirturu = new tbl_GelirTuru();
            List <tbl_GelirTuru> liste= gelirturu.Listele().ToList();*/
            frmMusteriler form = new frmMusteriler();
            form.MdiParent = this;
            form.Show();
        }

        private void frmAnaSayfa_Load(object sender, EventArgs e)
        {

        }
    }
}