using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Results_Processing_n7
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 15;
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
            for (int i = 0; i < Math.Min(Results.Count, n); i++)
                Console.Write("(" + (i + 1).ToString() + ")" + " " + Results[i] + " ");

            var S = StandardDeviation(Results);
            double Vmax = (Results.Max() - Avg(Results)) / S;
            double Vmin = (Avg(Results)-Results.Min()) / S;

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("vmax = " + Vmax);
            Console.WriteLine("vmin = " + Vmin);

            double Vminmin = Math.Min(Vmax, Vmin);
            Console.WriteLine("Vminmin = " + Vminmin);


            Select_Target_2.table t = new Select_Target_2.table(Select_Target_2.table.table78);

            double P = t.getValue(n, 0.975);
            Console.WriteLine("При P=0.975 и n=15; Vp=" + P);

            Console.WriteLine(Vminmin + "<" + P + "? " + (Vminmin < P).ToString());
            P = t.getValue(n, 0.95);
            Console.WriteLine("При P=0.95 и n=15; Vp=" + P);
            Console.WriteLine();
            /////////////////////////////////////
            ///
            Results.Clear();
            try
            {
                using (StreamReader sr = new StreamReader("input2.txt"))
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
            for (int i = 0; i < Math.Min(Results.Count, n); i++)
                Console.Write("(" + (i + 1).ToString() + ")" + " " + Results[i] + " ");

            S = StandardDeviation(Results);
            Vmax = (Results.Max() - Avg(Results)) / S;
            Vmin = (Avg(Results) - Results.Min()) / S;

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("vmax = " + Vmax);
            Console.WriteLine("vmin = " + Vmin);

            Vminmin = Math.Min(Vmax, Vmin);
            Console.WriteLine("Vminmin = " + Vminmin);


            t = new Select_Target_2.table(Select_Target_2.table.table78);


            P = t.getValue(n, 0.9);
            Console.WriteLine("При P=0.9 и n=15; Vp=" + P);
            Console.WriteLine(Vminmin + "<" + P + "? " + (Vminmin < P).ToString());

            P = t.getValue(n, 0.95);
            Console.WriteLine("При P=0.95 и n=15; Vp=" + P);
            Console.WriteLine(Vminmin + "<" + P + "? " + (Vminmin < P).ToString());

            P = t.getValue(n, 0.975);
            Console.WriteLine("При P=0.975 и n=15; Vp=" + P);
            Console.WriteLine(Vminmin + "<" + P + "? " + (Vminmin < P).ToString());

            P = t.getValue(n, 0.99);
            Console.WriteLine("При P=0.99 и n=15; Vp=" + P);
            Console.WriteLine(Vminmin + "<" + P + "? " + (Vminmin < P).ToString());



            Console.ReadLine();

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
    }
}
