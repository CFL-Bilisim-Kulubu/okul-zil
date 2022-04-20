using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Zil
{
    public partial class Form1 : Form
    {
        
        private string zilSaatleriKonum, z1, z2, im,sesDosyasiFiltresi = "Ses Dosyası (*.mp3)|*.mp3"
            ,excelDosyasiFiltresi = "Microsoft Excel Çalışma Sayfası(*.xlsx)|*.xlsx";
        private string[,] tenefüsSaatler;
        private int[,,] tenefüsSüreler;

        public Form1()
        {
            InitializeComponent();
        }

        // Declare the nofify constant
        public const int MM_MCINOTIFY = 953;

        // Override the WndProc function in the form
        protected override void WndProc(ref Message m)
        {

            if (m.Msg == MM_MCINOTIFY)
            {
                string command = "close MediaFile";
                mciSendString(command, null, 0, IntPtr.Zero);
            }
            base.WndProc(ref m);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void z1Button_Click(object sender, EventArgs e)
        {
            z1 = openFile(z1TextBox, "Zil Dosyası", sesDosyasiFiltresi);
        }
        private void z2Button_Click(object sender, EventArgs e)
        {
            z2 = openFile(z2TextBox, "Öğretmen Zili Dosyası", sesDosyasiFiltresi);
        }
        private void imButton_Click(object sender, EventArgs e)
        {
            im = openFile(imTextBox, "İstiklal Marşı Dosyası", sesDosyasiFiltresi);
        }
        private void imoButton_Click(object sender, EventArgs e)
        {
            if (im == "" || im == null)
                return;
            mp3Player(im);
            string command = "play MediaFile notify";
            mciSendString(command, null, 0, this.Handle);
        }
        private void z2oButton_Click(object sender, EventArgs e)
        {
            if (z2 == "" || z2 == null)
                return;
            mp3Player(z2);
            string command = "play MediaFile notify";
            mciSendString(command, null, 0, this.Handle);
        }
        private void z1oButton_Click(object sender, EventArgs e)
        {
            if (z1 == "" || z1 == null)
                return;
            mp3Player(z1);
            string command = "play MediaFile notify";
            mciSendString(command, null, 0, this.Handle);
        }
        private void ZilSaatleriGuncellemeButton_Click(object sender, EventArgs e)
        {
            PZT.Items.Clear();
            SAL.Items.Clear();
            CAR.Items.Clear();
            PER.Items.Clear();
            CUM.Items.Clear();
            CMT.Items.Clear();
            PZR.Items.Clear();
            /*
            foreach(string saat in tenefüsSaatler[0])
            {
                PZT.Items.Add(saat);
            }
            foreach (string saat in tenefüsSaatler[1])
            {
                SAL.Items.Add(saat);
            }
            foreach (string saat in tenefüsSaatler[2])
            {
                CAR.Items.Add(saat);
            }
            foreach (string saat in tenefüsSaatler[3])
            {
                PER.Items.Add(saat);
            }
            foreach (string saat in tenefüsSaatler[4])
            {
                CUM.Items.Add(saat);
            }
            foreach (string saat in tenefüsSaatler[5])
            {
                CMT.Items.Add(saat);
            }
            foreach (string saat in tenefüsSaatler[6])
            {
                PZR.Items.Add(saat);
            }
            */
        }
        private void zsButton_Click(object sender, EventArgs e)
        {
            zilSaatleriKonum = openFile(zsTextBox, "Zil Saatleri Dosyası", excelDosyasiFiltresi);

            if (zilSaatleriKonum == null || zilSaatleriKonum == "")
                return;

            Excel excel = new Excel(zilSaatleriKonum);
            excel.Read(out tenefüsSaatler,out tenefüsSüreler);

        }
        private string openFile(TextBox textBox,string title, string filter)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = title;
            openFileDialog.InitialDirectory = @"C:\";
            openFileDialog.Filter = filter;
            openFileDialog.FilterIndex = 1;
            openFileDialog.ShowDialog();
            if(openFileDialog.FileName == "")
            {
                textBox.Text = "!!LUTFEN DOSYA SEÇİNİZ!!";
                return "";
            }
            textBox.Text = openFileDialog.FileName;
            return openFileDialog.FileName;
        }


        [DllImport("winmm.dll")]
        public static extern long mciSendString(string strCommand, StringBuilder strReturn, int iReturnLength, IntPtr hwndCallBack);

        public void mp3Player(string fileName)
        {
            const string FORMAT = @"open ""{0}"" type mpegvideo alias MediaFile";
            string command = String.Format(FORMAT, fileName);
            mciSendString(command, null, 0, IntPtr.Zero);
        }

    }
}
