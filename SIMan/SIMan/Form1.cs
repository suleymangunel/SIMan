using System;
using System.Drawing;
using System.Collections;
using System.Windows.Forms;
using System.Data;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Microsoft.WindowsMobile;
using Microsoft.WindowsMobile.Telephony;
using Microsoft.WindowsMobile.PocketOutlook;
using System.IO;
using SIMfnc;

namespace SIMan
{
    public partial class Form1 : Form
    {
        uint kapasite = 0;
        string baslik = "", baslik2 = "";
        string RehberDosya = "\\rehber.txt";
        public Form1()
        {
            InitializeComponent();
        }

        static void Main()
        {
            Application.Run(new Form1());
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = "SIMan";
            baslik = this.Text;
            mSolGosterSIM_Click(null, null);
        }

        private void mSolGosterSIM_Click(object sender, EventArgs e)
        {
            this.Text = baslik + " (SIM)";
            TabloSIM.Visible = true;
            TabloTEL.Visible = false;
            TabloSIM.Top = 0;
            TabloSIM.Height = 180;
            prgBAR.Visible = false;
        }

        private void mSolGosterTEL_Click(object sender, EventArgs e)
        {
            this.Text = baslik + " (TEL)"; 
            TabloSIM.Visible = false;
            TabloTEL.Visible = true;
            TabloTEL.Top = 0;
            TabloTEL.Height = 180;
            prgBAR.Visible = false;
        }

        private void mSolGosterSIMTEL_Click(object sender, EventArgs e)
        {
            this.Text = baslik + " (SIM&TEL)"; TabloSIM.Visible = true;
            TabloTEL.Visible = true;
            TabloSIM.Top = 0;
            TabloTEL.Top = 95;
            TabloSIM.Height = 85;
            TabloTEL.Height = 85;
            prgBAR.Visible = false;
        }

        private void menuItem1_Click(object sender, EventArgs e)
        {
            Contact kisi = new Contact();
            OutlookSession os = new OutlookSession();
            kisi.FirstName = "Süleyman";
            kisi.Properties[ContactProperty.LastName] = "GÜNEL";
            kisi.Properties[ContactProperty.SIMPhone] = "12345";
            kisi.Properties[ContactProperty.BusinessTelephoneNumber] = "55555";
            //kisi.BusinessTelephoneNumber = "55555";   Üstteki ile aynýdýr
            os.Contacts.Items.Add(kisi);
        }

        private void menuItem2_Click(object sender, EventArgs e)
        {
            /*Contact kisi = new Contact();
            OutlookSession os = new OutlookSession();
            MessageBox.Show(os.Contacts.Items[3].Properties[ContactProperty.FirstName].ToString());
            MessageBox.Show(os.Contacts.Items[3].Properties[ContactProperty.LastName].ToString());
            //MessageBox.Show(os.Contacts.Items[3].Properties[ContactProperty.SIMPhone].ToString());*/
        }

        private void AddToListViewSIM(string Item, string Value)
        {
            ListViewItem lvi = new ListViewItem(Item);
            lvi.SubItems.Add(Value);
            TabloSIM.Items.Add(lvi);
        }

        private void AddToListViewTEL(string Item, string Value)
        {
            ListViewItem lvi = new ListViewItem(Item);
            lvi.SubItems.Add(Value);
            TabloTEL.Items.Add(lvi);
        }

