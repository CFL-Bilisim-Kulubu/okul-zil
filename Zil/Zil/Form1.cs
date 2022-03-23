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
        public void mp3Player(string fileName)
        {
            const string FORMAT = @"open ""{0}"" type mpegvideo alias MediaFile";
            string command = String.Format(FORMAT, fileName);
            mciSendString(command, null, 0, IntPtr.Zero);
        }

        private string z1, z2, im;

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
            z1 = openFile(z1TextBox, "Zil Dosyası");
        }
        private void z2Button_Click(object sender, EventArgs e)
        {
            z2 = openFile(z2TextBox, "Öğretmen Zili Dosyası");
        }
        private void imButton_Click(object sender, EventArgs e)
        {
            im = openFile(imTextBox, "İstiklal Marşı Dosyası");
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

        }
        private void zsButton_Click(object sender, EventArgs e)
        {

        }

      

        private string openFile(TextBox textBox,string title)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = title;
            openFileDialog.InitialDirectory = @"C:\";
            openFileDialog.Filter = "Ses Dosyası (*.mp3)|*.mp3";
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
    }
}
