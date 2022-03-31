using System;
using System.Threading.Tasks;   
using System.Collections.Generic;
using System.IO;
using _Excel = Microsoft.Office.Interop.Excel;
using Microsoft.Office.Interop.Excel;

namespace Zil
{
    class Excel
    {
        public Worksheet sayfa1;
        public string[][] TablodakiSüreler,TablodakiSaatler;
        public int[][][] TenefüsDeğişkenleri;
        public string path;

        public Excel(string path)
        {
            this.path = path;
            Application uygulama = new _Excel.Application();
            uygulama.Visible = true;
            
            Workbook kitap = uygulama.Workbooks.Open(path, 1);
            sayfa1 = (Worksheet)kitap.Sheets[1];
        }
        public void Read()
        {
            for (int i = 1; i < sayfa1.Columns.Count; i++)
            {
                if (i % 2 == 0)// tablodkai saatleri excelden yazar
                {
                    int uzunluk = TablodakiSaatler.Length;
                    int j = 1;
                    while (true)
                    {
                        if ((string)sayfa1.Cells[i, j] == "")
                            break;

                        TablodakiSaatler[uzunluk][j - 1] = TablodakiSaatler[i][j];
                        j++;
                    }
                }
                else//tablodaki günleri excelden yazar
                {
                    int uzunluk = TablodakiSüreler.Length;
                    int j = 1;
                    while (true)
                    {
                        if ((string)sayfa1.Cells[i, j] == "")
                            break;

                        TablodakiSüreler[uzunluk][j - 1] = TablodakiSüreler[i][j];
                        j++;
                    }
                }
            }


            for (int i = 0; i < TablodakiSüreler.Length; i++)
            {
                for (int j = 0; j < TablodakiSüreler[i].Length; j++)
                {
                    string parse = new string(TablodakiSüreler[i][j]);
                    string[] words = parse.Split("*");

                    TenefüsDeğişkenleri[i][j][0] = int.Parse(words[0]) - int.Parse(words[1]);
                    TenefüsDeğişkenleri[i][j][1] = int.Parse(words[1]);
                }
            }
        }
    }
}