        private void mSolKapasite_Click(object sender, EventArgs e)
        {
            mSolGosterSIM_Click(null, null);
            SIM.SimCaps simCaps = new SIM.SimCaps();
            int hSim = 0;
            uint phoneUsed = 0;
            uint phoneTotal = 0;
            uint smsUsed = 0;
            uint smsTotal = 0;

            // Empty ListView
            TabloSIM.Items.Clear();
            TabloSIM.Columns[0].Width = 121;
            TabloSIM.Columns[1].Width = 52;
            TabloSIM.Columns[0].Text = "Alan";
            TabloSIM.Columns[1].Text = "Deðer";

            // Start SIM Manager session (get handle)
            SIM.SimInitialize(0, 0, 0, ref hSim);

            // Get Phonebook status (used, total)
            SIM.SimGetPhonebookStatus(hSim, SIM.SIM_PBSTORAGE_SIM, ref phoneUsed, ref phoneTotal);
            AddToListViewSIM("Total phonebook size:", phoneTotal.ToString());
            AddToListViewSIM("Phonebook entries:", phoneUsed.ToString());
            kapasite = phoneTotal;

            // Get SIM capabilities
            SIM.SimGetDevCaps(hSim, SIM.SIM_CAPSTYPE_ALL, ref simCaps);
            AddToListViewSIM("Max. length of name:", simCaps.dwMaxPBETextLength.ToString());
            AddToListViewSIM("Max. length of phone number:", simCaps.dwMaxPBEAddressLength.ToString());

            // Get Messages (SMS) status (used, total)
            SIM.SimGetSmsStorageStatus(hSim, SIM.SIM_SMSSTORAGE_SIM, ref smsUsed, ref smsTotal);
            AddToListViewSIM("SMS message storage capacity:", smsTotal.ToString());
            AddToListViewSIM("SMS messages:", smsUsed.ToString());

            // End SIM Manager session
            SIM.SimDeinitialize(hSim);
        }

        private void mSolEkle_Click(object sender, EventArgs e)
        {
            //SIM karta kayýt ekle
            int hSim = 0;
            SIM.SimInitialize(0, 0, 0, ref hSim);
            SIM.SIMPHONEBOOKENTRY phonebookEntry = new SIM.SIMPHONEBOOKENTRY();
            phonebookEntry.cbSize = SIM.SIMEntryCapacity;
            phonebookEntry.dwAddressType = SIM.SIM_ADDRTYPE_UNKNOWN;
            phonebookEntry.dwNumPlan = SIM.SIM_NUMPLAN_UNKNOWN;
            phonebookEntry.dwParams = 15;
            phonebookEntry.lpszAddress = "1666911";
            phonebookEntry.lpszText = "test";
            SIM.SimWritePhonebookEntry(hSim, SIM.SIM_PBSTORAGE_SIM, SIM.SIM_PBINDEX_FIRSTAVAILABLE, ref phonebookEntry);
            SIM.SimDeinitialize(hSim);
        }

        private void mSolSil_Click(object sender, EventArgs e)
        {
            prgBAR.Minimum = 0;
            prgBAR.Value = 0;
            int iDeger = 0;
            //SIM karttan iþaretli kayýt(larý) sil
            if (TabloSIM.Focused)
            {
                TabloSIM.Height = TabloSIM.Height - prgBAR.Height - 5;
                prgBAR.Maximum = TabloSIM.Items.Count;
                prgBAR.Visible = true;
                int hSim = 0;
                SIM.SimInitialize(0, 0, 0, ref hSim);
                for (int i = 0; i < TabloSIM.Items.Count; i++)
                {
                    if (TabloSIM.Items[i].Checked)
                    {
                        SIM.SimDeletePhonebookEntry(hSim, SIM.SIM_PBSTORAGE_SIM, ((uint)(i + 1)));
                        iDeger++;
                    }
                    prgBAR.Value = i;
                }
                SIM.SimDeinitialize(hSim);
                TabloSIM.Items.Clear();
                mSolGosterSIM_Click(null, null);
                MessageBox.Show(iDeger.ToString() + " Kayýt SIM karttan silindi.");
            }

            //Telefondan iþaretli kayýt(larý) sil
            if (TabloTEL.Focused)
            {
                TabloTEL.Height = TabloTEL.Height - prgBAR.Height - 5;
                prgBAR.Maximum = TabloTEL.Items.Count;
                prgBAR.Visible = true;
                int j = 0;
                OutlookSession os = new OutlookSession();
                for (int i = 0; i < TabloTEL.Items.Count; i++)
                {
                    if (TabloTEL.Items[i].Checked)
                    {
                        os.Contacts.Items[i - j].Delete();
                        j++;
                    }
                    prgBAR.Value = i;
                }
                TabloTEL.Items.Clear();
                mSolGosterTEL_Click(null, null);
                MessageBox.Show(j.ToString() + " Kayýt telefondan silindi.");
            }
        }

