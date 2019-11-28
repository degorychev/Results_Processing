using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Results_Processing
{
    class Program
    {
        static void Main(string[] args)
        {
            List<double> Results = new List<double>();
            try
            {
                using (StreamReader sr = new StreamReader("input.txt"))
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

            Console.WriteLine("Считанные данные:");
            for (int i = 0; i < Results.Count; i++)
                Console.Write("(" + (i + 1).ToString() + ")" + " " + Results[i] + " ");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("1 посчитать среднее арифметическое");
            Console.WriteLine("2 посчитать доверительный интервал");
            Console.WriteLine("3 посчитать вероятность того, что погрешность не выйдет за границы");
            Console.WriteLine("q чтобы выйти");


            while (true)
            {
                string input = Console.ReadLine();
                if (input == "q")
                    break;
                int ans;
                if (!int.TryParse(input, out ans))
                {
                    Console.WriteLine("Число не распознано");
                    continue;
                }
                switch (ans)
                {
                    case 1:
                        Console.Write("Среднее арифметическое: ");
                        Console.WriteLine(Avg(Results));
                        break;
                    case 2:
                        Console.Write("Доверительный интервал для среднего: ");
                        Console.WriteLine(ConfidenceIntervalString(Results));
                        break;
                    case 3:
                        Console.Write("Доверительный интервал для среднего: ");
                        Console.WriteLine(ConfidenceIntervalString(Results));
                        break;
                    default:
                        Console.WriteLine("неизвестный пункт");
                        break;

                }
            }
        }

        static double ProbabilityInTheRange(List<double> input)
        {
            var b = StandardDeviation(input);
            double e = 0.005;

            double t = e / b;
            double ft = 0;
            return ft;

        }

        /// <summary>
        /// Среднее арифметическое в виде строки
        /// </summary>
        /// <param name="input">Список значений</param>
        /// <returns></returns>
        static string ConfidenceIntervalString(List<double> input)
        {
            double t = 2.576;//Значение интеграла вероятностей, из таблицы
            double E = ConfidenceInterval(input, t);
            string output = "+-" + E.ToString();
            return output;
        }

        /// <summary>
        /// Расчет среднего арифметического
        /// </summary>
        /// <param name="input">Список значений</param>
        /// <returns>Среднее арифметическое</returns>
        static double Avg(List<double> input)
        {
            double avg = 0;
            for (int i = 0; i < input.Count; i++)
                avg += input[i];
            avg /= input.Count;
            return avg;
        }

        /// <summary>
        /// Доверительные интервалы для среднего значения
        /// </summary>
        /// <param name="input">Список значений</param>
        /// <returns>вычесленный интервал +- E</returns>
        static double ConfidenceInterval(List<double> input, double t)
        {
            double So = StandardDeviation(input) / Math.Sqrt(input.Count);
            return So * t;
        }


        /// <summary>
        /// Среднее квадратическое отклонение
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static double StandardDeviation(List<double> input)
        {
            var srX = Avg(input);
            double sum = 0;
            for (int i = 0; i < input.Count; i++)
                sum += Math.Pow(input[i] - srX, 2);
            double S = Math.Sqrt(sum / input.Count);
            return S;
        }
    }
}
