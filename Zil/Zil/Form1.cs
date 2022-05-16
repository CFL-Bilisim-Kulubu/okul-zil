using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Timers;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Timer = System.Timers.Timer;
using System.Diagnostics;
using System.Media;

namespace Zil
{
    public partial class Form1 : Form
    {
        SoundPlayer sPlayer;
        private IntPtr ğ;
        private System.Timers.Timer timer;
        private string zilSaatleriKonum, z1, z2, 
            im,sesDosyasiFiltresi = "Ses Dosyası (*.wav)|*.wav",
            excelDosyasiFiltresi = "Microsoft Excel Çalışma Sayfası(*.xlsx)|*.xlsx";
        private string[,] tenefüsSaatler = new string[7,20];
        private int[,,] tenefüsSüreler = new int[7, 20, 2];
        private int tenefüsId = 1,gün;

        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            DateTime nowTime = DateTime.Now;
            gün = (int)(nowTime.DayOfWeek + 6) % 7;
            Debug.WriteLine(" günlerden : " + gün);
        }

        #region Ses Dosyalarını Açan Tuşlar
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
        #endregion

        #region Ses Çalan Tuşlar
        private void imoButton_Click(object sender, EventArgs e)
        {
            if (im == "" || im == null)
                return;
            stopAudio();

            mp3Player(im);
            string command = "play MediaFile notify";
            mciSendString(command, null, 0, this.Handle);
        }
        private void z2oButton_Click(object sender, EventArgs e)
        {
            if (z2 == "" || z2 == null)
                return;
            stopAudio();

            mp3Player(z2);
            string command = "play MediaFile notify";
            
            mciSendString(command, null, 0, this.Handle);
        }
        private void z1oButton_Click(object sender, EventArgs e)
        {
            if (z1 == "" || z1 == null)
                return;
            stopAudio();

            mp3Player(z1);
            string command = "play MediaFile notify";
            mciSendString(command, null, 0, this.Handle);
        }
        #endregion

        private void ZilSaatleriGuncellemeButton_Click(object sender, EventArgs e)
        {
            
        }
        private void zsButton_Click(object sender, EventArgs e)
        {
            zilSaatleriKonum = openFile(zsTextBox, "Zil Saatleri Dosyası", excelDosyasiFiltresi);

            if (zilSaatleriKonum == null || zilSaatleriKonum == "")
                return;

            Excel excel = new Excel(zilSaatleriKonum);
            excel.Read(out tenefüsSaatler,out tenefüsSüreler);

            PZT.Items.Clear();
            SAL.Items.Clear();
            CAR.Items.Clear();
            PER.Items.Clear();
            CUM.Items.Clear();
            CMT.Items.Clear();
            PZR.Items.Clear();

            for (int i = 0; i < tenefüsSaatler.GetLength(1); i++)
            {
                if (tenefüsSaatler[0, i] == null || tenefüsSaatler[0, i] == "") continue;
                PZT.Items.Add(tenefüsSaatler[0, i]);
            }
            for (int i = 0; i < tenefüsSaatler.GetLength(1); i++)
            {
                if (tenefüsSaatler[1, i] == null || tenefüsSaatler[1, i] == "") continue;
                SAL.Items.Add(tenefüsSaatler[1, i]);
            }
            for (int i = 0; i < tenefüsSaatler.GetLength(1); i++)
            {
                if (tenefüsSaatler[2, i] == null || tenefüsSaatler[2, i] == "") continue;
                CAR.Items.Add(tenefüsSaatler[2, i]);
            }
            for (int i = 0; i < tenefüsSaatler.GetLength(1); i++)
            {
                if (tenefüsSaatler[3, i] == null || tenefüsSaatler[3, i] == "") continue;
                PER.Items.Add(tenefüsSaatler[3, i]);
            }
            for (int i = 0; i < tenefüsSaatler.GetLength(1); i++)
            {
                if (tenefüsSaatler[4, i] == null || tenefüsSaatler[4, i] == "") continue;
                CUM.Items.Add(tenefüsSaatler[4, i]);
            }
            for (int i = 0; i < tenefüsSaatler.GetLength(1); i++)
            {
                if (tenefüsSaatler[5, i] == null || tenefüsSaatler[5, i] == "") continue;
                CMT.Items.Add(tenefüsSaatler[5, i]);
            }
            for (int i = 0; i < tenefüsSaatler.GetLength(1); i++)
            {
                if (tenefüsSaatler[6, i] == null || tenefüsSaatler[6, i] == "") continue;
                PZR.Items.Add(tenefüsSaatler[6, i]);
            }
        }

        #region zilZamanlayıcıSistem

