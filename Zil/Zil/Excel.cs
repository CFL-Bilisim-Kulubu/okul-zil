using NanoXLSX;
using System;
using System.Collections.Generic;
using System.IO;

namespace Zil
{
    internal class Excel
    {
        public Worksheet sayfa1;
        public string[,] TablodakiSüreler, TablodakiSaatler;
        public int[,,] TenefüsDeğişkenleri;
        public string path;

        public string[,] RawData = new string[14, 20];

        public Excel(string path)
        {
            using (FileStream fs = new FileStream(@"C:\Users\mertk\Documents\Github\cs\okul-zil\Zil\Zil\zil.xlsx", FileMode.Open))                 // Open the 'basic.xlsx' as file stream  
            {


                Workbook wb2 = Workbook.Load(fs);                                               // Read the file stream
                Console.WriteLine("contains worksheet name: " + wb2.CurrentWorksheet.SheetName);
                foreach (KeyValuePair<string, Cell> cell in wb2.CurrentWorksheet.Cells)         // Cycle through cells of loaded workbook (first worksheet)
                {
                    string cellKey = cell.Key;
                    if (cellKey.Contains("B"))
                        getRawData(cell.Value.Value.ToString(), 1, cell.Key);
                    else if (cellKey.Contains("C"))
                        getRawData(cell.Value.Value.ToString(), 2, cell.Key);
                    else if (cellKey.Contains("D"))
                        getRawData(cell.Value.Value.ToString(), 3, cell.Key);
                    else if (cellKey.Contains("E"))
                        getRawData(cell.Value.Value.ToString(), 4, cell.Key);
                    else if (cellKey.Contains("F"))
                        getRawData(cell.Value.Value.ToString(), 5, cell.Key);
                    else if (cellKey.Contains("G"))
                        getRawData(cell.Value.Value.ToString(), 6, cell.Key);
                    else if (cellKey.Contains("H"))
                        getRawData(cell.Value.Value.ToString(), 7, cell.Key);
                    else if (cellKey.Contains("I"))
                        getRawData(cell.Value.Value.ToString(), 8, cell.Key);
                     else if  (cellKey.Contains("J"))
                        getRawData(cell.Value.Value.ToString(), 9, cell.Key);
                    else if (cellKey.Contains("K"))
                        getRawData(cell.Value.Value.ToString(), 10, cell.Key);
                    else if (cellKey.Contains("L"))
                        getRawData(cell.Value.Value.ToString(), 11, cell.Key);
                    else if (cellKey.Contains("M"))
                        getRawData(cell.Value.Value.ToString(), 2, cell.Key);
                    else if (cellKey.Contains("N"))
                        getRawData(cell.Value.Value.ToString(), 13, cell.Key);
                    else if (cellKey.Contains("O"))
                        getRawData(cell.Value.Value.ToString(), 14, cell.Key);
                }      //gözlerim kanıyo lütfen kızmayın
            }
        }
        public void getRawData(string value, int column, string key)
        {
            string row = key;
            row = row.Substring(1);
            int rowAsInt = short.Parse(row);

            if (rowAsInt >= 20)
                return;

            RawData[column, rowAsInt] = value;
        }
        public void Read(out string[,] tenefusSaat, out int[,,] tenefusSure)
        {
            int l1 = RawData.GetLength(0) / 2, l2 = RawData.GetLength(1);
            TablodakiSaatler = new string[l1, l2];
            TablodakiSüreler = new string[l1, l2];
            TenefüsDeğişkenleri = new int[l1, l2, 2];


            for (int i = 1; i < RawData.GetLength(0); i++)
            {
                if (i % 2 == 1)// tablodaki saatleri excelden yazar
                {
                    int uzunluk = TablodakiSaatler.GetLength(0);
                    int j = 1;
                    while (true)
                    {
                        if (j > 15)
                            break;

                        TablodakiSaatler[i / 2, j - 1] = RawData[i, j];
                        j++;
                    }
                }
                else//tablodaki günleri excelden yazar
                {
                    int uzunluk = TablodakiSüreler.GetLength(0);
                    int j = 1;
                    while (true)
                    {
                        if (j > 15)
                            break;

                        TablodakiSüreler[(i - 1) / 2, j - 1] = RawData[i, j];
                        j++;
                    }
                }
            }


            for (int i = 0; i < TablodakiSüreler.GetLength(0); i++)
            {
                for (int j = 1; j < TablodakiSüreler.GetLength(1); j++)
                {
                    string parse = new string(TablodakiSüreler[i, j]);

                    if (parse is null || parse == "")
                    {
                        continue;
                    }

                    string[] words = parse.Split("*");
                    TenefüsDeğişkenleri[i, j, 0] = int.Parse(words[0]) - int.Parse(words[1]);
                    TenefüsDeğişkenleri[i, j, 1] = int.Parse(words[1]);
                }
            }
            tenefusSaat = TablodakiSaatler;
            tenefusSure = TenefüsDeğişkenleri;
        }
    }
}
