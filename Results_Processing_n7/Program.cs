using Libraries;
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
            ReaderResults r = new ReaderResults("input.txt", n);
            List<double> Results = r.Results;

            Console.WriteLine("Считанные данные:");
            for (int i = 0; i < Results.Count; i++)
                Console.Write("(" + (i + 1).ToString() + ")" + " " + Results[i] + " ");

            var S = MyMath.StandardDeviation(Results);
            double Vmax = (Results.Max() - MyMath.Avg(Results)) / S;
            double Vmin = (MyMath.Avg(Results) - Results.Min()) / S;

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
            r = new ReaderResults("input2.txt", n);
            Results = r.Results;
            Console.WriteLine("Считанные данные:");
            for (int i = 0; i < Math.Min(Results.Count, n); i++)
                Console.Write("(" + (i + 1).ToString() + ")" + " " + Results[i] + " ");

            S = MyMath.StandardDeviation(Results);
            Vmax = (Results.Max() - MyMath.Avg(Results)) / S;
            Vmin = (MyMath.Avg(Results) - Results.Min()) / S;

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
    }
}
