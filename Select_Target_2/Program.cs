using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Select_Target_2
{
    class Program
    {
        static void Main(string[] args)
        {
            table t = new table(table.table78);
            Console.WriteLine(t.getValue(9, 0.99));
            Console.ReadLine();
        }
    }
    public class table
    {
        public const string table78 = "tables/table12.csv";

        Dictionary<int, double[]> tablebook;
        public table(string filename)
        {
            tablebook = ReadTables(filename);
        }

        public double getValue(int n, double P)
        {
            if (tablebook.ContainsKey(n))
                switch (P)
                {
                    case 0.9:
                        return tablebook[n][0];
                    case 0.95:
                        return tablebook[n][1];
                    case 0.975:
                        return tablebook[n][2];
                    case 0.99:
                        return tablebook[n][3];
                }
            return 0;
        }

        static Dictionary<int, double[]> ReadTables(string TableName)
        {
            Dictionary<int, double[]> output = new Dictionary<int, double[]>();

            try
            {
                using (StreamReader sr = new StreamReader(TableName))
                {
                    while (!sr.EndOfStream)
                    {
                        string[] str = sr.ReadLine().Split(';');
                        int a = int.Parse(str[0]);
                        double b1 = double.Parse(str[1]);
                        double b2 = double.Parse(str[2]);
                        double b3 = double.Parse(str[3]);
                        double b4 = double.Parse(str[4]);
                        double[] arr = new double[] {b1, b2, b3, b4 };
                        output.Add(a, arr);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.ReadLine();
            }

            return output;
        }
    }
}
