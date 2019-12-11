using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Select_Target
{
    class Program
    {
        static void Main(string[] args)
        {
            table t = new table(table.table78);

            while (true)
            {
                double d = double.Parse(Console.ReadLine());
                Console.WriteLine(t.getValue(d));
            }
        }        
    }

    public class table
    {
        public const string table78 = "tables/table78.csv";
        public const string table9 = "tables/table9.csv";
        Dictionary<double, double> tablebook;
        public table (string filename)
        {
            tablebook = ReadTables(filename);
        }

        public double getValue(double search)
        {
            return tablebook[Searcher(search)];
        }

        private double Searcher(double searchStr)
        {
            double dif = double.MaxValue;
            var Results = tablebook.Keys.ToArray();
            double output = Results[0];
            for(int i=0; i<Results.Length; i++)            
                if(Math.Abs(searchStr-Results[i])<dif)
                {
                    dif = Math.Abs(searchStr - Results[i]);
                    output = Results[i];
                }
            return output;
        }

        static Dictionary<double, double> ReadTables(string TableName)
        {
            Dictionary<double, double> output = new Dictionary<double, double>();

            try
            {
                using (StreamReader sr = new StreamReader(TableName))
                {
                    while (!sr.EndOfStream)
                    {
                        string[] str = sr.ReadLine().Split(';');
                        double a = double.Parse(str[0]);
                        double b = double.Parse(str[1]);
                        output.Add(a, b);
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
