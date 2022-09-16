namespace SIMan
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.MainMenu mainMenu1;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.mSolKapasite = new System.Windows.Forms.MenuItem();
            this.mSolOku = new System.Windows.Forms.MenuItem();
            this.mSolOkuSIM = new System.Windows.Forms.MenuItem();
            this.mSolOkuTelefon = new System.Windows.Forms.MenuItem();
            this.mSolKopyala = new System.Windows.Forms.MenuItem();
            this.mSolKopyalaSIMtoTEL = new System.Windows.Forms.MenuItem();
            this.mSolKopyalaSIMtoTELsecili = new System.Windows.Forms.MenuItem();
            this.mSolKopyalaSIMtoTELhepsi = new System.Windows.Forms.MenuItem();
            this.mSolKopyalaTELtoSIM = new System.Windows.Forms.MenuItem();
            this.mSolKopyalaTELtoSIMsecili = new System.Windows.Forms.MenuItem();
            this.mSolKopyalaTELtoSIMhepsi = new System.Windows.Forms.MenuItem();
            this.mSolSil = new System.Windows.Forms.MenuItem();
            this.mSolGoster = new System.Windows.Forms.MenuItem();
            this.mSolGosterSIM = new System.Windows.Forms.MenuItem();
            this.mSolGosterTEL = new System.Windows.Forms.MenuItem();
            this.mSolGosterSIMTEL = new System.Windows.Forms.MenuItem();
            this.mSolTabloSec = new System.Windows.Forms.MenuItem();
            this.mSolTabloSecSIM = new System.Windows.Forms.MenuItem();
            this.mSolTabloSecTEL = new System.Windows.Forms.MenuItem();
            this.mSolTumunu = new System.Windows.Forms.MenuItem();
            this.mSolTumunuSec = new System.Windows.Forms.MenuItem();
            this.mSolTumunuSecme = new System.Windows.Forms.MenuItem();
            this.mSolTumunuCevir = new System.Windows.Forms.MenuItem();
            this.mSolCikis = new System.Windows.Forms.MenuItem();
            this.mSolRehberYedekleYukle = new System.Windows.Forms.MenuItem();
            this.menuItem3 = new System.Windows.Forms.MenuItem();
            this.TabloSIM = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.TabloTEL = new System.Windows.Forms.ListView();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.prgBAR = new System.Windows.Forms.ProgressBar();
            this.pbBEN = new System.Windows.Forms.PictureBox();
            this.txtUyari = new System.Windows.Forms.Label();
            this.mSolRehberYedekle = new System.Windows.Forms.MenuItem();
            this.mSolRehberGeriYukle = new System.Windows.Forms.MenuItem();
            this.SuspendLayout();
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.Add(this.menuItem2);
            this.mainMenu1.MenuItems.Add(this.menuItem3);
            // 
            // menuItem2
            // 
            this.menuItem2.MenuItems.Add(this.mSolKapasite);
            this.menuItem2.MenuItems.Add(this.mSolOku);
            this.menuItem2.MenuItems.Add(this.mSolKopyala);
            this.menuItem2.MenuItems.Add(this.mSolSil);
            this.menuItem2.MenuItems.Add(this.mSolGoster);
            this.menuItem2.MenuItems.Add(this.mSolTabloSec);
            this.menuItem2.MenuItems.Add(this.mSolTumunu);
            this.menuItem2.MenuItems.Add(this.mSolRehberYedekleYukle);
            this.menuItem2.MenuItems.Add(this.mSolCikis);
            this.menuItem2.Text = "Seçenekler";
            this.menuItem2.Click += new System.EventHandler(this.menuItem2_Click);
            // 
            // mSolKapasite
            // 
            this.mSolKapasite.Text = "Kapasite";
            this.mSolKapasite.Click += new System.EventHandler(this.mSolKapasite_Click);
            // 
            // mSolOku
            // 
            this.mSolOku.MenuItems.Add(this.mSolOkuSIM);
            this.mSolOku.MenuItems.Add(this.mSolOkuTelefon);
            this.mSolOku.Text = "Oku";
            // 
            // mSolOkuSIM
            // 
            this.mSolOkuSIM.Text = "SIM Hafýzasý";
            this.mSolOkuSIM.Click += new System.EventHandler(this.mSolOkuSIM_Click);
            // 
            // mSolOkuTelefon
            // 
            this.mSolOkuTelefon.Text = "Telefon Hafýzasý";
            this.mSolOkuTelefon.Click += new System.EventHandler(this.mSolOkuTelefon_Click);
            // 
            // mSolKopyala
            // 
            this.mSolKopyala.MenuItems.Add(this.mSolKopyalaSIMtoTEL);
            this.mSolKopyala.MenuItems.Add(this.mSolKopyalaTELtoSIM);
            this.mSolKopyala.Text = "Kopyala";
            this.mSolKopyala.Click += new System.EventHandler(this.mSolEkle_Click);
            // 
            // mSolKopyalaSIMtoTEL
            // 
            this.mSolKopyalaSIMtoTEL.MenuItems.Add(this.mSolKopyalaSIMtoTELsecili);
            this.mSolKopyalaSIMtoTEL.MenuItems.Add(this.mSolKopyalaSIMtoTELhepsi);
            this.mSolKopyalaSIMtoTEL.Text = "SIM->Telefon";
            // 
            // mSolKopyalaSIMtoTELsecili
            // 
            this.mSolKopyalaSIMtoTELsecili.Text = "Seçili olanlarý";
            this.mSolKopyalaSIMtoTELsecili.Click += new System.EventHandler(this.mSolKopyalaSIMtoTELsecili_Click);
            // 
            // mSolKopyalaSIMtoTELhepsi
            // 
            this.mSolKopyalaSIMtoTELhepsi.Text = "Hepsini";
            this.mSolKopyalaSIMtoTELhepsi.Click += new System.EventHandler(this.mSolKopyalaSIMtoTELhepsi_Click);
            // 
            // mSolKopyalaTELtoSIM
            // 
            this.mSolKopyalaTELtoSIM.MenuItems.Add(this.mSolKopyalaTELtoSIMsecili);
            this.mSolKopyalaTELtoSIM.MenuItems.Add(this.mSolKopyalaTELtoSIMhepsi);
            this.mSolKopyalaTELtoSIM.Text = "Telefon->SIM";
            // 
            // mSolKopyalaTELtoSIMsecili
            // 
            this.mSolKopyalaTELtoSIMsecili.Text = "Seçili olanlarý";
            this.mSolKopyalaTELtoSIMsecili.Click += new System.EventHandler(this.mSolKopyalaTELtoSIMsecili_Click);
            // 
            // mSolKopyalaTELtoSIMhepsi
            // 
            this.mSolKopyalaTELtoSIMhepsi.Text = "Hepsini";
            this.mSolKopyalaTELtoSIMhepsi.Click += new System.EventHandler(this.mSolKopyalaTELtoSIMhepsi_Click);
            // 
            // mSolSil
            // 
            this.mSolSil.Text = "Sil";
            this.mSolSil.Click += new System.EventHandler(this.mSolSil_Click);
            // 
            // mSolGoster
            // 
            this.mSolGoster.MenuItems.Add(this.mSolGosterSIM);
            this.mSolGoster.MenuItems.Add(this.mSolGosterTEL);
            this.mSolGoster.MenuItems.Add(this.mSolGosterSIMTEL);
            this.mSolGoster.Text = "Göster";
            // 
            // mSolGosterSIM
            // 
            this.mSolGosterSIM.Text = "SIM";
            this.mSolGosterSIM.Click += new System.EventHandler(this.mSolGosterSIM_Click);
            // 
            // mSolGosterTEL
            // 
            this.mSolGosterTEL.Text = "Telefon";
            this.mSolGosterTEL.Click += new System.EventHandler(this.mSolGosterTEL_Click);
            // 
            // mSolGosterSIMTEL
            // 
            this.mSolGosterSIMTEL.Text = "SIM && Telefon";
            this.mSolGosterSIMTEL.Click += new System.EventHandler(this.mSolGosterSIMTEL_Click);
            // 
            // mSolTabloSec
            // 
            this.mSolTabloSec.MenuItems.Add(this.mSolTabloSecSIM);
            this.mSolTabloSec.MenuItems.Add(this.mSolTabloSecTEL);
            this.mSolTabloSec.Text = "Tablo Seç";
            // 
            // mSolTabloSecSIM
            // 
            this.mSolTabloSecSIM.Text = "SIM";
            this.mSolTabloSecSIM.Click += new System.EventHandler(this.mSolTabloSecSIM_Click);
            // 
            // mSolTabloSecTEL
            // 
            this.mSolTabloSecTEL.Text = "Telefon";
            this.mSolTabloSecTEL.Click += new System.EventHandler(this.mSolTabloSecTEL_Click);
            // 
            // mSolTumunu
            // 
            this.mSolTumunu.MenuItems.Add(this.mSolTumunuSec);
            this.mSolTumunu.MenuItems.Add(this.mSolTumunuSecme);
            this.mSolTumunu.MenuItems.Add(this.mSolTumunuCevir);
            this.mSolTumunu.Text = "Tümünü...";
            // 
            // mSolTumunuSec
            // 
            this.mSolTumunuSec.Text = "Seç";
            this.mSolTumunuSec.Click += new System.EventHandler(this.mSolTumunuSec_Click);
            // 
            // mSolTumunuSecme
            // 
            this.mSolTumunuSecme.Text = "Seçimden Çýkar";
            this.mSolTumunuSecme.Click += new System.EventHandler(this.mSolTumunuSecme_Click);
            // 
            // mSolTumunuCevir
            // 
            this.mSolTumunuCevir.Text = "Tersine Çevir";
            this.mSolTumunuCevir.Click += new System.EventHandler(this.mSolTumunuCevir_Click);
            // 
            // mSolCikis
            // 
            this.mSolCikis.Text = "Çýkýþ";
            this.mSolCikis.Click += new System.EventHandler(this.mSolCikis_Click);
            // 
            // mSolRehberYedekleYukle
            // 
            this.mSolRehberYedekleYukle.MenuItems.Add(this.mSolRehberYedekle);
            this.mSolRehberYedekleYukle.MenuItems.Add(this.mSolRehberGeriYukle);
            this.mSolRehberYedekleYukle.Text = "Yedekle && Yükle";
            // 
            // menuItem3
            // 
            this.menuItem3.Text = "Hakkinda";
            this.menuItem3.Click += new System.EventHandler(this.menuItem3_Click_1);
            // 
            // TabloSIM
            // 
            this.TabloSIM.CheckBoxes = true;
            this.TabloSIM.Columns.Add(this.columnHeader1);
            this.TabloSIM.Columns.Add(this.columnHeader2);
            this.TabloSIM.Location = new System.Drawing.Point(0, 0);
            this.TabloSIM.Name = "TabloSIM";
            this.TabloSIM.Size = new System.Drawing.Size(176, 85);
            this.TabloSIM.TabIndex = 1;
            this.TabloSIM.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Alan";
            this.columnHeader1.Width = 121;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Deðer";
            this.columnHeader2.Width = 52;
            // 
            // TabloTEL
            // 
            this.TabloTEL.CheckBoxes = true;
            this.TabloTEL.Columns.Add(this.columnHeader3);
            this.TabloTEL.Columns.Add(this.columnHeader4);
            this.TabloTEL.Location = new System.Drawing.Point(0, 95);
            this.TabloTEL.Name = "TabloTEL";
            this.TabloTEL.Size = new System.Drawing.Size(176, 85);
            this.TabloTEL.TabIndex = 2;
            this.TabloTEL.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Alan";
            this.columnHeader3.Width = 121;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Deðer";
            this.columnHeader4.Width = 52;
            // 
            // prgBAR
            // 
            this.prgBAR.Location = new System.Drawing.Point(0, 158);
            this.prgBAR.Maximum = 0;
            this.prgBAR.Name = "prgBAR";
            this.prgBAR.Size = new System.Drawing.Size(176, 22);
            // 
            // pbBEN
            // 
            this.pbBEN.Image = ((System.Drawing.Image)(resources.GetObject("pbBEN.Image")));
            this.pbBEN.Location = new System.Drawing.Point(44, 0);
            this.pbBEN.Name = "pbBEN";
            this.pbBEN.Size = new System.Drawing.Size(91, 105);
            this.pbBEN.Visible = false;
            // 
            // txtUyari
            // 
            this.txtUyari.Font = new System.Drawing.Font("Segoe Condensed", 8F, System.Drawing.FontStyle.Bold);
            this.txtUyari.Location = new System.Drawing.Point(0, 108);
            this.txtUyari.Name = "txtUyari";
            this.txtUyari.Size = new System.Drawing.Size(176, 67);
            this.txtUyari.Text = "Programcý: Süleyman GÜNEL\r\nBu programýn kullanýmýndan doðabilecek hiçbir hatadan " +
                "programýn yazarý sorumlu tutulamaz. Programýn kullanýlmasý, bu þartýn kabul edil" +
                "diðini gösterir.";
            this.txtUyari.Visible = false;
            // 
            // mSolRehberYedekle
            // 
            this.mSolRehberYedekle.Text = "Yedekle";
            this.mSolRehberYedekle.Click += new System.EventHandler(this.mSolRehberYedekle_Click);
            // 
            // mSolRehberGeriYukle
            // 
            this.mSolRehberGeriYukle.Text = "Geri Yükle";
            this.mSolRehberGeriYukle.Click += new System.EventHandler(this.mSolRehberGeriYukle_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(176, 180);
            this.Controls.Add(this.txtUyari);
            this.Controls.Add(this.pbBEN);
            this.Controls.Add(this.prgBAR);
            this.Controls.Add(this.TabloTEL);
            this.Controls.Add(this.TabloSIM);
            this.KeyPreview = true;
            this.Menu = this.mainMenu1;
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MenuItem menuItem2;
        private System.Windows.Forms.ListView TabloSIM;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.MenuItem mSolKapasite;
        private System.Windows.Forms.MenuItem mSolOku;
        private System.Windows.Forms.MenuItem mSolKopyala;
        private System.Windows.Forms.MenuItem mSolSil;
        private System.Windows.Forms.MenuItem mSolOkuSIM;
        private System.Windows.Forms.MenuItem mSolOkuTelefon;
        private System.Windows.Forms.ListView TabloTEL;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.MenuItem mSolGoster;
        private System.Windows.Forms.MenuItem mSolGosterSIM;
        private System.Windows.Forms.MenuItem mSolGosterTEL;
        private System.Windows.Forms.MenuItem mSolGosterSIMTEL;
        private System.Windows.Forms.MenuItem mSolKopyalaSIMtoTEL;
        private System.Windows.Forms.MenuItem mSolKopyalaTELtoSIM;
        private System.Windows.Forms.MenuItem mSolTumunu;
        private System.Windows.Forms.MenuItem mSolTabloSec;
        private System.Windows.Forms.MenuItem mSolTabloSecSIM;
        private System.Windows.Forms.MenuItem mSolTabloSecTEL;
        private System.Windows.Forms.MenuItem mSolTumunuSec;
        private System.Windows.Forms.MenuItem mSolTumunuSecme;
        private System.Windows.Forms.MenuItem mSolTumunuCevir;
        private System.Windows.Forms.MenuItem mSolCikis;
        private System.Windows.Forms.MenuItem menuItem3;
        private System.Windows.Forms.ProgressBar prgBAR;
        private System.Windows.Forms.PictureBox pbBEN;
        private System.Windows.Forms.Label txtUyari;
        private System.Windows.Forms.MenuItem mSolKopyalaTELtoSIMsecili;
        private System.Windows.Forms.MenuItem mSolKopyalaTELtoSIMhepsi;
        private System.Windows.Forms.MenuItem mSolKopyalaSIMtoTELsecili;
        private System.Windows.Forms.MenuItem mSolKopyalaSIMtoTELhepsi;
        private System.Windows.Forms.MenuItem mSolRehberYedekleYukle;
        private System.Windows.Forms.MenuItem mSolRehberYedekle;
        private System.Windows.Forms.MenuItem mSolRehberGeriYukle;
    }
}

