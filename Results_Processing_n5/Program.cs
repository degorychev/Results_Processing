using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Libraries;

namespace Results_Processing_n5
{
    class Program
    {
        static void Main(string[] args)
        {
            ReaderResults r = new ReaderResults("input.txt");
            var Results = r.Results;

            var S = MyMath.StandardDeviation(Results);
            double t = 0.005 / S;
            Select_Target.table t78 = new Select_Target.table(Select_Target.table.table78);
            var Ft = t78.getValue(t);
            var obrFt = 1 - Ft;

            Console.WriteLine(obrFt*100 + "%");
            Console.ReadLine();
        }
    }
}
