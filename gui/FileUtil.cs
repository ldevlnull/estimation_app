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
                string[] coordsStr = null;
                x = new double[size];
                y = new double[size];
                for (int i = 0; i < size; i++)
                {
                    coordsStr = sw.ReadLine().Split(' ');
                    x[i] = Convert.ToDouble(coordsStr[0]);
                    y[i] = Convert.ToDouble(coordsStr[1]);
                }
            }
        }
    }
}