        private void mSolOkuSIM_Click(object sender, EventArgs e)
        {
            int hSim = 0;
            uint phoneUsed = 0;
            uint phoneTotal = 0;
            TabloSIM.Items.Clear();
            mSolGosterSIM_Click(null, null);
            TabloSIM.Focus();
            TabloSIM.Height = TabloSIM.Height - prgBAR.Height - 5;
            SIM.SimInitialize(0, 0, 0, ref hSim);
            SIM.SimGetPhonebookStatus(hSim, SIM.SIM_PBSTORAGE_SIM, ref phoneUsed, ref phoneTotal);
            TabloSIM.Columns[0].Width = 80;
            TabloSIM.Columns[1].Width = 93;
            TabloSIM.Columns[0].Text = "Ýsim";
            TabloSIM.Columns[1].Text = "Telefon";
            prgBAR.Maximum = (int)phoneTotal;
            prgBAR.Value = 0;
            prgBAR.Visible = true;
            for (uint sy = 1; sy <= phoneTotal; sy++)
            {
                //SIM karttan 1. kaydý oku
                hSim = 0;
                SIM.SimInitialize(0, 0, 0, ref hSim);
                SIM.SIMPHONEBOOKENTRY phonebookEntry = new SIM.SIMPHONEBOOKENTRY();
                SIM.SimReadPhonebookEntry(hSim, SIM.SIM_PBSTORAGE_SIM, sy, ref phonebookEntry);
                //MessageBox.Show(phonebookEntry.lpszText.ToString());     //Ýsim
                //MessageBox.Show(phonebookEntry.lpszAddress.ToString());  //Telefon
                SIM.SimDeinitialize(hSim);
                AddToListViewSIM(phonebookEntry.lpszText, phonebookEntry.lpszAddress);
                prgBAR.Value = (int)sy;
            }
            mSolGosterSIM_Click(null, null);
        }

        private void mSolOkuTelefon_Click(object sender, EventArgs e)
        {
            TabloTEL.Items.Clear();
            mSolGosterTEL_Click(null, null);
            TabloTEL.Focus();
            TabloTEL.Columns[0].Text = "Ýsim";
            TabloTEL.Columns[1].Text = "Telefon";
            Contact kisi = new Contact();
            OutlookSession os = new OutlookSession();
            string Ad = "", Soyad = "", Telefon = "";
            prgBAR.Maximum = os.Contacts.Items.Count;
            prgBAR.Value = 0;
            prgBAR.Visible = true;
            for (int i = 0; i < os.Contacts.Items.Count; i++)
            {
                Ad = os.Contacts.Items[i].FirstName;
                Soyad = os.Contacts.Items[i].LastName;
                Ad = Ad + " " + Soyad;
                if (Ad.Trim() == "") Ad = os.Contacts.Items[i].Email1Address;
                Telefon = os.Contacts.Items[i].MobileTelephoneNumber;
                if (Telefon.Trim() == "") Telefon = os.Contacts.Items[i].BusinessTelephoneNumber;
                if (Telefon.Trim() == "") Telefon = os.Contacts.Items[i].HomeTelephoneNumber;
                if (Telefon.Trim() == "") Telefon = "000";
                AddToListViewTEL(Ad, Telefon);
                prgBAR.Value = i;
            }
            mSolGosterTEL_Click(null, null);
        }

