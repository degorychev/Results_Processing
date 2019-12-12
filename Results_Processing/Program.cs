using Select_Target;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Libraries;

namespace Results_Processing
{
    class Program
    {
        static void Main(string[] args)
        {
            table t9 = new table(table.table9);
            ReaderResults r = new ReaderResults("input.txt");
            List<double> Results = r.Results;

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
                        Console.WriteLine(MyMath.Avg(Results));
                        break;
                    case 2:
                        Console.Write("Доверительный интервал для среднего: ");
                        var t = t9.getValue(0.99);
                        Console.WriteLine(ConfidenceIntervalString(Results, t));
                        break;
                    case 3:
                        Console.Write("Доверительный интервал для среднего: ");
                        //Console.WriteLine(ConfidenceIntervalString(Results));
                        break;
                    default:
                        Console.WriteLine("неизвестный пункт");
                        break;

                }
            }
        }

        static double ProbabilityInTheRange(List<double> input)
        {
            var b = MyMath.StandardDeviation(input);
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
        static string ConfidenceIntervalString(List<double> input, double t)
        {
            double E = ConfidenceInterval(input, t);
            string output = "+-" + E.ToString();
            return output;
        }



        /// <summary>
        /// Доверительные интервалы для среднего значения
        /// </summary>
        /// <param name="input">Список значений</param>
        /// <returns>вычесленный интервал +- E</returns>
        static double ConfidenceInterval(List<double> input, double t)
        {
            double So = MyMath.StandardDeviation(input) / Math.Sqrt(input.Count);
            return So * t;
        }
       
    }
}
