using System;
using System.Threading.Tasks;   
using System.Collections.Generic;
using System.IO;
using NanoXLSX;

namespace Zil
{
    class Excel
    {
        public Worksheet sayfa1;
        private string[][] rawData;
        private string[][] TablodakiSüreler,TablodakiSaatler;
        private int[][][] TenefüsDeğişkenleri;
        private string path;

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
                        getRawData(cell, 1); 
                    else if(cellKey.Contains("C"))
                        getRawData(cell, 2);
                    else if (cellKey.Contains("D"))
                        getRawData(cell, 3);
                    else if (cellKey.Contains("E"))
                        getRawData(cell, 4);
                    else if (cellKey.Contains("F"))
                        getRawData(cell, 5);
                    else if (cellKey.Contains("G"))
                        getRawData(cell, 6);
                    else if (cellKey.Contains("H"))
                        getRawData(cell, 7);
                    else if (cellKey.Contains("I"))
                        getRawData(cell, 8);
                    else if (cellKey.Contains("J"))
                        getRawData(cell, 9);
                    else if (cellKey.Contains("K"))
                        getRawData(cell, 10);
                    else if (cellKey.Contains("L"))
                        getRawData(cell, 11);
                    else if (cellKey.Contains("M"))
                        getRawData(cell, 12);
                    else if (cellKey.Contains("N"))
                        getRawData(cell, 13);
                    else if (cellKey.Contains("O"))
                        getRawData(cell, 14);
                }      //gözlerim kanıyo lütfen kızmayın
            }
        }
        private void getRawData(KeyValuePair<string, Cell> cell, int column)
        {
            string row = cell.Key;
            row = row.Substring(1);
            rawData[column][Int64.Parse(row)] = (string)cell.Value.Value;
        }
        public void Read(out string[][] tenefusSaat, out int[][][] tenefusSure)
        {
            for (int i = 1; i < rawData.Length; i++)
            {
                if (i % 2 == 0)// tablodkai saatleri excelden yazar
                {
                    int uzunluk = TablodakiSaatler.Length;
                    int j = 1;
                    while (true)
                    {
                        if (rawData[i][j] == "")
                            break;

                        TablodakiSaatler[uzunluk][j - 1] = rawData[i][j];
                        j++;
                    }
                }
                else//tablodaki günleri excelden yazar
                {
                    int uzunluk = TablodakiSüreler.Length;
                    int j = 1;
                    while (true)
                    {
                        if (rawData[i][j] == "")
                            break;

                        TablodakiSüreler[uzunluk][j - 1] = rawData[i][j];
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
            tenefusSaat = TablodakiSaatler;
            tenefusSure = TenefüsDeğişkenleri;
        }
    }
}
