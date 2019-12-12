using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libraries
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    public class ReaderResults
    {
        public readonly List<double> Results;
        public ReaderResults(string Path)
        {
            Results = new List<double>();
            try
            {
                using (StreamReader sr = new StreamReader(Path))
                {
                    while (!sr.EndOfStream)
                        Results.Add(double.Parse(sr.ReadLine()));//Чтение
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.ReadLine();
                return;
            }
        }
        public ReaderResults(string Path, int n)
        {
            Results = new List<double>();
            try
            {
                using (StreamReader sr = new StreamReader(Path))
                {
                    while (!sr.EndOfStream && Results.Count < n)
                        Results.Add(double.Parse(sr.ReadLine()));//Чтение
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.ReadLine();
                return;
            }
        }
    }

    public static class MyMath
    {
        /// <summary>
        /// Расчет среднего арифметического (Страница 25)
        /// </summary>
        /// <param name="input">Список значений</param>
        /// <returns>Среднее арифметическое</returns>
        public static double Avg(List<double> input)
        {
            double avg = 0;
            for (int i = 0; i < input.Count; i++)
                avg += input[i];
            avg /= input.Count;
            return avg;
        }

        /// <summary>
        /// Среднее квадратическое отклонение (Страница 26)
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static double StandardDeviation(List<double> input)
        {
            var srX = MyMath.Avg(input);
            double sum = 0;
            for (int i = 0; i < input.Count; i++)
                sum += Math.Pow(input[i] - srX, 2);
            double S = Math.Sqrt(sum / (input.Count - 1));
            return S;
        }
    }
}
