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
        private mp3Player mpPlayer;
        private string z1, z2, im;
        public Form1()
        {
            InitializeComponent();
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

        private void ZilSaatleriGuncellemeButton_Click(object sender, EventArgs e)
        {

        }

        private void imoButton_Click(object sender, EventArgs e)
        {

        }

        private void z2oButton_Click(object sender, EventArgs e)
        {

        }

        private void z1oButton_Click(object sender, EventArgs e)
        {
            mpPlayer = new mp3Player(z1);
            mpPlayer.Play();
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

        
    }
}
