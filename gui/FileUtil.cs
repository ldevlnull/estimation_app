using System;
using System.IO;

namespace gui
{
    static class FileUtil
    {
        public static void WriteCoords(double[] x, double[] y)
        {
            string fileName = Directory.GetCurrentDirectory() + "\\" + $"Result {DateTime.Now.Day}-{DateTime.Now.Month}-{DateTime.Now.Year} ({DateTime.Now.Hour} {DateTime.Now.Minute} {DateTime.Now.Second}).txt";
            using (StreamWriter sw = new StreamWriter(fileName))
            {
                for (int i = 0; i < x.Length; i++)
                {
                    sw.WriteLine($"x = {x[i]}\ty = {y[i]}");
                }
            }
        }
        public static void ReadCoords(out double[] x, out double[] y, string fileName)
        {
            using (StreamReader sw = new StreamReader(fileName))
            {
                int size = File.ReadAllLines(fileName).Length;
                string str = "";
                x = new double[size];
                y = new double[size];
                for (int i = 0; i < size; i++)
                {
                    str = sw.ReadLine();
                    x[i] = Convert.ToDouble(str.Substring(0, str.IndexOf(' ') + 1));
                    y[i] = Convert.ToDouble(str.Substring(str.IndexOf(' ')));
                }
            }
        }
    }
}