        private void menuItem3_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < TabloSIM.Items.Count; i++)
            {
                if (TabloSIM.Items[i].Checked) MessageBox.Show(TabloSIM.Items[i].SubItems[1].Text);
            }
        }

        private void mSolTabloSecSIM_Click(object sender, EventArgs e)
        {
            TabloSIM.Focus();
        }

        private void mSolTabloSecTEL_Click(object sender, EventArgs e)
        {
            TabloTEL.Focus();
        }

        private void mSolTumunuSec_Click(object sender, EventArgs e)
        {
            if (TabloSIM.Focused)
                for (int i = 0; i < TabloSIM.Items.Count; i++)
                    TabloSIM.Items[i].Checked = true;

            if (TabloTEL.Focused)
                for (int i = 0; i < TabloTEL.Items.Count; i++)
                    TabloTEL.Items[i].Checked = true;
        }

        private void mSolTumunuSecme_Click(object sender, EventArgs e)
        {
            if (TabloSIM.Focused)
                for (int i = 0; i < TabloSIM.Items.Count; i++)
                    TabloSIM.Items[i].Checked = false;

            if (TabloTEL.Focused)
                for (int i = 0; i < TabloTEL.Items.Count; i++)
                    TabloTEL.Items[i].Checked = false;
        }

        private void mSolTumunuCevir_Click(object sender, EventArgs e)
        {
            if (TabloSIM.Focused)
                for (int i = 0; i < TabloSIM.Items.Count; i++)
                    TabloSIM.Items[i].Checked = !TabloSIM.Items[i].Checked;

            if (TabloTEL.Focused)
                for (int i = 0; i < TabloTEL.Items.Count; i++)
                    TabloTEL.Items[i].Checked = !TabloTEL.Items[i].Checked;
        }

        private void mSolCikis_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void menuItem3_Click_1(object sender, EventArgs e)
        {
            if (menuItem2.Enabled)
            {
                baslik2 = this.Text;
                TabloSIM.Items.Clear();
                TabloTEL.Items.Clear();
                TabloSIM.Visible = false;
                TabloTEL.Visible = false;
                prgBAR.Visible = false;
                pbBEN.Visible = true;
                txtUyari.Visible = true;
                menuItem2.Enabled = false;
                menuItem3.Text = "Tamam";
                this.Text = baslik + " (Hakkýnda)";
            }
            else
            {
                mSolGosterSIM_Click(null, null);
                pbBEN.Visible = false;
                txtUyari.Visible = false;
                menuItem2.Enabled = true;
                menuItem3.Text = "Hakkýnda";
                this.Text = baslik2;
            }
        }

        private void mSolKopyalaTELtoSIMsecili_Click(object sender, EventArgs e)
        {
            TabloSIM.Items.Clear();
            mSolGosterSIM_Click(null, null);
            TabloSIM.Focus();
            TabloSIM.Height = TabloSIM.Height - prgBAR.Height - 5;

            int hSim = 0, kopyalanan = 0;
            int sayac = 0;
            uint phoneUsed = 0;
            uint phoneTotal = 0;
            uint Kalan = 0;
            uint MaxLengName = 0;
            uint MaxLengPhone = 0;
            string Ad = "", Soyad = "", Telefon = "";

            Contact kisi = new Contact();
            OutlookSession os = new OutlookSession();
            SIM.SimCaps simCaps = new SIM.SimCaps();
            SIM.SIMPHONEBOOKENTRY phonebookEntry = new SIM.SIMPHONEBOOKENTRY();

            SIM.SimInitialize(0, 0, 0, ref hSim);
            SIM.SimGetPhonebookStatus(hSim, SIM.SIM_PBSTORAGE_SIM, ref phoneUsed, ref phoneTotal);
            SIM.SimGetDevCaps(hSim, SIM.SIM_CAPSTYPE_ALL, ref simCaps);
            MaxLengName = simCaps.dwMaxPBETextLength;
            MaxLengPhone = simCaps.dwMaxPBEAddressLength;
            Kalan = phoneTotal - phoneUsed;
            prgBAR.Minimum = 0;
            if (Kalan > os.Contacts.Items.Count) Kalan = (uint)os.Contacts.Items.Count;
            if (Kalan >= 0) prgBAR.Maximum = (int)Kalan;
            prgBAR.Value = 0; prgBAR.Visible = true;

            for (sayac = 0; sayac < Kalan && sayac < os.Contacts.Items.Count; sayac++)
            {
                if (TabloTEL.Items[sayac].Checked)
                {
                    hSim = 0;
                    SIM.SimInitialize(0, 0, 0, ref hSim);
                    Ad = os.Contacts.Items[sayac].FirstName;
                    Soyad = os.Contacts.Items[sayac].LastName;
                    Ad = Ad + " " + Soyad;
                    if (Ad.Trim() == "") Ad = os.Contacts.Items[sayac].Email1Address;
                    if (Ad.Length > MaxLengName) Ad = Ad.Substring(0, ((int)MaxLengName));
                    Telefon = os.Contacts.Items[sayac].MobileTelephoneNumber;
                    if (Telefon.Trim() == "") Telefon = os.Contacts.Items[sayac].BusinessTelephoneNumber;
                    if (Telefon.Trim() == "") Telefon = os.Contacts.Items[sayac].HomeTelephoneNumber;
                    if (Telefon.Trim() == "") Telefon = "000";

                    phonebookEntry.cbSize = SIM.SIMEntryCapacity;
                    phonebookEntry.dwAddressType = SIM.SIM_ADDRTYPE_UNKNOWN;
                    phonebookEntry.dwNumPlan = SIM.SIM_NUMPLAN_UNKNOWN;
                    phonebookEntry.dwParams = 15;
                    phonebookEntry.lpszAddress = Telefon;
                    phonebookEntry.lpszText = Ad;
                    SIM.SimWritePhonebookEntry(hSim, SIM.SIM_PBSTORAGE_SIM, SIM.SIM_PBINDEX_FIRSTAVAILABLE, ref phonebookEntry);
                    SIM.SimDeinitialize(hSim);
                    AddToListViewSIM(phonebookEntry.lpszText, phonebookEntry.lpszAddress);
                    prgBAR.Value = sayac;
                    kopyalanan++;
                }
            }
            mSolGosterSIM_Click(null, null);
            MessageBox.Show(kopyalanan.ToString() + " Kayýt SIM karta kopyalandý.");
        }

        private void mSolKopyalaTELtoSIMhepsi_Click(object sender, EventArgs e)
        {
            TabloSIM.Items.Clear();
            mSolGosterSIM_Click(null, null);
            TabloSIM.Focus();
            TabloSIM.Height = TabloSIM.Height - prgBAR.Height - 5;

            int hSim = 0, kopyalanan = 0;
            int sayac = 0;
            uint phoneUsed = 0;
            uint phoneTotal = 0;
            uint Kalan = 0;
            uint MaxLengName = 0;
            uint MaxLengPhone = 0;
            string Ad = "", Soyad = "", Telefon = "";

            Contact kisi = new Contact();
            OutlookSession os = new OutlookSession();
            SIM.SimCaps simCaps = new SIM.SimCaps();
            SIM.SIMPHONEBOOKENTRY phonebookEntry = new SIM.SIMPHONEBOOKENTRY();

            SIM.SimInitialize(0, 0, 0, ref hSim);
            SIM.SimGetPhonebookStatus(hSim, SIM.SIM_PBSTORAGE_SIM, ref phoneUsed, ref phoneTotal);
            SIM.SimGetDevCaps(hSim, SIM.SIM_CAPSTYPE_ALL, ref simCaps);
            MaxLengName = simCaps.dwMaxPBETextLength;
            MaxLengPhone = simCaps.dwMaxPBEAddressLength;
            Kalan = phoneTotal - phoneUsed;
            prgBAR.Minimum = 0;
            if (Kalan > os.Contacts.Items.Count) Kalan = (uint)os.Contacts.Items.Count;
            if (Kalan >= 0) prgBAR.Maximum = (int)Kalan;
            prgBAR.Value = 0; prgBAR.Visible = true;

            for (sayac = 0; sayac < Kalan && sayac < os.Contacts.Items.Count; sayac++)
            {
                hSim = 0;
                SIM.SimInitialize(0, 0, 0, ref hSim);
                Ad = os.Contacts.Items[sayac].FirstName.Trim();
                Soyad = os.Contacts.Items[sayac].LastName.Trim();
                Ad = Ad + " " + Soyad;
                if (Ad.Trim() == "") Ad = os.Contacts.Items[sayac].Email1Address;
                if (Ad.Length > MaxLengName) Ad = Ad.Substring(0, ((int)MaxLengName));
                Telefon = os.Contacts.Items[sayac].MobileTelephoneNumber;
                if (Telefon.Trim() == "") Telefon = os.Contacts.Items[sayac].BusinessTelephoneNumber;
                if (Telefon.Trim() == "") Telefon = os.Contacts.Items[sayac].HomeTelephoneNumber;
                if (Telefon.Trim() == "") Telefon = "000";

                phonebookEntry.cbSize = SIM.SIMEntryCapacity;
                phonebookEntry.dwAddressType = SIM.SIM_ADDRTYPE_UNKNOWN;
                phonebookEntry.dwNumPlan = SIM.SIM_NUMPLAN_UNKNOWN;
                phonebookEntry.dwParams = 15;
                phonebookEntry.lpszAddress = Telefon;
                phonebookEntry.lpszText = Ad;
                SIM.SimWritePhonebookEntry(hSim, SIM.SIM_PBSTORAGE_SIM, SIM.SIM_PBINDEX_FIRSTAVAILABLE, ref phonebookEntry);
                SIM.SimDeinitialize(hSim);
                AddToListViewSIM(phonebookEntry.lpszText, phonebookEntry.lpszAddress);
                prgBAR.Value = sayac;
                kopyalanan++;
            }
            mSolGosterSIM_Click(null, null);
            MessageBox.Show(kopyalanan.ToString() + " Kayýt SIM karta kopyalandý.");
        }

        private void mSolKopyalaSIMtoTELsecili_Click(object sender, EventArgs e)
        {
            TabloTEL.Items.Clear();
            mSolGosterTEL_Click(null, null);
            TabloTEL.Focus();
            TabloTEL.Height = TabloTEL.Height - prgBAR.Height - 5;

            int hSim = 0, kopyalanan = 0;
            uint sayac = 0;
            uint phoneUsed = 0;
            uint phoneTotal = 0;
            string AdSoyad = "", Ad = "", Soyad = "", Telefon = "";

            Contact kisi = new Contact();
            OutlookSession os = new OutlookSession();
            SIM.SimCaps simCaps = new SIM.SimCaps();
            SIM.SIMPHONEBOOKENTRY phonebookEntry = new SIM.SIMPHONEBOOKENTRY();

            SIM.SimInitialize(0, 0, 0, ref hSim);
            SIM.SimGetPhonebookStatus(hSim, SIM.SIM_PBSTORAGE_SIM, ref phoneUsed, ref phoneTotal);
            SIM.SimGetDevCaps(hSim, SIM.SIM_CAPSTYPE_ALL, ref simCaps);
            prgBAR.Maximum = (int)phoneTotal; prgBAR.Minimum = 0; prgBAR.Value = 0; prgBAR.Visible = true;

            for (sayac = 0; sayac < phoneTotal; sayac++)
            {
                if (TabloSIM.Items[((int)sayac)].Checked)
                {
                    hSim = 0;
                    SIM.SimInitialize(0, 0, 0, ref hSim);
                    phonebookEntry = new SIM.SIMPHONEBOOKENTRY();
                    SIM.SimReadPhonebookEntry(hSim, SIM.SIM_PBSTORAGE_SIM, (sayac + 1), ref phonebookEntry);
                    Ad = ""; Soyad = ""; Telefon = "";
                    AdSoyad = phonebookEntry.lpszText.ToString().Trim();
                    Telefon = phonebookEntry.lpszAddress.ToString().Trim();
                    if (AdSoyad != "" || Telefon != "")
                    {
                        int konum = AdSoyad.IndexOf(" ", 0, AdSoyad.Length);
                        Ad = AdSoyad;
                        if (konum > 0)
                        {
                            Ad = AdSoyad.Substring(0, konum);
                            Soyad = AdSoyad.Substring(konum, AdSoyad.Length - Ad.Length);
                        }
                        if (Telefon == "") Telefon = "000";
                        if (Ad == "") Ad = Telefon;

                        kisi = new Contact();
                        kisi.FirstName = Ad;
                        kisi.LastName = Soyad;
                        kisi.MobileTelephoneNumber = Telefon;
                        os.Contacts.Items.Add(kisi);
                        AddToListViewTEL((Ad + " " + Soyad), Telefon);
                        kopyalanan++;
                    }
                }
            }
            mSolGosterTEL_Click(null, null);
            MessageBox.Show(kopyalanan.ToString() + " Kayýt telefona kopyalandý.");
        }

        private void mSolKopyalaSIMtoTELhepsi_Click(object sender, EventArgs e)
        {
            TabloTEL.Items.Clear();
            mSolGosterTEL_Click(null, null);
            TabloTEL.Focus();
            TabloTEL.Height = TabloSIM.Height - prgBAR.Height - 5;

            int hSim = 0, kopyalanan = 0;
            uint sayac = 0;
            uint phoneUsed = 0;
            uint phoneTotal = 0;
            string AdSoyad = "", Ad = "", Soyad = "", Telefon = "";

            Contact kisi = new Contact();
            OutlookSession os = new OutlookSession();
            SIM.SimCaps simCaps = new SIM.SimCaps();
            SIM.SIMPHONEBOOKENTRY phonebookEntry = new SIM.SIMPHONEBOOKENTRY();

            SIM.SimInitialize(0, 0, 0, ref hSim);
            SIM.SimGetPhonebookStatus(hSim, SIM.SIM_PBSTORAGE_SIM, ref phoneUsed, ref phoneTotal);
            SIM.SimGetDevCaps(hSim, SIM.SIM_CAPSTYPE_ALL, ref simCaps);
            prgBAR.Maximum = (int)phoneTotal; prgBAR.Minimum = 0; prgBAR.Value = 0; prgBAR.Visible = true;

            for (sayac = 0; sayac < phoneTotal; sayac++)
            {
                hSim = 0;
                SIM.SimInitialize(0, 0, 0, ref hSim);
                phonebookEntry = new SIM.SIMPHONEBOOKENTRY();
                SIM.SimReadPhonebookEntry(hSim, SIM.SIM_PBSTORAGE_SIM, (sayac + 1), ref phonebookEntry);
                Ad = ""; Soyad = ""; Telefon = "";
                AdSoyad = phonebookEntry.lpszText.ToString().Trim();
                Telefon = phonebookEntry.lpszAddress.ToString().Trim();
                if (AdSoyad != "" || Telefon != "")
                {
                    int konum = AdSoyad.IndexOf(" ", 0, AdSoyad.Length);
                    Ad = AdSoyad;
                    if (konum > 0)
                    {
                        Ad = AdSoyad.Substring(0, konum);
                        Soyad = AdSoyad.Substring(konum, AdSoyad.Length - Ad.Length);
                    }
                    if (Telefon == "") Telefon = "000";
                    if (Ad == "") Ad = Telefon;

                    kisi = new Contact();
                    kisi.FirstName = Ad;
                    kisi.LastName = Soyad;
                    kisi.MobileTelephoneNumber = Telefon;
                    os.Contacts.Items.Add(kisi);
                    AddToListViewTEL((Ad + " " + Soyad), Telefon);
                    kopyalanan++;
                }
                SIM.SimDeinitialize(hSim);
                prgBAR.Value = (int)sayac;
            }
            mSolGosterTEL_Click(null, null);
            MessageBox.Show(kopyalanan.ToString() + " Kayýt telefona kopyalandý.");
        }

        private void mSolRehberYedekle_Click(object sender, EventArgs e)
        {
            TabloSIM.Items.Clear();
            mSolGosterSIM_Click(null, null);
            TabloSIM.Focus();
            TabloSIM.Height = TabloSIM.Height - prgBAR.Height - 5;

            int hSim = 0;
            uint phoneUsed = 0;
            uint phoneTotal = 0;
            StreamWriter Yaz = new StreamWriter(RehberDosya);
            SIM.SimInitialize(0, 0, 0, ref hSim);
            SIM.SimGetPhonebookStatus(hSim, SIM.SIM_PBSTORAGE_SIM, ref phoneUsed, ref phoneTotal);
            prgBAR.Minimum = 0;
            prgBAR.Maximum = (int)phoneTotal;
            prgBAR.Value = 0; prgBAR.Visible = true;
            for (uint sy = 1; sy <= phoneTotal; sy++)
            {
                hSim = 0;
                SIM.SimInitialize(0, 0, 0, ref hSim);
                SIM.SIMPHONEBOOKENTRY phonebookEntry = new SIM.SIMPHONEBOOKENTRY();
                SIM.SimReadPhonebookEntry(hSim, SIM.SIM_PBSTORAGE_SIM, sy, ref phonebookEntry);
                SIM.SimDeinitialize(hSim);
                if (phonebookEntry.lpszText.Trim() != "" && phonebookEntry.lpszAddress != "")
                {
                    Yaz.WriteLine(phonebookEntry.lpszText);
                    Yaz.WriteLine(phonebookEntry.lpszAddress);
                }
                prgBAR.Value = (int)sy;
            }
            Yaz.Close();
            mSolGosterSIM_Click(null, null);
            MessageBox.Show("SIM Rehberi Yedeklendi.");
        }

        private void mSolRehberGeriYukle_Click(object sender, EventArgs e)
        {
            TabloSIM.Items.Clear();
            mSolGosterSIM_Click(null, null);
            TabloSIM.Focus();
            TabloSIM.Height = TabloSIM.Height - prgBAR.Height - 5;

            int hSim = 0, kopyalanan = 0;
            uint sayac = 0;
            uint phoneUsed = 0;
            uint phoneTotal = 0;
            uint MaxLengName = 0;
            uint MaxLengPhone = 0;
            string Ad, Telefon;

            StreamReader Oku = new StreamReader(RehberDosya);
            SIM.SimCaps simCaps = new SIM.SimCaps();
            SIM.SIMPHONEBOOKENTRY phonebookEntry = new SIM.SIMPHONEBOOKENTRY();

            SIM.SimInitialize(0, 0, 0, ref hSim);
            SIM.SimGetPhonebookStatus(hSim, SIM.SIM_PBSTORAGE_SIM, ref phoneUsed, ref phoneTotal);
            SIM.SimGetDevCaps(hSim, SIM.SIM_CAPSTYPE_ALL, ref simCaps);
            MaxLengName = simCaps.dwMaxPBETextLength;
            MaxLengPhone = simCaps.dwMaxPBEAddressLength;
            prgBAR.Minimum = 0;
            prgBAR.Maximum = (int)phoneTotal;
            prgBAR.Value = 0; prgBAR.Visible = true;

            while (!Oku.EndOfStream)
            {
                Telefon = Oku.ReadLine().Trim();
                Ad = Oku.ReadLine().Trim();
                if (Ad.Length > MaxLengName) Ad = Ad.Substring(0, ((int)MaxLengName));
                if (Telefon.Trim() == "") Telefon = "000";

                hSim = 0;
                SIM.SimInitialize(0, 0, 0, ref hSim);
                phonebookEntry.cbSize = SIM.SIMEntryCapacity;
                phonebookEntry.dwAddressType = SIM.SIM_ADDRTYPE_UNKNOWN;
                phonebookEntry.dwNumPlan = SIM.SIM_NUMPLAN_UNKNOWN;
                phonebookEntry.dwParams = 15;
                phonebookEntry.lpszText = Telefon;
                phonebookEntry.lpszAddress = Ad;
                sayac++;
                SIM.SimWritePhonebookEntry(hSim, SIM.SIM_PBSTORAGE_SIM, sayac, ref phonebookEntry);
                SIM.SimDeinitialize(hSim);
                prgBAR.Value = kopyalanan;
                kopyalanan++;
            }
            Oku.Close();
            SIM.SimInitialize(0, 0, 0, ref hSim);
            for (int i = kopyalanan + 1; i <= phoneTotal; i++)
            {
                SIM.SimDeletePhonebookEntry(hSim, SIM.SIM_PBSTORAGE_SIM, ((uint)i + 1));
                prgBAR.Value = i;
            }
            prgBAR.Value = 0;
            SIM.SimDeinitialize(hSim);

            mSolGosterSIM_Click(null, null);
            MessageBox.Show(kopyalanan.ToString() + " Kayýt SIM karta geri yüklendi.");
        }
    }
}