        private void calistir_Click(object sender, EventArgs e)
        {
            zilBaşlat(tenefüsSaatler[gün,tenefüsId]);
            calistir.Enabled = false;
            Debug.WriteLine(" Zil çalıştırıldı ");
        }
        private void timerAyarlayıcı(DateTime time,ElapsedEventHandler e)
        {
            double tickTime = (double)(time - DateTime.Now).TotalMilliseconds;

            timer = new Timer(tickTime);
            timer.Elapsed += new ElapsedEventHandler(e);
            timer.Start();
        }
        private void zilBaşlat(string time)
        {
            Debug.WriteLine(time);
            string[] parsedTimes = time.Split(".");
            int hour, minute;
            try
            {
                hour = Int32.Parse(parsedTimes[0]);
                minute = Int32.Parse(parsedTimes[1]);
            }
            catch (Exception)
            {
                return;
            }

            DateTime nowTime = DateTime.Now;
            DateTime scheduledTime = new DateTime(nowTime.Year, nowTime.Month, nowTime.Day, hour, minute, 0, 0);
            Debug.WriteLine(scheduledTime);

            if (nowTime > scheduledTime)
            {
                tenefüsId++;
                zilBaşlat(tenefüsSaatler[gün, tenefüsId]);
                return;
            }
            timerAyarlayıcı(scheduledTime, new ElapsedEventHandler(zilPart1));
        }
        private void zilPart1(object sender, ElapsedEventArgs e)
        {
            timer.Stop();

            if (z1 == "" || z1 == null)
                return;


            sPlayer = new SoundPlayer(z1);
            sPlayer.Play();

            Debug.WriteLine("süre" + tenefüsSüreler[0,tenefüsId,1]);
            int minute = tenefüsSüreler[0, tenefüsId, 0];

            DateTime nowTime = DateTime.Now;
            DateTime scheduledTime;

            if (nowTime.Minute + minute < 60)
            {
                scheduledTime = new DateTime(nowTime.Year, nowTime.Month, nowTime.Day, nowTime.Hour, nowTime.Minute + minute, 0, 0);
            }
            else
            {
                scheduledTime = new DateTime(nowTime.Year, nowTime.Month, nowTime.Day, nowTime.Hour + 1, nowTime.Minute + minute - 60, 0, 0);
            }
            Debug.WriteLine(scheduledTime);

            timerAyarlayıcı(scheduledTime, new ElapsedEventHandler(zilPart2));
        }
        private void zilPart2(object sender, ElapsedEventArgs e)
        {
            timer.Stop();

            if (z2 == "" || z2 == null)
                return;


            sPlayer = new SoundPlayer(z2);
            sPlayer.Play();

            Debug.WriteLine("süre" + tenefüsSüreler[0, tenefüsId, 1]);
            int minute = tenefüsSüreler[0, tenefüsId, 0];

            DateTime nowTime = DateTime.Now;
            DateTime scheduledTime;

            if (nowTime.Minute + minute < 60)
            {
                scheduledTime = new DateTime(nowTime.Year, nowTime.Month, nowTime.Day, nowTime.Hour, nowTime.Minute + minute, 0, 0);
            }
            else
            {
                scheduledTime = new DateTime(nowTime.Year, nowTime.Month, nowTime.Day, nowTime.Hour + 1, nowTime.Minute + minute - 60, 0, 0);
            }
            Debug.WriteLine(scheduledTime);

            tenefüsId++;

            zilBaşlat(tenefüsSaatler[gün,tenefüsId]);
        }

        #endregion

        private string openFile(TextBox textBox,string title, string filter)
        {
            if (textBox == null || title == null || filter == null || title == "" || filter == "")  return "";

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = title;
            openFileDialog.InitialDirectory = @"C:\";
            openFileDialog.Filter = filter;
            openFileDialog.FilterIndex = 1;
            openFileDialog.ShowDialog();

            if(openFileDialog.FileName == "")
            {
                textBox.Text = " !! LUTFEN DOSYA SEÇİNİZ !! ";
                return "";
            }
            
            textBox.Text = openFileDialog.FileName;
            return openFileDialog.FileName;
        }

        #region Ses Oynatma Sistemi - Eski - Test kısmı için

        // Declare the nofify constant
        public const int MM_MCINOTIFY = 953;

        // Override the WndProc function in the form
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == MM_MCINOTIFY)
            {
                stopAudio();
            }
            base.WndProc(ref m);
        }


        [DllImport("winmm.dll")]
        public static extern long mciSendString(string strCommand, StringBuilder strReturn, int iReturnLength, IntPtr hwndCallBack);

        public void mp3Player(string fileName)
        {
            const string FORMAT = @"open ""{0}"" type mpegvideo alias MediaFile";
            string command = String.Format(FORMAT, fileName);
            mciSendString(command, null, 0, IntPtr.Zero);
        }

        private void stopAudio()
        {
            string command = "close MediaFile";
            mciSendString(command, null, 0, IntPtr.Zero);
        }

        #endregion

    }
}