
namespace Zil
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.z1Button = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.z1TextBox = new System.Windows.Forms.TextBox();
            this.z2TextBox = new System.Windows.Forms.TextBox();
            this.imTextBox = new System.Windows.Forms.TextBox();
            this.z2oButton = new System.Windows.Forms.Button();
            this.imoButton = new System.Windows.Forms.Button();
            this.imButton = new System.Windows.Forms.Button();
            this.zsTextBox = new System.Windows.Forms.TextBox();
            this.PZT = new System.Windows.Forms.ListBox();
            this.SAL = new System.Windows.Forms.ListBox();
            this.CAR = new System.Windows.Forms.ListBox();
            this.CMT = new System.Windows.Forms.ListBox();
            this.CUM = new System.Windows.Forms.ListBox();
            this.PER = new System.Windows.Forms.ListBox();
            this.PZR = new System.Windows.Forms.ListBox();
            this.ZilSaatleriGuncellemeButton = new System.Windows.Forms.Button();
            this.z1oButton = new System.Windows.Forms.Button();
            this.z2Button = new System.Windows.Forms.Button();
            this.zsButton = new System.Windows.Forms.Button();
            this.startButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // z1Button
            // 
            this.z1Button.Location = new System.Drawing.Point(333, 17);
            this.z1Button.Name = "z1Button";
            this.z1Button.Size = new System.Drawing.Size(156, 44);
            this.z1Button.TabIndex = 0;
            this.z1Button.Text = "Zil Dosyası";
            this.z1Button.UseVisualStyleBackColor = true;
            this.z1Button.Click += new System.EventHandler(this.z1Button_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(-31, 39);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(160, 43);
            this.button2.TabIndex = 1;
            this.button2.Text = "Öğretmen Zili Dosyası";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // z1TextBox
            // 
            this.z1TextBox.Location = new System.Drawing.Point(9, 17);
            this.z1TextBox.Name = "z1TextBox";
            this.z1TextBox.Size = new System.Drawing.Size(318, 23);
            this.z1TextBox.TabIndex = 2;
            this.z1TextBox.TextChanged += new System.EventHandler(this.z1TextBox_TextChanged);
            // 
            // z2TextBox
            // 
            this.z2TextBox.Location = new System.Drawing.Point(9, 69);
            this.z2TextBox.Name = "z2TextBox";
            this.z2TextBox.Size = new System.Drawing.Size(318, 23);
            this.z2TextBox.TabIndex = 3;
            // 
            // imTextBox
            // 
            this.imTextBox.Location = new System.Drawing.Point(9, 120);
            this.imTextBox.Name = "imTextBox";
            this.imTextBox.Size = new System.Drawing.Size(318, 23);
            this.imTextBox.TabIndex = 5;
            // 
            // z2oButton
            // 
            this.z2oButton.Location = new System.Drawing.Point(495, 69);
            this.z2oButton.Name = "z2oButton";
            this.z2oButton.Size = new System.Drawing.Size(75, 44);
            this.z2oButton.TabIndex = 7;
            this.z2oButton.Text = "Oynat";
            this.z2oButton.UseVisualStyleBackColor = true;
            this.z2oButton.Click += new System.EventHandler(this.z2oButton_Click);
            // 
            // imoButton
            // 
            this.imoButton.Location = new System.Drawing.Point(495, 120);
            this.imoButton.Name = "imoButton";
            this.imoButton.Size = new System.Drawing.Size(75, 44);
            this.imoButton.TabIndex = 8;
            this.imoButton.Text = "Oynat";
            this.imoButton.UseVisualStyleBackColor = true;
            this.imoButton.Click += new System.EventHandler(this.imoButton_Click);
            // 
            // imButton
            // 
            this.imButton.Location = new System.Drawing.Point(333, 120);
            this.imButton.Name = "imButton";
            this.imButton.Size = new System.Drawing.Size(156, 44);
            this.imButton.TabIndex = 10;
            this.imButton.Text = "İstiklal Marşı Dosyası";
            this.imButton.UseVisualStyleBackColor = true;
            this.imButton.Click += new System.EventHandler(this.imButton_Click);
            // 
            // zsTextBox
            // 
            this.zsTextBox.Location = new System.Drawing.Point(9, 170);
            this.zsTextBox.Name = "zsTextBox";
            this.zsTextBox.Size = new System.Drawing.Size(318, 23);
            this.zsTextBox.TabIndex = 11;
            // 
            // PZT
            // 
            this.PZT.FormattingEnabled = true;
            this.PZT.ItemHeight = 15;
            this.PZT.Location = new System.Drawing.Point(9, 228);
            this.PZT.Name = "PZT";
            this.PZT.Size = new System.Drawing.Size(75, 334);
            this.PZT.TabIndex = 13;
            // 
            // SAL
            // 
            this.SAL.FormattingEnabled = true;
            this.SAL.ItemHeight = 15;
            this.SAL.Location = new System.Drawing.Point(90, 228);
            this.SAL.Name = "SAL";
            this.SAL.Size = new System.Drawing.Size(75, 334);
            this.SAL.TabIndex = 14;
            // 
            // CAR
            // 
            this.CAR.FormattingEnabled = true;
            this.CAR.ItemHeight = 15;
            this.CAR.Location = new System.Drawing.Point(171, 228);
            this.CAR.Name = "CAR";
            this.CAR.Size = new System.Drawing.Size(75, 334);
            this.CAR.TabIndex = 15;
            // 
            // CMT
            // 
            this.CMT.FormattingEnabled = true;
            this.CMT.ItemHeight = 15;
            this.CMT.Location = new System.Drawing.Point(414, 228);
            this.CMT.Name = "CMT";
            this.CMT.Size = new System.Drawing.Size(75, 334);
            this.CMT.TabIndex = 18;
            // 
            // CUM
            // 
            this.CUM.FormattingEnabled = true;
            this.CUM.ItemHeight = 15;
            this.CUM.Location = new System.Drawing.Point(333, 228);
            this.CUM.Name = "CUM";
            this.CUM.Size = new System.Drawing.Size(75, 334);
            this.CUM.TabIndex = 17;
            // 
            // PER
            // 
            this.PER.FormattingEnabled = true;
            this.PER.ItemHeight = 15;
            this.PER.Location = new System.Drawing.Point(252, 228);
            this.PER.Name = "PER";
            this.PER.Size = new System.Drawing.Size(75, 334);
            this.PER.TabIndex = 16;
            // 
            // PZR
            // 
            this.PZR.FormattingEnabled = true;
            this.PZR.ItemHeight = 15;
            this.PZR.Location = new System.Drawing.Point(495, 228);
            this.PZR.Name = "PZR";
            this.PZR.Size = new System.Drawing.Size(75, 334);
            this.PZR.TabIndex = 19;
            // 
            // ZilSaatleriGuncellemeButton
            // 
            this.ZilSaatleriGuncellemeButton.Location = new System.Drawing.Point(495, 170);
            this.ZilSaatleriGuncellemeButton.Name = "ZilSaatleriGuncellemeButton";
            this.ZilSaatleriGuncellemeButton.Size = new System.Drawing.Size(75, 44);
            this.ZilSaatleriGuncellemeButton.TabIndex = 20;
            this.ZilSaatleriGuncellemeButton.Text = "Güncelle";
            this.ZilSaatleriGuncellemeButton.UseVisualStyleBackColor = true;
            this.ZilSaatleriGuncellemeButton.Click += new System.EventHandler(this.ZilSaatleriGuncellemeButton_Click);
            // 
            // z1oButton
            // 
            this.z1oButton.Location = new System.Drawing.Point(495, 17);
            this.z1oButton.Name = "z1oButton";
            this.z1oButton.Size = new System.Drawing.Size(75, 44);
            this.z1oButton.TabIndex = 21;
            this.z1oButton.Text = "Oynat";
            this.z1oButton.UseVisualStyleBackColor = true;
            this.z1oButton.Click += new System.EventHandler(this.z1oButton_Click);
            // 
            // z2Button
            // 
            this.z2Button.Location = new System.Drawing.Point(333, 70);
            this.z2Button.Name = "z2Button";
            this.z2Button.Size = new System.Drawing.Size(156, 44);
            this.z2Button.TabIndex = 22;
            this.z2Button.Text = "Öğretmen Zili Dosyası";
            this.z2Button.UseVisualStyleBackColor = true;
            // 
            // zsButton
            // 
            this.zsButton.Location = new System.Drawing.Point(333, 170);
            this.zsButton.Name = "zsButton";
            this.zsButton.Size = new System.Drawing.Size(156, 44);
            this.zsButton.TabIndex = 23;
            this.zsButton.Text = "Zil Saatleri Dosyası";
            this.zsButton.UseVisualStyleBackColor = true;
            this.zsButton.Click += new System.EventHandler(this.zsButton_Click);
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(577, 17);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(336, 44);
            this.startButton.TabIndex = 24;
            this.startButton.Text = "Çalıştır";
            this.startButton.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(925, 574);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.zsButton);
            this.Controls.Add(this.z2Button);
            this.Controls.Add(this.z1oButton);
            this.Controls.Add(this.ZilSaatleriGuncellemeButton);
            this.Controls.Add(this.PZR);
            this.Controls.Add(this.CMT);
            this.Controls.Add(this.CUM);
            this.Controls.Add(this.PER);
            this.Controls.Add(this.CAR);
            this.Controls.Add(this.SAL);
            this.Controls.Add(this.PZT);
            this.Controls.Add(this.zsTextBox);
            this.Controls.Add(this.imButton);
            this.Controls.Add(this.imoButton);
            this.Controls.Add(this.z2oButton);
            this.Controls.Add(this.imTextBox);
            this.Controls.Add(this.z2TextBox);
            this.Controls.Add(this.z1TextBox);
            this.Controls.Add(this.z1Button);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button z1Button;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox z1TextBox;
        private System.Windows.Forms.TextBox z2TextBox;
        private System.Windows.Forms.TextBox imTextBox;
        private System.Windows.Forms.Button z2oButton;
        private System.Windows.Forms.Button imoButton;
        private System.Windows.Forms.Button imButton;
        private System.Windows.Forms.TextBox zsTextBox;
        private System.Windows.Forms.ListBox PZT;
        private System.Windows.Forms.ListBox SAL;
        private System.Windows.Forms.ListBox CAR;
        private System.Windows.Forms.ListBox CMT;
        private System.Windows.Forms.ListBox CUM;
        private System.Windows.Forms.ListBox PER;
        private System.Windows.Forms.ListBox PZR;
        private System.Windows.Forms.Button ZilSaatleriGuncellemeButton;
        private System.Windows.Forms.Button z1oButton;
        private System.Windows.Forms.Button z2Button;
        private System.Windows.Forms.Button zsButton;
        private System.Windows.Forms.Button startButton;
    }
}

