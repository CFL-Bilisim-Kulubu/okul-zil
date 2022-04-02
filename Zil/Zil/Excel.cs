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
        public string[][] TablodakiSüreler, TablodakiSaatler;
        public int[][][] TenefüsDeğişkenleri;
        public string path;

        public string[][] RawData = new string[9][];

        public Excel(string path)
        {
            for (int i = 0; i < RawData.Length; i++)
            {
                RawData[i] = new string[15];
            }
            using (FileStream fs = new FileStream(@"C:\Users\mertk\Documents\Github\cs\okul-zil\Zil\Zil\zil.xlsx", FileMode.Open))                 // Open the 'basic.xlsx' as file stream  
            {
                

                Workbook wb2 = Workbook.Load(fs);                                               // Read the file stream
                Console.WriteLine("contains worksheet name: " + wb2.CurrentWorksheet.SheetName);
                foreach (KeyValuePair<string, Cell> cell in wb2.CurrentWorksheet.Cells)         // Cycle through cells of loaded workbook (first worksheet)
                {
                    string cellKey = cell.Key;
                    if (cellKey.Contains("B"))
                        getRawData(cell.Value.Value.ToString(), 1, cell.Key); 
                    else if(cellKey.Contains("C"))
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
                    else if (cellKey.Contains("J"))
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
        public void getRawData(string value, int column,string key)
        {
            string row = key;
            row = row.Substring(1);
            int rowAsInt = Int16.Parse(row);

            if (rowAsInt >= 99)
                return;

            RawData[column][rowAsInt] = value;
        }
        public void Read(out string[][] tenefusSaat, out int[][][] tenefusSure)
        {
            for (int i = 1; i < RawData.Length; i++)
            {
                if (i % 2 == 0)// tablodkai saatleri excelden yazar
                {
                    int uzunluk = TablodakiSaatler.Length;
                    int j = 1;
                    while (true)
                    {
                        if (RawData[i][j] == "")
                            break;

                        TablodakiSaatler[uzunluk][j - 1] = RawData[i][j];
                        j++;
                    }
                }
                else//tablodaki günleri excelden yazar
                {
                    int uzunluk = TablodakiSüreler.Length;
                    int j = 1;
                    while (true)
                    {
                        if (RawData[i][j] == "")
                            break;

                        TablodakiSüreler[uzunluk][j - 1] = RawData[i][j];
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
